using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace Data_Visualizer
{
	public partial class Form1 : Form
	{
		public class worldPoint
		{
			public int Recno;
			public double X, Y;
			public worldPoint(int recno, double x, double y)
			{
				this.Recno = recno;
				this.X = x;
				this.Y = y;
			}
		}

		List<string> seriesName;
		int headerLines = 0;

		List<Color> someColor = new List<Color>()
		{
			Color.Blue, Color.Red, Color.Green, 
			Color.DodgerBlue, Color.Maroon, Color.Lime,
			Color.BlueViolet, Color.MediumVioletRed, Color.Olive, 
			Color.DarkMagenta, Color.DarkOrange, Color.Teal
		};

		string iniFileName { get { return Application.ProductName + ".ini"; } }
		
		string dataFileName;
		List<string> record;
		int nRecords;
		char[] delimiters = { '\t' };
		string[] commentDelimiter = { "//" };
		List<List<worldPoint>> worldData;

		ScaleForm scaleForm = new ScaleForm();

		double xMin0, xMax0, yMin0, yMax0;  // dataset bounds
		double xMin, xMax, yMin, yMax;	  // viewport bounds in dataset units
		double xSpan, ySpan;				// viewport size in dataset units
		int xDivisions, yDivisions;
		double xStep, yStep;
		double xTransform, yTransform;
		string xFormat, yFormat;

		bool xIsOmitted;
		bool xIsDateTime;
		bool logScaleX, logScaleY;
		int xSigDigits = 0, ySigDigits = 0;
		bool descendX = false, descendY = false;
		bool showPoints = false;
		bool showLines = true;
		bool autoUpdate = true;
		int autoUpdateInterval = 60000;
		bool autoScale = false;

		Font scaleFont = new Font("Tahoma", 10);
		int ticLength = 7;
		const int margin = 12;

		Rectangle canvasRectangle;
		List<Point[]> canvasData;
		List<GraphicsPath> plot;
		List<Pen> pathPen;

		bool shiftKeyDown = false;
		bool ctrlKeyDown = false;
		bool mouseDown = false;
		Point panFrom;
		Point reScaleFrom;
		double reScaleXMin, reScaleXMax, reScaleYMin, reScaleYMax;
		int xScaleMin, xScaleMax, yScaleMin, yScaleMax;

		public Form1()
		{
			InitializeComponent();
			InitializeMenuItems();
			xMax = 100;
			yMax = 100;
			scaleEverything();

			MouseWheel += new MouseEventHandler(Form1_MouseWheel);

			try
			{
				StreamReader fin = new StreamReader(iniFileName);
				dataFileName = fin.ReadLine();
				fin.Close();
			}
			catch { }
			fileChanged();
		}

		void InitializeMenuItems()
		{
			autoUpdateMenuItem.Checked = autoUpdate;
			IntervalMenuItem.Text = "Interval: " + (autoUpdateInterval / 1000).ToString() + "s";
			IntervalTextBox.Text = (autoUpdateInterval / 1000).ToString();
			IntervalTextBox.LostFocus += new EventHandler(IntervalTextBox_LostFocus);
			autoScaleMenuItem.Checked = autoScale;
			showPointsMenuItem.Checked = showPoints;
			showLinesMenuItem.Checked = showLines;
			logScaleXMenuItem.Checked = logScaleX;
			logScaleYMenuItem.Checked = logScaleY;
			descendXMenuItem.Checked = descendX;
			descendYMenuItem.Checked = descendY;
		}

		void fileChanged()
		{
			this.Text = dataFileName ?? "Data Visualizer";

			penColorPanel.Controls.Clear();

			record = new List<string>();
			nRecords = 0;
			worldData = new List<List<worldPoint>>();
			seriesName = new List<string>();
			readData();
		}

		void readInf()
		{
			string directory = Path.GetDirectoryName(dataFileName);
			string infFileName = Application.ProductName + ".inf";

			StreamReader fin = null;
			while (fin == null)
			{
				try
				{
					if (directory == null)
						fin = new StreamReader(infFileName);
					else
						fin = new StreamReader(directory + "\\" + infFileName);
					break;
				}
				catch
				{
					if (directory == null)
						break;
					else
						directory = Path.GetDirectoryName(directory);
				}

			}
			if (fin == null)
			{
				try { fin = new StreamReader(Application.ExecutablePath + "\\" + infFileName); }
				catch
				{
					MessageBox.Show("Could not find series names.");
					return;
				}
			}

			string baseName = baseFileName(dataFileName);
			string[] token;
			string line = fin.ReadLine();
			while (line != null)
			{
				token = tokenize(line);
				if (token[0].Equals(baseName))
				{
					for (int i = 1; i < token.Length; i++)
						seriesName.Add(token[i]);
					break;
				}
				line = fin.ReadLine();
			}

			fin.Close();
		}

		void setSeriesNames(string s)
		{
			setSeriesNames(tokenize(s));
		}

		void setSeriesNames(string[] names)
		{
			if (names == null || names.Length == 0) return;
			foreach (string name in names)
				seriesName.Add(name);
		}

		bool containsNumber(string[] sa)
		{
			double d;
			foreach (string s in sa)
				if (double.TryParse(s, out d))
					return true;
			return false;
		}


		void readData()
		{
			if (String.IsNullOrEmpty(dataFileName))
				return;

			StreamReader fin;
			try { fin = new StreamReader(dataFileName); }
			catch
			{
				statusLabel1.Text = "Couldn't open file '" + dataFileName + "'";
				return;
			}

			string[] token;
			double x = 0, y = 0;
			int prevRecords = nRecords;
			double xMin1 = 0, xMax1 = 0, yMin1 = 0, yMax1 = 0;  // data bounds of the recently read
			int nLines = 0;
			string line = fin.ReadLine();

			if (nRecords == 0)  // preview the first line to make some assumptions about the data
			{
				token = tokenize(line);
				if (token.Length == 0)
				{
					statusLabel1.Text = "Empty first line in '" + dataFileName + "'";
					return;
				}

				if (containsNumber(token))
				{
					headerLines = 0;
					readInf();		// get the series names from the inf file
				}
				else
				{
					headerLines = 1;
					setSeriesNames(token);
					line = fin.ReadLine();
					token = tokenize(line);
					if (token.Length == 0)
					{
						statusLabel1.Text = "No data in '" + dataFileName + "'";
						return;
					}
				}

				xIsOmitted = token.Length == 1;
				if (!xIsOmitted)
				{
					xIsDateTime = false;
					try
					{
						x = double.Parse(token[0]);
						if (token[0].Contains("e"))
							logScaleX = true;
						else
							logScaleX = false;
						if (token[0].Contains("."))
						{
							int significand = logScaleX ? token[0].IndexOf("e") : token[0].Length-1;
							int dot = token[0].IndexOf(".");
							xSigDigits = significand - dot;
						}
						else
							xSigDigits = 0;
					}
					catch
					{
						logScaleX = false;
						try
						{
							x = DateTime.Parse(token[0]).Ticks;
							xIsDateTime = true;
						}
						catch {}
					}
					logScaleXMenuItem.Checked = logScaleX;
				}
				int iy = xIsOmitted ? 0 : 1;
				if (token[iy].Contains("e"))
					logScaleY = true;
				else
					logScaleY = false;
				logScaleYMenuItem.Checked = logScaleY;
				if (token[iy].Contains("."))
				{
					int significand = logScaleY ? token[iy].IndexOf("e") : token[iy].Length-1;
					int dot = token[iy].IndexOf(".");
					ySigDigits = significand - dot;
				}
				else
					ySigDigits = 0;
			}


			while (line != null)
			{
				++nLines;
				if (nLines > nRecords)  // parse only lines not already seen
				{
					record.Add(line.Replace("\t", " "));
					token = tokenize(line);
					if (token.Length > 0)
					{
						if (xIsOmitted) x = nRecords;
						else if (xIsDateTime)
						{
							try { x = DateTime.Parse(token[0]).Ticks; }
							catch { /* x is prior x-value */ }
						}
						else
						{
							try 
							{ 
								x = double.Parse(token[0]);
								if (logScaleX) x = x < 1e-7 ? -7 : Math.Log10(x);
							}
							catch { /* x is prior x-value */ }
						}

						if (nRecords == prevRecords) xMin1 = xMax1 = x;
						else if (x < xMin1) xMin1 = x;
						else if (x > xMax1) xMax1 = x;

						bool recordAdded = false;
						int series = 0;
						foreach (string t in token.Skip(xIsOmitted ? 0 : 1))
						{
							try
							{
								y = double.Parse(t.Replace('>', ' '));
								if (logScaleY) y = y < 1e-7 ? -7 : Math.Log10(y);

								if (nRecords == prevRecords) yMin1 = yMax1 = y;
								else if (y < yMin1) yMin1 = y;
								else if (y > yMax1) yMax1 = y;

								if (worldData.Count < series + 1)
									worldData.Add(new List<worldPoint>());
								worldData[series].Add(new worldPoint(nRecords, x, y));
								recordAdded = true;
							}
							catch { /* no y value; dataset is unaltered */ }
							++series;
						}
						if (recordAdded) ++nRecords;
					}
				}
				line = fin.ReadLine();
			}
			fin.Close();


			if (nLines < nRecords) nRecords = nLines;   // datafile shrank (?)

			// update data bounds (xMin0 et al. bound the full dataset)
			// xMin et al. are the viewport bounds in dataset units
			if (prevRecords == 0)
			{
				xMin = xMin0 = xMin1;
				xMax = xMax0 = xMax1;
				yMin = yMin0 = yMin1;
				yMax = yMax0 = yMax1;
			}
			else if (nRecords != prevRecords)
			{
				if (xMin1 < xMin0) xMin0 = xMin1;
				if (xMax1 > xMax0) xMax0 = xMax1;
				if (yMin1 < yMin0) yMin0 = yMin1;
				if (yMax1 > yMax0) yMax0 = yMax1;

				if (autoScale)
				{
					if (xMin1 < xMin) xMin = xMin1;
					if (xMax1 > xMax) xMax = xMax1;
					if (yMin1 < yMin) yMin = yMin1;
					if (yMax1 > yMax) yMax = yMax1;
				}
			}

			plotGraph();
			
			if (autoUpdate) timer1.Start();
		}

		string baseFileName(string fileName)
		{
			fileName = Path.GetFileNameWithoutExtension(fileName).Trim();
			int index = fileName.LastIndexOf(' ');
			if (index >= 0 && char.IsDigit(fileName[index + 1]))
				fileName = fileName.Substring(0, index);
			return fileName;
		}

		void addPen()
		{
			int i = pathPen.Count;
			Color c = someColor[i % someColor.Count];
			Pen p = new Pen(c, 1.0f);

			Label patch = new Label();
			patch.BackColor = c;
			patch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			patch.ForeColor = c;
			patch.Location = new System.Drawing.Point(16 * i, 0);
			patch.Margin = new System.Windows.Forms.Padding(0);
			patch.Name = "penColor" + pathPen.Count;
			patch.Tag = p;
			patch.Size = new System.Drawing.Size(10, 10);
			patch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			patch.MouseDown += new System.Windows.Forms.MouseEventHandler(Color_MouseDown);
			if (seriesName.Count > i)
				toolTip.SetToolTip(patch, seriesName[i]);

			penColorPanel.Width = 13 + 16 * i;
			penColorPanel.Left = statusStrip1.Width - 23 - penColorPanel.Width;
			penColorPanel.Controls.Add(patch);

			pathPen.Add(p);
		}

		const double TicksPerSecond = 1e7;
		const double TicksPerMinute = TicksPerSecond * 60;
		const double TicksPerHour = TicksPerMinute * 60;
		const double TicksPerDay = TicksPerHour * 24;
		string formatString(double step, int sigDigits, bool logScale, bool isDateTime)
		{
			if (isDateTime)
			{
				if (step >= TicksPerDay) return "MM/dd";
				else if (step >= TicksPerHour) return "h tt";
				else if (step >= TicksPerMinute) return "HH:mm";
				else if (step >= TicksPerSecond) return "mm:ss";
				else return "ss.fff";
			}
			if (logScale) return "0.000000000000".Substring(0, 2 + Math.Min(2, sigDigits) - 1) + "e0";
			if (sigDigits == 0) return "0";
			int places = Math.Max(0, (int)Math.Ceiling(-Math.Log10(step)));
			return "0.000000000000".Substring(0, 2 + Math.Min(10, Math.Max(places, sigDigits)));
		}

		string[] tokenize(string line)
		{
			string[] nocomments = line.Split(commentDelimiter, 1, StringSplitOptions.RemoveEmptyEntries);
			string decommented = (nocomments.Length == 0) ? "" : nocomments[0];
			return decommented.Split(delimiters);
		}

		void plotGraph()
		{
			scaleEverything();

			if (penColorPanel.Controls.Count == 0)
			{
				penColorPanel.SuspendLayout();
				pathPen = new List<Pen>();
				foreach (List<worldPoint> s in worldData) addPen();
				penColorPanel.ResumeLayout(true);
			}

			canvasData = new List<Point[]>();

			int series = 0;
			foreach (List<worldPoint> worldSeries in worldData)
			{
				canvasData.Add(new Point[worldSeries.Count]);
				int i = 0;
				foreach (worldPoint wp in worldSeries)
				{
					canvasData[series][i] = new Point(canvasX(wp.X), canvasY(wp.Y));
					++i;
				}
				++series;
			}

			plot = new List<GraphicsPath>();
			foreach (Point[] pa in canvasData)
			{
				plot.Add(new GraphicsPath());
				plot.Last().AddLines(pa);
				
			}
			yScalePictureBox.Invalidate();
			xScalePictureBox.Invalidate();
			canvasPictureBox.Invalidate();
		}

		void scaleEverything()
		{
			xSpan = xMax - xMin;
			ySpan = yMax - yMin;

			canvasPictureBox.Top = menuStrip1.Height + margin;
			yScalePictureBox.Top = canvasPictureBox.Top - margin;
			yScalePictureBox.Left = margin;

			xScalePictureBox.Height = scaleFont.Height + ticLength + 3;
			xScalePictureBox.Top = statusStrip1.Top - xScalePictureBox.Height;
			canvasPictureBox.Height = xScalePictureBox.Top - menuStrip1.Height - margin;
			yScalePictureBox.Height = canvasPictureBox.Height + 2 * margin;

			// yScaleMin/Max are yScalePictureBox pixel values that 
			// correspond to the top and bottom edges of the canvas.
			yScaleMin = canvasPictureBox.Top - yScalePictureBox.Top;
			yScaleMax = yScaleMin + canvasPictureBox.Height - 1;

			yDivisions = yScalePictureBox.Height / 40;
			yStep = ySpan / yDivisions;
			yFormat = formatString(yStep, ySigDigits, logScaleY, false);
			yScalePictureBox.Width = longestLabelWidth(yMax, yMin, yFormat) + ticLength + 2;

			canvasPictureBox.Left = yScalePictureBox.Left + yScalePictureBox.Width;
			canvasPictureBox.Width = DisplayRectangle.Width - 3 * margin - yScalePictureBox.Width;
			// canvasPictureBox is 2 margins from right to give room for final xScale text

			xDivisions = (canvasPictureBox.Width + 2 * margin) / 80;
			xStep = xSpan / xDivisions;
			xFormat = formatString(xStep, xSigDigits, logScaleX, xIsDateTime);
			int halfXLabelWidth = longestLabelWidth(xMax, xMin, xFormat) / 2 + 2; // plus 2 pixels extra

			xScalePictureBox.Width = canvasPictureBox.Width + halfXLabelWidth + 2 * margin;
			xScalePictureBox.Left = canvasPictureBox.Left - halfXLabelWidth;

			// xScaleMin/Max are xScalePictureBox pixel values that 
			// correspond to the left and right edges of the canvas.
			xScaleMin = canvasPictureBox.Left - xScalePictureBox.Left;
			xScaleMax = xScaleMin + canvasPictureBox.Width - 1;

			canvasRectangle.Location = canvasPictureBox.Location;
			canvasRectangle.Size = canvasPictureBox.Size;

			penColorPanel.Top = DisplayRectangle.Bottom - 15;
			penColorPanel.Left = DisplayRectangle.Right - penColorPanel.Width - 20;

			xTransform = (double)(canvasPictureBox.Width - 1) / xSpan;
			yTransform = (double)(canvasPictureBox.Height - 1) / ySpan;
		}

		int longestLabelWidth(double a, double b, string fmt)
		{
			int awidth = TextRenderer.MeasureText(a.ToString(fmt), scaleFont).Width;
			int bwidth = TextRenderer.MeasureText(b.ToString(fmt), scaleFont).Width;
			return bwidth > awidth ? bwidth : awidth;
		}

		int canvasX(double worldX)
		{
			int dMin = dtoInt((worldX - xMin) * xTransform);
			if (descendX)
				return canvasPictureBox.Width - 1 - dMin;
			else
				return dMin; 
		}

		int canvasY(double worldY)
		{
			int dMin = dtoInt((worldY - yMin) * yTransform);
			if (descendY)
				return dMin;
			else
				return canvasPictureBox.Height - 1 - dMin; 
		}

		double worldX(int canvasX)
		{
			if (descendX)
				return (double)(canvasPictureBox.Width - 1 - canvasX) / xTransform + xMin;
			else
				return (double)canvasX / xTransform + xMin; 
		}

		double worldY(int canvasY)
		{
			if (descendY)
				return (double)canvasY / yTransform + yMin;
			else
				return (double)(canvasPictureBox.Height - 1 - canvasY) / yTransform + yMin;
		}

		// find the record nearest to world coordinates (x,y)
		// might be good enough (and much simpler) to find the record nearest in x only
		int nearestRecno(double x, double y)
		{
			// finds record nearest in x only (y is ignored)
			int bestRecno = 0;
			double dx = xMax - xMin;
			double bestDx = dx;

			foreach (worldPoint wp in worldData[0])
			{
				dx = Math.Abs(x - wp.X);
				if (dx < bestDx)
				{
					bestRecno = wp.Recno;
					bestDx = dx;
				}
			}
			return bestRecno;

			/*
			// finds record nearest (x, y)
			int bestRecno = 0;
			double dx = xMax - xMin, dy = yMax - yMin;
			double dist2 = dx * dx + dy * dy;
			double bestDist2 = dist2;

			foreach (List<worldPoint> series in worldData)
			{
				foreach (worldPoint wp in series)
				{
					dx = x - wp.X; dy = y - wp.Y;
					dist2 = dx * dx + dy * dy;
					if (dist2 < bestDist2)
					{
						bestRecno = wp.Recno;
						bestDist2 = dist2;
					}
				}
			}
			return bestRecno;
			*/
		}

		Point[] diamond = 
		{
			new Point(-2, 0), new Point(0, -2), new Point(+2, 0),
			new Point(0, +2), new Point(-2, 0)
		};
		void plotSymbol(Graphics g, Point[] symbolOutline, int x, int y, Brush brush)
		{
			int pcount = symbolOutline.Count();
			Point[] vertex = new Point[pcount];
			for (int i = 0; i < pcount; i++)
				vertex[i] = new Point(symbolOutline[i].X + x, symbolOutline[i].Y + y);
			GraphicsPath outline = new GraphicsPath();
			outline.AddLines(vertex);
			g.FillPath(brush, outline);
		}

		private void canvasPictureBox_Paint(object sender, PaintEventArgs e)
		{
			if (plot == null) return;

			Graphics g = e.Graphics;
			g.SmoothingMode = SmoothingMode.AntiAlias;
			g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
			//g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			for (int i = plot.Count - 1; i >= 0; i--)
			{
				try
				{
					Pen pen = pathPen[i % pathPen.Count];
					if (showLines) g.DrawPath(pen, plot[i]);
					if (showPoints)
					{
						Brush brush = new SolidBrush(pen.Color);
						foreach (PointF p in plot[i].PathPoints)
							plotSymbol(g, diamond, (int)p.X, (int)p.Y, brush);
					}
				}
				catch { }
			}
		}

		private void yScalePictureBox_Paint(object sender, PaintEventArgs e)
		{
			// draw y-scale
			try
			{
				Point pt1 = new Point(e.ClipRectangle.Width - 1, 0);
				Point pt2 = new Point(pt1.X - ticLength, 0);
				Point pt3 = new Point(0, 0);

				List<double> tic = new List<double>();
				tic.Add(yMax);
				tic.Add(yMin);
				for (int y = 1; y < yDivisions; y++)
					tic.Add(tic[y] + yStep);

				foreach (double y in tic)
				{
					string label;
					if (logScaleY)
						label = Math.Pow(10, y).ToString(yFormat);
					else
						label = y.ToString(yFormat);

					pt1.Y = canvasY(y) + margin;
					pt2.Y = pt1.Y;
					pt3.Y = pt1.Y - scaleFont.Height / 2;
					pt3.X = pt2.X - dtoInt(e.Graphics.MeasureString(label, scaleFont).Width);
					e.Graphics.DrawLine(Pens.Black, pt1, pt2);
					e.Graphics.DrawString(label, scaleFont, Brushes.Black, pt3);
				}
				pt1.Y = margin;
				pt2.X = pt1.X;
				pt2.Y = e.ClipRectangle.Height - 1 - margin;
				e.Graphics.DrawLine(Pens.Black, pt1, pt2);
			}
			catch { }
		}

		private void xScalePictureBox_Paint(object sender, PaintEventArgs e)
		{
			// draw x-scale
			try
			{
				int canvasScaleShift = canvasPictureBox.Left - xScalePictureBox.Left;
				Point pt1 = new Point(0, e.ClipRectangle.Top + 1);
				Point pt2 = new Point(0, pt1.Y + ticLength);
				Point pt3 = new Point(0, pt2.Y + 3);

				List<double> tic = new List<double>();
				tic.Add(xMax);
				tic.Add(xMin);
				for (int x = 1; x < xDivisions; x++)
					tic.Add(tic[x] + xStep);

				foreach (double x in tic)
				{
					string label;
					if (xIsDateTime)
						label = new DateTime((long)x).ToString(xFormat);
					else if (logScaleX)
						label = Math.Pow(10, x).ToString(xFormat);
					else
						label = x.ToString(xFormat);

					pt1.X = canvasX(x) + canvasScaleShift;
					pt2.X = pt1.X;
					pt3.X = pt1.X - dtoInt(e.Graphics.MeasureString(label, scaleFont).Width / 2);
					e.Graphics.DrawLine(Pens.Black, pt1, pt2);
					e.Graphics.DrawString(label, scaleFont, Brushes.Black, pt3);
				}
				pt1.X = canvasX(xMin) + canvasScaleShift;
				pt1.Y = pt2.Y = 0;
				pt2.X = canvasX(xMax) + canvasScaleShift;
				e.Graphics.DrawLine(Pens.Black, pt1, pt2);
			}
			catch { }
		}

		private void Form1_SizeChanged(object sender, EventArgs e)
		{ plotGraph(); }

		private void controlMouseUp(object sender, MouseEventArgs e)
		{ mouseDown = false; }

		private void canvasPictureBox_MouseDown(object sender, MouseEventArgs e)
		{ panFrom = e.Location; mouseDown = e.Button == System.Windows.Forms.MouseButtons.Left; }

		private void canvasPictureBox_MouseMove(object sender, MouseEventArgs e)
		{
			if (mouseDown)
			{
				// pan X
				double dx = worldX(panFrom.X) - worldX(e.X);
				xMin += dx;
				xMax += dx;

				// pan Y
				double dy = worldY(panFrom.Y) - worldY(e.Y);
				yMin += dy;
				yMax += dy;

				panFrom = e.Location;

				// refresh display
				plotGraph();
			}
			else
			{
				try
				{
					int rec = nearestRecno(worldX(e.X), worldY(e.Y));
					statusLabel1.Text = record[rec];
				}
				catch { }
			}
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Shift) shiftKeyDown = true;
			if (e.Control) ctrlKeyDown = true;
		}

		private void Form1_KeyUp(object sender, KeyEventArgs e)
		{
			if (!e.Shift) shiftKeyDown = false;
			if (!e.Control) ctrlKeyDown = false;
		}

		const double zoomFactor = 1.5;
		void Form1_MouseWheel(object sender, MouseEventArgs e)
		{
			if (e.Delta != 0 && canvasRectangle.Contains(e.Location))
			{
				if (shiftKeyDown)
					zoomY(e.Y - canvasPictureBox.Top, e.Delta > 0 ? 1.0 / zoomFactor : zoomFactor);
				else if (ctrlKeyDown)
					zoomX(e.X - canvasPictureBox.Left, e.Delta > 0 ? 1.0 / zoomFactor : zoomFactor);
				else
					zoomXY(e.X - canvasPictureBox.Left, e.Y - canvasPictureBox.Top, e.Delta > 0 ? 1.0 / zoomFactor : zoomFactor);
			}
		}

		// zoom in or out around click point
		void zoomX(int ctr, double zoomScale)
		{
			try
			{
				double x = worldX(ctr);
				xMin = x - (x - xMin) * zoomScale;
				xMax = xMin + xSpan * zoomScale;
				plotGraph();
			}
			catch { }
		}

		// zoom in or out in Y around click point
		void zoomY(int ctr, double zoomScale)
		{
			try
			{
				double y = worldY(ctr);
				yMin = y - (y - yMin) * zoomScale;
				yMax = yMin + ySpan * zoomScale;
				plotGraph();
			}
			catch { }
		}

		void zoomXY(int xctr, int yctr, double zoomScale)
		{
			try
			{
				double x = worldX(xctr);
				xMin = x - (x - xMin) * zoomScale;
				xMax = xMin + xSpan * zoomScale;

				double y = worldY(yctr);
				yMin = y - (y - yMin) * zoomScale;
				yMax = yMin + ySpan * zoomScale;

				plotGraph();
			}
			catch { }
		}

		private void timer1_Tick(object sender, EventArgs e)
		{ readData(); }

		private void fileOpenMenuItem_Click(object sender, EventArgs e)
		{
			openFileDialog1.InitialDirectory = Path.GetDirectoryName(dataFileName);
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				openFile(openFileDialog1.FileName);
			}
		}

		void openFile(string path)
		{
			timer1.Stop();
			dataFileName = path;
			StreamWriter fout = new StreamWriter(iniFileName);
			fout.WriteLine(dataFileName);
			fout.Close();
			fileChanged();
		}

		private void exitMenuItem_Click(object sender, EventArgs e)
		{
			timer1.Stop();
			this.Close();
			Application.Exit();
		}

		private void OptionsMenuItem_DropDownOpening(object sender, EventArgs e)
		{
			autoUpdateMenuItem.Checked = autoUpdate;
			IntervalMenuItem.Text = "Interval: " + (autoUpdateInterval / 1000).ToString() + "s";
			IntervalTextBox.Text = (autoUpdateInterval / 1000).ToString();
			autoScaleMenuItem.Checked = autoScale;
			showPointsMenuItem.Checked = showPoints;
			showLinesMenuItem.Checked = showLines;
			logScaleXMenuItem.Checked = logScaleX;
			logScaleYMenuItem.Checked = logScaleY;
			descendXMenuItem.Checked = descendX;
			descendYMenuItem.Checked = descendY;
		}

		private void yScalePictureBox_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button != System.Windows.Forms.MouseButtons.Right)
				return;

			scaleForm.Text = "y-scale";
			scaleForm.MinLabel.Text = "Top:";
			scaleForm.MaxLabel.Text = "Bottom:";

			scaleForm.TopLeftTextBox.Visible = true;
			scaleForm.TopLeftDTPicker.Visible = false;

			scaleForm.BottomRightTextBox.Visible = true;
			scaleForm.BottomRightDTPicker.Visible = false;
			
			string yMinString = logScaleY ? Math.Pow(10, yMin).ToString(yFormat) : yMin.ToString();
			string yMaxString = logScaleY ? Math.Pow(10, yMax).ToString(yFormat) : yMax.ToString();

			scaleForm.TopLeftTextBox.Text = descendY ? yMinString : yMaxString;
			scaleForm.BottomRightTextBox.Text = descendY ? yMaxString : yMinString;

			if (scaleForm.ShowDialog() != DialogResult.OK)
				return;

			try
			{
				double top = double.Parse(scaleForm.TopLeftTextBox.Text, NumberStyles.Float);
				double bottom = double.Parse(scaleForm.BottomRightTextBox.Text, NumberStyles.Float);
				if (logScaleY)
				{
					top = Math.Log10(top);
					bottom = Math.Log10(bottom);
				}
				descendY = bottom > top;
				if (descendY)
				{
					yMin = top;
					yMax = bottom;
				}
				else
				{
					yMin = bottom;
					yMax = top;
				}
			}
			catch { }

			plotGraph();
		}

		private void yScalePictureBox_MouseDown(object sender, MouseEventArgs e)
		{ 
			if (e.Y < yScaleMax)
			{
				mouseDown = e.Button == System.Windows.Forms.MouseButtons.Left;
				if (mouseDown)
				{
					reScaleFrom.Y = e.Y;
					reScaleYMin = yMin;
					reScaleYMax = yMax;
				}
			}
		}

		private void Form1_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Link;
		}

		private void Form1_DragDrop(object sender, DragEventArgs e)
		{
			string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			openFile(FileList[0]);
		}

		private void yScalePictureBox_MouseMove(object sender, MouseEventArgs e)
		{
			if (mouseDown)
			{
				// reScale Y
				try
				{
					if (e.Y >= yScaleMax)
					{
						mouseDown = false;
						descendY = !descendY;
						descendYMenuItem.Checked = descendY;
						yMin = yMin0;
						yMax = yMax0;
					}
					else
					{
						double oldY = reScaleFrom.Y - yScaleMax;
						double newY = e.Y - yScaleMax;
						double scaleFactor = oldY / newY;
						if (descendY)
							yMin = reScaleYMax - (reScaleYMax - reScaleYMin) * scaleFactor;
						else
							yMax = reScaleYMin + (reScaleYMax - reScaleYMin) * scaleFactor;
					}

					// refresh display
					plotGraph();
				}
				catch { }
			}
		}

		private void xScalePictureBox_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button != System.Windows.Forms.MouseButtons.Right)
				return;

			scaleForm.Text = "x-scale";
			scaleForm.MinLabel.Text = "Left:";
			scaleForm.MaxLabel.Text = "Right:";
			
			if (xIsDateTime)
			{
				scaleForm.TopLeftDTPicker.Visible = true;
				scaleForm.TopLeftTextBox.Visible = false;

				scaleForm.BottomRightDTPicker.Visible = true;
				scaleForm.BottomRightTextBox.Visible = false;

				DateTime xMinDT = new DateTime((long)xMin);
				DateTime xMaxDT = new DateTime((long)xMax);

				scaleForm.TopLeftDTPicker.Value = descendX ? xMaxDT : xMinDT;
				scaleForm.BottomRightDTPicker.Value = descendX ? xMinDT : xMaxDT;
			}
			else
			{
				scaleForm.TopLeftTextBox.Visible = true;
				scaleForm.TopLeftDTPicker.Visible = false;

				scaleForm.BottomRightTextBox.Visible = true;
				scaleForm.BottomRightDTPicker.Visible = false;

				string xMinString;
				if (logScaleX)
					xMinString = Math.Pow(10, xMin).ToString();
				else
					xMinString = xMin.ToString();

				string xMaxString;
				if (logScaleX)
					xMaxString = Math.Pow(10, xMax).ToString(xFormat);
				else
					xMaxString = xMax.ToString();

				scaleForm.TopLeftTextBox.Text = descendX ? xMaxString : xMinString;
				scaleForm.BottomRightTextBox.Text = descendX ? xMinString : xMaxString;
			}

			if (scaleForm.ShowDialog() != DialogResult.OK)
				return;

			try
			{
				double left, right;
				if (xIsDateTime)
				{
					left = scaleForm.TopLeftDTPicker.Value.Ticks;
					right = scaleForm.BottomRightDTPicker.Value.Ticks;
				}
				else
				{
					left = double.Parse(scaleForm.TopLeftTextBox.Text, NumberStyles.Float);
					right = double.Parse(scaleForm.BottomRightTextBox.Text, NumberStyles.Float);
				}
				if (logScaleX)
				{
					left = Math.Log10(left);
					right = Math.Log10(right);
				}
				descendX = left > right;
				if (descendX)
				{
					xMin = right;
					xMax = left;
				}
				else
				{
					xMin = left;
					xMax = right;
				}
			}
			catch { }

			plotGraph();
		}

		private void xScalePictureBox_MouseDown(object sender, MouseEventArgs e)
		{ 
			if (e.X > xScaleMin)
			{
				mouseDown = e.Button == System.Windows.Forms.MouseButtons.Left;
				if (mouseDown)
				{
					reScaleFrom.X = e.X;
					reScaleXMin = xMin;
					reScaleXMax = xMax;
				}
			}
		}

		private void xScalePictureBox_MouseMove(object sender, MouseEventArgs e)
		{
			if (mouseDown)
			{
				// reScale X
				try
				{
					if (e.X <= xScaleMin)
					{
						mouseDown = false;
						descendX = !descendX;
						descendXMenuItem.Checked = descendX;
						xMin = xMin0;
						xMax = xMax0;
					}
					else
					{
						double oldX = reScaleFrom.X - xScaleMin;
						double newX = e.X - xScaleMin;
						double scaleFactor = oldX / newX;
						if (descendX)
							xMin = reScaleXMax - (reScaleXMax - reScaleXMin) * scaleFactor;
						else
							xMax = reScaleXMin + (reScaleXMax - reScaleXMin) * scaleFactor;
					}
					// refresh display
					plotGraph();
				}
				catch { }
			}
		}

		private void yScalePictureBox_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				yMin = yMin0;
				yMax = yMax0;
				plotGraph();
			}
			catch { }
		}

		private void xScalePictureBox_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				xMin = xMin0;
				xMax = xMax0;
				plotGraph();
			}
			catch { }
		}

		private void Color_MouseDown(object sender, MouseEventArgs e)
		{
			Control c = sender as Control; if (c == null) return;
			Pen p = c.Tag as Pen;
			if (e.Button == MouseButtons.Right)
			{
				colorDialog1.Color = c.BackColor;
				colorDialog1.AnyColor = true;
				colorDialog1.FullOpen = true;
				if (colorDialog1.ShowDialog() == DialogResult.OK)
				{
					p.Color = c.BackColor = c.ForeColor = colorDialog1.Color;
					plotGraph();
				}
			}
			else
			{
				if (p.Color == Color.Transparent)
					p.Color = c.BackColor = c.ForeColor;
				else
					p.Color = c.BackColor = Color.Transparent;
				plotGraph();
			}
		}

		private void logScaleXMenuItem_Click(object sender, EventArgs e)
		{
			if (!logScaleX && xMin0 <= 0)
			{
				MessageBox.Show("Logarithmic data must contain only positive values.",
					"I can't do that, Dave.");
				return;
			}

			logScaleX = !logScaleX;
			logScaleXMenuItem.Checked = logScaleX;
			
			if (logScaleX)
			{
				foreach (List<worldPoint> series in worldData)
					foreach (worldPoint wp in series)
						wp.X = wp.X <= 0 ? 1e-7 : Math.Log10(wp.X);
				xMin = Math.Log10(xMin);
				xMax = Math.Log10(xMax);
			}
			else
			{
				foreach (List<worldPoint> series in worldData)
					foreach (worldPoint wp in series)
						wp.X = Math.Pow(10, wp.X);
				xMin = Math.Pow(10, xMin);
				xMax = Math.Pow(10, xMax);
			}
			plotGraph();
		}

		private void logScaleYMenuItem_Click(object sender, EventArgs e)
		{
			if (!logScaleY && yMin0 <= 0)
			{
				MessageBox.Show("Logarithmic data must contain only positive values.",
					"I can't do that, Dave.");
				return;
			}

			logScaleY = !logScaleY;
			logScaleYMenuItem.Checked = logScaleY;

			if (logScaleY)
			{
				foreach (List<worldPoint> series in worldData)
					foreach (worldPoint wp in series)
						wp.Y = wp.Y <= 0 ? 1e-7 : Math.Log10(wp.Y);
				yMin = Math.Log10(yMin);
				yMax = Math.Log10(yMax);
			}
			else
			{
				foreach (List<worldPoint> series in worldData)
					foreach (worldPoint wp in series)
						wp.Y = Math.Pow(10, wp.Y);
				yMin = Math.Pow(10, yMin);
				yMax = Math.Pow(10, yMax);
			}
			plotGraph();
		}

		private void disableUpdatesMenuItem_Click(object sender, EventArgs e)
		{
			autoUpdate = autoUpdateMenuItem.Checked;
			if (!autoUpdate)
				timer1.Stop();
		}

		private void updateNowMenuItem_Click(object sender, EventArgs e)
		{ readData(); }

		private void showPointsMenuItem_Click(object sender, EventArgs e)
		{
			showPoints = showPointsMenuItem.Checked;
			plotGraph();
		}

		private void showLinesMenuItem_Click(object sender, EventArgs e)
		{
			showLines = showLinesMenuItem.Checked;
			plotGraph();
		}

		private void descendXMenuItem_Click(object sender, EventArgs e)
		{
			descendX = descendXMenuItem.Checked;
			plotGraph();
		}

		private void descendYMenuItem_Click(object sender, EventArgs e)
		{
			descendY = descendYMenuItem.Checked;
			plotGraph();
		}

		private void autoscaleMenuItem_Click(object sender, EventArgs e)
		{
			autoScale = autoScaleMenuItem.Checked;
		}

		private void IntervalMenuItem_MouseDown(object sender, MouseEventArgs e)
		{
			IntervalTextBox.Visible = true;
			IntervalMenuItem.Visible = false;
			IntervalTextBox.Focus();
			IntervalTextBox.SelectAll();
		}

		private void IntervalTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			string valid = "1234567890";
			if (e.KeyChar == (char)Keys.Back)
				return;
			else if (e.KeyChar == (char)Keys.Enter)
			{
				SendKeys.Send("{TAB}");
				e.Handled = true;
			}
			else if (!valid.Contains(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		void IntervalTextBox_LostFocus(object sender, EventArgs e)
		{
			int interval = 1;
			try { interval = int.Parse(IntervalTextBox.Text); }
			catch { }
			if (interval >= 1)
				autoUpdateInterval = interval * 1000;
			IntervalMenuItem.Text = "Interval: " + autoUpdateInterval / 1000 + "s";
			IntervalMenuItem.Visible = true;
			IntervalTextBox.Visible = false;
			timer1.Interval = autoUpdateInterval;
		}

		int dtoInt(double d)
		{ return (int)(d < 0 ? Math.Ceiling(d - 0.5) : Math.Floor(d + 0.5)); }
	}
}

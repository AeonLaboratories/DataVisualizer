namespace Data_Visualizer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.canvasPictureBox = new System.Windows.Forms.PictureBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.statusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.yScalePictureBox = new System.Windows.Forms.PictureBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.xScalePictureBox = new System.Windows.Forms.PictureBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fileOpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.OptionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.updateNowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.autoUpdateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.IntervalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.IntervalTextBox = new System.Windows.Forms.ToolStripTextBox();
			this.autoScaleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showPointsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showLinesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.logScaleXMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.logScaleYMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.descendXMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.descendYMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.penColorPanel = new System.Windows.Forms.Panel();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.canvasPictureBox)).BeginInit();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.yScalePictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.xScalePictureBox)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// canvasPictureBox
			// 
			this.canvasPictureBox.Location = new System.Drawing.Point(71, 44);
			this.canvasPictureBox.Name = "canvasPictureBox";
			this.canvasPictureBox.Size = new System.Drawing.Size(379, 242);
			this.canvasPictureBox.TabIndex = 0;
			this.canvasPictureBox.TabStop = false;
			this.canvasPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.canvasPictureBox_Paint);
			this.canvasPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvasPictureBox_MouseDown);
			this.canvasPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvasPictureBox_MouseMove);
			this.canvasPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.controlMouseUp);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 372);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(613, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// statusLabel1
			// 
			this.statusLabel1.Name = "statusLabel1";
			this.statusLabel1.Size = new System.Drawing.Size(0, 17);
			// 
			// yScalePictureBox
			// 
			this.yScalePictureBox.Location = new System.Drawing.Point(11, 32);
			this.yScalePictureBox.Name = "yScalePictureBox";
			this.yScalePictureBox.Size = new System.Drawing.Size(60, 266);
			this.yScalePictureBox.TabIndex = 2;
			this.yScalePictureBox.TabStop = false;
			this.yScalePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.yScalePictureBox_Paint);
			this.yScalePictureBox.DoubleClick += new System.EventHandler(this.yScalePictureBox_DoubleClick);
			this.yScalePictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.yScalePictureBox_MouseClick);
			this.yScalePictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.yScalePictureBox_MouseDown);
			this.yScalePictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.yScalePictureBox_MouseMove);
			this.yScalePictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.controlMouseUp);
			// 
			// timer1
			// 
			this.timer1.Interval = 60000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// xScalePictureBox
			// 
			this.xScalePictureBox.Location = new System.Drawing.Point(60, 284);
			this.xScalePictureBox.Name = "xScalePictureBox";
			this.xScalePictureBox.Size = new System.Drawing.Size(401, 26);
			this.xScalePictureBox.TabIndex = 3;
			this.xScalePictureBox.TabStop = false;
			this.xScalePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.xScalePictureBox_Paint);
			this.xScalePictureBox.DoubleClick += new System.EventHandler(this.xScalePictureBox_DoubleClick);
			this.xScalePictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.xScalePictureBox_MouseClick);
			this.xScalePictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.xScalePictureBox_MouseDown);
			this.xScalePictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.xScalePictureBox_MouseMove);
			this.xScalePictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.controlMouseUp);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.DefaultExt = "txt";
			this.openFileDialog1.Filter = "Text files|*.txt;*.csv";
			this.openFileDialog1.Title = "Select file to graph";
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem,
            this.OptionsMenuItem});
			this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(613, 24);
			this.menuStrip1.TabIndex = 5;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// FileMenuItem
			// 
			this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileOpenMenuItem,
            this.exitMenuItem});
			this.FileMenuItem.Name = "FileMenuItem";
			this.FileMenuItem.Size = new System.Drawing.Size(37, 20);
			this.FileMenuItem.Text = "&File";
			// 
			// fileOpenMenuItem
			// 
			this.fileOpenMenuItem.Name = "fileOpenMenuItem";
			this.fileOpenMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.fileOpenMenuItem.Size = new System.Drawing.Size(155, 22);
			this.fileOpenMenuItem.Text = "&Open...";
			this.fileOpenMenuItem.Click += new System.EventHandler(this.fileOpenMenuItem_Click);
			// 
			// exitMenuItem
			// 
			this.exitMenuItem.Name = "exitMenuItem";
			this.exitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.exitMenuItem.Size = new System.Drawing.Size(155, 22);
			this.exitMenuItem.Text = "E&xit";
			this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
			// 
			// OptionsMenuItem
			// 
			this.OptionsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateNowMenuItem,
            this.autoUpdateMenuItem,
            this.IntervalMenuItem,
            this.IntervalTextBox,
            this.autoScaleMenuItem,
            this.showPointsMenuItem,
            this.showLinesMenuItem,
            this.logScaleXMenuItem,
            this.logScaleYMenuItem,
            this.descendXMenuItem,
            this.descendYMenuItem});
			this.OptionsMenuItem.Name = "OptionsMenuItem";
			this.OptionsMenuItem.Size = new System.Drawing.Size(61, 20);
			this.OptionsMenuItem.Text = "Options";
			this.OptionsMenuItem.DropDownOpening += new System.EventHandler(this.OptionsMenuItem_DropDownOpening);
			// 
			// updateNowMenuItem
			// 
			this.updateNowMenuItem.Name = "updateNowMenuItem";
			this.updateNowMenuItem.Size = new System.Drawing.Size(160, 22);
			this.updateNowMenuItem.Text = "Update Now";
			this.updateNowMenuItem.Click += new System.EventHandler(this.updateNowMenuItem_Click);
			// 
			// autoUpdateMenuItem
			// 
			this.autoUpdateMenuItem.Checked = true;
			this.autoUpdateMenuItem.CheckOnClick = true;
			this.autoUpdateMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.autoUpdateMenuItem.Name = "autoUpdateMenuItem";
			this.autoUpdateMenuItem.Size = new System.Drawing.Size(160, 22);
			this.autoUpdateMenuItem.Text = "Auto Update";
			this.autoUpdateMenuItem.Click += new System.EventHandler(this.disableUpdatesMenuItem_Click);
			// 
			// IntervalMenuItem
			// 
			this.IntervalMenuItem.Name = "IntervalMenuItem";
			this.IntervalMenuItem.Size = new System.Drawing.Size(160, 22);
			this.IntervalMenuItem.Text = "Interval:";
			this.IntervalMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.IntervalMenuItem_MouseDown);
			// 
			// IntervalTextBox
			// 
			this.IntervalTextBox.Name = "IntervalTextBox";
			this.IntervalTextBox.Size = new System.Drawing.Size(100, 23);
			this.IntervalTextBox.Text = "60";
			this.IntervalTextBox.ToolTipText = "Enter the number of seconds between automatic updates";
			this.IntervalTextBox.Visible = false;
			this.IntervalTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntervalTextBox_KeyPress);
			// 
			// autoScaleMenuItem
			// 
			this.autoScaleMenuItem.CheckOnClick = true;
			this.autoScaleMenuItem.Name = "autoScaleMenuItem";
			this.autoScaleMenuItem.Size = new System.Drawing.Size(160, 22);
			this.autoScaleMenuItem.Text = "Auto Scale";
			this.autoScaleMenuItem.Click += new System.EventHandler(this.autoscaleMenuItem_Click);
			// 
			// showPointsMenuItem
			// 
			this.showPointsMenuItem.CheckOnClick = true;
			this.showPointsMenuItem.Name = "showPointsMenuItem";
			this.showPointsMenuItem.Size = new System.Drawing.Size(160, 22);
			this.showPointsMenuItem.Text = "Show Points";
			this.showPointsMenuItem.Click += new System.EventHandler(this.showPointsMenuItem_Click);
			// 
			// showLinesMenuItem
			// 
			this.showLinesMenuItem.Checked = true;
			this.showLinesMenuItem.CheckOnClick = true;
			this.showLinesMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showLinesMenuItem.Name = "showLinesMenuItem";
			this.showLinesMenuItem.Size = new System.Drawing.Size(160, 22);
			this.showLinesMenuItem.Text = "Show Lines";
			this.showLinesMenuItem.Click += new System.EventHandler(this.showLinesMenuItem_Click);
			// 
			// logScaleXMenuItem
			// 
			this.logScaleXMenuItem.Name = "logScaleXMenuItem";
			this.logScaleXMenuItem.Size = new System.Drawing.Size(160, 22);
			this.logScaleXMenuItem.Text = "Log Scale X";
			this.logScaleXMenuItem.Click += new System.EventHandler(this.logScaleXMenuItem_Click);
			// 
			// logScaleYMenuItem
			// 
			this.logScaleYMenuItem.Name = "logScaleYMenuItem";
			this.logScaleYMenuItem.Size = new System.Drawing.Size(160, 22);
			this.logScaleYMenuItem.Text = "Log Scale Y";
			this.logScaleYMenuItem.Click += new System.EventHandler(this.logScaleYMenuItem_Click);
			// 
			// descendXMenuItem
			// 
			this.descendXMenuItem.CheckOnClick = true;
			this.descendXMenuItem.Name = "descendXMenuItem";
			this.descendXMenuItem.Size = new System.Drawing.Size(160, 22);
			this.descendXMenuItem.Text = "Descend X";
			this.descendXMenuItem.Click += new System.EventHandler(this.descendXMenuItem_Click);
			// 
			// descendYMenuItem
			// 
			this.descendYMenuItem.CheckOnClick = true;
			this.descendYMenuItem.Name = "descendYMenuItem";
			this.descendYMenuItem.Size = new System.Drawing.Size(160, 22);
			this.descendYMenuItem.Text = "Descend Y";
			this.descendYMenuItem.Click += new System.EventHandler(this.descendYMenuItem_Click);
			// 
			// penColorPanel
			// 
			this.penColorPanel.AutoSize = true;
			this.penColorPanel.Location = new System.Drawing.Point(568, 380);
			this.penColorPanel.Name = "penColorPanel";
			this.penColorPanel.Size = new System.Drawing.Size(22, 10);
			this.penColorPanel.TabIndex = 127;
			// 
			// toolTip
			// 
			this.toolTip.AutomaticDelay = 250;
			this.toolTip.AutoPopDelay = 5000;
			this.toolTip.InitialDelay = 250;
			this.toolTip.ReshowDelay = 50;
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(613, 394);
			this.Controls.Add(this.penColorPanel);
			this.Controls.Add(this.yScalePictureBox);
			this.Controls.Add(this.xScalePictureBox);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.canvasPictureBox);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Graph";
			this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
			((System.ComponentModel.ISupportInitialize)(this.canvasPictureBox)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.yScalePictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.xScalePictureBox)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvasPictureBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel1;
        private System.Windows.Forms.PictureBox yScalePictureBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox xScalePictureBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileOpenMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel penColorPanel;
        private System.Windows.Forms.ToolStripMenuItem OptionsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logScaleYMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoUpdateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateNowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPointsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLinesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logScaleXMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descendXMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descendYMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoScaleMenuItem;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.ToolStripMenuItem IntervalMenuItem;
		private System.Windows.Forms.ToolStripTextBox IntervalTextBox;
    }
}


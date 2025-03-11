namespace Data_Visualizer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            fileOpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            OptionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            updateNowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            autoUpdateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            IntervalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            IntervalTextBox = new System.Windows.Forms.ToolStripTextBox();
            autoScaleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            showPointsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            showLinesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            logScaleXMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            logScaleYMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            descendXMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            descendYMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            statusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            timer1 = new System.Windows.Forms.Timer(components);
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            colorDialog1 = new System.Windows.Forms.ColorDialog();
            toolTip = new System.Windows.Forms.ToolTip(components);
            yScalePictureBox = new System.Windows.Forms.PictureBox();
            canvasPictureBox = new System.Windows.Forms.PictureBox();
            xScalePictureBox = new System.Windows.Forms.PictureBox();
            penColorPanel = new System.Windows.Forms.Panel();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)yScalePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)canvasPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xScalePictureBox).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { FileMenuItem, OptionsMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(817, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // FileMenuItem
            // 
            FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { fileOpenMenuItem, exitMenuItem });
            FileMenuItem.Name = "FileMenuItem";
            FileMenuItem.Size = new System.Drawing.Size(46, 24);
            FileMenuItem.Text = "&File";
            // 
            // fileOpenMenuItem
            // 
            fileOpenMenuItem.Name = "fileOpenMenuItem";
            fileOpenMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O;
            fileOpenMenuItem.Size = new System.Drawing.Size(181, 26);
            fileOpenMenuItem.Text = "&Open";
            fileOpenMenuItem.Click += fileOpenMenuItem_Click;
            // 
            // exitMenuItem
            // 
            exitMenuItem.Name = "exitMenuItem";
            exitMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4;
            exitMenuItem.Size = new System.Drawing.Size(181, 26);
            exitMenuItem.Text = "E&xit";
            exitMenuItem.Click += exitMenuItem_Click;
            // 
            // OptionsMenuItem
            // 
            OptionsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { updateNowMenuItem, autoUpdateMenuItem, IntervalMenuItem, IntervalTextBox, autoScaleMenuItem, showPointsMenuItem, showLinesMenuItem, logScaleXMenuItem, logScaleYMenuItem, descendXMenuItem, descendYMenuItem });
            OptionsMenuItem.Name = "OptionsMenuItem";
            OptionsMenuItem.Size = new System.Drawing.Size(75, 24);
            OptionsMenuItem.Text = "Options";
            // 
            // updateNowMenuItem
            // 
            updateNowMenuItem.Name = "updateNowMenuItem";
            updateNowMenuItem.Size = new System.Drawing.Size(177, 26);
            updateNowMenuItem.Text = "Update Now";
            updateNowMenuItem.Click += updateNowMenuItem_Click;
            // 
            // autoUpdateMenuItem
            // 
            autoUpdateMenuItem.Checked = true;
            autoUpdateMenuItem.CheckOnClick = true;
            autoUpdateMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            autoUpdateMenuItem.Name = "autoUpdateMenuItem";
            autoUpdateMenuItem.Size = new System.Drawing.Size(177, 26);
            autoUpdateMenuItem.Text = "Auto Update";
            autoUpdateMenuItem.Click += disableUpdatesMenuItem_Click;
            // 
            // IntervalMenuItem
            // 
            IntervalMenuItem.Name = "IntervalMenuItem";
            IntervalMenuItem.Size = new System.Drawing.Size(177, 26);
            IntervalMenuItem.Text = "Interval:";
            IntervalMenuItem.MouseDown += IntervalMenuItem_MouseDown;
            // 
            // IntervalTextBox
            // 
            IntervalTextBox.Name = "IntervalTextBox";
            IntervalTextBox.Size = new System.Drawing.Size(100, 27);
            IntervalTextBox.Text = "60";
            IntervalTextBox.ToolTipText = "Enter the number of seconds between automatic updates";
            IntervalTextBox.Visible = false;
            IntervalTextBox.KeyPress += IntervalTextBox_KeyPress;
            // 
            // autoScaleMenuItem
            // 
            autoScaleMenuItem.CheckOnClick = true;
            autoScaleMenuItem.Name = "autoScaleMenuItem";
            autoScaleMenuItem.Size = new System.Drawing.Size(177, 26);
            autoScaleMenuItem.Text = "Auto Scale";
            autoScaleMenuItem.Click += autoscaleMenuItem_Click;
            // 
            // showPointsMenuItem
            // 
            showPointsMenuItem.CheckOnClick = true;
            showPointsMenuItem.Name = "showPointsMenuItem";
            showPointsMenuItem.Size = new System.Drawing.Size(177, 26);
            showPointsMenuItem.Text = "Show Points";
            showPointsMenuItem.Click += showPointsMenuItem_Click;
            // 
            // showLinesMenuItem
            // 
            showLinesMenuItem.Checked = true;
            showLinesMenuItem.CheckOnClick = true;
            showLinesMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            showLinesMenuItem.Name = "showLinesMenuItem";
            showLinesMenuItem.Size = new System.Drawing.Size(177, 26);
            showLinesMenuItem.Text = "Show Lines";
            showLinesMenuItem.Click += showLinesMenuItem_Click;
            // 
            // logScaleXMenuItem
            // 
            logScaleXMenuItem.Name = "logScaleXMenuItem";
            logScaleXMenuItem.Size = new System.Drawing.Size(177, 26);
            logScaleXMenuItem.Text = "Log Scale X";
            logScaleXMenuItem.Click += logScaleXMenuItem_Click;
            // 
            // logScaleYMenuItem
            // 
            logScaleYMenuItem.Name = "logScaleYMenuItem";
            logScaleYMenuItem.Size = new System.Drawing.Size(177, 26);
            logScaleYMenuItem.Text = "Log Scale Y";
            logScaleYMenuItem.Click += logScaleYMenuItem_Click;
            // 
            // descendXMenuItem
            // 
            descendXMenuItem.CheckOnClick = true;
            descendXMenuItem.Name = "descendXMenuItem";
            descendXMenuItem.Size = new System.Drawing.Size(177, 26);
            descendXMenuItem.Text = "Descend X";
            descendXMenuItem.CheckedChanged += descendXMenuItem_Click;
            // 
            // descendYMenuItem
            // 
            descendYMenuItem.CheckOnClick = true;
            descendYMenuItem.Name = "descendYMenuItem";
            descendYMenuItem.Size = new System.Drawing.Size(177, 26);
            descendYMenuItem.Text = "Descend Y";
            descendYMenuItem.Click += descendYMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { statusLabel1 });
            statusStrip1.Location = new System.Drawing.Point(0, 461);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(817, 24);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel1
            // 
            statusLabel1.Name = "statusLabel1";
            statusLabel1.Size = new System.Drawing.Size(763, 18);
            statusLabel1.Spring = true;
            statusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            timer1.Interval = 60000;
            timer1.Tick += timer1_Tick;
            // 
            // openFileDialog1
            // 
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "Text files|*.txt;*.csv";
            openFileDialog1.Title = "Select file to graph";
            // 
            // toolTip
            // 
            toolTip.AutomaticDelay = 250;
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 250;
            toolTip.ReshowDelay = 50;
            // 
            // yScalePictureBox
            // 
            yScalePictureBox.Location = new System.Drawing.Point(15, 39);
            yScalePictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            yScalePictureBox.Name = "yScalePictureBox";
            yScalePictureBox.Size = new System.Drawing.Size(80, 326);
            yScalePictureBox.TabIndex = 2;
            yScalePictureBox.TabStop = false;
            yScalePictureBox.Paint += yScalePictureBox_Paint;
            yScalePictureBox.DoubleClick += yScalePictureBox_DoubleClick;
            yScalePictureBox.MouseClick += yScalePictureBox_MouseClick;
            yScalePictureBox.MouseDown += yScalePictureBox_MouseDown;
            yScalePictureBox.MouseMove += yScalePictureBox_MouseMove;
            yScalePictureBox.MouseUp += controlMouseUp;
            // 
            // canvasPictureBox
            // 
            canvasPictureBox.BackColor = System.Drawing.Color.White;
            canvasPictureBox.Location = new System.Drawing.Point(95, 55);
            canvasPictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            canvasPictureBox.Name = "canvasPictureBox";
            canvasPictureBox.Size = new System.Drawing.Size(505, 298);
            canvasPictureBox.TabIndex = 3;
            canvasPictureBox.TabStop = false;
            canvasPictureBox.Paint += canvasPictureBox_Paint;
            canvasPictureBox.MouseDown += canvasPictureBox_MouseDown;
            canvasPictureBox.MouseMove += canvasPictureBox_MouseMove;
            canvasPictureBox.MouseUp += controlMouseUp;
            // 
            // xScalePictureBox
            // 
            xScalePictureBox.Location = new System.Drawing.Point(80, 350);
            xScalePictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            xScalePictureBox.Name = "xScalePictureBox";
            xScalePictureBox.Size = new System.Drawing.Size(532, 32);
            xScalePictureBox.TabIndex = 4;
            xScalePictureBox.TabStop = false;
            xScalePictureBox.Paint += xScalePictureBox_Paint;
            xScalePictureBox.DoubleClick += xScalePictureBox_DoubleClick;
            xScalePictureBox.MouseClick += xScalePictureBox_MouseClick;
            xScalePictureBox.MouseDown += xScalePictureBox_MouseDown;
            xScalePictureBox.MouseMove += xScalePictureBox_MouseMove;
            xScalePictureBox.MouseUp += controlMouseUp;
            // 
            // penColorPanel
            // 
            penColorPanel.AutoSize = true;
            penColorPanel.Location = new System.Drawing.Point(757, 468);
            penColorPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            penColorPanel.Name = "penColorPanel";
            penColorPanel.Size = new System.Drawing.Size(29, 12);
            penColorPanel.TabIndex = 127;
            // 
            // Form1
            // 
            AllowDrop = true;
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(817, 485);
            Controls.Add(penColorPanel);
            Controls.Add(canvasPictureBox);
            Controls.Add(yScalePictureBox);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Controls.Add(xScalePictureBox);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Graph";
            SizeChanged += Form1_SizeChanged;
            DragDrop += Form1_DragDrop;
            DragEnter += Form1_DragEnter;
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)yScalePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)canvasPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)xScalePictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptionsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileOpenMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateNowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoUpdateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IntervalMenuItem;
        private System.Windows.Forms.ToolStripTextBox IntervalTextBox;
        private System.Windows.Forms.ToolStripMenuItem autoScaleMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPointsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLinesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logScaleXMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logScaleYMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descendXMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descendYMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.PictureBox yScalePictureBox;
        private System.Windows.Forms.PictureBox canvasPictureBox;
        private System.Windows.Forms.PictureBox xScalePictureBox;
        private System.Windows.Forms.Panel penColorPanel;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel1;
    }
}

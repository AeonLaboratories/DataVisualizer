namespace Data_Visualizer
{
    partial class ScaleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScaleForm));
            DataPanel = new System.Windows.Forms.Panel();
            BottomRightTextBox = new System.Windows.Forms.TextBox();
            TopLeftTextBox = new System.Windows.Forms.TextBox();
            MaxLabel = new System.Windows.Forms.Label();
            MinLabel = new System.Windows.Forms.Label();
            DialogResultPanel = new System.Windows.Forms.Panel();
            OkDialogButton = new System.Windows.Forms.Button();
            CancelDialogButton = new System.Windows.Forms.Button();
            TopLeftDTPicker = new System.Windows.Forms.DateTimePicker();
            BottomRightDTPicker = new System.Windows.Forms.DateTimePicker();
            DataPanel.SuspendLayout();
            DialogResultPanel.SuspendLayout();
            SuspendLayout();
            // 
            // DataPanel
            // 
            DataPanel.BackColor = System.Drawing.Color.White;
            DataPanel.Controls.Add(BottomRightDTPicker);
            DataPanel.Controls.Add(TopLeftDTPicker);
            DataPanel.Controls.Add(BottomRightTextBox);
            DataPanel.Controls.Add(TopLeftTextBox);
            DataPanel.Controls.Add(MaxLabel);
            DataPanel.Controls.Add(MinLabel);
            DataPanel.Controls.Add(DialogResultPanel);
            DataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            DataPanel.Location = new System.Drawing.Point(0, 0);
            DataPanel.Margin = new System.Windows.Forms.Padding(4);
            DataPanel.Name = "DataPanel";
            DataPanel.Size = new System.Drawing.Size(320, 145);
            DataPanel.TabIndex = 0;
            // 
            // BottomRightTextBox
            // 
            BottomRightTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            BottomRightTextBox.Location = new System.Drawing.Point(91, 47);
            BottomRightTextBox.Margin = new System.Windows.Forms.Padding(4);
            BottomRightTextBox.Name = "BottomRightTextBox";
            BottomRightTextBox.Size = new System.Drawing.Size(212, 22);
            BottomRightTextBox.TabIndex = 1;
            // 
            // TopLeftTextBox
            // 
            TopLeftTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            TopLeftTextBox.Location = new System.Drawing.Point(91, 15);
            TopLeftTextBox.Margin = new System.Windows.Forms.Padding(4);
            TopLeftTextBox.Name = "TopLeftTextBox";
            TopLeftTextBox.Size = new System.Drawing.Size(212, 22);
            TopLeftTextBox.TabIndex = 0;
            // 
            // MaxLabel
            // 
            MaxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            MaxLabel.Location = new System.Drawing.Point(16, 46);
            MaxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            MaxLabel.Name = "MaxLabel";
            MaxLabel.Size = new System.Drawing.Size(67, 25);
            MaxLabel.TabIndex = 2;
            MaxLabel.Text = "Right:";
            MaxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MinLabel
            // 
            MinLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            MinLabel.Location = new System.Drawing.Point(16, 14);
            MinLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            MinLabel.Name = "MinLabel";
            MinLabel.Size = new System.Drawing.Size(67, 25);
            MinLabel.TabIndex = 0;
            MinLabel.Text = "Left:";
            MinLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DialogResultPanel
            // 
            DialogResultPanel.BackColor = System.Drawing.SystemColors.Control;
            DialogResultPanel.Controls.Add(OkDialogButton);
            DialogResultPanel.Controls.Add(CancelDialogButton);
            DialogResultPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            DialogResultPanel.Location = new System.Drawing.Point(0, 86);
            DialogResultPanel.Margin = new System.Windows.Forms.Padding(4);
            DialogResultPanel.Name = "DialogResultPanel";
            DialogResultPanel.Size = new System.Drawing.Size(320, 59);
            DialogResultPanel.TabIndex = 1;
            // 
            // OkDialogButton
            // 
            OkDialogButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            OkDialogButton.Location = new System.Drawing.Point(96, 12);
            OkDialogButton.Margin = new System.Windows.Forms.Padding(4);
            OkDialogButton.Name = "OkDialogButton";
            OkDialogButton.Size = new System.Drawing.Size(100, 32);
            OkDialogButton.TabIndex = 2;
            OkDialogButton.Text = "OK";
            OkDialogButton.UseVisualStyleBackColor = true;
            // 
            // CancelDialogButton
            // 
            CancelDialogButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            CancelDialogButton.Location = new System.Drawing.Point(204, 12);
            CancelDialogButton.Margin = new System.Windows.Forms.Padding(4);
            CancelDialogButton.Name = "CancelDialogButton";
            CancelDialogButton.Size = new System.Drawing.Size(100, 32);
            CancelDialogButton.TabIndex = 3;
            CancelDialogButton.Text = "Cancel";
            CancelDialogButton.UseVisualStyleBackColor = true;
            // 
            // TopLeftDTPicker
            // 
            TopLeftDTPicker.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";
            TopLeftDTPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            TopLeftDTPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            TopLeftDTPicker.Location = new System.Drawing.Point(91, 15);
            TopLeftDTPicker.Margin = new System.Windows.Forms.Padding(4);
            TopLeftDTPicker.Name = "TopLeftDTPicker";
            TopLeftDTPicker.Size = new System.Drawing.Size(212, 22);
            TopLeftDTPicker.TabIndex = 3;
            // 
            // BottomRightDTPicker
            // 
            BottomRightDTPicker.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";
            BottomRightDTPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            BottomRightDTPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            BottomRightDTPicker.Location = new System.Drawing.Point(91, 47);
            BottomRightDTPicker.Margin = new System.Windows.Forms.Padding(4);
            BottomRightDTPicker.Name = "BottomRightDTPicker";
            BottomRightDTPicker.Size = new System.Drawing.Size(212, 22);
            BottomRightDTPicker.TabIndex = 3;
            // 
            // ScaleForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(320, 145);
            Controls.Add(DataPanel);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "ScaleForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "ScaleForm";
            DataPanel.ResumeLayout(false);
            DataPanel.PerformLayout();
            DialogResultPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel DataPanel;
        private System.Windows.Forms.Panel DialogResultPanel;
        private System.Windows.Forms.Button CancelDialogButton;
        public System.Windows.Forms.Label MinLabel;
        private System.Windows.Forms.Button OkDialogButton;
        public System.Windows.Forms.TextBox TopLeftTextBox;
        public System.Windows.Forms.Label MaxLabel;
        public System.Windows.Forms.TextBox BottomRightTextBox;
        public System.Windows.Forms.DateTimePicker TopLeftDTPicker;
        public System.Windows.Forms.DateTimePicker BottomRightDTPicker;
    }
}
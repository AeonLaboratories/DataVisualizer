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
			this.DataPanel = new System.Windows.Forms.Panel();
			this.BottomRightDTPicker = new System.Windows.Forms.DateTimePicker();
			this.TopLeftDTPicker = new System.Windows.Forms.DateTimePicker();
			this.BottomRightTextBox = new System.Windows.Forms.TextBox();
			this.TopLeftTextBox = new System.Windows.Forms.TextBox();
			this.MaxLabel = new System.Windows.Forms.Label();
			this.MinLabel = new System.Windows.Forms.Label();
			this.DialogResultPanel = new System.Windows.Forms.Panel();
			this.CancelDialogButton = new System.Windows.Forms.Button();
			this.OkDialogButton = new System.Windows.Forms.Button();
			this.DataPanel.SuspendLayout();
			this.DialogResultPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// DataPanel
			// 
			this.DataPanel.BackColor = System.Drawing.Color.White;
			this.DataPanel.Controls.Add(this.BottomRightDTPicker);
			this.DataPanel.Controls.Add(this.TopLeftDTPicker);
			this.DataPanel.Controls.Add(this.BottomRightTextBox);
			this.DataPanel.Controls.Add(this.TopLeftTextBox);
			this.DataPanel.Controls.Add(this.MaxLabel);
			this.DataPanel.Controls.Add(this.MinLabel);
			this.DataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DataPanel.Location = new System.Drawing.Point(0, 0);
			this.DataPanel.Name = "DataPanel";
			this.DataPanel.Size = new System.Drawing.Size(240, 118);
			this.DataPanel.TabIndex = 0;
			// 
			// BottomRightDTPicker
			// 
			this.BottomRightDTPicker.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";
			this.BottomRightDTPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.BottomRightDTPicker.Location = new System.Drawing.Point(68, 38);
			this.BottomRightDTPicker.Name = "BottomRightDTPicker";
			this.BottomRightDTPicker.Size = new System.Drawing.Size(160, 20);
			this.BottomRightDTPicker.TabIndex = 3;
			// 
			// TopLeftDTPicker
			// 
			this.TopLeftDTPicker.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";
			this.TopLeftDTPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.TopLeftDTPicker.Location = new System.Drawing.Point(68, 12);
			this.TopLeftDTPicker.Name = "TopLeftDTPicker";
			this.TopLeftDTPicker.Size = new System.Drawing.Size(160, 20);
			this.TopLeftDTPicker.TabIndex = 3;
			// 
			// BottomRightTextBox
			// 
			this.BottomRightTextBox.Location = new System.Drawing.Point(68, 38);
			this.BottomRightTextBox.Name = "BottomRightTextBox";
			this.BottomRightTextBox.Size = new System.Drawing.Size(160, 20);
			this.BottomRightTextBox.TabIndex = 1;
			// 
			// TopLeftTextBox
			// 
			this.TopLeftTextBox.Location = new System.Drawing.Point(68, 12);
			this.TopLeftTextBox.Name = "TopLeftTextBox";
			this.TopLeftTextBox.Size = new System.Drawing.Size(160, 20);
			this.TopLeftTextBox.TabIndex = 0;
			// 
			// MaxLabel
			// 
			this.MaxLabel.Location = new System.Drawing.Point(12, 37);
			this.MaxLabel.Name = "MaxLabel";
			this.MaxLabel.Size = new System.Drawing.Size(50, 20);
			this.MaxLabel.TabIndex = 2;
			this.MaxLabel.Text = "Right:";
			this.MaxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MinLabel
			// 
			this.MinLabel.Location = new System.Drawing.Point(12, 11);
			this.MinLabel.Name = "MinLabel";
			this.MinLabel.Size = new System.Drawing.Size(50, 20);
			this.MinLabel.TabIndex = 0;
			this.MinLabel.Text = "Left:";
			this.MinLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DialogResultPanel
			// 
			this.DialogResultPanel.Controls.Add(this.CancelDialogButton);
			this.DialogResultPanel.Controls.Add(this.OkDialogButton);
			this.DialogResultPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.DialogResultPanel.Location = new System.Drawing.Point(0, 70);
			this.DialogResultPanel.Name = "DialogResultPanel";
			this.DialogResultPanel.Size = new System.Drawing.Size(240, 48);
			this.DialogResultPanel.TabIndex = 1;
			// 
			// CancelDialogButton
			// 
			this.CancelDialogButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelDialogButton.Location = new System.Drawing.Point(153, 10);
			this.CancelDialogButton.Name = "CancelDialogButton";
			this.CancelDialogButton.Size = new System.Drawing.Size(75, 26);
			this.CancelDialogButton.TabIndex = 3;
			this.CancelDialogButton.Text = "Cancel";
			this.CancelDialogButton.UseVisualStyleBackColor = true;
			// 
			// OkDialogButton
			// 
			this.OkDialogButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OkDialogButton.Location = new System.Drawing.Point(72, 10);
			this.OkDialogButton.Name = "OkDialogButton";
			this.OkDialogButton.Size = new System.Drawing.Size(75, 26);
			this.OkDialogButton.TabIndex = 2;
			this.OkDialogButton.Text = "OK";
			this.OkDialogButton.UseVisualStyleBackColor = true;
			// 
			// ScaleForm
			// 
			this.AcceptButton = this.OkDialogButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelDialogButton;
			this.ClientSize = new System.Drawing.Size(240, 118);
			this.Controls.Add(this.DialogResultPanel);
			this.Controls.Add(this.DataPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ScaleForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ScaleForm";
			this.DataPanel.ResumeLayout(false);
			this.DataPanel.PerformLayout();
			this.DialogResultPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel DataPanel;
		private System.Windows.Forms.Panel DialogResultPanel;
		private System.Windows.Forms.Button CancelDialogButton;
		private System.Windows.Forms.Button OkDialogButton;
		public System.Windows.Forms.TextBox BottomRightTextBox;
		public System.Windows.Forms.Label MaxLabel;
		public System.Windows.Forms.Label MinLabel;
		public System.Windows.Forms.TextBox TopLeftTextBox;
		public System.Windows.Forms.DateTimePicker TopLeftDTPicker;
		public System.Windows.Forms.DateTimePicker BottomRightDTPicker;
	}
}
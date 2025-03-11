using System;
using System.Windows.Forms;

namespace Data_Visualizer
{
    public partial class ScaleForm : Form
    {
        ContextMenuStrip copyPasteContextMenu;

        public ScaleForm()
        {
            InitializeComponent();
            setupContextMenu();
        }

        void setupContextMenu()
        {
            copyPasteContextMenu = new ContextMenuStrip();

            ToolStripMenuItem copyMenuItem = new ToolStripMenuItem("Copy", null, CopyDate);
            ToolStripMenuItem pasteMenuItem = new ToolStripMenuItem("Paste", null, PasteDate);

            copyPasteContextMenu.Items.Add(copyMenuItem);
            copyPasteContextMenu.Items.Add(pasteMenuItem);

            ContextMenuStrip = copyPasteContextMenu;
            TopLeftDTPicker.ContextMenuStrip = copyPasteContextMenu;
            BottomRightDTPicker.ContextMenuStrip = copyPasteContextMenu;
        }

        private void CopyDate(object sender, EventArgs e)
        {
            ToolStripMenuItem clicked = sender as ToolStripMenuItem;
            ContextMenuStrip strip = clicked.Owner as ContextMenuStrip;
            DateTimePicker dtp = strip.SourceControl as DateTimePicker;

            string text = "";
            if (dtp != null)
                text = dtp.Value.ToString(dtp.CustomFormat);
            else if (TopLeftDTPicker.Visible)
            {
                text = TopLeftDTPicker.Value.ToString(TopLeftDTPicker.CustomFormat) + ".." +
                    BottomRightDTPicker.Value.ToString(BottomRightDTPicker.CustomFormat);
            }
            else
            {
                text = TopLeftTextBox.Text + ".." + BottomRightTextBox.Text;
            }

            if (text != "")
                Clipboard.SetText(text);
        }

        private void PasteDate(object sender, EventArgs e)
        {
            ToolStripMenuItem clicked = sender as ToolStripMenuItem;
            ContextMenuStrip strip = clicked.Owner as ContextMenuStrip;
            DateTimePicker dtp = strip.SourceControl as DateTimePicker;

            string[] text = Clipboard.GetText().Split(new string[] { ".." }, StringSplitOptions.None);

            try
            {
                if (dtp != null)
                {
                    dtp.Value = DateTime.Parse(text[0]);
                }
                else if (TopLeftDTPicker.Visible)
                {
                    TopLeftDTPicker.Value = DateTime.Parse(text[0]);
                    BottomRightDTPicker.Value = DateTime.Parse(text[1]);
                }
                else
                {
                    TopLeftTextBox.Text = text[0];
                    BottomRightTextBox.Text = text[1];
                }
            }
            catch { }
        }
    }
}

namespace KursYonetimSistemi.UI.Controls
{
    partial class CalendarDayControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dayLabel = new System.Windows.Forms.Label();
            this.schedulesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();

            // dayLabel
            this.dayLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.dayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;

            // schedulesPanel
            this.schedulesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulesPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;

            // CalendarDayControl
            this.Controls.Add(this.schedulesPanel);
            this.Controls.Add(this.dayLabel);
            this.Name = "CalendarDayControl";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label dayLabel;
        private System.Windows.Forms.FlowLayoutPanel schedulesPanel;
    }
}

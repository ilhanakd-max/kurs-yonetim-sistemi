namespace KursYonetimSistemi.UI.Controls
{
    partial class ScheduleControl
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
            this.calendarPanel = new System.Windows.Forms.Panel();
            this.prevMonthButton = new System.Windows.Forms.Button();
            this.nextMonthButton = new System.Windows.Forms.Button();
            this.monthLabel = new System.Windows.Forms.Label();
            this.addScheduleButton = new System.Windows.Forms.Button();
            this.workshopFilterComboBox = new System.Windows.Forms.ComboBox();
            this.teacherFilterComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();

            // calendarPanel
            this.calendarPanel.Dock = System.Windows.Forms.DockStyle.Fill;

            // prevMonthButton
            this.prevMonthButton.Text = "◀ Önceki";
            this.prevMonthButton.Click += new System.EventHandler(this.prevMonthButton_Click);

            // nextMonthButton
            this.nextMonthButton.Text = "Sonraki ▶";
            this.nextMonthButton.Click += new System.EventHandler(this.nextMonthButton_Click);

            // monthLabel
            this.monthLabel.AutoSize = true;

            // addScheduleButton
            this.addScheduleButton.Text = "+ Yeni Ders Ekle";
            this.addScheduleButton.Click += new System.EventHandler(this.addScheduleButton_Click);

            // Layout
            var topPanel = new System.Windows.Forms.Panel();
            topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            topPanel.Height = 40;
            topPanel.Controls.Add(this.addScheduleButton);
            topPanel.Controls.Add(this.nextMonthButton);
            topPanel.Controls.Add(this.monthLabel);
            topPanel.Controls.Add(this.prevMonthButton);
            topPanel.Controls.Add(this.toggleViewButton);
            topPanel.Controls.Add(this.workshopFilterComboBox);
            topPanel.Controls.Add(this.teacherFilterComboBox);

            this.addScheduleButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.workshopFilterComboBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.teacherFilterComboBox.Dock = System.Windows.Forms.DockStyle.Right;

            // toggleViewButton
            this.toggleViewButton.Text = "Haftalık Görünüm";
            this.toggleViewButton.Click += new System.EventHandler(this.toggleViewButton_Click);
            this.toggleViewButton.Dock = System.Windows.Forms.DockStyle.Right;

            // weeklyViewGrid
            this.weeklyViewGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.weeklyViewGrid.Visible = false;

            this.Controls.Add(this.calendarPanel);
            this.Controls.Add(this.weeklyViewGrid);
            this.Controls.Add(topPanel);

            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel calendarPanel;
        private System.Windows.Forms.Button prevMonthButton;
        private System.Windows.Forms.Button nextMonthButton;
        private System.Windows.Forms.Label monthLabel;
        private System.Windows.Forms.Button addScheduleButton;
        private System.Windows.Forms.ComboBox workshopFilterComboBox;
        private System.Windows.Forms.ComboBox teacherFilterComboBox;
        private System.Windows.Forms.Button toggleViewButton;
        private System.Windows.Forms.TableLayoutPanel weeklyViewGrid;
    }
}

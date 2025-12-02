namespace KursYonetimSistemi.UI.Controls
{
    partial class ReportsControl
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
            this.mainLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.reportTypeLabel = new System.Windows.Forms.Label();
            this.reportTypeComboBox = new System.Windows.Forms.ComboBox();
            this.startDateLabel = new System.Windows.Forms.Label();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateLabel = new System.Windows.Forms.Label();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.courseSelectionLabel = new System.Windows.Forms.Label();
            this.courseSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.generateReportButton = new System.Windows.Forms.Button();
            this.exportExcelButton = new System.Windows.Forms.Button();
            this.exportPdfButton = new System.Windows.Forms.Button();
            this.exportTxtButton = new System.Windows.Forms.Button();
            this.reportWebBrowser = new System.Windows.Forms.WebBrowser();

            this.mainLayout.SuspendLayout();
            this.SuspendLayout();

            // mainLayout
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.mainLayout.Controls.Add(this.reportTypeLabel);
            this.mainLayout.Controls.Add(this.reportTypeComboBox);
            this.mainLayout.Controls.Add(this.startDateLabel);
            this.mainLayout.Controls.Add(this.startDatePicker);
            this.mainLayout.Controls.Add(this.endDateLabel);
            this.mainLayout.Controls.Add(this.endDatePicker);
            this.mainLayout.Controls.Add(this.courseSelectionLabel);
            this.mainLayout.Controls.Add(this.courseSelectionComboBox);
            this.mainLayout.Controls.Add(this.generateReportButton);
            this.mainLayout.Controls.Add(this.exportExcelButton);
            this.mainLayout.Controls.Add(this.exportPdfButton);
            this.mainLayout.Controls.Add(this.exportTxtButton);
            this.mainLayout.Controls.Add(this.reportWebBrowser);

            // reportTypeLabel
            this.reportTypeLabel.Text = "Rapor Türü:";
            // reportTypeComboBox
            this.reportTypeComboBox.Items.AddRange(new object[] {
            "Course",
            "Teacher",
            "Workshop",
            "Student",
            "Schedule",
            "Attendance"});

            // startDateLabel
            this.startDateLabel.Text = "Başlangıç Tarihi:";
            // endDateLabel
            this.endDateLabel.Text = "Bitiş Tarihi:";

            // courseSelectionLabel
            this.courseSelectionLabel.Text = "Kurs Seçin:";

            // generateReportButton
            this.generateReportButton.Text = "Rapor Oluştur";
            this.generateReportButton.Click += new System.EventHandler(this.generateReportButton_Click);

            // exportExcelButton
            this.exportExcelButton.Text = "Excel'e Aktar";
            this.exportExcelButton.Click += new System.EventHandler(this.exportExcelButton_Click);

            // exportPdfButton
            this.exportPdfButton.Text = "PDF'e Aktar";
            this.exportPdfButton.Click += new System.EventHandler(this.exportPdfButton_Click);

            // exportTxtButton
            this.exportTxtButton.Text = "TXT'e Aktar";
            this.exportTxtButton.Click += new System.EventHandler(this.exportTxtButton_Click);

            // reportWebBrowser
            this.reportWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;

            this.Controls.Add(this.mainLayout);

            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.FlowLayoutPanel mainLayout;
        private System.Windows.Forms.Label reportTypeLabel;
        private System.Windows.Forms.ComboBox reportTypeComboBox;
        private System.Windows.Forms.Label startDateLabel;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.Label endDateLabel;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.Label courseSelectionLabel;
        private System.Windows.Forms.ComboBox courseSelectionComboBox;
        private System.Windows.Forms.Button generateReportButton;
        private System.Windows.Forms.Button exportExcelButton;
        private System.Windows.Forms.Button exportPdfButton;
        private System.Windows.Forms.Button exportTxtButton;
        private System.Windows.Forms.WebBrowser reportWebBrowser;
    }
}

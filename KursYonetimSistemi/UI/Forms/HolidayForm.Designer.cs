namespace KursYonetimSistemi.UI.Forms
{
    partial class HolidayForm
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
            this.holidayNameLabel = new System.Windows.Forms.Label();
            this.holidayNameTextBox = new System.Windows.Forms.TextBox();
            this.startDateLabel = new System.Windows.Forms.Label();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateLabel = new System.Windows.Forms.Label();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.recurringCheckBox = new System.Windows.Forms.CheckBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();

            this.mainLayout.SuspendLayout();
            this.SuspendLayout();

            // mainLayout
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.mainLayout.Controls.Add(this.holidayNameLabel);
            this.mainLayout.Controls.Add(this.holidayNameTextBox);
            this.mainLayout.Controls.Add(this.startDateLabel);
            this.mainLayout.Controls.Add(this.startDatePicker);
            this.mainLayout.Controls.Add(this.endDateLabel);
            this.mainLayout.Controls.Add(this.endDatePicker);
            this.mainLayout.Controls.Add(this.recurringCheckBox);
            this.mainLayout.Controls.Add(this.descriptionLabel);
            this.mainLayout.Controls.Add(this.descriptionTextBox);
            this.mainLayout.Controls.Add(this.saveButton);

            // holidayNameLabel
            this.holidayNameLabel.Text = "Tatil Adı:";
            // holidayNameTextBox
            this.holidayNameTextBox.Size = new System.Drawing.Size(200, 20);

            // startDateLabel
            this.startDateLabel.Text = "Başlangıç Tarihi:";
            // startDatePicker
            this.startDatePicker.Size = new System.Drawing.Size(200, 20);

            // endDateLabel
            this.endDateLabel.Text = "Bitiş Tarihi:";
            // endDatePicker
            this.endDatePicker.Size = new System.Drawing.Size(200, 20);

            // recurringCheckBox
            this.recurringCheckBox.Text = "Her yıl tekrarla";

            // descriptionLabel
            this.descriptionLabel.Text = "Açıklama:";
            // descriptionTextBox
            this.descriptionTextBox.Size = new System.Drawing.Size(200, 60);
            this.descriptionTextBox.Multiline = true;

            this.saveButton.Text = "Kaydet";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);

            this.Controls.Add(this.mainLayout);
            this.Text = "Tatil Formu";

            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.FlowLayoutPanel mainLayout;
        private System.Windows.Forms.Label holidayNameLabel;
        private System.Windows.Forms.TextBox holidayNameTextBox;
        private System.Windows.Forms.Label startDateLabel;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.Label endDateLabel;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.CheckBox recurringCheckBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Button saveButton;
    }
}

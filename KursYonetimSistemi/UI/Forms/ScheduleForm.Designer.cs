namespace KursYonetimSistemi.UI.Forms
{
    partial class ScheduleForm
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
            this.courseLabel = new System.Windows.Forms.Label();
            this.courseComboBox = new System.Windows.Forms.ComboBox();
            this.teacherLabel = new System.Windows.Forms.Label();
            this.teacherComboBox = new System.Windows.Forms.ComboBox();
            this.workshopLabel = new System.Windows.Forms.Label();
            this.workshopComboBox = new System.Windows.Forms.ComboBox();
            this.dayLabel = new System.Windows.Forms.Label();
            this.dayComboBox = new System.Windows.Forms.ComboBox();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.startTimeMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.endTimeLabel = new System.Windows.Forms.Label();
            this.endTimeMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.startDateLabel = new System.Windows.Forms.Label();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateLabel = new System.Windows.Forms.Label();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.notesLabel = new System.Windows.Forms.Label();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.activeCheckBox = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();

            this.mainLayout.SuspendLayout();
            this.SuspendLayout();

            // mainLayout
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.mainLayout.Controls.Add(this.courseLabel);
            this.mainLayout.Controls.Add(this.courseComboBox);
            this.mainLayout.Controls.Add(this.teacherLabel);
            this.mainLayout.Controls.Add(this.teacherComboBox);
            this.mainLayout.Controls.Add(this.workshopLabel);
            this.mainLayout.Controls.Add(this.workshopComboBox);
            this.mainLayout.Controls.Add(this.dayLabel);
            this.mainLayout.Controls.Add(this.dayComboBox);
            this.mainLayout.Controls.Add(this.startTimeLabel);
            this.mainLayout.Controls.Add(this.startTimeMaskedTextBox);
            this.mainLayout.Controls.Add(this.endTimeLabel);
            this.mainLayout.Controls.Add(this.endTimeMaskedTextBox);
            this.mainLayout.Controls.Add(this.startDateLabel);
            this.mainLayout.Controls.Add(this.startDatePicker);
            this.mainLayout.Controls.Add(this.endDateLabel);
            this.mainLayout.Controls.Add(this.endDatePicker);
            this.mainLayout.Controls.Add(this.notesLabel);
            this.mainLayout.Controls.Add(this.notesTextBox);
            this.mainLayout.Controls.Add(this.activeCheckBox);
            this.mainLayout.Controls.Add(this.saveButton);

            // courseLabel
            this.courseLabel.Text = "Kurs:";
            // courseComboBox
            this.courseComboBox.Size = new System.Drawing.Size(200, 21);

            // teacherLabel
            this.teacherLabel.Text = "Eğitmen:";
            // teacherComboBox
            this.teacherComboBox.Size = new System.Drawing.Size(200, 21);

            // workshopLabel
            this.workshopLabel.Text = "Atölye:";
            // workshopComboBox
            this.workshopComboBox.Size = new System.Drawing.Size(200, 21);

            // dayLabel
            this.dayLabel.Text = "Gün:";
            // dayComboBox
            this.dayComboBox.Size = new System.Drawing.Size(200, 21);
            this.dayComboBox.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});

            // startTimeLabel
            this.startTimeLabel.Text = "Başlangıç Saati:";
            // startTimeMaskedTextBox
            this.startTimeMaskedTextBox.Size = new System.Drawing.Size(200, 20);

            // endTimeLabel
            this.endTimeLabel.Text = "Bitiş Saati:";
            // endTimeMaskedTextBox
            this.endTimeMaskedTextBox.Size = new System.Drawing.Size(200, 20);

            // startDateLabel
            this.startDateLabel.Text = "Başlangıç Tarihi:";
            // startDatePicker
            this.startDatePicker.Size = new System.Drawing.Size(200, 20);

            // endDateLabel
            this.endDateLabel.Text = "Bitiş Tarihi:";
            // endDatePicker
            this.endDatePicker.Size = new System.Drawing.Size(200, 20);

            // notesLabel
            this.notesLabel.Text = "Notlar:";
            // notesTextBox
            this.notesTextBox.Size = new System.Drawing.Size(200, 60);
            this.notesTextBox.Multiline = true;

            // activeCheckBox
            this.activeCheckBox.Text = "Aktif";

            this.saveButton.Text = "Kaydet";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);

            this.Controls.Add(this.mainLayout);
            this.Text = "Ders Formu";

            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.FlowLayoutPanel mainLayout;
        private System.Windows.Forms.Label courseLabel;
        private System.Windows.Forms.ComboBox courseComboBox;
        private System.Windows.Forms.Label teacherLabel;
        private System.Windows.Forms.ComboBox teacherComboBox;
        private System.Windows.Forms.Label workshopLabel;
        private System.Windows.Forms.ComboBox workshopComboBox;
        private System.Windows.Forms.Label dayLabel;
        private System.Windows.Forms.ComboBox dayComboBox;
        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.MaskedTextBox startTimeMaskedTextBox;
        private System.Windows.Forms.Label endTimeLabel;
        private System.Windows.Forms.MaskedTextBox endTimeMaskedTextBox;
        private System.Windows.Forms.Label startDateLabel;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.Label endDateLabel;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.Label notesLabel;
        private System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.CheckBox activeCheckBox;
        private System.Windows.Forms.Button saveButton;
    }
}

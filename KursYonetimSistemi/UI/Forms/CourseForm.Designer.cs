namespace KursYonetimSistemi.UI.Forms
{
    partial class CourseForm
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
            this.courseNameLabel = new System.Windows.Forms.Label();
            this.courseNameTextBox = new System.Windows.Forms.TextBox();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.durationLabel = new System.Windows.Forms.Label();
            this.durationNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.capacityLabel = new System.Windows.Forms.Label();
            this.capacityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.startTimeMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.endTimeLabel = new System.Windows.Forms.Label();
            this.endTimeMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.ageGroupLabel = new System.Windows.Forms.Label();
            this.ageGroupComboBox = new System.Windows.Forms.ComboBox();
            this.levelLabel = new System.Windows.Forms.Label();
            this.levelComboBox = new System.Windows.Forms.ComboBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.materialsLabel = new System.Windows.Forms.Label();
            this.materialsTextBox = new System.Windows.Forms.TextBox();
            this.activeCheckBox = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();

            this.mainLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.durationNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.capacityNumericUpDown)).BeginInit();
            this.SuspendLayout();

            // mainLayout
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.mainLayout.Controls.Add(this.courseNameLabel);
            this.mainLayout.Controls.Add(this.courseNameTextBox);
            this.mainLayout.Controls.Add(this.categoryLabel);
            this.mainLayout.Controls.Add(this.categoryComboBox);
            this.mainLayout.Controls.Add(this.durationLabel);
            this.mainLayout.Controls.Add(this.durationNumericUpDown);
            this.mainLayout.Controls.Add(this.capacityLabel);
            this.mainLayout.Controls.Add(this.capacityNumericUpDown);
            this.mainLayout.Controls.Add(this.startTimeLabel);
            this.mainLayout.Controls.Add(this.startTimeMaskedTextBox);
            this.mainLayout.Controls.Add(this.endTimeLabel);
            this.mainLayout.Controls.Add(this.endTimeMaskedTextBox);
            this.mainLayout.Controls.Add(this.ageGroupLabel);
            this.mainLayout.Controls.Add(this.ageGroupComboBox);
            this.mainLayout.Controls.Add(this.levelLabel);
            this.mainLayout.Controls.Add(this.levelComboBox);
            this.mainLayout.Controls.Add(this.descriptionLabel);
            this.mainLayout.Controls.Add(this.descriptionTextBox);
            this.mainLayout.Controls.Add(this.materialsLabel);
            this.mainLayout.Controls.Add(this.materialsTextBox);
            this.mainLayout.Controls.Add(this.activeCheckBox);
            this.mainLayout.Controls.Add(this.saveButton);

            // courseNameLabel
            this.courseNameLabel.Text = "Kurs Adı:";
            // courseNameTextBox
            this.courseNameTextBox.Size = new System.Drawing.Size(200, 20);

            // categoryLabel
            this.categoryLabel.Text = "Kategori:";
            // categoryComboBox
            this.categoryComboBox.Size = new System.Drawing.Size(200, 21);

            // durationLabel
            this.durationLabel.Text = "Süre (hafta):";
            // durationNumericUpDown
            this.durationNumericUpDown.Size = new System.Drawing.Size(200, 20);

            // capacityLabel
            this.capacityLabel.Text = "Kapasite:";
            // capacityNumericUpDown
            this.capacityNumericUpDown.Size = new System.Drawing.Size(200, 20);

            // startTimeLabel
            this.startTimeLabel.Text = "Başlangıç Saati:";
            // startTimeMaskedTextBox
            this.startTimeMaskedTextBox.Size = new System.Drawing.Size(200, 20);

            // endTimeLabel
            this.endTimeLabel.Text = "Bitiş Saati:";
            // endTimeMaskedTextBox
            this.endTimeMaskedTextBox.Size = new System.Drawing.Size(200, 20);

            // ageGroupLabel
            this.ageGroupLabel.Text = "Yaş Grubu:";
            // ageGroupComboBox
            this.ageGroupComboBox.Size = new System.Drawing.Size(200, 21);
            this.ageGroupComboBox.Items.AddRange(new object[] {
            "Çocuk (7-12)",
            "Genç (13-18)",
            "Yetişkin (18+)",
            "65+",
            "Tüm Yaşlar"});

            // levelLabel
            this.levelLabel.Text = "Seviye:";
            // levelComboBox
            this.levelComboBox.Size = new System.Drawing.Size(200, 21);
            this.levelComboBox.Items.AddRange(new object[] {
            "Başlangıç",
            "Orta",
            "İleri"});

            // descriptionLabel
            this.descriptionLabel.Text = "Açıklama:";
            // descriptionTextBox
            this.descriptionTextBox.Size = new System.Drawing.Size(200, 60);
            this.descriptionTextBox.Multiline = true;

            // materialsLabel
            this.materialsLabel.Text = "Gerekli Malzemeler:";
            // materialsTextBox
            this.materialsTextBox.Size = new System.Drawing.Size(200, 60);
            this.materialsTextBox.Multiline = true;

            // activeCheckBox
            this.activeCheckBox.Text = "Aktif";

            this.saveButton.Text = "Kaydet";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);

            this.Controls.Add(this.mainLayout);
            this.Text = "Kurs Formu";

            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.durationNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.capacityNumericUpDown)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.FlowLayoutPanel mainLayout;
        private System.Windows.Forms.Label courseNameLabel;
        private System.Windows.Forms.TextBox courseNameTextBox;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Label durationLabel;
        private System.Windows.Forms.NumericUpDown durationNumericUpDown;
        private System.Windows.Forms.Label capacityLabel;
        private System.Windows.Forms.NumericUpDown capacityNumericUpDown;
        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.MaskedTextBox startTimeMaskedTextBox;
        private System.Windows.Forms.Label endTimeLabel;
        private System.Windows.Forms.MaskedTextBox endTimeMaskedTextBox;
        private System.Windows.Forms.Label ageGroupLabel;
        private System.Windows.Forms.ComboBox ageGroupComboBox;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.ComboBox levelComboBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label materialsLabel;
        private System.Windows.Forms.TextBox materialsTextBox;
        private System.Windows.Forms.CheckBox activeCheckBox;
        private System.Windows.Forms.Button saveButton;
    }
}

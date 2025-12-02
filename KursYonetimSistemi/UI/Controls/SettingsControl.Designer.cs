namespace KursYonetimSistemi.UI.Controls
{
    partial class SettingsControl
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
            this.orgNameLabel = new System.Windows.Forms.Label();
            this.orgNameTextBox = new System.Windows.Forms.TextBox();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.startTimeMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.endTimeLabel = new System.Windows.Forms.Label();
            this.endTimeMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.lessonDurationLabel = new System.Windows.Forms.Label();
            this.lessonDurationNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.breakDurationLabel = new System.Windows.Forms.Label();
            this.breakDurationNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.weekendOffCheckBox = new System.Windows.Forms.CheckBox();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.clearDataButton = new System.Windows.Forms.Button();
            this.categoriesLabel = new System.Windows.Forms.Label();
            this.categoriesListBox = new System.Windows.Forms.ListBox();
            this.newCategoryTextBox = new System.Windows.Forms.TextBox();
            this.addCategoryButton = new System.Windows.Forms.Button();
            this.deleteCategoryButton = new System.Windows.Forms.Button();

            this.mainLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lessonDurationNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.breakDurationNumericUpDown)).BeginInit();
            this.SuspendLayout();

            // mainLayout
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.mainLayout.Controls.Add(this.orgNameLabel);
            this.mainLayout.Controls.Add(this.orgNameTextBox);
            this.mainLayout.Controls.Add(this.startTimeLabel);
            this.mainLayout.Controls.Add(this.startTimeMaskedTextBox);
            this.mainLayout.Controls.Add(this.endTimeLabel);
            this.mainLayout.Controls.Add(this.endTimeMaskedTextBox);
            this.mainLayout.Controls.Add(this.lessonDurationLabel);
            this.mainLayout.Controls.Add(this.lessonDurationNumericUpDown);
            this.mainLayout.Controls.Add(this.breakDurationLabel);
            this.mainLayout.Controls.Add(this.breakDurationNumericUpDown);
            this.mainLayout.Controls.Add(this.weekendOffCheckBox);
            this.mainLayout.Controls.Add(this.saveSettingsButton);
            this.mainLayout.Controls.Add(this.exportButton);
            this.mainLayout.Controls.Add(this.importButton);
            this.mainLayout.Controls.Add(this.clearDataButton);
            this.mainLayout.Controls.Add(this.categoriesLabel);
            this.mainLayout.Controls.Add(this.categoriesListBox);
            this.mainLayout.Controls.Add(this.newCategoryTextBox);
            this.mainLayout.Controls.Add(this.addCategoryButton);
            this.mainLayout.Controls.Add(this.deleteCategoryButton);
            this.mainLayout.Controls.Add(this.themeLabel);
            this.mainLayout.Controls.Add(this.themeLayoutPanel);
            this.themeLayoutPanel.Controls.Add(this.themeRadioButton1);
            this.themeLayoutPanel.Controls.Add(this.themeRadioButton2);
            this.themeLayoutPanel.Controls.Add(this.themeRadioButton3);

            // orgNameLabel
            this.orgNameLabel.Text = "Kurum Adı:";
            // orgNameTextBox
            this.orgNameTextBox.Size = new System.Drawing.Size(200, 20);

            // startTimeLabel
            this.startTimeLabel.Text = "Başlangıç Saati:";
            // startTimeMaskedTextBox
            this.startTimeMaskedTextBox.Size = new System.Drawing.Size(200, 20);

            // endTimeLabel
            this.endTimeLabel.Text = "Bitiş Saati:";
            // endTimeMaskedTextBox
            this.endTimeMaskedTextBox.Size = new System.Drawing.Size(200, 20);

            // lessonDurationLabel
            this.lessonDurationLabel.Text = "Ders Süresi (dakika):";
            // lessonDurationNumericUpDown
            this.lessonDurationNumericUpDown.Size = new System.Drawing.Size(200, 20);

            // breakDurationLabel
            this.breakDurationLabel.Text = "Mola Süresi (dakika):";
            // breakDurationNumericUpDown
            this.breakDurationNumericUpDown.Size = new System.Drawing.Size(200, 20);

            // weekendOffCheckBox
            this.weekendOffCheckBox.Text = "Hafta sonu tatil";

            // saveSettingsButton
            this.saveSettingsButton.Text = "Ayarları Kaydet";
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);

            // exportButton
            this.exportButton.Text = "Verileri Dışa Aktar";
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);

            // importButton
            this.importButton.Text = "Verileri İçe Aktar";
            this.importButton.Click += new System.EventHandler(this.importButton_Click);

            // clearDataButton
            this.clearDataButton.Text = "Tüm Verileri Sil";
            this.clearDataButton.Click += new System.EventHandler(this.clearDataButton_Click);

            // categoriesLabel
            this.categoriesLabel.Text = "Kategoriler:";
            // categoriesListBox
            this.categoriesListBox.Size = new System.Drawing.Size(200, 100);
            // newCategoryTextBox
            this.newCategoryTextBox.Size = new System.Drawing.Size(200, 20);
            // addCategoryButton
            this.addCategoryButton.Text = "Ekle";
            this.addCategoryButton.Click += new System.EventHandler(this.addCategoryButton_Click);
            // deleteCategoryButton
            this.deleteCategoryButton.Text = "Sil";
            this.deleteCategoryButton.Click += new System.EventHandler(this.deleteCategoryButton_Click);

            // themeLabel
            this.themeLabel.Text = "Tema Rengi:";
            // themeLayoutPanel
            this.themeLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            // themeRadioButton1
            this.themeRadioButton1.Text = "Mavi";
            this.themeRadioButton1.Tag = "#1a5276";
            // themeRadioButton2
            this.themeRadioButton2.Text = "Yeşil";
            this.themeRadioButton2.Tag = "#27ae60";
            // themeRadioButton3
            this.themeRadioButton3.Text = "Kırmızı";
            this.themeRadioButton3.Tag = "#c0392b";

            this.Controls.Add(this.mainLayout);

            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lessonDurationNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.breakDurationNumericUpDown)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.FlowLayoutPanel mainLayout;
        private System.Windows.Forms.Label orgNameLabel;
        private System.Windows.Forms.TextBox orgNameTextBox;
        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.MaskedTextBox startTimeMaskedTextBox;
        private System.Windows.Forms.Label endTimeLabel;
        private System.Windows.Forms.MaskedTextBox endTimeMaskedTextBox;
        private System.Windows.Forms.Label lessonDurationLabel;
        private System.Windows.Forms.NumericUpDown lessonDurationNumericUpDown;
        private System.Windows.Forms.Label breakDurationLabel;
        private System.Windows.Forms.NumericUpDown breakDurationNumericUpDown;
        private System.Windows.Forms.CheckBox weekendOffCheckBox;
        private System.Windows.Forms.Button saveSettingsButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button clearDataButton;
        private System.Windows.Forms.Label categoriesLabel;
        private System.Windows.Forms.ListBox categoriesListBox;
        private System.Windows.Forms.TextBox newCategoryTextBox;
        private System.Windows.Forms.Button addCategoryButton;
        private System.Windows.Forms.Button deleteCategoryButton;
        private System.Windows.Forms.Label themeLabel;
        private System.Windows.Forms.FlowLayoutPanel themeLayoutPanel;
        private System.Windows.Forms.RadioButton themeRadioButton1;
        private System.Windows.Forms.RadioButton themeRadioButton2;
        private System.Windows.Forms.RadioButton themeRadioButton3;
    }
}

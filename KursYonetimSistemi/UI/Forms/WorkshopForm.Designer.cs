namespace KursYonetimSistemi.UI.Forms
{
    partial class WorkshopForm
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
            this.workshopNameLabel = new System.Windows.Forms.Label();
            this.workshopNameTextBox = new System.Windows.Forms.TextBox();
            this.locationLabel = new System.Windows.Forms.Label();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.capacityLabel = new System.Windows.Forms.Label();
            this.capacityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.equipmentLabel = new System.Windows.Forms.Label();
            this.equipmentTextBox = new System.Windows.Forms.TextBox();
            this.activeCheckBox = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();

            this.mainLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.capacityNumericUpDown)).BeginInit();
            this.SuspendLayout();

            // mainLayout
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.mainLayout.Controls.Add(this.workshopNameLabel);
            this.mainLayout.Controls.Add(this.workshopNameTextBox);
            this.mainLayout.Controls.Add(this.locationLabel);
            this.mainLayout.Controls.Add(this.locationTextBox);
            this.mainLayout.Controls.Add(this.capacityLabel);
            this.mainLayout.Controls.Add(this.capacityNumericUpDown);
            this.mainLayout.Controls.Add(this.equipmentLabel);
            this.mainLayout.Controls.Add(this.equipmentTextBox);
            this.mainLayout.Controls.Add(this.activeCheckBox);
            this.mainLayout.Controls.Add(this.saveButton);

            // workshopNameLabel
            this.workshopNameLabel.Text = "Atölye Adı:";
            // workshopNameTextBox
            this.workshopNameTextBox.Size = new System.Drawing.Size(200, 20);

            // locationLabel
            this.locationLabel.Text = "Konum:";
            // locationTextBox
            this.locationTextBox.Size = new System.Drawing.Size(200, 20);

            // capacityLabel
            this.capacityLabel.Text = "Kapasite:";
            // capacityNumericUpDown
            this.capacityNumericUpDown.Size = new System.Drawing.Size(200, 20);

            // equipmentLabel
            this.equipmentLabel.Text = "Donanım:";
            // equipmentTextBox
            this.equipmentTextBox.Size = new System.Drawing.Size(200, 60);
            this.equipmentTextBox.Multiline = true;

            // activeCheckBox
            this.activeCheckBox.Text = "Aktif";

            this.saveButton.Text = "Kaydet";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);

            this.Controls.Add(this.mainLayout);
            this.Text = "Atölye Formu";

            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.capacityNumericUpDown)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.FlowLayoutPanel mainLayout;
        private System.Windows.Forms.Label workshopNameLabel;
        private System.Windows.Forms.TextBox workshopNameTextBox;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.Label capacityLabel;
        private System.Windows.Forms.NumericUpDown capacityNumericUpDown;
        private System.Windows.Forms.Label equipmentLabel;
        private System.Windows.Forms.TextBox equipmentTextBox;
        private System.Windows.Forms.CheckBox activeCheckBox;
        private System.Windows.Forms.Button saveButton;
    }
}

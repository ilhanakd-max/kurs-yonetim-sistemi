namespace KursYonetimSistemi.UI.Forms
{
    partial class TeacherForm
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
            this.teacherNameLabel = new System.Windows.Forms.Label();
            this.teacherNameTextBox = new System.Windows.Forms.TextBox();
            this.tcLabel = new System.Windows.Forms.Label();
            this.tcTextBox = new System.Windows.Forms.TextBox();
            this.branchLabel = new System.Windows.Forms.Label();
            this.branchTextBox = new System.Windows.Forms.TextBox();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.addressLabel = new System.Windows.Forms.Label();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.notesLabel = new System.Windows.Forms.Label();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.activeCheckBox = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();

            this.mainLayout.SuspendLayout();
            this.SuspendLayout();

            // mainLayout
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.mainLayout.Controls.Add(this.teacherNameLabel);
            this.mainLayout.Controls.Add(this.teacherNameTextBox);
            this.mainLayout.Controls.Add(this.tcLabel);
            this.mainLayout.Controls.Add(this.tcTextBox);
            this.mainLayout.Controls.Add(this.branchLabel);
            this.mainLayout.Controls.Add(this.branchTextBox);
            this.mainLayout.Controls.Add(this.phoneLabel);
            this.mainLayout.Controls.Add(this.phoneTextBox);
            this.mainLayout.Controls.Add(this.emailLabel);
            this.mainLayout.Controls.Add(this.emailTextBox);
            this.mainLayout.Controls.Add(this.addressLabel);
            this.mainLayout.Controls.Add(this.addressTextBox);
            this.mainLayout.Controls.Add(this.notesLabel);
            this.mainLayout.Controls.Add(this.notesTextBox);
            this.mainLayout.Controls.Add(this.activeCheckBox);
            this.mainLayout.Controls.Add(this.saveButton);

            // teacherNameLabel
            this.teacherNameLabel.Text = "Ad Soyad:";
            // teacherNameTextBox
            this.teacherNameTextBox.Size = new System.Drawing.Size(200, 20);

            // tcLabel
            this.tcLabel.Text = "TC Kimlik No:";
            // tcTextBox
            this.tcTextBox.Size = new System.Drawing.Size(200, 20);

            // branchLabel
            this.branchLabel.Text = "Branş:";
            // branchTextBox
            this.branchTextBox.Size = new System.Drawing.Size(200, 20);

            // phoneLabel
            this.phoneLabel.Text = "Telefon:";
            // phoneTextBox
            this.phoneTextBox.Size = new System.Drawing.Size(200, 20);

            // emailLabel
            this.emailLabel.Text = "E-posta:";
            // emailTextBox
            this.emailTextBox.Size = new System.Drawing.Size(200, 20);

            // addressLabel
            this.addressLabel.Text = "Adres:";
            // addressTextBox
            this.addressTextBox.Size = new System.Drawing.Size(200, 60);
            this.addressTextBox.Multiline = true;

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
            this.Text = "Eğitmen Formu";

            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.FlowLayoutPanel mainLayout;
        private System.Windows.Forms.Label teacherNameLabel;
        private System.Windows.Forms.TextBox teacherNameTextBox;
        private System.Windows.Forms.Label tcLabel;
        private System.Windows.Forms.TextBox tcTextBox;
        private System.Windows.Forms.Label branchLabel;
        private System.Windows.Forms.TextBox branchTextBox;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.Label notesLabel;
        private System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.CheckBox activeCheckBox;
        private System.Windows.Forms.Button saveButton;
    }
}

namespace KursYonetimSistemi.UI.Controls
{
    partial class StudentsControl
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
            this.studentsDataGridView = new System.Windows.Forms.DataGridView();
            this.addStudentButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.studentCourseComboBox = new System.Windows.Forms.ComboBox();
            this.EditButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DeleteButton = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.studentsDataGridView)).BeginInit();
            this.SuspendLayout();

            // studentsDataGridView
            this.studentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studentsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studentsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EditButton,
            this.DeleteButton});
            this.studentsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.studentsDataGridView_CellContentClick);

            // addStudentButton
            this.addStudentButton.Text = "+ Yeni Öğrenci Ekle";
            this.addStudentButton.Click += new System.EventHandler(this.addStudentButton_Click);

            // searchTextBox
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // studentCourseComboBox
            this.studentCourseComboBox.SelectedIndexChanged += new System.EventHandler(this.studentCourseComboBox_SelectedIndexChanged);

            // Layout
            var topPanel = new System.Windows.Forms.Panel();
            topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            topPanel.Height = 40;
            topPanel.Controls.Add(this.addStudentButton);
            topPanel.Controls.Add(this.searchTextBox);
            topPanel.Controls.Add(this.studentCourseComboBox);
            this.addStudentButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.searchTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.studentCourseComboBox.Dock = System.Windows.Forms.DockStyle.Left;

            var gridPanel = new System.Windows.Forms.Panel();
            gridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            gridPanel.Controls.Add(this.studentsDataGridView);

            this.Controls.Add(gridPanel);
            this.Controls.Add(topPanel);

            // EditButton
            this.EditButton.HeaderText = "Düzenle";
            this.EditButton.Name = "EditButton";
            this.EditButton.Text = "✏️";
            this.EditButton.UseColumnTextForButtonValue = true;

            // DeleteButton
            this.DeleteButton.HeaderText = "Sil";
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Text = "🗑️";
            this.DeleteButton.UseColumnTextForButtonValue = true;

            ((System.ComponentModel.ISupportInitialize)(this.studentsDataGridView)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView studentsDataGridView;
        private System.Windows.Forms.Button addStudentButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.ComboBox studentCourseComboBox;
        private System.Windows.Forms.DataGridViewButtonColumn EditButton;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteButton;
    }
}

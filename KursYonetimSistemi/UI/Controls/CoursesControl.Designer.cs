namespace KursYonetimSistemi.UI.Controls
{
    partial class CoursesControl
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
            this.coursesDataGridView = new System.Windows.Forms.DataGridView();
            this.addCourseButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.EditButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DeleteButton = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.coursesDataGridView)).BeginInit();
            this.SuspendLayout();

            // coursesDataGridView
            this.coursesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.coursesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.coursesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EditButton,
            this.DeleteButton});
            this.coursesDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.coursesDataGridView_CellContentClick);

            // addCourseButton
            this.addCourseButton.Text = "+ Yeni Kurs Ekle";
            this.addCourseButton.Click += new System.EventHandler(this.addCourseButton_Click);

            // searchTextBox
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // categoryComboBox
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox_SelectedIndexChanged);

            // Layout
            var topPanel = new System.Windows.Forms.Panel();
            topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            topPanel.Height = 40;
            topPanel.Controls.Add(this.addCourseButton);
            topPanel.Controls.Add(this.searchTextBox);
            topPanel.Controls.Add(this.categoryComboBox);
            this.addCourseButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.searchTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.categoryComboBox.Dock = System.Windows.Forms.DockStyle.Left;

            var gridPanel = new System.Windows.Forms.Panel();
            gridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            gridPanel.Controls.Add(this.coursesDataGridView);

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

            ((System.ComponentModel.ISupportInitialize)(this.coursesDataGridView)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView coursesDataGridView;
        private System.Windows.Forms.Button addCourseButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.DataGridViewButtonColumn EditButton;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteButton;
    }
}

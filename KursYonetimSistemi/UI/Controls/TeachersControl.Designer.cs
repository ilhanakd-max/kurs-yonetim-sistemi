namespace KursYonetimSistemi.UI.Controls
{
    partial class TeachersControl
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
            this.teachersDataGridView = new System.Windows.Forms.DataGridView();
            this.addTeacherButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.EditButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DeleteButton = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.teachersDataGridView)).BeginInit();
            this.SuspendLayout();

            // teachersDataGridView
            this.teachersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.teachersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teachersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EditButton,
            this.DeleteButton});
            this.teachersDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.teachersDataGridView_CellContentClick);

            // addTeacherButton
            this.addTeacherButton.Text = "+ Yeni Eğitmen Ekle";
            this.addTeacherButton.Click += new System.EventHandler(this.addTeacherButton_Click);

            // searchTextBox
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);

            // Layout
            var topPanel = new System.Windows.Forms.Panel();
            topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            topPanel.Height = 40;
            topPanel.Controls.Add(this.addTeacherButton);
            topPanel.Controls.Add(this.searchTextBox);
            this.addTeacherButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.searchTextBox.Dock = System.Windows.Forms.DockStyle.Left;

            var gridPanel = new System.Windows.Forms.Panel();
            gridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            gridPanel.Controls.Add(this.teachersDataGridView);

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

            ((System.ComponentModel.ISupportInitialize)(this.teachersDataGridView)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView teachersDataGridView;
        private System.Windows.Forms.Button addTeacherButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.DataGridViewButtonColumn EditButton;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteButton;
    }
}

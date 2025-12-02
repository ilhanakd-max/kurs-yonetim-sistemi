namespace KursYonetimSistemi.UI.Controls
{
    partial class WorkshopsControl
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
            this.workshopsDataGridView = new System.Windows.Forms.DataGridView();
            this.addWorkshopButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.EditButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DeleteButton = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.workshopsDataGridView)).BeginInit();
            this.SuspendLayout();

            // workshopsDataGridView
            this.workshopsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.workshopsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workshopsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EditButton,
            this.DeleteButton});
            this.workshopsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.workshopsDataGridView_CellContentClick);

            // addWorkshopButton
            this.addWorkshopButton.Text = "+ Yeni Atölye Ekle";
            this.addWorkshopButton.Click += new System.EventHandler(this.addWorkshopButton_Click);

            // searchTextBox
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);

            // Layout
            var topPanel = new System.Windows.Forms.Panel();
            topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            topPanel.Height = 40;
            topPanel.Controls.Add(this.addWorkshopButton);
            topPanel.Controls.Add(this.searchTextBox);
            this.addWorkshopButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.searchTextBox.Dock = System.Windows.Forms.DockStyle.Left;

            var gridPanel = new System.Windows.Forms.Panel();
            gridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            gridPanel.Controls.Add(this.workshopsDataGridView);

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

            ((System.ComponentModel.ISupportInitialize)(this.workshopsDataGridView)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView workshopsDataGridView;
        private System.Windows.Forms.Button addWorkshopButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.DataGridViewButtonColumn EditButton;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteButton;
    }
}

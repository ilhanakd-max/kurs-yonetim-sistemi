namespace KursYonetimSistemi.UI.Controls
{
    partial class HolidaysControl
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
            this.holidaysDataGridView = new System.Windows.Forms.DataGridView();
            this.addHolidayButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.EditButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DeleteButton = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.holidaysDataGridView)).BeginInit();
            this.SuspendLayout();

            // holidaysDataGridView
            this.holidaysDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.holidaysDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.holidaysDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EditButton,
            this.DeleteButton});
            this.holidaysDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.holidaysDataGridView_CellContentClick);

            // addHolidayButton
            this.addHolidayButton.Text = "+ Yeni Tatil Ekle";
            this.addHolidayButton.Click += new System.EventHandler(this.addHolidayButton_Click);

            // searchTextBox
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);

            // Layout
            var topPanel = new System.Windows.Forms.Panel();
            topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            topPanel.Height = 40;
            topPanel.Controls.Add(this.addHolidayButton);
            topPanel.Controls.Add(this.searchTextBox);
            this.addHolidayButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.searchTextBox.Dock = System.Windows.Forms.DockStyle.Left;

            var gridPanel = new System.Windows.Forms.Panel();
            gridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            gridPanel.Controls.Add(this.holidaysDataGridView);

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

            ((System.ComponentModel.ISupportInitialize)(this.holidaysDataGridView)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView holidaysDataGridView;
        private System.Windows.Forms.Button addHolidayButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.DataGridViewButtonColumn EditButton;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteButton;
    }
}

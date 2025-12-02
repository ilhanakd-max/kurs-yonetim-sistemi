using System;
using System.Windows.Forms;
using KursYonetimSistemi.Services;

namespace KursYonetimSistemi.UI.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            DataManager.LoadData();
            ThemeManager.ApplyTheme(this);

            this.saveDataToolStripMenuItem.Click += new System.EventHandler(this.saveDataToolStripMenuItem_Click);
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
        }

        private void saveDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataManager.SaveData();
            MessageBox.Show("Veriler kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            DataManager.SaveData();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kurs Yönetim Sistemi v1.0", "Hakkında", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

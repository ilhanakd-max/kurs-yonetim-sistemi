using System;
using System.Windows.Forms;
using KursYonetimSistemi.Models;
using KursYonetimSistemi.Services;
using System.Linq;

namespace KursYonetimSistemi.UI.Controls
{
    public partial class WorkshopsControl : UserControl
    {
        public WorkshopsControl()
        {
            InitializeComponent();
            LoadWorkshops();
        }

        public void LoadWorkshops(string searchTerm = null)
        {
            var workshops = DataManager.Workshops.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                workshops = workshops.Where(w => w.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || w.Location.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
            }

            var workshopList = workshops.Select(w => new
            {
                w.Id,
                w.Name,
                w.Location,
                w.Capacity,
                w.Equipment,
                Status = w.Active ? "Aktif" : "Pasif"
            }).ToList();

            workshopsDataGridView.DataSource = workshopList;
            workshopsDataGridView.Columns["Id"].Visible = false;
        }

        private void addWorkshopButton_Click(object sender, EventArgs e)
        {
            using (var form = new Forms.WorkshopForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadWorkshops(searchTextBox.Text);
                }
            }
        }

        private void workshopsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var workshopId = workshopsDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                if (workshopsDataGridView.Columns[e.ColumnIndex].Name == "EditButton")
                {
                    using (var form = new Forms.WorkshopForm(workshopId))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            LoadWorkshops(searchTextBox.Text);
                        }
                    }
                }
                else if (workshopsDataGridView.Columns[e.ColumnIndex].Name == "DeleteButton")
                {
                    if (DataManager.Schedules.Any(s => s.WorkshopId == workshopId))
                    {
                        MessageBox.Show("Bu atölyenin ders programında dersleri bulunmaktadır. Lütfen önce bu dersleri silin.", "Silme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (MessageBox.Show("Bu atölyeyi silmek istediğinizden emin misiniz?", "Atölyeyi Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        var workshop = DataManager.Workshops.FirstOrDefault(w => w.Id == workshopId);
                        if (workshop != null)
                        {
                            DataManager.Workshops.Remove(workshop);
                            DataManager.SaveData();
                            LoadWorkshops(searchTextBox.Text);
                        }
                    }
                }
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            LoadWorkshops(searchTextBox.Text);
        }
    }
}

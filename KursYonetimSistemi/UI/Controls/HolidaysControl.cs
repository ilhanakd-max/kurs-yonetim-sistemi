using System;
using System.Windows.Forms;
using KursYonetimSistemi.Models;
using KursYonetimSistemi.Services;
using System.Linq;

namespace KursYonetimSistemi.UI.Controls
{
    public partial class HolidaysControl : UserControl
    {
        public HolidaysControl()
        {
            InitializeComponent();
            LoadHolidays();
        }

        public void LoadHolidays(string searchTerm = null)
        {
            var holidays = DataManager.Holidays;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                holidays = holidays.Where(h => h.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
            }

            var holidayList = holidays.Select(h => new
            {
                h.Id,
                h.Name,
                h.StartDate,
                h.EndDate,
                Recurring = h.Recurring ? "Evet" : "Hayır",
                h.Description
            }).ToList();

            holidaysDataGridView.DataSource = holidayList;
            holidaysDataGridView.Columns["Id"].Visible = false;
        }

        private void addHolidayButton_Click(object sender, EventArgs e)
        {
            using (var form = new Forms.HolidayForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadHolidays(searchTextBox.Text);
                }
            }
        }

        private void holidaysDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var holidayId = holidaysDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                if (holidaysDataGridView.Columns[e.ColumnIndex].Name == "EditButton")
                {
                    using (var form = new Forms.HolidayForm(holidayId))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            LoadHolidays(searchTextBox.Text);
                        }
                    }
                }
                else if (holidaysDataGridView.Columns[e.ColumnIndex].Name == "DeleteButton")
                {
                    if (MessageBox.Show("Bu tatili silmek istediğinizden emin misiniz?", "Tatili Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        var holiday = DataManager.Holidays.FirstOrDefault(h => h.Id == holidayId);
                        if (holiday != null)
                        {
                            DataManager.Holidays.Remove(holiday);
                            DataManager.SaveData();
                            LoadHolidays(searchTextBox.Text);
                        }
                    }
                }
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            LoadHolidays(searchTextBox.Text);
        }
    }
}

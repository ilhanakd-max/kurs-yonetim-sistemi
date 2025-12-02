using System;
using System.Linq;
using System.Windows.Forms;
using KursYonetimSistemi.Models;
using KursYonetimSistemi.Services;

namespace KursYonetimSistemi.UI.Forms
{
    public partial class HolidayForm : Form
    {
        private Holiday _holiday;
        private bool _isNew;

        public HolidayForm(string holidayId = null)
        {
            InitializeComponent();

            if (holidayId == null)
            {
                _isNew = true;
                _holiday = new Holiday();
                this.Text = "Yeni Tatil Ekle";
            }
            else
            {
                _isNew = false;
                _holiday = DataManager.Holidays.FirstOrDefault(h => h.Id == holidayId);
                this.Text = "Tatil Düzenle";
                PopulateForm();
            }
        }

        private void PopulateForm()
        {
            holidayNameTextBox.Text = _holiday.Name;
            startDatePicker.Value = _holiday.StartDate;
            endDatePicker.Value = _holiday.EndDate;
            recurringCheckBox.Checked = _holiday.Recurring;
            descriptionTextBox.Text = _holiday.Description;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            _holiday.Name = holidayNameTextBox.Text;
            _holiday.StartDate = startDatePicker.Value;
            _holiday.EndDate = endDatePicker.Value;
            _holiday.Recurring = recurringCheckBox.Checked;
            _holiday.Description = descriptionTextBox.Text;

            if (_isNew)
            {
                DataManager.Holidays.Add(_holiday);
            }

            DataManager.SaveData();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

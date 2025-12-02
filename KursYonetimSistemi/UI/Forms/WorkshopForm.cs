using System;
using System.Linq;
using System.Windows.Forms;
using KursYonetimSistemi.Models;
using KursYonetimSistemi.Services;

namespace KursYonetimSistemi.UI.Forms
{
    public partial class WorkshopForm : Form
    {
        private Workshop _workshop;
        private bool _isNew;

        public WorkshopForm(string workshopId = null)
        {
            InitializeComponent();

            if (workshopId == null)
            {
                _isNew = true;
                _workshop = new Workshop();
                this.Text = "Yeni Atölye Ekle";
            }
            else
            {
                _isNew = false;
                _workshop = DataManager.Workshops.FirstOrDefault(w => w.Id == workshopId);
                this.Text = "Atölye Düzenle";
                PopulateForm();
            }
        }

        private void PopulateForm()
        {
            workshopNameTextBox.Text = _workshop.Name;
            locationTextBox.Text = _workshop.Location;
            capacityNumericUpDown.Value = _workshop.Capacity;
            equipmentTextBox.Text = _workshop.Equipment;
            // Color picker would be implemented here
            activeCheckBox.Checked = _workshop.Active;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            _workshop.Name = workshopNameTextBox.Text;
            _workshop.Location = locationTextBox.Text;
            _workshop.Capacity = (int)capacityNumericUpDown.Value;
            _workshop.Equipment = equipmentTextBox.Text;
            // _workshop.Color = ... // From color picker
            _workshop.Active = activeCheckBox.Checked;

            if (_isNew)
            {
                DataManager.Workshops.Add(_workshop);
            }

            DataManager.SaveData();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

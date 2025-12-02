using System;
using System.Linq;
using System.Windows.Forms;
using KursYonetimSistemi.Models;
using KursYonetimSistemi.Services;

namespace KursYonetimSistemi.UI.Forms
{
    public partial class TeacherForm : Form
    {
        private Teacher _teacher;
        private bool _isNew;

        public TeacherForm(string teacherId = null)
        {
            InitializeComponent();

            if (teacherId == null)
            {
                _isNew = true;
                _teacher = new Teacher();
                this.Text = "Yeni Eğitmen Ekle";
            }
            else
            {
                _isNew = false;
                _teacher = DataManager.Teachers.FirstOrDefault(t => t.Id == teacherId);
                this.Text = "Eğitmen Düzenle";
                PopulateForm();
            }
        }

        private void PopulateForm()
        {
            teacherNameTextBox.Text = _teacher.Name;
            tcTextBox.Text = _teacher.Tc;
            branchTextBox.Text = _teacher.Branch;
            phoneTextBox.Text = _teacher.Phone;
            emailTextBox.Text = _teacher.Email;
            addressTextBox.Text = _teacher.Address;
            notesTextBox.Text = _teacher.Notes;
            activeCheckBox.Checked = _teacher.Active;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            _teacher.Name = teacherNameTextBox.Text;
            _teacher.Tc = tcTextBox.Text;
            _teacher.Branch = branchTextBox.Text;
            _teacher.Phone = phoneTextBox.Text;
            _teacher.Email = emailTextBox.Text;
            _teacher.Address = addressTextBox.Text;
            _teacher.Notes = notesTextBox.Text;
            _teacher.Active = activeCheckBox.Checked;

            if (_isNew)
            {
                DataManager.Teachers.Add(_teacher);
            }

            DataManager.SaveData();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

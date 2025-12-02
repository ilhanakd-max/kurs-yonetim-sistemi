using System;
using System.Linq;
using System.Windows.Forms;
using KursYonetimSistemi.Models;
using KursYonetimSistemi.Services;
using System.Collections.Generic;

namespace KursYonetimSistemi.UI.Forms
{
    public partial class StudentForm : Form
    {
        private Student _student;
        private bool _isNew;
        private List<CheckBox> courseCheckBoxes = new List<CheckBox>();

        public StudentForm(string studentId = null)
        {
            InitializeComponent();
            LoadCourses();

            if (studentId == null)
            {
                _isNew = true;
                _student = new Student();
                this.Text = "Yeni Öğrenci Ekle";
            }
            else
            {
                _isNew = false;
                _student = DataManager.Students.FirstOrDefault(s => s.Id == studentId);
                this.Text = "Öğrenci Düzenle";
                PopulateForm();
            }
        }

        private void PopulateForm()
        {
            studentNameTextBox.Text = _student.Name;
            tcTextBox.Text = _student.Tc;
            birthdatePicker.Value = _student.Birthdate;
            phoneTextBox.Text = _student.Phone;
            emailTextBox.Text = _student.Email;
            addressTextBox.Text = _student.Address;
            guardianTextBox.Text = _student.Guardian;
            notesTextBox.Text = _student.Notes;
            activeCheckBox.Checked = _student.Active;

            foreach (var checkBox in courseCheckBoxes)
            {
                if (_student.Courses.Contains(checkBox.Tag.ToString()))
                {
                    checkBox.Checked = true;
                }
            }
        }

        private void LoadCourses()
        {
            var courses = DataManager.Courses.Where(c => c.Active).ToList();
            int yPos = 0;
            foreach (var course in courses)
            {
                var checkBox = new CheckBox
                {
                    Text = course.Name,
                    Tag = course.Id,
                    AutoSize = true,
                    Location = new System.Drawing.Point(0, yPos)
                };
                coursesPanel.Controls.Add(checkBox);
                courseCheckBoxes.Add(checkBox);
                yPos += checkBox.Height;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            _student.Name = studentNameTextBox.Text;
            _student.Tc = tcTextBox.Text;
            _student.Birthdate = birthdatePicker.Value;
            _student.Phone = phoneTextBox.Text;
            _student.Email = emailTextBox.Text;
            _student.Address = addressTextBox.Text;
            _student.Guardian = guardianTextBox.Text;
            _student.Notes = notesTextBox.Text;
            _student.Active = activeCheckBox.Checked;
            _student.Courses = courseCheckBoxes.Where(cb => cb.Checked).Select(cb => cb.Tag.ToString()).ToList();

            if (_isNew)
            {
                DataManager.Students.Add(_student);
            }

            DataManager.SaveData();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

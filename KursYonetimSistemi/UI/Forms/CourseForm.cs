using System;
using System.Linq;
using System.Windows.Forms;
using KursYonetimSistemi.Models;
using KursYonetimSistemi.Services;

namespace KursYonetimSistemi.UI.Forms
{
    public partial class CourseForm : Form
    {
        private Course _course;
        private bool _isNew;

        public CourseForm(string courseId = null)
        {
            InitializeComponent();
            LoadCategories();

            if (courseId == null)
            {
                _isNew = true;
                _course = new Course();
                this.Text = "Yeni Kurs Ekle";
            }
            else
            {
                _isNew = false;
                _course = DataManager.Courses.FirstOrDefault(c => c.Id == courseId);
                this.Text = "Kurs Düzenle";
                PopulateForm();
            }
        }

        private void PopulateForm()
        {
            courseNameTextBox.Text = _course.Name;
            categoryComboBox.SelectedItem = _course.Category;
            durationNumericUpDown.Value = _course.Duration;
            capacityNumericUpDown.Value = _course.Capacity;
            startTimeMaskedTextBox.Text = _course.StartTime;
            endTimeMaskedTextBox.Text = _course.EndTime;
            ageGroupComboBox.SelectedItem = _course.AgeGroup;
            levelComboBox.SelectedItem = _course.Level;
            descriptionTextBox.Text = _course.Description;
            materialsTextBox.Text = _course.Materials;
            activeCheckBox.Checked = _course.Active;
        }

        private void LoadCategories()
        {
            categoryComboBox.DataSource = DataManager.Categories.ToList();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            _course.Name = courseNameTextBox.Text;
            _course.Category = categoryComboBox.SelectedItem.ToString();
            _course.Duration = (int)durationNumericUpDown.Value;
            _course.Capacity = (int)capacityNumericUpDown.Value;
            _course.StartTime = startTimeMaskedTextBox.Text;
            _course.EndTime = endTimeMaskedTextBox.Text;
            _course.AgeGroup = ageGroupComboBox.SelectedItem.ToString();
            _course.Level = levelComboBox.SelectedItem.ToString();
            _course.Description = descriptionTextBox.Text;
            _course.Materials = materialsTextBox.Text;
            _course.Active = activeCheckBox.Checked;

            if (_isNew)
            {
                DataManager.Courses.Add(_course);
            }

            DataManager.SaveData();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

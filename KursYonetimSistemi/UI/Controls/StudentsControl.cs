using System;
using System.Windows.Forms;
using KursYonetimSistemi.Models;
using KursYonetimSistemi.Services;
using System.Linq;
using System.Collections.Generic;

namespace KursYonetimSistemi.UI.Controls
{
    public partial class StudentsControl : UserControl
    {
        public StudentsControl()
        {
            InitializeComponent();
            LoadStudents();
            LoadCoursesFilter();
        }

        public void LoadStudents(string searchTerm = null, string courseId = null)
        {
            var students = DataManager.Students;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                students = students.Where(s => s.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || s.Tc.Contains(searchTerm));
            }

            if (!string.IsNullOrEmpty(courseId) && courseId != "")
            {
                students = students.Where(s => s.Courses.Contains(courseId));
            }

            var studentList = students.ToList().Select(s => new
            {
                s.Id,
                s.Name,
                s.Tc,
                s.Phone,
                Courses = string.Join(", ", s.Courses.Select(cId => DataManager.Courses.FirstOrDefault(c => c.Id == cId)?.Name ?? "")),
                s.RegistrationDate,
                Status = s.Active ? "Aktif" : "Pasif"
            }).ToList();

            studentsDataGridView.DataSource = studentList;
            studentsDataGridView.Columns["Id"].Visible = false;
        }

        private void LoadCoursesFilter()
        {
            var courses = new List<Course> { new Course { Id = "", Name = "Tüm Kurslar" } };
            courses.AddRange(DataManager.Courses.Where(c => c.Active));
            studentCourseComboBox.DataSource = courses;
            studentCourseComboBox.DisplayMember = "Name";
            studentCourseComboBox.ValueMember = "Id";
        }

        private void addStudentButton_Click(object sender, EventArgs e)
        {
            using (var form = new Forms.StudentForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadStudents(searchTextBox.Text, studentCourseComboBox.SelectedValue?.ToString());
                }
            }
        }

        private void studentsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var studentId = studentsDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                if (studentsDataGridView.Columns[e.ColumnIndex].Name == "EditButton")
                {
                    using (var form = new Forms.StudentForm(studentId))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            LoadStudents(searchTextBox.Text, studentCourseComboBox.SelectedValue?.ToString());
                        }
                    }
                }
                else if (studentsDataGridView.Columns[e.ColumnIndex].Name == "DeleteButton")
                {
                    if (MessageBox.Show("Bu öğrenciyi silmek istediğinizden emin misiniz?", "Öğrenciyi Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        var student = DataManager.Students.FirstOrDefault(s => s.Id == studentId);
                        if (student != null)
                        {
                            DataManager.Students.Remove(student);
                            DataManager.SaveData();
                            LoadStudents(searchTextBox.Text, studentCourseComboBox.SelectedValue?.ToString());
                        }
                    }
                }
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void studentCourseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            var searchTerm = searchTextBox.Text;
            var courseId = studentCourseComboBox.SelectedValue?.ToString();
            LoadStudents(searchTerm, courseId);
        }
    }
}

using System;
using System.Windows.Forms;
using KursYonetimSistemi.Models;
using KursYonetimSistemi.Services;
using System.Linq;
using System.Collections.Generic;

namespace KursYonetimSistemi.UI.Controls
{
    public partial class CoursesControl : UserControl
    {
        public CoursesControl()
        {
            InitializeComponent();
            LoadCourses();
            LoadCategories();
        }

        public void LoadCourses(string searchTerm = null, string category = null)
        {
            var courses = DataManager.Courses;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                courses = courses.Where(c => c.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(category) && category != "Tüm Kategoriler")
            {
                courses = courses.Where(c => c.Category == category);
            }

            var courseList = courses.Select(c => new
            {
                c.Id,
                c.Name,
                c.Category,
                c.Duration,
                c.Capacity,
                Enrolled = DataManager.Students.Count(s => s.Courses.Contains(c.Id)),
                Status = c.Active ? "Aktif" : "Pasif"
            }).ToList();

            coursesDataGridView.DataSource = courseList;
            coursesDataGridView.Columns["Id"].Visible = false;
        }

        private void LoadCategories()
        {
            var categories = new List<string> { "Tüm Kategoriler" };
            categories.AddRange(DataManager.Categories);
            categoryComboBox.DataSource = categories;
        }

        private void addCourseButton_Click(object sender, EventArgs e)
        {
            using (var form = new Forms.CourseForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadCourses(searchTextBox.Text, categoryComboBox.SelectedItem.ToString());
                }
            }
        }

        private void coursesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var courseId = coursesDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                if (coursesDataGridView.Columns[e.ColumnIndex].Name == "EditButton")
                {
                    using (var form = new Forms.CourseForm(courseId))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            LoadCourses(searchTextBox.Text, categoryComboBox.SelectedItem.ToString());
                        }
                    }
                }
                else if (coursesDataGridView.Columns[e.ColumnIndex].Name == "DeleteButton")
                {
                    if (DataManager.Students.Any(s => s.Courses.Contains(courseId)) || DataManager.Schedules.Any(s => s.CourseId == courseId))
                    {
                        MessageBox.Show("Bu kursa kayıtlı öğrenciler veya ders programında dersler bulunmaktadır. Lütfen önce bu kayıtları silin.", "Silme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (MessageBox.Show("Bu kursu silmek istediğinizden emin misiniz?", "Kursu Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        var course = DataManager.Courses.FirstOrDefault(c => c.Id == courseId);
                        if (course != null)
                        {
                            DataManager.Courses.Remove(course);
                            DataManager.SaveData();
                            LoadCourses(searchTextBox.Text, categoryComboBox.SelectedItem.ToString());
                        }
                    }
                }
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            var searchTerm = searchTextBox.Text;
            var category = categoryComboBox.SelectedItem.ToString();
            LoadCourses(searchTerm, category);
        }
    }
}

using System;
using System.Windows.Forms;
using KursYonetimSistemi.Models;
using KursYonetimSistemi.Services;
using System.Linq;

namespace KursYonetimSistemi.UI.Controls
{
    public partial class TeachersControl : UserControl
    {
        public TeachersControl()
        {
            InitializeComponent();
            LoadTeachers();
        }

        public void LoadTeachers(string searchTerm = null)
        {
            var teachers = DataManager.Teachers.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                teachers = teachers.Where(t => t.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || t.Branch.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
            }

            var teacherList = teachers.Select(t => new
            {
                t.Id,
                t.Name,
                t.Branch,
                t.Phone,
                t.Email,
                LessonCount = DataManager.Schedules.Count(s => s.TeacherId == t.Id),
                Status = t.Active ? "Aktif" : "Pasif"
            }).ToList();

            teachersDataGridView.DataSource = teacherList;
            teachersDataGridView.Columns["Id"].Visible = false;
        }

        private void addTeacherButton_Click(object sender, EventArgs e)
        {
            using (var form = new Forms.TeacherForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadTeachers(searchTextBox.Text);
                }
            }
        }

        private void teachersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var teacherId = teachersDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                if (teachersDataGridView.Columns[e.ColumnIndex].Name == "EditButton")
                {
                    using (var form = new Forms.TeacherForm(teacherId))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            LoadTeachers(searchTextBox.Text);
                        }
                    }
                }
                else if (teachersDataGridView.Columns[e.ColumnIndex].Name == "DeleteButton")
                {
                    if (DataManager.Schedules.Any(s => s.TeacherId == teacherId))
                    {
                        MessageBox.Show("Bu eğitmenin ders programında dersleri bulunmaktadır. Lütfen önce bu dersleri silin.", "Silme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (MessageBox.Show("Bu eğitmeni silmek istediğinizden emin misiniz?", "Eğitmeni Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        var teacher = DataManager.Teachers.FirstOrDefault(t => t.Id == teacherId);
                        if (teacher != null)
                        {
                            DataManager.Teachers.Remove(teacher);
                            DataManager.SaveData();
                            LoadTeachers(searchTextBox.Text);
                        }
                    }
                }
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            LoadTeachers(searchTextBox.Text);
        }
    }
}

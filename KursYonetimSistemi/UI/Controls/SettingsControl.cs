using System;
using System.Windows.Forms;
using KursYonetimSistemi.Services;
using System.Linq;

namespace KursYonetimSistemi.UI.Controls
{
    public partial class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            InitializeComponent();
            LoadSettings();
            LoadCategories();
        }

        private void LoadSettings()
        {
            orgNameTextBox.Text = DataManager.Settings.OrgName;
            foreach (RadioButton rb in themeLayoutPanel.Controls)
            {
                if (rb.Tag.ToString() == DataManager.Settings.PrimaryColor)
                {
                    rb.Checked = true;
                    break;
                }
            }
            startTimeMaskedTextBox.Text = DataManager.Settings.StartTime;
            endTimeMaskedTextBox.Text = DataManager.Settings.EndTime;
            lessonDurationNumericUpDown.Value = DataManager.Settings.LessonDuration;
            breakDurationNumericUpDown.Value = DataManager.Settings.BreakDuration;
            weekendOffCheckBox.Checked = DataManager.Settings.WeekendOff;
        }

        private void LoadCategories()
        {
            categoriesListBox.DataSource = null;
            categoriesListBox.DataSource = DataManager.Categories;
        }

        private void saveSettingsButton_Click(object sender, EventArgs e)
        {
            DataManager.Settings.OrgName = orgNameTextBox.Text;
            foreach (RadioButton rb in themeLayoutPanel.Controls)
            {
                if (rb.Checked)
                {
                    DataManager.Settings.PrimaryColor = rb.Tag.ToString();
                    break;
                }
            }
            DataManager.Settings.StartTime = startTimeMaskedTextBox.Text;
            DataManager.Settings.EndTime = endTimeMaskedTextBox.Text;
            DataManager.Settings.LessonDuration = (int)lessonDurationNumericUpDown.Value;
            DataManager.Settings.BreakDuration = (int)breakDurationNumericUpDown.Value;
            DataManager.Settings.WeekendOff = weekendOffCheckBox.Checked;
            DataManager.SaveData();
            ThemeManager.ApplyTheme(this.ParentForm);
            MessageBox.Show("Ayarlar kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "JSON Dosyaları (*.json)|*.json";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    DataManager.ExportBackup(sfd.FileName);
                    MessageBox.Show("Veriler dışa aktarıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "JSON Dosyaları (*.json)|*.json";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    DataManager.ImportBackup(ofd.FileName);
                    MessageBox.Show("Veriler içe aktarıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh all data views
                    var mainForm = this.ParentForm as Forms.MainForm;
                    if (mainForm != null)
                    {
                        var coursesControl = mainForm.Controls.Find("coursesControl", true).FirstOrDefault() as CoursesControl;
                        coursesControl?.LoadCourses();

                        var studentsControl = mainForm.Controls.Find("studentsControl", true).FirstOrDefault() as StudentsControl;
                        studentsControl?.LoadStudents();

                        var teachersControl = mainForm.Controls.Find("teachersControl", true).FirstOrDefault() as TeachersControl;
                        teachersControl?.LoadTeachers();

                        var workshopsControl = mainForm.Controls.Find("workshopsControl", true).FirstOrDefault() as WorkshopsControl;
                        workshopsControl?.LoadWorkshops();

                        var holidaysControl = mainForm.Controls.Find("holidaysControl", true).FirstOrDefault() as HolidaysControl;
                        holidaysControl?.LoadHolidays();

                        var scheduleControl = mainForm.Controls.Find("scheduleControl", true).FirstOrDefault() as ScheduleControl;
                        scheduleControl?.RenderCalendar();

                        var dashboardControl = mainForm.Controls.Find("dashboardControl", true).FirstOrDefault() as DashboardControl;
                        dashboardControl?.UpdateDashboard();
                    }
                }
            }
        }

        private void clearDataButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("TÜM VERİLER SİLİNECEK! Bu işlem geri alınamaz. Devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (MessageBox.Show("Emin misiniz? Tüm kurslar, öğrenciler, eğitmenler ve programlar silinecek!", "Son Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    DataManager.Courses.Clear();
                    DataManager.Workshops.Clear();
                    DataManager.Teachers.Clear();
                    DataManager.Students.Clear();
                    DataManager.Schedules.Clear();
                    DataManager.Holidays.Clear();
                    DataManager.Categories.Clear();
                    DataManager.SaveData();
                    MessageBox.Show("Tüm veriler silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void addCategoryButton_Click(object sender, EventArgs e)
        {
            var newCategory = newCategoryTextBox.Text;
            if (!string.IsNullOrEmpty(newCategory))
            {
                DataManager.Categories.Add(newCategory);
                DataManager.SaveData();
                LoadCategories();
                newCategoryTextBox.Clear();
            }
        }

        private void deleteCategoryButton_Click(object sender, EventArgs e)
        {
            var selectedCategory = categoriesListBox.SelectedItem as string;
            if (selectedCategory != null)
            {
                DataManager.Categories.Remove(selectedCategory);
                DataManager.SaveData();
                LoadCategories();
            }
        }
    }
}

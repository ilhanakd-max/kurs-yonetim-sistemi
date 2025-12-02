using System;
using System.Linq;
using System.Windows.Forms;
using KursYonetimSistemi.Models;
using KursYonetimSistemi.Services;

namespace KursYonetimSistemi.UI.Forms
{
    public partial class ScheduleForm : Form
    {
        private Schedule _schedule;
        private bool _isNew;

        public ScheduleForm(string scheduleId = null)
        {
            InitializeComponent();
            LoadCourses();
            LoadTeachers();
            LoadWorkshops();

            if (scheduleId == null)
            {
                _isNew = true;
                _schedule = new Schedule();
                this.Text = "Yeni Ders Ekle";
            }
            else
            {
                _isNew = false;
                _schedule = DataManager.Schedules.FirstOrDefault(s => s.Id == scheduleId);
                this.Text = "Ders Düzenle";
                PopulateForm();
            }
        }

        private void PopulateForm()
        {
            courseComboBox.SelectedValue = _schedule.CourseId;
            teacherComboBox.SelectedValue = _schedule.TeacherId;
            workshopComboBox.SelectedValue = _schedule.WorkshopId;
            dayComboBox.SelectedItem = _schedule.Day.ToString();
            startTimeMaskedTextBox.Text = _schedule.StartTime;
            endTimeMaskedTextBox.Text = _schedule.EndTime;
            if (_schedule.StartDate.HasValue) startDatePicker.Value = _schedule.StartDate.Value;
            if (_schedule.EndDate.HasValue) endDatePicker.Value = _schedule.EndDate.Value;
            notesTextBox.Text = _schedule.Notes;
            activeCheckBox.Checked = _schedule.Active;
        }

        private void LoadCourses()
        {
            courseComboBox.DataSource = DataManager.Courses.Where(c => c.Active).ToList();
            courseComboBox.DisplayMember = "Name";
            courseComboBox.ValueMember = "Id";
        }

        private void LoadTeachers()
        {
            teacherComboBox.DataSource = DataManager.Teachers.Where(t => t.Active).ToList();
            teacherComboBox.DisplayMember = "Name";
            teacherComboBox.ValueMember = "Id";
        }

        private void LoadWorkshops()
        {
            workshopComboBox.DataSource = DataManager.Workshops.Where(w => w.Active).ToList();
            workshopComboBox.DisplayMember = "Name";
            workshopComboBox.ValueMember = "Id";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!TimeSpan.TryParse(startTimeMaskedTextBox.Text, out var startTime) || !TimeSpan.TryParse(endTimeMaskedTextBox.Text, out var endTime))
            {
                MessageBox.Show("Lütfen geçerli bir başlangıç ve bitiş saati girin.", "Geçersiz Saat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _schedule.CourseId = courseComboBox.SelectedValue.ToString();
            _schedule.TeacherId = teacherComboBox.SelectedValue.ToString();
            _schedule.WorkshopId = workshopComboBox.SelectedValue.ToString();
            _schedule.Day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), dayComboBox.SelectedItem.ToString());
            _schedule.StartTime = startTimeMaskedTextBox.Text;
            _schedule.EndTime = endTimeMaskedTextBox.Text;
            _schedule.StartDate = startDatePicker.Value;
            _schedule.EndDate = endDatePicker.Value;
            _schedule.Notes = notesTextBox.Text;
            _schedule.Active = activeCheckBox.Checked;

            // Conflict detection
            var conflictingSchedule = DataManager.Schedules.FirstOrDefault(s =>
                s.Id != _schedule.Id &&
                s.Day == _schedule.Day &&
                s.WorkshopId == _schedule.WorkshopId &&
                ((TimeSpan.Parse(s.StartTime) < endTime && TimeSpan.Parse(s.EndTime) > startTime) ||
                (startTime < TimeSpan.Parse(s.EndTime) && endTime > TimeSpan.Parse(s.StartTime)))
            );

            if (conflictingSchedule != null)
            {
                MessageBox.Show("Bu atölyede, belirtilen saatte başka bir ders bulunmaktadır.", "Çakışma", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            conflictingSchedule = DataManager.Schedules.FirstOrDefault(s =>
                s.Id != _schedule.Id &&
                s.Day == _schedule.Day &&
                s.TeacherId == _schedule.TeacherId &&
                ((TimeSpan.Parse(s.StartTime) < endTime && TimeSpan.Parse(s.EndTime) > startTime) ||
                (startTime < TimeSpan.Parse(s.EndTime) && endTime > TimeSpan.Parse(s.StartTime)))
            );

            if (conflictingSchedule != null)
            {
                MessageBox.Show("Bu eğitmenin, belirtilen saatte başka bir dersi bulunmaktadır.", "Çakışma", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_isNew)
            {
                DataManager.Schedules.Add(_schedule);
            }

            DataManager.SaveData();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

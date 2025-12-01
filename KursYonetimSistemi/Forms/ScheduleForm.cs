using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace KursYonetimSistemi.Forms
{
    public partial class ScheduleForm : Form
    {
        public ScheduleItem ScheduleItem { get; private set; }
        private readonly List<Course> _courses;
        private readonly List<Teacher> _teachers;
        private readonly List<Workshop> _workshops;

        public ScheduleForm(ScheduleItem item, List<Course> courses, List<Teacher> teachers, List<Workshop> workshops)
        {
            InitializeComponent();
            ScheduleItem = item ?? new ScheduleItem();
            _courses = courses;
            _teachers = teachers;
            _workshops = workshops;

            LoadComboBoxes();
            BindData();
        }

        private void LoadComboBoxes()
        {
            cmbCourse.DataSource = _courses.Where(c => c.IsActive).ToList();
            cmbCourse.DisplayMember = "Name";
            cmbCourse.ValueMember = "Id";

            cmbTeacher.DataSource = _teachers.Where(t => t.IsActive).ToList();
            cmbTeacher.DisplayMember = "Name";
            cmbTeacher.ValueMember = "Id";

            cmbWorkshop.DataSource = _workshops.Where(w => w.IsActive).ToList();
            cmbWorkshop.DisplayMember = "Name";
            cmbWorkshop.ValueMember = "Id";

            cmbDay.DataSource = Enum.GetValues(typeof(DayOfWeek));
        }

        private void BindData()
        {
            if (ScheduleItem.Id != Guid.Empty)
            {
                cmbCourse.SelectedValue = ScheduleItem.CourseId;
                cmbTeacher.SelectedValue = ScheduleItem.TeacherId;
                cmbWorkshop.SelectedValue = ScheduleItem.WorkshopId;
                cmbDay.SelectedItem = ScheduleItem.Day;
                dtpStartTime.Value = DateTime.Today + ScheduleItem.StartTime;
                dtpEndTime.Value = DateTime.Today + ScheduleItem.EndTime;
                chkIsActive.Checked = ScheduleItem.IsActive;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ScheduleItem.CourseId = (Guid)cmbCourse.SelectedValue;
            ScheduleItem.TeacherId = (Guid)cmbTeacher.SelectedValue;
            ScheduleItem.WorkshopId = (Guid)cmbWorkshop.SelectedValue;
            ScheduleItem.Day = (DayOfWeek)cmbDay.SelectedValue;
            ScheduleItem.StartTime = dtpStartTime.Value.TimeOfDay;
            ScheduleItem.EndTime = dtpEndTime.Value.TimeOfDay;
            ScheduleItem.IsActive = chkIsActive.Checked;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

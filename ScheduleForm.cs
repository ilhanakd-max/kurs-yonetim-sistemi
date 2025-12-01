using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace KursYonetimSistemi
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

    // Designer partial class
    public partial class ScheduleForm
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cmbCourse;
        private ComboBox cmbTeacher;
        private ComboBox cmbWorkshop;
        private ComboBox cmbDay;
        private DateTimePicker dtpStartTime;
        private DateTimePicker dtpEndTime;
        private CheckBox chkIsActive;
        private Button btnSave;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbCourse = new System.Windows.Forms.ComboBox();
            this.cmbTeacher = new System.Windows.Forms.ComboBox();
            this.cmbWorkshop = new System.Windows.Forms.ComboBox();
            this.cmbDay = new System.Windows.Forms.ComboBox();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            // ... Add labels for each control
            this.SuspendLayout();

            // cmbCourse
            this.cmbCourse.FormattingEnabled = true;
            this.cmbCourse.Location = new System.Drawing.Point(130, 12);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(200, 23);

            // cmbTeacher
            this.cmbTeacher.FormattingEnabled = true;
            this.cmbTeacher.Location = new System.Drawing.Point(130, 41);
            this.cmbTeacher.Name = "cmbTeacher";
            this.cmbTeacher.Size = new System.Drawing.Size(200, 23);

            // cmbWorkshop
            this.cmbWorkshop.FormattingEnabled = true;
            this.cmbWorkshop.Location = new System.Drawing.Point(130, 70);
            this.cmbWorkshop.Name = "cmbWorkshop";
            this.cmbWorkshop.Size = new System.Drawing.Size(200, 23);

            // cmbDay
            this.cmbDay.FormattingEnabled = true;
            this.cmbDay.Location = new System.Drawing.Point(130, 99);
            this.cmbDay.Name = "cmbDay";
            this.cmbDay.Size = new System.Drawing.Size(200, 23);

            // dtpStartTime
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartTime.Location = new System.Drawing.Point(130, 128);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;

            // dtpEndTime
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndTime.Location = new System.Drawing.Point(130, 157);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;

            // chkIsActive
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.Location = new System.Drawing.Point(130, 186);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Text = "Aktif";

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(174, 226);
            this.btnSave.Name = "btnSave";
            this.btnSave.Text = "Kaydet";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(255, 226);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Text = "İptal";

            // Add Labels
            this.Controls.Add(new Label { Text = "Kurs", Location = new System.Drawing.Point(12, 15) });
            this.Controls.Add(new Label { Text = "Eğitmen", Location = new System.Drawing.Point(12, 44) });
            this.Controls.Add(new Label { Text = "Atölye", Location = new System.Drawing.Point(12, 73) });
            this.Controls.Add(new Label { Text = "Gün", Location = new System.Drawing.Point(12, 102) });
            this.Controls.Add(new Label { Text = "Başlangıç Saati", Location = new System.Drawing.Point(12, 131) });
            this.Controls.Add(new Label { Text = "Bitiş Saati", Location = new System.Drawing.Point(12, 160) });

            // Form
            this.ClientSize = new System.Drawing.Size(350, 270);
            this.Controls.Add(this.cmbCourse);
            this.Controls.Add(this.cmbTeacher);
            this.Controls.Add(this.cmbWorkshop);
            this.Controls.Add(this.cmbDay);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Name = "ScheduleForm";
            this.Text = "Ders Planla";
            this.ResumeLayout(false);
        }
    }
}

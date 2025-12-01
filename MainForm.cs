using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KursYonetimSistemi
{
    public partial class MainForm : Form
    {
        private readonly DataManager _dataManager;
        private readonly ReportManager _reportManager;

        public MainForm()
        {
            InitializeComponent();
            _dataManager = new DataManager();
            _reportManager = new ReportManager(_dataManager.Data);
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetupEventHandlers();
            RefreshAllDataViews();
        }

        private void SetupEventHandlers()
        {
            tabControlMain.SelectedIndexChanged += (s, e) => RefreshAllDataViews();
            btnNewCourse.Click += (s, e) => EditCourse(null);
            btnEditCourse.Click += (s, e) => {
                if (dataGridViewCourses.CurrentRow?.DataBoundItem is Course course) EditCourse(course);
            };
            btnDeleteCourse.Click += (s, e) => {
                if (dataGridViewCourses.CurrentRow?.DataBoundItem is Course course) DeleteEntity(course, "kursu", _dataManager.Data.Courses);
            };
            btnNewWorkshop.Click += (s, e) => EditWorkshop(null);
            btnEditWorkshop.Click += (s, e) => {
                if (dataGridViewWorkshops.CurrentRow?.DataBoundItem is Workshop workshop) EditWorkshop(workshop);
            };
            btnDeleteWorkshop.Click += (s, e) => {
                 if (dataGridViewWorkshops.CurrentRow?.DataBoundItem is Workshop workshop) DeleteEntity(workshop, "atölyeyi", _dataManager.Data.Workshops);
            };
            btnNewTeacher.Click += (s, e) => EditTeacher(null);
            btnEditTeacher.Click += (s, e) => {
                if (dataGridViewTeachers.CurrentRow?.DataBoundItem is Teacher teacher) EditTeacher(teacher);
            };
            btnDeleteTeacher.Click += (s, e) => {
                 if (dataGridViewTeachers.CurrentRow?.DataBoundItem is Teacher teacher) DeleteEntity(teacher, "eğitmeni", _dataManager.Data.Teachers);
            };
            btnNewStudent.Click += (s, e) => EditStudent(null);
            btnEditStudent.Click += (s, e) => {
                 if (dataGridViewStudents.CurrentRow?.DataBoundItem is Student student) EditStudent(student);
            };
            btnDeleteStudent.Click += (s, e) => {
                if (dataGridViewStudents.CurrentRow?.DataBoundItem is Student student) DeleteEntity(student, "öğrenciyi", _dataManager.Data.Students);
            };
            btnNewLesson.Click += (s, e) => EditScheduleItem(null);
            btnBackupData.Click += BtnBackupData_Click;
            btnRestoreData.Click += BtnRestoreData_Click;
            btnExportCourses.Click += (s, e) => _reportManager.ExportCoursesToCsv();
            btnExportWorkshops.Click += (s, e) => _reportManager.ExportWorkshopsToCsv();
            btnExportTeachers.Click += (s, e) => _reportManager.ExportTeachersToCsv();
            btnExportStudents.Click += (s, e) => _reportManager.ExportStudentsToCsv();
        }

        private void RefreshAllDataViews()
        {
            RefreshDashboard();
            RefreshDataGridView(dataGridViewCourses, _dataManager.Data.Courses);
            RefreshDataGridView(dataGridViewWorkshops, _dataManager.Data.Workshops);
            RefreshDataGridView(dataGridViewTeachers, _dataManager.Data.Teachers);
            RefreshDataGridView(dataGridViewStudents, _dataManager.Data.Students);
            RefreshScheduleView();
        }

        private void RefreshDashboard()
        {
            lblStatTotalCourses.Text = $"Toplam Kurs: {_dataManager.Data.Courses.Count}";
            lblStatTotalWorkshops.Text = $"Toplam Atölye: {_dataManager.Data.Workshops.Count}";
            lblStatTotalTeachers.Text = $"Toplam Eğitmen: {_dataManager.Data.Teachers.Count}";
            lblStatTotalStudents.Text = $"Toplam Öğrenci: {_dataManager.Data.Students.Count}";

            flowLayoutPanelTodayLessons.Controls.Clear();
            var today = DateTime.Now.DayOfWeek;
            var todaysLessons = _dataManager.Data.Schedule.Where(s => s.Day == today && s.IsActive).OrderBy(s => s.StartTime);
            foreach (var lesson in todaysLessons)
            {
                var course = _dataManager.Data.Courses.FirstOrDefault(c => c.Id == lesson.CourseId);
                var teacher = _dataManager.Data.Teachers.FirstOrDefault(t => t.Id == lesson.TeacherId);
                var workshop = _dataManager.Data.Workshops.FirstOrDefault(w => w.Id == lesson.WorkshopId);
                var lessonLabel = new Label {
                    Text = $"{lesson.StartTime:hh\\:mm} - {lesson.EndTime:hh\\:mm}: {course?.Name} ({teacher?.Name}) - {workshop?.Name}",
                    AutoSize = true, Margin = new Padding(3), Font = new Font("Segoe UI", 11)
                };
                flowLayoutPanelTodayLessons.Controls.Add(lessonLabel);
            }
        }

        private void RefreshDataGridView<T>(DataGridView dgv, object dataSource)
        {
            var bs = new BindingSource { DataSource = dataSource };
            dgv.DataSource = bs;
            if (dgv.Columns["Id"] != null) dgv.Columns["Id"].Visible = false;
        }

        private void RefreshScheduleView()
        {
            tableLayoutPanelSchedule.SuspendLayout();
            tableLayoutPanelSchedule.Controls.Clear();
            tableLayoutPanelSchedule.ColumnStyles.Clear();
            tableLayoutPanelSchedule.RowStyles.Clear();

            // Setup columns
            tableLayoutPanelSchedule.ColumnCount = 8;
            tableLayoutPanelSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F)); // Time
            string[] days = { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi", "Pazar" };
            for (int i = 0; i < 7; i++)
            {
                tableLayoutPanelSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28f));
                var lblDay = new Label { Text = days[i], TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill, Font = new Font(this.Font, FontStyle.Bold) };
                tableLayoutPanelSchedule.Controls.Add(lblDay, i + 1, 0);
            }

            // Setup rows for hours
            var startTime = _dataManager.Data.Settings.CalismaBaslangic;
            var endTime = _dataManager.Data.Settings.CalismaBitis;
            var lessonDuration = _dataManager.Data.Settings.DersSuresi;

            int rowCount = 0;
            for (TimeSpan time = startTime; time < endTime; time = time.Add(TimeSpan.FromMinutes(lessonDuration)))
            {
                rowCount++;
                tableLayoutPanelSchedule.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
                var lblTime = new Label { Text = time.ToString(@"hh\:mm"), TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill };
                tableLayoutPanelSchedule.Controls.Add(lblTime, 0, rowCount);
            }
            tableLayoutPanelSchedule.RowCount = rowCount + 1;

            // Populate schedule
            foreach(var item in _dataManager.Data.Schedule.Where(s => s.IsActive))
            {
                int col = item.Day == DayOfWeek.Sunday ? 7 : (int)item.Day;

                int row = (int)((item.StartTime - startTime).TotalMinutes / lessonDuration) + 1;

                var course = _dataManager.Data.Courses.FirstOrDefault(c => c.Id == item.CourseId);
                var workshop = _dataManager.Data.Workshops.FirstOrDefault(w => w.Id == item.WorkshopId);

                if (row > 0 && row < tableLayoutPanelSchedule.RowCount)
                {
                    var btn = new Button
                    {
                        Text = course?.Name,
                        Dock = DockStyle.Fill,
                        Tag = item,
                        BackColor = ColorTranslator.FromHtml(workshop?.ColorHex ?? "#FFFFFF"),
                        ForeColor = Color.White
                    };
                    btn.Click += (s, e) => EditScheduleItem((s as Button).Tag as ScheduleItem);

                    int durationInMinutes = (int)(item.EndTime - item.StartTime).TotalMinutes;
                    int rowSpan = durationInMinutes / lessonDuration;

                    tableLayoutPanelSchedule.Controls.Add(btn, col, row);
                    if (rowSpan > 1)
                    {
                        tableLayoutPanelSchedule.SetRowSpan(btn, rowSpan);
                    }
                }
            }

            tableLayoutPanelSchedule.ResumeLayout();
        }

        private void EditCourse(Course course)
        {
            using (var form = new EntityForm<Course>(course))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (course == null) _dataManager.Data.Courses.Add(form.Entity);
                    _dataManager.SaveData();
                    RefreshAllDataViews();
                }
            }
        }

        private void EditWorkshop(Workshop workshop)
        {
            using (var form = new EntityForm<Workshop>(workshop))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (workshop == null) _dataManager.Data.Workshops.Add(form.Entity);
                    _dataManager.SaveData();
                    RefreshAllDataViews();
                }
            }
        }

        private void EditTeacher(Teacher teacher)
        {
            using (var form = new EntityForm<Teacher>(teacher))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (teacher == null) _dataManager.Data.Teachers.Add(form.Entity);
                    _dataManager.SaveData();
                    RefreshAllDataViews();
                }
            }
        }

        private void EditStudent(Student student)
        {
             using (var form = new EntityForm<Student>(student))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (student == null) _dataManager.Data.Students.Add(form.Entity);
                    _dataManager.SaveData();
                    RefreshAllDataViews();
                }
            }
        }

        private void EditScheduleItem(ScheduleItem item)
        {
            using (var form = new ScheduleForm(item, _dataManager.Data.Courses, _dataManager.Data.Teachers, _dataManager.Data.Workshops))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var conflict = _dataManager.CheckConflict(form.ScheduleItem);
                    if (conflict != null)
                    {
                        MessageBox.Show(conflict, "Çakışma Tespit Edildi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (item == null) _dataManager.Data.Schedule.Add(form.ScheduleItem);
                    _dataManager.SaveData();
                    RefreshAllDataViews();
                }
            }
        }

        private void DeleteEntity<T>(T entity, string entityName, System.Collections.Generic.List<T> entityList)
        {
            if (MessageBox.Show($"Bu {entityName} silmek istediğinizden emin misiniz?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                entityList.Remove(entity);
                _dataManager.SaveData();
                RefreshAllDataViews();
            }
        }

        private void BtnBackupData_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog { Filter = "JSON Dosyası|*.json", Title = "Veri Yedeği Oluştur" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    _dataManager.ExportBackup(sfd.FileName);
                    MessageBox.Show("Veriler başarıyla dışa aktarıldı!");
                }
            }
        }

        private void BtnRestoreData_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Mevcut verileriniz silinecek ve yedekten gelen veriler yüklenecektir. Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var ofd = new OpenFileDialog { Filter = "JSON Dosyası|*.json", Title = "Veri Yedeğini Geri Yükle" })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        _dataManager.ImportBackup(ofd.FileName);
                        RefreshAllDataViews();
                        MessageBox.Show("Veriler başarıyla içe aktarıldı!");
                    }
                }
            }
        }
    }
}

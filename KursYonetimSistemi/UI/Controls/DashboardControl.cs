using System.Windows.Forms;
using KursYonetimSistemi.Services;
using System.Linq;

namespace KursYonetimSistemi.UI.Controls
{
    public partial class DashboardControl : UserControl
    {
        public DashboardControl()
        {
            InitializeComponent();
            UpdateDashboard();
        }

        public void UpdateDashboard()
        {
            totalCoursesLabel.Text = $"Aktif Kurs: {DataManager.Courses.Count(c => c.Active)}";
            UpdateLiveLessonPanel();
            totalWorkshopsLabel.Text = $"Atölye: {DataManager.Workshops.Count(w => w.Active)}";
            totalTeachersLabel.Text = $"Eğitmen: {DataManager.Teachers.Count(t => t.Active)}";
            totalStudentsLabel.Text = $"Öğrenci: {DataManager.Students.Count(s => s.Active)}";
            weeklyLessonsLabel.Text = $"Haftalık Ders: {DataManager.Schedules.Count(s => s.Active)}";
            upcomingHolidaysLabel.Text = $"Yaklaşan Tatil: {DataManager.Holidays.Count(h => h.StartDate >= System.DateTime.Today)}";
        }

        private void UpdateLiveLessonPanel()
        {
            liveLessonPanel.Controls.Clear();
            var now = DateTime.Now;
            var today = now.DayOfWeek;
            var upcomingLessons = DataManager.Schedules
                .Where(s => s.Day == today && s.StartDate <= now && s.EndDate >= now)
                .OrderBy(s => s.StartTime)
                .ToList();

            int yPos = 10;
            foreach (var lesson in upcomingLessons)
            {
                var course = DataManager.Courses.FirstOrDefault(c => c.Id == lesson.CourseId);
                var label = new Label
                {
                    Text = $"{lesson.StartTime} - {lesson.EndTime}: {course?.Name}",
                    Location = new System.Drawing.Point(10, yPos),
                    AutoSize = true
                };

                if (TimeSpan.Parse(lesson.StartTime) <= now.TimeOfDay && TimeSpan.Parse(lesson.EndTime) >= now.TimeOfDay)
                {
                    label.Font = new System.Drawing.Font(label.Font, System.Drawing.FontStyle.Bold);
                }

                liveLessonPanel.Controls.Add(label);
                yPos += 20;
            }
        }
    }
}

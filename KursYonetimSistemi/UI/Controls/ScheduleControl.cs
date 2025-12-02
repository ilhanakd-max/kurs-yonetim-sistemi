using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using KursYonetimSistemi.Models;
using KursYonetimSistemi.Services;

namespace KursYonetimSistemi.UI.Controls
{
    public partial class ScheduleControl : UserControl
    {
        private DateTime _currentDate = DateTime.Today;
        private TableLayoutPanel calendarGrid;
        private bool _isWeeklyView = false;

        public ScheduleControl()
        {
            InitializeComponent();
            InitializeCalendarGrid();
            RenderCalendar();
            LoadFilters();
        }

        private void InitializeCalendarGrid()
        {
            calendarGrid = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 6,
                ColumnCount = 7
            };

            for (int i = 0; i < 7; i++)
            {
                calendarGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 7));
            }
            for (int i = 0; i < 6; i++)
            {
                calendarGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / 6));
            }

            calendarPanel.Controls.Add(calendarGrid);
        }

        private void RenderCalendar()
        {
            if (_isWeeklyView)
            {
                RenderWeeklyView();
            }
            else
            {
                RenderMonthlyView();
            }
        }

        private void RenderMonthlyView()
        {
            monthLabel.Text = _currentDate.ToString("MMMM yyyy");
            calendarGrid.Visible = true;
            weeklyViewGrid.Visible = false;
            calendarGrid.Controls.Clear();

            var firstDayOfMonth = new DateTime(_currentDate.Year, _currentDate.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(_currentDate.Year, _currentDate.Month);
            int firstDayOfWeek = (int)firstDayOfMonth.DayOfWeek;

            int dayCounter = 1;
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    if (row == 0 && col < firstDayOfWeek)
                    {
                        calendarGrid.Controls.Add(new Panel(), col, row);
                    }
                    else if (dayCounter <= daysInMonth)
                    {
                        var dayControl = new CalendarDayControl();
                        var date = new DateTime(_currentDate.Year, _currentDate.Month, dayCounter);
                        dayControl.SetDay(dayCounter, false);

                        var schedules = DataManager.Schedules.Where(s => s.Day == (DayOfWeek)col && date >= s.StartDate && date <= s.EndDate).ToList();
                        foreach(var schedule in schedules)
                        {
                            var course = DataManager.Courses.FirstOrDefault(c => c.Id == schedule.CourseId);
                            dayControl.AddSchedule(course?.Name ?? "Bilinmeyen Kurs");
                        }

                        calendarGrid.Controls.Add(dayControl, col, row);
                        dayCounter++;
                    }
                    else
                    {
                        calendarGrid.Controls.Add(new Panel(), col, row);
                    }
                }
            }
        }

        private void RenderWeeklyView()
        {
            monthLabel.Text = $"Week of {_currentDate:d}";
            calendarGrid.Visible = false;
            weeklyViewGrid.Visible = true;
            weeklyViewGrid.Controls.Clear();

            // Simplified weekly view logic
            for (int day = 0; day < 7; day++)
            {
                var dayLabel = new Label { Text = ((DayOfWeek)day).ToString(), Dock = DockStyle.Fill };
                weeklyViewGrid.Controls.Add(dayLabel, day, 0);

                var schedules = DataManager.Schedules.Where(s => s.Day == (DayOfWeek)day).ToList();
                int row = 1;
                foreach(var schedule in schedules)
                {
                    var course = DataManager.Courses.FirstOrDefault(c => c.Id == schedule.CourseId);
                    var scheduleLabel = new Label { Text = $"{schedule.StartTime} {course?.Name}", Dock = DockStyle.Fill };
                    weeklyViewGrid.Controls.Add(scheduleLabel, day, row++);
                }
            }
        }

        private void LoadFilters()
        {
            // ... (existing code)
        }

        private void prevMonthButton_Click(object sender, EventArgs e)
        {
            _currentDate = _currentDate.AddMonths(-1);
            RenderCalendar();
        }

        private void nextMonthButton_Click(object sender, EventArgs e)
        {
            _currentDate = _currentDate.AddMonths(1);
            RenderCalendar();
        }

        private void addScheduleButton_Click(object sender, EventArgs e)
        {
            using (var form = new Forms.ScheduleForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    RenderCalendar();
                }
            }
        }

        private void toggleViewButton_Click(object sender, EventArgs e)
        {
            _isWeeklyView = !_isWeeklyView;
            toggleViewButton.Text = _isWeeklyView ? "Aylık Görünüm" : "Haftalık Görünüm";
            RenderCalendar();
        }
    }
}

using System;

namespace KursYonetimSistemi.Models
{
    public class Schedule
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CourseId { get; set; }
        public string TeacherId { get; set; }
        public string WorkshopId { get; set; }
        public DayOfWeek Day { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Notes { get; set; }
        public bool Active { get; set; } = true;
    }
}

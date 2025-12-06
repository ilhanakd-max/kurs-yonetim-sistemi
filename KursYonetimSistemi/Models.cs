using System;
using System.Collections.Generic;

namespace KursYonetimSistemi
{
    public class Course
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Category { get; set; }
        public int DurationWeeks { get; set; }
        public int Capacity { get; set; }
        public bool IsActive { get; set; } = true;
        public string AgeGroup { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public string Materials { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }

    public class Teacher
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Branch { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; } = true;
        public string TCKimlikNo { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
    }

    public class Student
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string TCKimlikNo { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public List<Guid> EnrolledCourseIds { get; set; } = new List<Guid>();
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public string GuardianInfo { get; set; }
        public string Notes { get; set; }
    }

    public class Workshop
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public string Equipment { get; set; }
        public bool IsActive { get; set; } = true;
        public string ColorHex { get; set; }
    }

    public class ScheduleItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CourseId { get; set; }
        public Guid TeacherId { get; set; }
        public Guid WorkshopId { get; set; }
        public DayOfWeek Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; } = true;
        public string Notes { get; set; }
    }

    public class Holiday
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsRecurring { get; set; }
        public string Description { get; set; }
    }

    public class AppData
    {
        public List<Course> Courses { get; set; } = new List<Course>();
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Workshop> Workshops { get; set; } = new List<Workshop>();
        public List<ScheduleItem> Schedule { get; set; } = new List<ScheduleItem>();
        public List<Holiday> Holidays { get; set; } = new List<Holiday>();
        public List<string> Categories { get; set; } = new List<string>();
        public Settings Settings { get; set; } = new Settings();
    }

    public class Settings
    {
        public string KurumAdi { get; set; } = "Çeşme Belediyesi Kültür Müdürlüğü";
        public TimeSpan CalismaBaslangic { get; set; } = new TimeSpan(9, 0, 0);
        public TimeSpan CalismaBitis { get; set; } = new TimeSpan(21, 0, 0);
        public int DersSuresi { get; set; } = 60;
        public int TeneffusSuresi { get; set; } = 15;
    }
}

namespace KursYonetimSistemi.Models
{
    public class Course
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Category { get; set; }
        public int Duration { get; set; } // in weeks
        public int Capacity { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string AgeGroup { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public string Materials { get; set; }
        public bool Active { get; set; } = true;
    }
}

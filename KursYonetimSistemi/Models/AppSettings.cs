namespace KursYonetimSistemi.Models
{
    public class AppSettings
    {
        public string OrgName { get; set; } = "Çeşme Belediyesi Kültür Müdürlüğü";
        public string StartTime { get; set; } = "09:00";
        public string EndTime { get; set; } = "21:00";
        public int LessonDuration { get; set; } = 60;
        public int BreakDuration { get; set; } = 15;
        public bool WeekendOff { get; set; } = true;
        public string PrimaryColor { get; set; } = "#1a5276";
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KursYonetimSistemi.Models
{
    public class Course
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Ad { get; set; } = string.Empty;
        public string Kategori { get; set; } = string.Empty;
        public string Seviye { get; set; } = "Başlangıç";
        public string Aciklama { get; set; } = string.Empty;
        public bool Aktif { get; set; } = true;
        public ObservableCollection<string> Etiketler { get; set; } = new();
    }

    public class Teacher
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Ad { get; set; } = string.Empty;
        public string Uzmanlik { get; set; } = string.Empty;
        public string Telefon { get; set; } = string.Empty;
        public string Eposta { get; set; } = string.Empty;
        public bool Aktif { get; set; } = true;
    }

    public class Student
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Ad { get; set; } = string.Empty;
        public string Telefon { get; set; } = string.Empty;
        public string Eposta { get; set; } = string.Empty;
        public string KursId { get; set; } = string.Empty;
        public bool Aktif { get; set; } = true;
        public string Notlar { get; set; } = string.Empty;
    }

    public class Workshop
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Ad { get; set; } = string.Empty;
        public int Kapasite { get; set; }
        public bool Aktif { get; set; } = true;
        public string Lokasyon { get; set; } = string.Empty;
    }

    public class Holiday
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Ad { get; set; } = string.Empty;
        public DateTime? Baslangic { get; set; }
        public DateTime? Bitis { get; set; }
        public bool Tekrarli { get; set; }
        public string Aciklama { get; set; } = string.Empty;
    }

    public class ScheduleEntry
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string KursId { get; set; } = string.Empty;
        public string OgretmenId { get; set; } = string.Empty;
        public string AtolyeId { get; set; } = string.Empty;
        public DayOfWeek Gun { get; set; }
        public TimeSpan BaslangicSaati { get; set; }
        public TimeSpan BitisSaati { get; set; }
        public bool Aktif { get; set; } = true;
        public string Notlar { get; set; } = string.Empty;
    }

    public class Setting
    {
        public string KurumAdi { get; set; } = "Çeşme Belediyesi Kültür Müdürlüğü";
        public TimeSpan MesaiBaslangic { get; set; } = TimeSpan.FromHours(9);
        public TimeSpan MesaiBitis { get; set; } = TimeSpan.FromHours(21);
        public int DersSuresiDakika { get; set; } = 60;
        public int AraSuresiDakika { get; set; } = 15;
        public bool HaftaSonuKapali { get; set; } = true;
        public string TemaRengi { get; set; } = "#1a5276";
    }

    public class BackupPackage
    {
        public List<Course> Courses { get; set; } = new();
        public List<Teacher> Teachers { get; set; } = new();
        public List<Student> Students { get; set; } = new();
        public List<Workshop> Workshops { get; set; } = new();
        public List<ScheduleEntry> Schedules { get; set; } = new();
        public List<Holiday> Holidays { get; set; } = new();
        public List<string> Categories { get; set; } = new();
        public Setting Settings { get; set; } = new();
    }
}

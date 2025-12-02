using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using KursYonetimSistemi.Models;
using Newtonsoft.Json;

namespace KursYonetimSistemi.Services
{
    public class DataService
    {
        private readonly string _dataDirectory;
        private readonly JsonSerializerSettings _settings = new()
        {
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Ignore
        };

        public ObservableCollection<Course> Courses { get; private set; } = new();
        public ObservableCollection<Teacher> Teachers { get; private set; } = new();
        public ObservableCollection<Student> Students { get; private set; } = new();
        public ObservableCollection<Workshop> Workshops { get; private set; } = new();
        public ObservableCollection<ScheduleEntry> Schedules { get; private set; } = new();
        public ObservableCollection<Holiday> Holidays { get; private set; } = new();
        public ObservableCollection<string> Categories { get; private set; } = new();
        public Setting Settings { get; private set; } = new();

        public event EventHandler? DataChanged;

        public DataService()
        {
            _dataDirectory = AppDomain.CurrentDomain.BaseDirectory;
            LoadAll();
            EnsureDefaults();
        }

        public void LoadAll()
        {
            Courses = LoadCollection("courses.json", Courses);
            Teachers = LoadCollection("teachers.json", Teachers);
            Students = LoadCollection("students.json", Students);
            Workshops = LoadCollection("workshops.json", Workshops);
            Schedules = LoadCollection("schedules.json", Schedules);
            Holidays = LoadCollection("holidays.json", Holidays);
            Categories = LoadCollection("categories.json", Categories, new[] { "Müzik", "Resim", "El Sanatları", "Dans", "Spor", "Dil", "Bilgisayar", "Diğer" });
            Settings = LoadObject("settings.json", Settings) ?? new Setting();
        }

        private ObservableCollection<T> LoadCollection<T>(string fileName, ObservableCollection<T> target, T[]? defaults = null)
        {
            var path = Path.Combine(_dataDirectory, fileName);
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                var items = JsonConvert.DeserializeObject<ObservableCollection<T>>(json);
                if (items != null)
                {
                    return items;
                }
            }

            if (defaults != null)
            {
                return new ObservableCollection<T>(defaults);
            }

            return target;
        }

        private ObservableCollection<string> LoadCollection(string fileName, ObservableCollection<string> target, string[] defaults)
        {
            var path = Path.Combine(_dataDirectory, fileName);
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                var items = JsonConvert.DeserializeObject<ObservableCollection<string>>(json);
                if (items != null)
                {
                    return items;
                }
            }
            return new ObservableCollection<string>(defaults);
        }

        private T? LoadObject<T>(string fileName, T? fallback)
        {
            var path = Path.Combine(_dataDirectory, fileName);
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<T>(json);
            }
            return fallback;
        }

        private void EnsureDefaults()
        {
            if (!Holidays.Any())
            {
                Holidays.Add(new Holiday { Ad = "Yılbaşı", Baslangic = new DateTime(DateTime.Now.Year, 1, 1), Bitis = new DateTime(DateTime.Now.Year, 1, 1), Tekrarli = true, Aciklama = "Yeni yıl tatili" });
                Holidays.Add(new Holiday { Ad = "Ulusal Egemenlik ve Çocuk Bayramı", Baslangic = new DateTime(DateTime.Now.Year, 4, 23), Bitis = new DateTime(DateTime.Now.Year, 4, 23), Tekrarli = true });
                Holidays.Add(new Holiday { Ad = "Emek ve Dayanışma Günü", Baslangic = new DateTime(DateTime.Now.Year, 5, 1), Bitis = new DateTime(DateTime.Now.Year, 5, 1), Tekrarli = true });
                SaveAll();
            }
        }

        public void SaveAll()
        {
            SaveCollection("courses.json", Courses);
            SaveCollection("teachers.json", Teachers);
            SaveCollection("students.json", Students);
            SaveCollection("workshops.json", Workshops);
            SaveCollection("schedules.json", Schedules);
            SaveCollection("holidays.json", Holidays);
            SaveCollection("categories.json", Categories);
            SaveObject("settings.json", Settings);
            DataChanged?.Invoke(this, EventArgs.Empty);
        }

        private void SaveCollection<T>(string fileName, ObservableCollection<T> collection)
        {
            var path = Path.Combine(_dataDirectory, fileName);
            var json = JsonConvert.SerializeObject(collection, _settings);
            File.WriteAllText(path, json);
        }

        private void SaveObject<T>(string fileName, T obj)
        {
            var path = Path.Combine(_dataDirectory, fileName);
            var json = JsonConvert.SerializeObject(obj, _settings);
            File.WriteAllText(path, json);
        }

        public BackupPackage ExportBackup()
        {
            return new BackupPackage
            {
                Courses = Courses.ToList(),
                Teachers = Teachers.ToList(),
                Students = Students.ToList(),
                Workshops = Workshops.ToList(),
                Schedules = Schedules.ToList(),
                Holidays = Holidays.ToList(),
                Categories = Categories.ToList(),
                Settings = Settings
            };
        }

        public void RestoreBackup(BackupPackage package)
        {
            Courses = new ObservableCollection<Course>(package.Courses);
            Teachers = new ObservableCollection<Teacher>(package.Teachers);
            Students = new ObservableCollection<Student>(package.Students);
            Workshops = new ObservableCollection<Workshop>(package.Workshops);
            Schedules = new ObservableCollection<ScheduleEntry>(package.Schedules);
            Holidays = new ObservableCollection<Holiday>(package.Holidays);
            Categories = new ObservableCollection<string>(package.Categories);
            Settings = package.Settings;
            SaveAll();
        }

        public bool HasScheduleConflict(ScheduleEntry candidate)
        {
            return Schedules.Any(existing => existing.Id != candidate.Id && existing.Aktif && candidate.Aktif
                && existing.Gun == candidate.Gun
                && candidate.BaslangicSaati < existing.BitisSaati
                && candidate.BitisSaati > existing.BaslangicSaati
                && (existing.AtolyeId == candidate.AtolyeId || existing.OgretmenId == candidate.OgretmenId));
        }

        public bool IsHoliday(DateTime date)
        {
            return Holidays.Any(h =>
            {
                if (h.Baslangic is null || h.Bitis is null) return false;
                var start = h.Tekrarli ? new DateTime(date.Year, h.Baslangic.Value.Month, h.Baslangic.Value.Day) : h.Baslangic.Value.Date;
                var end = h.Tekrarli ? new DateTime(date.Year, h.Bitis.Value.Month, h.Bitis.Value.Day) : h.Bitis.Value.Date;
                return date.Date >= start && date.Date <= end;
            });
        }
    }
}

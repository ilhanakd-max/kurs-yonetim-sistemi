using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using KursYonetimSistemi.Models;

namespace KursYonetimSistemi.Services
{
    public static class DataManager
    {
        private static readonly string DataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        private static readonly JsonSerializerOptions JsonOptions;

        public static List<Course> Courses { get; set; } = new List<Course>();
        public static List<Workshop> Workshops { get; set; } = new List<Workshop>();
        public static List<Teacher> Teachers { get; set; } = new List<Teacher>();
        public static List<Student> Students { get; set; } = new List<Student>();
        public static List<Schedule> Schedules { get; set; } = new List<Schedule>();
        public static List<Holiday> Holidays { get; set; } = new List<Holiday>();
        public static List<string> Categories { get; set; } = new List<string>();
        public static AppSettings Settings { get; set; } = new AppSettings();

        static DataManager()
        {
            JsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
        }

        public static void LoadData()
        {
            try
            {
                if (!Directory.Exists(DataPath))
                {
                    Directory.CreateDirectory(DataPath);
                }

                Courses = Load<List<Course>>("courses.json") ?? new List<Course>();
                Workshops = Load<List<Workshop>>("workshops.json") ?? new List<Workshop>();
                Teachers = Load<List<Teacher>>("teachers.json") ?? new List<Teacher>();
                Students = Load<List<Student>>("students.json") ?? new List<Student>();
                Schedules = Load<List<Schedule>>("schedules.json") ?? new List<Schedule>();
                Holidays = Load<List<Holiday>>("holidays.json") ?? new List<Holiday>();
                Categories = Load<List<string>>("categories.json") ?? new List<string> { "Müzik", "Resim", "El Sanatları", "Dans", "Spor", "Dil", "Bilgisayar", "Diğer" };
                Settings = Load<AppSettings>("settings.json") ?? new AppSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void SaveData()
        {
            if (!Directory.Exists(DataPath))
            {
                Directory.CreateDirectory(DataPath);
            }

            Save("courses.json", Courses);
            Save("workshops.json", Workshops);
            Save("teachers.json", Teachers);
            Save("students.json", Students);
            Save("schedules.json", Schedules);
            Save("holidays.json", Holidays);
            Save("categories.json", Categories);
            Save("settings.json", Settings);
        }

        private static T? Load<T>(string fileName)
        {
            var filePath = Path.Combine(DataPath, fileName);
            if (!File.Exists(filePath))
            {
                return default;
            }

            var jsonString = File.ReadAllText(filePath, Encoding.UTF8);
            return JsonSerializer.Deserialize<T>(jsonString, JsonOptions);
        }

        private static void Save<T>(string fileName, T data)
        {
            var filePath = Path.Combine(DataPath, fileName);
            var jsonString = JsonSerializer.Serialize(data, JsonOptions);
            File.WriteAllText(filePath, jsonString, new UTF8Encoding(true));
        }

        public static void ExportBackup(string backupPath)
        {
            var backupData = new
            {
                Courses,
                Workshops,
                Teachers,
                Students,
                Schedules,
                Holidays,
                Categories,
                Settings
            };
            Save(backupPath, backupData);
        }

        public static void ImportBackup(string backupPath)
        {
            try
            {
                var backupJson = File.ReadAllText(backupPath, Encoding.UTF8);
                var backupData = JsonSerializer.Deserialize<JsonElement>(backupJson);

                Courses = JsonSerializer.Deserialize<List<Course>>(backupData.GetProperty("Courses").GetRawText(), JsonOptions) ?? new List<Course>();
                Workshops = JsonSerializer.Deserialize<List<Workshop>>(backupData.GetProperty("Workshops").GetRawText(), JsonOptions) ?? new List<Workshop>();
                Teachers = JsonSerializer.Deserialize<List<Teacher>>(backupData.GetProperty("Teachers").GetRawText(), JsonOptions) ?? new List<Teacher>();
                Students = JsonSerializer.Deserialize<List<Student>>(backupData.GetProperty("Students").GetRawText(), JsonOptions) ?? new List<Student>();
                Schedules = JsonSerializer.Deserialize<List<Schedule>>(backupData.GetProperty("Schedules").GetRawText(), JsonOptions) ?? new List<Schedule>();
                Holidays = JsonSerializer.Deserialize<List<Holiday>>(backupData.GetProperty("Holidays").GetRawText(), JsonOptions) ?? new List<Holiday>();
                Categories = JsonSerializer.Deserialize<List<string>>(backupData.GetProperty("Categories").GetRawText(), JsonOptions) ?? new List<string>();
                Settings = JsonSerializer.Deserialize<AppSettings>(backupData.GetProperty("Settings").GetRawText(), JsonOptions) ?? new AppSettings();

                SaveData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri içe aktarılırken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

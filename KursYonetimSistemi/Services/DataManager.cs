using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Web.Script.Serialization;

namespace KursYonetimSistemi.Services
{
    public class DataManager
    {
        private static readonly string AppDataPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "KursYonetimSistemi"
        );
        private static readonly string JsonFilePath = Path.Combine(AppDataPath, "data.json");
        private readonly JavaScriptSerializer _serializer;

        public AppData Data { get; private set; }

        public DataManager()
        {
            _serializer = new JavaScriptSerializer
            {
                MaxJsonLength = int.MaxValue
            };
            Directory.CreateDirectory(AppDataPath);
            LoadData();
        }

        public void LoadData()
        {
            if (File.Exists(JsonFilePath))
            {
                try
                {
                    var json = File.ReadAllText(JsonFilePath, new UTF8Encoding(true));
                    Data = _serializer.Deserialize<AppData>(json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Veri yüklenirken hata oluştu: {ex.Message}");
                    Data = new AppData();
                }
            }
            else
            {
                Data = new AppData();
            }
        }

        public void SaveData()
        {
            var json = _serializer.Serialize(Data);
            using (var writer = new StreamWriter(JsonFilePath, false, new UTF8Encoding(true)))
            {
                writer.Write(json);
            }
        }

        public string CheckConflict(ScheduleItem newItem)
        {
            var conflictingItem = Data.Schedule.FirstOrDefault(existingItem =>
            {
                if (!existingItem.IsActive || existingItem.Id == newItem.Id)
                    return false;

                if (existingItem.Day != newItem.Day)
                    return false;

                bool timeOverlap = newItem.StartTime < existingItem.EndTime && newItem.EndTime > existingItem.StartTime;

                if (timeOverlap)
                {
                    if (existingItem.TeacherId == newItem.TeacherId) return true;
                    if (existingItem.WorkshopId == newItem.WorkshopId) return true;
                }

                return false;
            });

            if (conflictingItem != null)
            {
                var teacher = Data.Teachers.FirstOrDefault(t => t.Id == conflictingItem.TeacherId);
                var workshop = Data.Workshops.FirstOrDefault(w => w.Id == conflictingItem.WorkshopId);
                return $"Çakışma: {teacher?.Name} veya {workshop?.Name} zaten {conflictingItem.StartTime:hh\\:mm} - {conflictingItem.EndTime:hh\\:mm} saatleri arasında meşgul.";
            }

            return null;
        }

        public void ExportBackup(string path)
        {
            var json = _serializer.Serialize(Data);
            File.WriteAllText(path, json, new UTF8Encoding(true));
        }

        public void ImportBackup(string path)
        {
            var json = File.ReadAllText(path, new UTF8Encoding(true));
            var importedData = _serializer.Deserialize<AppData>(json);
            if (importedData != null)
            {
                Data = importedData;
                SaveData();
            }
        }
    }
}

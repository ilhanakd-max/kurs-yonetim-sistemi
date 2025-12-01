using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KursYonetimSistemi.Services
{
    public class ReportManager
    {
        private readonly AppData _data;

        public ReportManager(AppData data)
        {
            _data = data;
        }

        public void ExportCoursesToCsv()
        {
            var header = "Kurs Adı,Kategori,Kapasite,Kayıtlı Öğrenci";
            ExportToCsv("Kurslar", header, _data.Courses, (course) =>
                $"\"{course.Name}\",\"{course.Category}\",{course.Capacity},{_data.Students.Count(s => s.EnrolledCourseIds.Contains(course.Id))}"
            );
        }

        public void ExportWorkshopsToCsv()
        {
            var header = "Atölye Adı,Konum,Kapasite";
            ExportToCsv("Atölyeler", header, _data.Workshops, (workshop) =>
                $"\"{workshop.Name}\",\"{workshop.Location}\",{workshop.Capacity}"
            );
        }

        public void ExportTeachersToCsv()
        {
            var header = "Eğitmen Adı,Branş,Telefon,E-posta";
            ExportToCsv("Eğitmenler", header, _data.Teachers, (teacher) =>
                $"\"{teacher.Name}\",\"{teacher.Branch}\",\"{teacher.PhoneNumber}\",\"{teacher.Email}\""
            );
        }

        public void ExportStudentsToCsv()
        {
            var header = "Öğrenci Adı,Telefon,E-posta,Kurs Sayısı";
            ExportToCsv("Öğrenciler", header, _data.Students, (student) =>
                $"\"{student.Name}\",\"{student.PhoneNumber}\",\"{student.Email}\",{student.EnrolledCourseIds.Count}"
            );
        }

        private void ExportToCsv<T>(string reportName, string header, IEnumerable<T> data, Func<T, string> lineFormatter)
        {
            using (var sfd = new SaveFileDialog { Filter = "CSV Dosyası|*.csv", Title = $"{reportName} Raporu Oluştur", FileName = $"{reportName}.csv" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var sb = new StringBuilder();
                        sb.AppendLine(header);

                        foreach (var item in data)
                        {
                            sb.AppendLine(lineFormatter(item));
                        }

                        // Use UTF-8 with BOM for Excel compatibility with Turkish characters
                        File.WriteAllText(sfd.FileName, sb.ToString(), new UTF8Encoding(true));
                        MessageBox.Show($"{reportName} raporu başarıyla oluşturuldu!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Rapor oluşturulurken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}

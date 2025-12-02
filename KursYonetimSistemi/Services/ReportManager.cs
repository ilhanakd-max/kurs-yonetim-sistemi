using System;
using System.Linq;
using KursYonetimSistemi.Models;
using KursYonetimSistemi.Services;
using System.Text;
using System.Collections.Generic;
using System.IO;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using OfficeOpenXml;
using System.Data;

namespace KursYonetimSistemi.Services
{
    public static class ReportManager
    {
        public static string GenerateReport(string reportType, DateTime startDate, DateTime endDate, string courseId = null)
        {
            var dt = GetReportData(reportType, startDate, endDate, courseId);
            var sb = new StringBuilder();
            sb.Append("<html><head><style>table { width: 100%; border-collapse: collapse; } th, td { border: 1px solid #ddd; padding: 8px; text-align: left; } th { background-color: #f2f2f2; }</style></head><body>");
            sb.Append($"<h1>{reportType} Raporu</h1>");
            sb.Append("<table><tr>");
            foreach (DataColumn col in dt.Columns)
            {
                sb.Append($"<th>{col.ColumnName}</th>");
            }
            sb.Append("</tr>");
            foreach (DataRow row in dt.Rows)
            {
                sb.Append("<tr>");
                foreach (DataColumn col in dt.Columns)
                {
                    sb.Append($"<td>{row[col]}</td>");
                }
                sb.Append("</tr>");
            }
            sb.Append("</table></body></html>");
            return sb.ToString();
        }

        public static void ExportToPdf(string htmlContent, string filePath)
        {
            QuestPDF.Settings.License = LicenseType.Community;
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Content().Html(htmlContent);
                });
            }).GeneratePdf(filePath);
        }

        public static void ExportToExcel(string reportType, DateTime startDate, DateTime endDate, string filePath, string courseId = null)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Rapor");
                DataTable dt = GetReportData(reportType, startDate, endDate, courseId);
                worksheet.Cells["A1"].LoadFromDataTable(dt, true);
                package.SaveAs(new FileInfo(filePath));
            }
        }

        public static void ExportToTxt(string reportType, DateTime startDate, DateTime endDate, string filePath, string courseId = null)
        {
            var dt = GetReportData(reportType, startDate, endDate, courseId);
            var sb = new StringBuilder();
            foreach (DataColumn col in dt.Columns)
            {
                sb.Append($"{col.ColumnName}\t");
            }
            sb.AppendLine();
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    sb.Append($"{row[col]}\t");
                }
                sb.AppendLine();
            }
            File.WriteAllText(filePath, sb.ToString());
        }

        private static DataTable GetReportData(string reportType, DateTime startDate, DateTime endDate, string courseId = null)
        {
            var dt = new DataTable();

            switch(reportType)
            {
                case "Course":
                    dt.Columns.AddRange(new DataColumn[] {
                        new DataColumn("Kurs Adı"), new DataColumn("Kategori"), new DataColumn("Kayıtlı Öğrenci"), new DataColumn("Ders Sayısı")
                    });
                    var courses = DataManager.Courses.Where(c => c.Active);
                    foreach (var course in courses)
                    {
                        var enrolledCount = DataManager.Students.Count(s => s.Courses.Contains(course.Id));
                        var scheduleCount = DataManager.Schedules.Count(s => s.CourseId == course.Id && s.StartDate <= endDate && s.EndDate >= startDate);
                        dt.Rows.Add(course.Name, course.Category, enrolledCount, scheduleCount);
                    }
                    break;
                case "Teacher":
                    dt.Columns.AddRange(new DataColumn[] {
                        new DataColumn("Eğitmen Adı"), new DataColumn("Branş"), new DataColumn("Verdiği Ders Sayısı")
                    });
                    var teachers = DataManager.Teachers.Where(t => t.Active);
                    foreach (var teacher in teachers)
                    {
                        var lessonCount = DataManager.Schedules.Count(s => s.TeacherId == teacher.Id && s.StartDate <= endDate && s.EndDate >= startDate);
                        dt.Rows.Add(teacher.Name, teacher.Branch, lessonCount);
                    }
                    break;
                case "Workshop":
                    dt.Columns.AddRange(new DataColumn[] {
                        new DataColumn("Atölye Adı"), new DataColumn("Kapasite"), new DataColumn("Ders Sayısı")
                    });
                    var workshops = DataManager.Workshops.Where(w => w.Active);
                    foreach (var workshop in workshops)
                    {
                        var scheduleCount = DataManager.Schedules.Count(s => s.WorkshopId == workshop.Id && s.StartDate <= endDate && s.EndDate >= startDate);
                        dt.Rows.Add(workshop.Name, workshop.Capacity, scheduleCount);
                    }
                    break;
                case "Student":
                    dt.Columns.AddRange(new DataColumn[] {
                        new DataColumn("Öğrenci Adı"), new DataColumn("Telefon"), new DataColumn("Kayıtlı Olduğu Kurslar")
                    });
                    var students = DataManager.Students.Where(s => s.Active && s.RegistrationDate >= startDate && s.RegistrationDate <= endDate);
                    foreach (var student in students)
                    {
                        var courseNames = student.Courses.Select(cId => DataManager.Courses.FirstOrDefault(c => c.Id == cId)?.Name);
                        dt.Rows.Add(student.Name, student.Phone, string.Join(", ", courseNames));
                    }
                    break;
                case "Schedule":
                    dt.Columns.AddRange(new DataColumn[] {
                        new DataColumn("Tarih"), new DataColumn("Saat"), new DataColumn("Kurs"), new DataColumn("Eğitmen"), new DataColumn("Atölye")
                    });
                    var schedules = DataManager.Schedules.Where(s => s.StartDate >= startDate && s.EndDate <= endDate).OrderBy(s => s.StartDate).ThenBy(s => s.StartTime);
                    foreach (var schedule in schedules)
                    {
                        var course = DataManager.Courses.FirstOrDefault(c => c.Id == schedule.CourseId);
                        var teacher = DataManager.Teachers.FirstOrDefault(t => t.Id == schedule.TeacherId);
                        var workshop = DataManager.Workshops.FirstOrDefault(w => w.Id == schedule.WorkshopId);
                        dt.Rows.Add(schedule.StartDate?.ToString("d"), $"{schedule.StartTime} - {schedule.EndTime}", course?.Name, teacher?.Name, workshop?.Name);
                    }
                    break;
                case "Attendance":
                    dt.Columns.AddRange(new DataColumn[] { new DataColumn("Öğrenci Adı"), new DataColumn("Durum") });
                    if (!string.IsNullOrEmpty(courseId))
                    {
                        var studentsInCourse = DataManager.Students.Where(s => s.Courses.Contains(courseId));
                        foreach (var student in studentsInCourse)
                        {
                            dt.Rows.Add(student.Name, "");
                        }
                    }
                    break;
            }

            return dt;
        }
    }
}

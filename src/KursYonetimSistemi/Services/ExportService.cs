using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using ClosedXML.Excel;
using KursYonetimSistemi.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace KursYonetimSistemi.Services
{
    public class ExportService
    {
        public void ExportTxt(string path, IEnumerable<string> satirlar)
        {
            File.WriteAllLines(path, satirlar);
        }

        public void ExportExcel<T>(string path, IEnumerable<T> veriler, string sayfaAdi)
        {
            using var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add(sayfaAdi);
            var props = typeof(T).GetProperties();
            for (int i = 0; i < props.Length; i++)
            {
                ws.Cell(1, i + 1).Value = props[i].Name;
            }

            int row = 2;
            foreach (var item in veriler)
            {
                for (int i = 0; i < props.Length; i++)
                {
                    ws.Cell(row, i + 1).Value = props[i].GetValue(item);
                }
                row++;
            }

            ws.Columns().AdjustToContents();
            wb.SaveAs(path);
        }

        public void ExportPdf(string path, string baslik, IEnumerable<string> satirlar)
        {
            var font = Fonts.TryResolve("Arial") ?? Fonts.Calibri;
            QuestPDF.Settings.License = LicenseType.Community;

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);
                    page.Size(PageSizes.A4);
                    page.DefaultTextStyle(x => x.FontSize(11).FontColor(Colors.Black).FontFamily(font));
                    page.Header().Text(baslik).FontSize(20).FontColor("#1a5276").SemiBold();
                    page.Content().Column(col =>
                    {
                        col.Spacing(6);
                        foreach (var line in satirlar)
                        {
                            col.Item().Text(line);
                        }
                    });
                    page.Footer().AlignCenter().Text($"Oluşturma Tarihi: {DateTime.Now.ToString("g", new CultureInfo("tr-TR"))}");
                });
            }).GeneratePdf(path);
        }

        public IEnumerable<string> DerleRapor(DataService data)
        {
            var satirlar = new List<string>
            {
                "ÇEŞME BELEDİYESİ KURS YÖNETİMİ RAPORU",
                "---------------------------------------",
                $"Toplam Kurs: {data.Courses.Count(c => c.Aktif)} / Pasif: {data.Courses.Count(c => !c.Aktif)}",
                $"Toplam Eğitmen: {data.Teachers.Count(t => t.Aktif)} / Pasif: {data.Teachers.Count(t => !t.Aktif)}",
                $"Toplam Öğrenci: {data.Students.Count(s => s.Aktif)} / Pasif: {data.Students.Count(s => !s.Aktif)}",
                $"Toplam Atölye: {data.Workshops.Count(w => w.Aktif)} / Pasif: {data.Workshops.Count(w => !w.Aktif)}",
                $"Aktif Ders Planı: {data.Schedules.Count(s => s.Aktif)}",
                "",
                "KURS LİSTESİ"
            };

            satirlar.AddRange(data.Courses.Select(c => $"- {c.Ad} | {c.Kategori} | Seviye: {c.Seviye} | Durum: {(c.Aktif ? "Aktif" : "Pasif")}"));
            satirlar.Add("");
            satirlar.Add("EĞİTMENLER");
            satirlar.AddRange(data.Teachers.Select(t => $"- {t.Ad} ({t.Uzmanlik}) {t.Telefon} {t.Eposta} | Durum: {(t.Aktif ? "Aktif" : "Pasif")}"));
            satirlar.Add("");
            satirlar.Add("ÖĞRENCİLER");
            satirlar.AddRange(data.Students.Select(s => $"- {s.Ad} | Kurs: {data.Courses.FirstOrDefault(c => c.Id == s.KursId)?.Ad ?? "Belirtilmedi"} | Durum: {(s.Aktif ? "Aktif" : "Pasif")}"));
            satirlar.Add("");
            satirlar.Add("DERS PROGRAMI");
            satirlar.AddRange(data.Schedules.Select(s =>
            {
                var kurs = data.Courses.FirstOrDefault(c => c.Id == s.KursId)?.Ad ?? "Bilinmeyen Kurs";
                var ogretmen = data.Teachers.FirstOrDefault(t => t.Id == s.OgretmenId)?.Ad ?? "Bilinmiyor";
                var atolye = data.Workshops.FirstOrDefault(w => w.Id == s.AtolyeId)?.Ad ?? "Atölye";
                return $"- {GetDayName(s.Gun)} {s.BaslangicSaati:hh\\:mm}-{s.BitisSaati:hh\\:mm} | {kurs} | {ogretmen} | {atolye} | {(s.Aktif ? "Aktif" : "Pasif")}";
            }));
            return satirlar;
        }

        private static string GetDayName(DayOfWeek day)
        {
            return day switch
            {
                DayOfWeek.Monday => "Pazartesi",
                DayOfWeek.Tuesday => "Salı",
                DayOfWeek.Wednesday => "Çarşamba",
                DayOfWeek.Thursday => "Perşembe",
                DayOfWeek.Friday => "Cuma",
                DayOfWeek.Saturday => "Cumartesi",
                _ => "Pazar"
            };
        }
    }
}

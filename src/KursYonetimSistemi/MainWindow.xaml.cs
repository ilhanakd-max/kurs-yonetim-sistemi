using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;
using KursYonetimSistemi.Models;
using KursYonetimSistemi.Services;
using KursYonetimSistemi.Views;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace KursYonetimSistemi
{
    public partial class MainWindow : Window
    {
        private readonly DataService _data;
        private readonly ExportService _export;
        private readonly CalendarService _calendar;
        private readonly ObservableCollection<string> _notifications = new();
        private readonly DispatcherTimer _clockTimer;
        private ICollectionView _courseView = CollectionViewSource.GetDefaultView(new ObservableCollection<Course>());

        public MainWindow()
        {
            InitializeComponent();
            _data = new DataService();
            _export = new ExportService();
            _calendar = new CalendarService(_data);

            GridKurs.ItemsSource = _data.Courses;
            GridEgitmen.ItemsSource = _data.Teachers;
            GridOgrenci.ItemsSource = _data.Students;
            GridAtolye.ItemsSource = _data.Workshops;
            GridDers.ItemsSource = _data.Schedules;
            GridTatil.ItemsSource = _data.Holidays;
            ListeKategori.ItemsSource = _data.Categories;
            NotificationsList.ItemsSource = _notifications;

            _courseView = CollectionViewSource.GetDefaultView(GridKurs.ItemsSource);

            _clockTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _clockTimer.Tick += (s, e) => UpdateDateTime();
            _clockTimer.Start();

            RenderAll();
        }

        private void RenderAll()
        {
            UpdateDashboard();
            RenderWeeklyCalendar();
            RenderLiveLessons();
            ListeRapor.ItemsSource = _export.DerleRapor(_data);
            TextKurum.Text = _data.Settings.KurumAdi;
            TxtKurum.Text = _data.Settings.KurumAdi;
            TxtMesaiBas.Text = _data.Settings.MesaiBaslangic.ToString(@"hh\:mm");
            TxtMesaiBit.Text = _data.Settings.MesaiBitis.ToString(@"hh\:mm");
            TxtDersSure.Text = _data.Settings.DersSuresiDakika.ToString();
            TxtAraSure.Text = _data.Settings.AraSuresiDakika.ToString();
            ChkHaftaSonu.IsChecked = _data.Settings.HaftaSonuKapali;
            _courseView.Refresh();
        }

        private void UpdateDashboard()
        {
            LblKurs.Text = _data.Courses.Count(c => c.Aktif).ToString();
            LblOgrenci.Text = _data.Students.Count(s => s.Aktif).ToString();
            LblEgitmen.Text = _data.Teachers.Count(t => t.Aktif).ToString();
            LblAtolye.Text = _data.Workshops.Count(w => w.Aktif).ToString();
            LblDers.Text = _data.Schedules.Count(s => s.Aktif).ToString();
            var saat = _data.Schedules.Where(s => s.Aktif).Sum(s => (s.BitisSaati - s.BaslangicSaati).TotalHours);
            LblSaat.Text = $"{saat:0.0} saat";
        }

        private void RenderWeeklyCalendar()
        {
            var bugun = DateTime.Now;
            WeeklyCalendar.ItemsSource = _calendar.HaftalikTakvim(bugun)
                .Select(g => $"{g.Tarih:dd MMMM dddd}: {string.Join(", ", g.Dersler.Select(d => FormatDers(d)))}");
        }

        private void RenderLiveLessons()
        {
            var simdi = DateTime.Now;
            var aktif = _data.Schedules.Where(s => s.Aktif && s.Gun == simdi.DayOfWeek
                && s.BaslangicSaati <= simdi.TimeOfDay && s.BitisSaati >= simdi.TimeOfDay);
            LiveLessonsList.ItemsSource = aktif.Select(FormatDers);
        }

        private string FormatDers(ScheduleEntry ders)
        {
            var kurs = _data.Courses.FirstOrDefault(c => c.Id == ders.KursId)?.Ad ?? "Kurs";
            var ogretmen = _data.Teachers.FirstOrDefault(t => t.Id == ders.OgretmenId)?.Ad ?? "Eğitmen";
            var atolye = _data.Workshops.FirstOrDefault(w => w.Id == ders.AtolyeId)?.Ad ?? "Atölye";
            return $"{kurs} - {ogretmen} - {atolye} ({ders.BaslangicSaati:hh\\:mm}-{ders.BitisSaati:hh\\:mm})";
        }

        private void UpdateDateTime()
        {
            TextTarih.Text = DateTime.Now.ToString("dd MMMM yyyy dddd", new System.Globalization.CultureInfo("tr-TR"));
            TextSaat.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void YeniKurs_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CourseDialog(_data.Categories);
            if (dialog.ShowDialog() == true)
            {
                _data.Courses.Add(dialog.Kurs);
                _data.SaveAll();
                RenderAll();
                AddNotification($"Yeni kurs eklendi: {dialog.Kurs.Ad}");
            }
        }

        private Course? SeciliKurs() => GridKurs.SelectedItem as Course;

        private void DuzenleKurs_Click(object sender, RoutedEventArgs e)
        {
            if (SeciliKurs() is Course kurs)
            {
                var dialog = new CourseDialog(_data.Categories, kurs);
                if (dialog.ShowDialog() == true)
                {
                    _data.SaveAll();
                    RenderAll();
                }
            }
        }

        private void SilKurs_Click(object sender, RoutedEventArgs e)
        {
            if (SeciliKurs() is Course kurs && MessageBox.Show("Kursu silmek istiyor musunuz?", "Onay", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _data.Courses.Remove(kurs);
                _data.SaveAll();
                RenderAll();
            }
        }

        private void AraKurs_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            _courseView.Filter = obj =>
            {
                if (obj is not Course kurs) return true;
                var aranan = AraKurs.Text?.Trim().ToLowerInvariant() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(aranan)) return true;
                return kurs.Ad.ToLowerInvariant().Contains(aranan) || kurs.Kategori.ToLowerInvariant().Contains(aranan);
            };
            _courseView.Refresh();
        }

        private Teacher? SeciliEgitmen() => GridEgitmen.SelectedItem as Teacher;
        private void YeniEgitmen_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new TeacherDialog();
            if (dlg.ShowDialog() == true)
            {
                _data.Teachers.Add(dlg.Ogretmen);
                _data.SaveAll();
                RenderAll();
            }
        }

        private void DuzenleEgitmen_Click(object sender, RoutedEventArgs e)
        {
            if (SeciliEgitmen() is Teacher ogretmen)
            {
                var dlg = new TeacherDialog(ogretmen);
                if (dlg.ShowDialog() == true)
                {
                    _data.SaveAll();
                    RenderAll();
                }
            }
        }

        private void SilEgitmen_Click(object sender, RoutedEventArgs e)
        {
            if (SeciliEgitmen() is Teacher ogretmen && MessageBox.Show("Eğitmeni silmek istiyor musunuz?", "Onay", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _data.Teachers.Remove(ogretmen);
                _data.SaveAll();
                RenderAll();
            }
        }

        private Student? SeciliOgrenci() => GridOgrenci.SelectedItem as Student;
        private void YeniOgrenci_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new StudentDialog(_data.Courses);
            if (dlg.ShowDialog() == true)
            {
                _data.Students.Add(dlg.Ogrenci);
                _data.SaveAll();
                RenderAll();
            }
        }

        private void DuzenleOgrenci_Click(object sender, RoutedEventArgs e)
        {
            if (SeciliOgrenci() is Student ogrenci)
            {
                var dlg = new StudentDialog(_data.Courses, ogrenci);
                if (dlg.ShowDialog() == true)
                {
                    _data.SaveAll();
                    RenderAll();
                }
            }
        }

        private void SilOgrenci_Click(object sender, RoutedEventArgs e)
        {
            if (SeciliOgrenci() is Student ogrenci && MessageBox.Show("Öğrenciyi silmek istiyor musunuz?", "Onay", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _data.Students.Remove(ogrenci);
                _data.SaveAll();
                RenderAll();
            }
        }

        private Workshop? SeciliAtolye() => GridAtolye.SelectedItem as Workshop;
        private void YeniAtolye_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new WorkshopDialog();
            if (dlg.ShowDialog() == true)
            {
                _data.Workshops.Add(dlg.Atolye);
                _data.SaveAll();
                RenderAll();
            }
        }

        private void DuzenleAtolye_Click(object sender, RoutedEventArgs e)
        {
            if (SeciliAtolye() is Workshop atolye)
            {
                var dlg = new WorkshopDialog(atolye);
                if (dlg.ShowDialog() == true)
                {
                    _data.SaveAll();
                    RenderAll();
                }
            }
        }

        private void SilAtolye_Click(object sender, RoutedEventArgs e)
        {
            if (SeciliAtolye() is Workshop atolye && MessageBox.Show("Atölye silinecek. Emin misiniz?", "Onay", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _data.Workshops.Remove(atolye);
                _data.SaveAll();
                RenderAll();
            }
        }

        private ScheduleEntry? SeciliDers() => GridDers.SelectedItem as ScheduleEntry;
        private void YeniDers_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new ScheduleDialog(_data.Courses, _data.Teachers, _data.Workshops);
            if (dlg.ShowDialog() == true)
            {
                if (_data.HasScheduleConflict(dlg.Ders))
                {
                    MessageBox.Show("Atölye veya eğitmen çakışması var!", "Uyarı");
                }
                _data.Schedules.Add(dlg.Ders);
                _data.SaveAll();
                RenderAll();
            }
        }

        private void DuzenleDers_Click(object sender, RoutedEventArgs e)
        {
            if (SeciliDers() is ScheduleEntry ders)
            {
                var dlg = new ScheduleDialog(_data.Courses, _data.Teachers, _data.Workshops, ders);
                if (dlg.ShowDialog() == true)
                {
                    _data.SaveAll();
                    RenderAll();
                }
            }
        }

        private void SilDers_Click(object sender, RoutedEventArgs e)
        {
            if (SeciliDers() is ScheduleEntry ders && MessageBox.Show("Ders silinecek, onaylıyor musunuz?", "Onay", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _data.Schedules.Remove(ders);
                _data.SaveAll();
                RenderAll();
            }
        }

        private void Cakis_Click(object sender, RoutedEventArgs e)
        {
            var sorunlar = new List<string>();
            foreach (var ders in _data.Schedules)
            {
                if (_data.HasScheduleConflict(ders))
                {
                    sorunlar.Add(FormatDers(ders));
                }
            }
            if (sorunlar.Count == 0)
            {
                MessageBox.Show("Çakışma bulunamadı.");
            }
            else
            {
                MessageBox.Show("Çakışmalar:\n" + string.Join("\n", sorunlar));
            }
        }

        private Holiday? SeciliTatil() => GridTatil.SelectedItem as Holiday;
        private void YeniTatil_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new HolidayDialog();
            if (dlg.ShowDialog() == true)
            {
                _data.Holidays.Add(dlg.Tatil);
                _data.SaveAll();
                RenderAll();
            }
        }

        private void DuzenleTatil_Click(object sender, RoutedEventArgs e)
        {
            if (SeciliTatil() is Holiday tatil)
            {
                var dlg = new HolidayDialog(tatil);
                if (dlg.ShowDialog() == true)
                {
                    _data.SaveAll();
                    RenderAll();
                }
            }
        }

        private void SilTatil_Click(object sender, RoutedEventArgs e)
        {
            if (SeciliTatil() is Holiday tatil && MessageBox.Show("Tatil kaydı silinsin mi?", "Onay", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _data.Holidays.Remove(tatil);
                _data.SaveAll();
                RenderAll();
            }
        }

        private void YeniKategori_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new CategoryDialog();
            if (dlg.ShowDialog() == true && !string.IsNullOrWhiteSpace(dlg.KategoriAdi))
            {
                _data.Categories.Add(dlg.KategoriAdi);
                _data.SaveAll();
                RenderAll();
            }
        }

        private void SilKategori_Click(object sender, RoutedEventArgs e)
        {
            if (ListeKategori.SelectedItem is string kategori && MessageBox.Show("Kategori silinsin mi?", "Onay", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _data.Categories.Remove(kategori);
                _data.SaveAll();
                RenderAll();
            }
        }

        private void RaporTxt_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new SaveFileDialog { Filter = "Metin Dosyası|*.txt" };
            if (dlg.ShowDialog() == true)
            {
                _export.ExportTxt(dlg.FileName, _export.DerleRapor(_data));
            }
        }

        private void RaporExcel_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new SaveFileDialog { Filter = "Excel|*.xlsx" };
            if (dlg.ShowDialog() == true)
            {
                _export.ExportExcel(dlg.FileName, _data.Schedules, "Ders Planı");
            }
        }

        private void RaporPdf_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new SaveFileDialog { Filter = "PDF|*.pdf" };
            if (dlg.ShowDialog() == true)
            {
                _export.ExportPdf(dlg.FileName, "Kurs Yönetim Raporu", _export.DerleRapor(_data));
            }
        }

        private void AyarKaydet_Click(object sender, RoutedEventArgs e)
        {
            _data.Settings.KurumAdi = TxtKurum.Text.Trim();
            _data.Settings.MesaiBaslangic = TimeSpan.TryParse(TxtMesaiBas.Text, out var bas) ? bas : TimeSpan.FromHours(9);
            _data.Settings.MesaiBitis = TimeSpan.TryParse(TxtMesaiBit.Text, out var bitis) ? bitis : TimeSpan.FromHours(21);
            _data.Settings.DersSuresiDakika = int.TryParse(TxtDersSure.Text, out var ds) ? ds : 60;
            _data.Settings.AraSuresiDakika = int.TryParse(TxtAraSure.Text, out var ara) ? ara : 15;
            _data.Settings.HaftaSonuKapali = ChkHaftaSonu.IsChecked == true;
            _data.SaveAll();
            RenderAll();
            AddNotification("Ayarlar güncellendi.");
        }

        private void Yedekle_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new SaveFileDialog { Filter = "JSON|*.json" };
            if (dlg.ShowDialog() == true)
            {
                var paket = _data.ExportBackup();
                File.WriteAllText(dlg.FileName, JsonConvert.SerializeObject(paket, Formatting.Indented));
                AddNotification("Yedekleme tamamlandı.");
            }
        }

        private void GeriYukle_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog { Filter = "JSON|*.json" };
            if (dlg.ShowDialog() == true)
            {
                var json = File.ReadAllText(dlg.FileName);
                var paket = JsonConvert.DeserializeObject<BackupPackage>(json);
                if (paket != null)
                {
                    _data.RestoreBackup(paket);
                    RenderAll();
                }
            }
        }

        private void AddNotification(string mesaj)
        {
            _notifications.Insert(0, $"{DateTime.Now:HH:mm} - {mesaj}");
            while (_notifications.Count > 8)
            {
                _notifications.RemoveAt(_notifications.Count - 1);
            }
        }
    }
}

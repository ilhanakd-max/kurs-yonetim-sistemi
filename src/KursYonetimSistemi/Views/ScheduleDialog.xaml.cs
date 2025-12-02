using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using KursYonetimSistemi.Models;

namespace KursYonetimSistemi.Views
{
    public partial class ScheduleDialog : Window
    {
        public ScheduleEntry Ders { get; private set; }
        private readonly DayOfWeek[] _gunler = new[]
        {
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
            DayOfWeek.Sunday
        };
        public ScheduleDialog(IEnumerable<Course> kurslar, IEnumerable<Teacher> ogretmenler, IEnumerable<Workshop> atolyeler, ScheduleEntry? mevcut = null)
        {
            InitializeComponent();
            CmbKurs.ItemsSource = kurslar;
            CmbEgitmen.ItemsSource = ogretmenler;
            CmbAtolye.ItemsSource = atolyeler;
            CmbGun.SelectedIndex = 0;
            Ders = mevcut ?? new ScheduleEntry();
            if (mevcut != null)
            {
                CmbKurs.SelectedItem = kurslar.FirstOrDefault(k => k.Id == mevcut.KursId);
                CmbEgitmen.SelectedItem = ogretmenler.FirstOrDefault(t => t.Id == mevcut.OgretmenId);
                CmbAtolye.SelectedItem = atolyeler.FirstOrDefault(a => a.Id == mevcut.AtolyeId);
                var index = Array.IndexOf(_gunler, mevcut.Gun);
                CmbGun.SelectedIndex = index >= 0 ? index : 0;
                TxtBaslangic.Text = mevcut.BaslangicSaati.ToString(@"hh\:mm");
                TxtBitis.Text = mevcut.BitisSaati.ToString(@"hh\:mm");
                ChkAktif.IsChecked = mevcut.Aktif;
            }
            else
            {
                ChkAktif.IsChecked = true;
            }
        }

        private void Kaydet_Click(object sender, RoutedEventArgs e)
        {
            Ders.KursId = (CmbKurs.SelectedItem as Course)?.Id ?? string.Empty;
            Ders.OgretmenId = (CmbEgitmen.SelectedItem as Teacher)?.Id ?? string.Empty;
            Ders.AtolyeId = (CmbAtolye.SelectedItem as Workshop)?.Id ?? string.Empty;
            Ders.Gun = _gunler[CmbGun.SelectedIndex];
            Ders.BaslangicSaati = TimeSpan.TryParse(TxtBaslangic.Text, out var bas) ? bas : TimeSpan.Zero;
            Ders.BitisSaati = TimeSpan.TryParse(TxtBitis.Text, out var bitis) ? bitis : bas.Add(TimeSpan.FromMinutes(60));
            Ders.Aktif = ChkAktif.IsChecked == true;
            DialogResult = true;
        }

        private void Iptal_Click(object sender, RoutedEventArgs e) => DialogResult = false;
    }
}

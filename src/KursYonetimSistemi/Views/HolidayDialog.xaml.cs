using System;
using System.Windows;
using KursYonetimSistemi.Models;

namespace KursYonetimSistemi.Views
{
    public partial class HolidayDialog : Window
    {
        public Holiday Tatil { get; private set; }
        public HolidayDialog(Holiday? mevcut = null)
        {
            InitializeComponent();
            Tatil = mevcut ?? new Holiday();
            if (mevcut != null)
            {
                TxtAd.Text = mevcut.Ad;
                DpBaslangic.SelectedDate = mevcut.Baslangic;
                DpBitis.SelectedDate = mevcut.Bitis;
                ChkTekrar.IsChecked = mevcut.Tekrarli;
            }
            else
            {
                ChkTekrar.IsChecked = true;
            }
        }

        private void Kaydet_Click(object sender, RoutedEventArgs e)
        {
            Tatil.Ad = TxtAd.Text.Trim();
            Tatil.Baslangic = DpBaslangic.SelectedDate;
            Tatil.Bitis = DpBitis.SelectedDate;
            Tatil.Tekrarli = ChkTekrar.IsChecked == true;
            DialogResult = true;
        }

        private void Iptal_Click(object sender, RoutedEventArgs e) => DialogResult = false;
    }
}

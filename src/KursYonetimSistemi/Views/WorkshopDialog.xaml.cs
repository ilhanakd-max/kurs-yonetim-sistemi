using System;
using System.Windows;
using KursYonetimSistemi.Models;

namespace KursYonetimSistemi.Views
{
    public partial class WorkshopDialog : Window
    {
        public Workshop Atolye { get; private set; }
        public WorkshopDialog(Workshop? mevcut = null)
        {
            InitializeComponent();
            Atolye = mevcut ?? new Workshop();
            if (mevcut != null)
            {
                TxtAd.Text = mevcut.Ad;
                TxtKapasite.Text = mevcut.Kapasite.ToString();
                TxtLokasyon.Text = mevcut.Lokasyon;
                ChkAktif.IsChecked = mevcut.Aktif;
            }
            else
            {
                ChkAktif.IsChecked = true;
            }
        }

        private void Kaydet_Click(object sender, RoutedEventArgs e)
        {
            Atolye.Ad = TxtAd.Text.Trim();
            if (int.TryParse(TxtKapasite.Text, out var kapasite))
            {
                Atolye.Kapasite = kapasite;
            }
            Atolye.Lokasyon = TxtLokasyon.Text.Trim();
            Atolye.Aktif = ChkAktif.IsChecked == true;
            DialogResult = true;
        }

        private void Iptal_Click(object sender, RoutedEventArgs e) => DialogResult = false;
    }
}

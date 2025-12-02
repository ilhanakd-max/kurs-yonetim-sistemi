using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using KursYonetimSistemi.Models;

namespace KursYonetimSistemi.Views
{
    public partial class StudentDialog : Window
    {
        public Student Ogrenci { get; private set; }
        public StudentDialog(IEnumerable<Course> kurslar, Student? mevcut = null)
        {
            InitializeComponent();
            CmbKurs.ItemsSource = kurslar;
            Ogrenci = mevcut ?? new Student();
            if (mevcut != null)
            {
                TxtAd.Text = mevcut.Ad;
                CmbKurs.SelectedItem = kurslar.FirstOrDefault(k => k.Id == mevcut.KursId);
                TxtTelefon.Text = mevcut.Telefon;
                TxtEposta.Text = mevcut.Eposta;
                TxtNot.Text = mevcut.Notlar;
                ChkAktif.IsChecked = mevcut.Aktif;
            }
            else
            {
                ChkAktif.IsChecked = true;
            }
        }

        private void Kaydet_Click(object sender, RoutedEventArgs e)
        {
            Ogrenci.Ad = TxtAd.Text.Trim();
            Ogrenci.Telefon = TxtTelefon.Text.Trim();
            Ogrenci.Eposta = TxtEposta.Text.Trim();
            Ogrenci.KursId = (CmbKurs.SelectedItem as Course)?.Id ?? string.Empty;
            Ogrenci.Notlar = TxtNot.Text.Trim();
            Ogrenci.Aktif = ChkAktif.IsChecked == true;
            DialogResult = true;
        }

        private void Iptal_Click(object sender, RoutedEventArgs e) => DialogResult = false;
    }
}

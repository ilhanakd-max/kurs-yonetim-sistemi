using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using KursYonetimSistemi.Models;

namespace KursYonetimSistemi.Views
{
    public partial class CourseDialog : Window
    {
        public Course Kurs { get; private set; }

        public CourseDialog(IEnumerable<string> kategoriler, Course? kurs = null)
        {
            InitializeComponent();
            CmbKategori.ItemsSource = kategoriler;
            CmbSeviye.SelectedIndex = 0;
            Kurs = kurs ?? new Course();
            if (kurs != null)
            {
                TxtAd.Text = kurs.Ad;
                CmbKategori.SelectedItem = kurs.Kategori;
                CmbSeviye.SelectedItem = CmbSeviye.Items.Cast<ComboBoxItem>().FirstOrDefault(i => (string)i.Content == kurs.Seviye);
                TxtAciklama.Text = kurs.Aciklama;
                ChkAktif.IsChecked = kurs.Aktif;
            }
            else
            {
                ChkAktif.IsChecked = true;
            }
        }

        private void Kaydet_Click(object sender, RoutedEventArgs e)
        {
            Kurs.Ad = TxtAd.Text.Trim();
            Kurs.Kategori = (string?)CmbKategori.SelectedItem ?? string.Empty;
            Kurs.Seviye = (CmbSeviye.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Başlangıç";
            Kurs.Aciklama = TxtAciklama.Text;
            Kurs.Aktif = ChkAktif.IsChecked == true;
            DialogResult = true;
        }

        private void Iptal_Click(object sender, RoutedEventArgs e) => DialogResult = false;
    }
}

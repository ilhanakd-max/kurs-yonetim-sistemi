using System.Windows;
using KursYonetimSistemi.Models;

namespace KursYonetimSistemi.Views
{
    public partial class TeacherDialog : Window
    {
        public Teacher Ogretmen { get; private set; }
        public TeacherDialog(Teacher? mevcut = null)
        {
            InitializeComponent();
            Ogretmen = mevcut ?? new Teacher();
            if (mevcut != null)
            {
                TxtAd.Text = mevcut.Ad;
                TxtUzmanlik.Text = mevcut.Uzmanlik;
                TxtTelefon.Text = mevcut.Telefon;
                TxtEposta.Text = mevcut.Eposta;
                ChkAktif.IsChecked = mevcut.Aktif;
            }
            else
            {
                ChkAktif.IsChecked = true;
            }
        }

        private void Kaydet_Click(object sender, RoutedEventArgs e)
        {
            Ogretmen.Ad = TxtAd.Text.Trim();
            Ogretmen.Uzmanlik = TxtUzmanlik.Text.Trim();
            Ogretmen.Telefon = TxtTelefon.Text.Trim();
            Ogretmen.Eposta = TxtEposta.Text.Trim();
            Ogretmen.Aktif = ChkAktif.IsChecked == true;
            DialogResult = true;
        }

        private void Iptal_Click(object sender, RoutedEventArgs e) => DialogResult = false;
    }
}

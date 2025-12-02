using System.Windows;

namespace KursYonetimSistemi.Views
{
    public partial class CategoryDialog : Window
    {
        public string KategoriAdi { get; private set; } = string.Empty;
        public CategoryDialog(string? mevcut = null)
        {
            InitializeComponent();
            if (!string.IsNullOrWhiteSpace(mevcut))
            {
                TxtAd.Text = mevcut;
            }
        }

        private void Kaydet_Click(object sender, RoutedEventArgs e)
        {
            KategoriAdi = TxtAd.Text.Trim();
            DialogResult = true;
        }

        private void Iptal_Click(object sender, RoutedEventArgs e) => DialogResult = false;
    }
}

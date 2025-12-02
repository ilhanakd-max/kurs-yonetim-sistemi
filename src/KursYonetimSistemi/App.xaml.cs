using System.Windows;
using System.Text;

namespace KursYonetimSistemi
{
    public partial class App : Application
    {
        public App()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
    }
}

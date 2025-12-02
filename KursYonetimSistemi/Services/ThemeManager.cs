using System.Drawing;
using System.Windows.Forms;
using KursYonetimSistemi.Services;

namespace KursYonetimSistemi.Services
{
    public static class ThemeManager
    {
        public static void ApplyTheme(Control parent)
        {
            var primaryColor = ColorTranslator.FromHtml(DataManager.Settings.PrimaryColor);

            foreach (Control control in parent.Controls)
            {
                if (control is Button)
                {
                    control.BackColor = primaryColor;
                    control.ForeColor = Color.White;
                }
                else if (control is DataGridView)
                {
                    var dgv = (DataGridView)control;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = primaryColor;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                }
                else if (control is Label)
                {
                    // You might want to be more specific here, e.g., only color certain labels
                    // control.ForeColor = primaryColor;
                }

                if (control.HasChildren)
                {
                    ApplyTheme(control);
                }
            }
        }
    }
}

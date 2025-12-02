using System;
using System.Windows.Forms;
using KursYonetimSistemi.Services;
using System.Linq;

namespace KursYonetimSistemi.UI.Controls
{
    public partial class ReportsControl : UserControl
    {
        private string _currentReportHtml;

        public ReportsControl()
        {
            InitializeComponent();
            LoadCourses();
            reportTypeComboBox.SelectedIndexChanged += ReportTypeComboBox_SelectedIndexChanged;
            courseSelectionLabel.Visible = false;
            courseSelectionComboBox.Visible = false;
        }

        private void LoadCourses()
        {
            courseSelectionComboBox.DataSource = DataManager.Courses.Where(c => c.Active).ToList();
            courseSelectionComboBox.DisplayMember = "Name";
            courseSelectionComboBox.ValueMember = "Id";
        }

        private void ReportTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool attendanceSelected = reportTypeComboBox.SelectedItem.ToString() == "Attendance";
            courseSelectionLabel.Visible = attendanceSelected;
            courseSelectionComboBox.Visible = attendanceSelected;
        }

        private void generateReportButton_Click(object sender, EventArgs e)
        {
            var reportType = reportTypeComboBox.SelectedItem.ToString();
            string courseId = reportType == "Attendance" ? courseSelectionComboBox.SelectedValue.ToString() : null;
            _currentReportHtml = ReportManager.GenerateReport(reportType, startDatePicker.Value, endDatePicker.Value, courseId);
            reportWebBrowser.DocumentText = _currentReportHtml;
        }

        private void exportExcelButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentReportHtml))
            {
                MessageBox.Show("Lütfen önce bir rapor oluşturun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Dosyaları (*.xlsx)|*.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ReportManager.ExportToExcel(reportTypeComboBox.SelectedItem.ToString(), startDatePicker.Value, endDatePicker.Value, sfd.FileName, courseSelectionComboBox.SelectedValue?.ToString());
                    MessageBox.Show("Rapor Excel'e aktarıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void exportPdfButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentReportHtml))
            {
                MessageBox.Show("Lütfen önce bir rapor oluşturun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF Dosyaları (*.pdf)|*.pdf";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ReportManager.ExportToPdf(_currentReportHtml, sfd.FileName);
                    MessageBox.Show("Rapor PDF'e aktarıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void exportTxtButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentReportHtml))
            {
                MessageBox.Show("Lütfen önce bir rapor oluşturun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Metin Dosyaları (*.txt)|*.txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ReportManager.ExportToTxt(reportTypeComboBox.SelectedItem.ToString(), startDatePicker.Value, endDatePicker.Value, sfd.FileName, courseSelectionComboBox.SelectedValue?.ToString());
                    MessageBox.Show("Rapor TXT'e aktarıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}

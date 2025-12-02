using System.Drawing;
using System.Windows.Forms;

namespace KursYonetimSistemi.UI.Controls
{
    public partial class CalendarDayControl : UserControl
    {
        public CalendarDayControl()
        {
            InitializeComponent();
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        public void SetDay(int day, bool isOtherMonth)
        {
            dayLabel.Text = day.ToString();
            if (isOtherMonth)
            {
                this.BackColor = SystemColors.ControlLight;
                dayLabel.ForeColor = SystemColors.GrayText;
            }
        }

        public void AddSchedule(string scheduleText)
        {
            var scheduleLabel = new Label
            {
                Text = scheduleText,
                Dock = DockStyle.Top,
                AutoSize = true,
                BackColor = Color.LightBlue,
                Margin = new Padding(1)
            };
            schedulesPanel.Controls.Add(scheduleLabel);
        }
    }
}

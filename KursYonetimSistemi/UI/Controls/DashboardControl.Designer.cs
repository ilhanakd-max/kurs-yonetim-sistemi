namespace KursYonetimSistemi.UI.Controls
{
    partial class DashboardControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.mainLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.totalCoursesLabel = new System.Windows.Forms.Label();
            this.totalWorkshopsLabel = new System.Windows.Forms.Label();
            this.totalTeachersLabel = new System.Windows.Forms.Label();
            this.totalStudentsLabel = new System.Windows.Forms.Label();
            this.weeklyLessonsLabel = new System.Windows.Forms.Label();
            this.upcomingHolidaysLabel = new System.Windows.Forms.Label();

            this.mainLayout.SuspendLayout();
            this.SuspendLayout();

            // mainLayout
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.mainLayout.Controls.Add(this.totalCoursesLabel);
            this.mainLayout.Controls.Add(this.totalWorkshopsLabel);
            this.mainLayout.Controls.Add(this.totalTeachersLabel);
            this.mainLayout.Controls.Add(this.totalStudentsLabel);
            this.mainLayout.Controls.Add(this.weeklyLessonsLabel);
            this.mainLayout.Controls.Add(this.upcomingHolidaysLabel);
            this.mainLayout.Controls.Add(this.liveLessonPanel);

            // liveLessonPanel
            this.liveLessonPanel.Size = new System.Drawing.Size(400, 200);
            this.liveLessonPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // totalCoursesLabel
            this.totalCoursesLabel.Text = "Aktif Kurs: 0";
            // totalWorkshopsLabel
            this.totalWorkshopsLabel.Text = "Atölye: 0";
            // totalTeachersLabel
            this.totalTeachersLabel.Text = "Eğitmen: 0";
            // totalStudentsLabel
            this.totalStudentsLabel.Text = "Öğrenci: 0";
            // weeklyLessonsLabel
            this.weeklyLessonsLabel.Text = "Haftalık Ders: 0";
            // upcomingHolidaysLabel
            this.upcomingHolidaysLabel.Text = "Yaklaşan Tatil: 0";

            this.Controls.Add(this.mainLayout);
            this.Name = "DashboardControl";

            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.FlowLayoutPanel mainLayout;
        private System.Windows.Forms.Label totalCoursesLabel;
        private System.Windows.Forms.Label totalWorkshopsLabel;
        private System.Windows.Forms.Label totalTeachersLabel;
        private System.Windows.Forms.Label totalStudentsLabel;
        private System.Windows.Forms.Label weeklyLessonsLabel;
        private System.Windows.Forms.Label upcomingHolidaysLabel;
        private System.Windows.Forms.Panel liveLessonPanel;
    }
}

namespace KursYonetimSistemi.UI.Forms
{
    partial class MainForm
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
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.dashboardTab = new System.Windows.Forms.TabPage();
            this.scheduleTab = new System.Windows.Forms.TabPage();
            this.coursesTab = new System.Windows.Forms.TabPage();
            this.workshopsTab = new System.Windows.Forms.TabPage();
            this.teachersTab = new System.Windows.Forms.TabPage();
            this.studentsTab = new System.Windows.Forms.TabPage();
            this.holidaysTab = new System.Windows.Forms.TabPage();
            this.reportsTab = new System.Windows.Forms.TabPage();
            this.settingsTab = new System.Windows.Forms.TabPage();

            this.mainTabControl.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();

            //
            // mainMenuStrip
            //
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1200, 24);
            this.mainMenuStrip.TabIndex = 1;
            this.mainMenuStrip.Text = "mainMenuStrip";
            //
            // fileToolStripMenuItem
            //
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveDataToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.fileToolStripMenuItem.Text = "Dosya";
            //
            // saveDataToolStripMenuItem
            //
            this.saveDataToolStripMenuItem.Name = "saveDataToolStripMenuItem";
            this.saveDataToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveDataToolStripMenuItem.Text = "Verileri Kaydet";
            //
            // exitToolStripMenuItem
            //
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Çıkış";
            //
            // helpToolStripMenuItem
            //
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.helpToolStripMenuItem.Text = "Yardım";
            //
            // aboutToolStripMenuItem
            //
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "Hakkında";

            // mainTabControl
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Controls.Add(this.dashboardTab);
            this.mainTabControl.Controls.Add(this.scheduleTab);
            this.mainTabControl.Controls.Add(this.coursesTab);
            this.mainTabControl.Controls.Add(this.workshopsTab);
            this.mainTabControl.Controls.Add(this.teachersTab);
            this.mainTabControl.Controls.Add(this.studentsTab);
            this.mainTabControl.Controls.Add(this.holidaysTab);
            this.mainTabControl.Controls.Add(this.reportsTab);
            this.mainTabControl.Controls.Add(this.settingsTab);

            // dashboardTab
            this.dashboardTab.Text = "📊 Gösterge Paneli";
            this.dashboardControl = new KursYonetimSistemi.UI.Controls.DashboardControl();
            this.dashboardControl.Name = "dashboardControl";
            this.dashboardTab.Controls.Add(this.dashboardControl);
            this.dashboardControl.Dock = System.Windows.Forms.DockStyle.Fill;
            // scheduleTab
            this.scheduleTab.Text = "📅 Program";
            this.scheduleControl = new KursYonetimSistemi.UI.Controls.ScheduleControl();
            this.scheduleControl.Name = "scheduleControl";
            this.scheduleTab.Controls.Add(this.scheduleControl);
            this.scheduleControl.Dock = System.Windows.Forms.DockStyle.Fill;
            // coursesTab
            this.coursesTab.Text = "📚 Kurslar";
            this.coursesControl = new KursYonetimSistemi.UI.Controls.CoursesControl();
            this.coursesControl.Name = "coursesControl";
            this.coursesTab.Controls.Add(this.coursesControl);
            this.coursesControl.Dock = System.Windows.Forms.DockStyle.Fill;
            // workshopsTab
            this.workshopsTab.Text = "🏢 Atölyeler";
            this.workshopsControl = new KursYonetimSistemi.UI.Controls.WorkshopsControl();
            this.workshopsControl.Name = "workshopsControl";
            this.workshopsTab.Controls.Add(this.workshopsControl);
            this.workshopsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            // teachersTab
            this.teachersTab.Text = "👨‍🏫 Eğitmenler";
            this.teachersControl = new KursYonetimSistemi.UI.Controls.TeachersControl();
            this.teachersControl.Name = "teachersControl";
            this.teachersTab.Controls.Add(this.teachersControl);
            this.teachersControl.Dock = System.Windows.Forms.DockStyle.Fill;
            // studentsTab
            this.studentsTab.Text = "👨‍🎓 Öğrenciler";
            this.studentsControl = new KursYonetimSistemi.UI.Controls.StudentsControl();
            this.studentsControl.Name = "studentsControl";
            this.studentsTab.Controls.Add(this.studentsControl);
            this.studentsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            // holidaysTab
            this.holidaysTab.Text = "🎌 Tatiller";
            this.holidaysControl = new KursYonetimSistemi.UI.Controls.HolidaysControl();
            this.holidaysControl.Name = "holidaysControl";
            this.holidaysTab.Controls.Add(this.holidaysControl);
            this.holidaysControl.Dock = System.Windows.Forms.DockStyle.Fill;
            // reportsTab
            this.reportsTab.Text = "📈 Raporlar";
            this.reportsControl = new KursYonetimSistemi.UI.Controls.ReportsControl();
            this.reportsTab.Controls.Add(this.reportsControl);
            this.reportsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            // settingsTab
            this.settingsTab.Text = "⚙️ Ayarlar";
            this.settingsControl = new KursYonetimSistemi.UI.Controls.SettingsControl();
            this.settingsTab.Controls.Add(this.settingsControl);
            this.settingsControl.Dock = System.Windows.Forms.DockStyle.Fill;

            // MainForm
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.Text = "Kurs Yönetim Sistemi";
            this.mainTabControl.ResumeLayout(false);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage dashboardTab;
        private System.Windows.Forms.TabPage scheduleTab;
        private System.Windows.Forms.TabPage coursesTab;
        private System.Windows.Forms.TabPage workshopsTab;
        private System.Windows.Forms.TabPage teachersTab;
        private System.Windows.Forms.TabPage studentsTab;
        private System.Windows.Forms.TabPage holidaysTab;
        private System.Windows.Forms.TabPage reportsTab;
        private System.Windows.Forms.TabPage settingsTab;
        private Controls.DashboardControl dashboardControl;
        private Controls.CoursesControl coursesControl;
        private Controls.WorkshopsControl workshopsControl;
        private Controls.TeachersControl teachersControl;
        private Controls.StudentsControl studentsControl;
        private Controls.HolidaysControl holidaysControl;
        private Controls.ScheduleControl scheduleControl;
        private Controls.ReportsControl reportsControl;
        private Controls.SettingsControl settingsControl;
    }
}

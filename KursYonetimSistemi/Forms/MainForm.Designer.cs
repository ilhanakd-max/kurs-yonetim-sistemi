namespace KursYonetimSistemi.Forms
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageDashboard = new System.Windows.Forms.TabPage();
            this.lblTodayLessons = new System.Windows.Forms.Label();
            this.flowLayoutPanelTodayLessons = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxStats = new System.Windows.Forms.GroupBox();
            this.lblStatTotalStudents = new System.Windows.Forms.Label();
            this.lblStatTotalTeachers = new System.Windows.Forms.Label();
            this.lblStatTotalWorkshops = new System.Windows.Forms.Label();
            this.lblStatTotalCourses = new System.Windows.Forms.Label();
            this.tabPageSchedule = new System.Windows.Forms.TabPage();
            this.btnNewLesson = new System.Windows.Forms.Button();
            this.tableLayoutPanelSchedule = new System.Windows.Forms.TableLayoutPanel();
            this.tabPageCourses = new System.Windows.Forms.TabPage();
            this.btnDeleteCourse = new System.Windows.Forms.Button();
            this.btnEditCourse = new System.Windows.Forms.Button();
            this.btnNewCourse = new System.Windows.Forms.Button();
            this.dataGridViewCourses = new System.Windows.Forms.DataGridView();
            this.tabPageWorkshops = new System.Windows.Forms.TabPage();
            this.btnDeleteWorkshop = new System.Windows.Forms.Button();
            this.btnEditWorkshop = new System.Windows.Forms.Button();
            this.btnNewWorkshop = new System.Windows.Forms.Button();
            this.dataGridViewWorkshops = new System.Windows.Forms.DataGridView();
            this.tabPageTeachers = new System.Windows.Forms.TabPage();
            this.btnDeleteTeacher = new System.Windows.Forms.Button();
            this.btnEditTeacher = new System.Windows.Forms.Button();
            this.btnNewTeacher = new System.Windows.Forms.Button();
            this.dataGridViewTeachers = new System.Windows.Forms.DataGridView();
            this.tabPageStudents = new System.Windows.Forms.TabPage();
            this.btnDeleteStudent = new System.Windows.Forms.Button();
            this.btnEditStudent = new System.Windows.Forms.Button();
            this.btnNewStudent = new System.Windows.Forms.Button();
            this.dataGridViewStudents = new System.Windows.Forms.DataGridView();
            this.tabPageReports = new System.Windows.Forms.TabPage();
            this.btnExportStudents = new System.Windows.Forms.Button();
            this.btnExportTeachers = new System.Windows.Forms.Button();
            this.btnExportWorkshops = new System.Windows.Forms.Button();
            this.btnExportCourses = new System.Windows.Forms.Button();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.btnRestoreData = new System.Windows.Forms.Button();
            this.btnBackupData = new System.Windows.Forms.Button();
            this.tabControlMain.SuspendLayout();
            this.tabPageDashboard.SuspendLayout();
            this.groupBoxStats.SuspendLayout();
            this.tabPageSchedule.SuspendLayout();
            this.tabPageCourses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCourses)).BeginInit();
            this.tabPageWorkshops.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorkshops)).BeginInit();
            this.tabPageTeachers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeachers)).BeginInit();
            this.tabPageStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).BeginInit();
            this.tabPageReports.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.SuspendLayout();
            //
            // tabControlMain
            //
            this.tabControlMain.Controls.Add(this.tabPageDashboard);
            this.tabControlMain.Controls.Add(this.tabPageSchedule);
            this.tabControlMain.Controls.Add(this.tabPageCourses);
            this.tabControlMain.Controls.Add(this.tabPageWorkshops);
            this.tabControlMain.Controls.Add(this.tabPageTeachers);
            this.tabControlMain.Controls.Add(this.tabPageStudents);
            this.tabControlMain.Controls.Add(this.tabPageReports);
            this.tabControlMain.Controls.Add(this.tabPageSettings);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1264, 761);
            this.tabControlMain.TabIndex = 0;
            //
            // tabPageDashboard
            //
            this.tabPageDashboard.Controls.Add(this.lblTodayLessons);
            this.tabPageDashboard.Controls.Add(this.flowLayoutPanelTodayLessons);
            this.tabPageDashboard.Controls.Add(this.groupBoxStats);
            this.tabPageDashboard.Location = new System.Drawing.Point(4, 24);
            this.tabPageDashboard.Name = "tabPageDashboard";
            this.tabPageDashboard.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDashboard.Size = new System.Drawing.Size(1256, 733);
            this.tabPageDashboard.TabIndex = 0;
            this.tabPageDashboard.Text = "Gösterge Paneli";
            this.tabPageDashboard.UseVisualStyleBackColor = true;
            //
            // lblTodayLessons
            //
            this.lblTodayLessons.AutoSize = true;
            this.lblTodayLessons.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTodayLessons.Location = new System.Drawing.Point(23, 140);
            this.lblTodayLessons.Name = "lblTodayLessons";
            this.lblTodayLessons.Size = new System.Drawing.Size(147, 25);
            this.lblTodayLessons.TabIndex = 2;
            this.lblTodayLessons.Text = "Bugünün Dersleri";
            //
            // flowLayoutPanelTodayLessons
            //
            this.flowLayoutPanelTodayLessons.AutoScroll = true;
            this.flowLayoutPanelTodayLessons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelTodayLessons.Location = new System.Drawing.Point(23, 168);
            this.flowLayoutPanelTodayLessons.Name = "flowLayoutPanelTodayLessons";
            this.flowLayoutPanelTodayLessons.Size = new System.Drawing.Size(1207, 549);
            this.flowLayoutPanelTodayLessons.TabIndex = 1;
            this.flowLayoutPanelTodayLessons.WrapContents = false;
            //
            // groupBoxStats
            //
            this.groupBoxStats.Controls.Add(this.lblStatTotalStudents);
            this.groupBoxStats.Controls.Add(this.lblStatTotalTeachers);
            this.groupBoxStats.Controls.Add(this.lblStatTotalWorkshops);
            this.groupBoxStats.Controls.Add(this.lblStatTotalCourses);
            this.groupBoxStats.Location = new System.Drawing.Point(23, 22);
            this.groupBoxStats.Name = "groupBoxStats";
            this.groupBoxStats.Size = new System.Drawing.Size(1207, 100);
            this.groupBoxStats.TabIndex = 0;
            this.groupBoxStats.TabStop = false;
            this.groupBoxStats.Text = "İstatistikler";
            //
            // lblStatTotalStudents
            //
            this.lblStatTotalStudents.AutoSize = true;
            this.lblStatTotalStudents.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatTotalStudents.Location = new System.Drawing.Point(340, 40);
            this.lblStatTotalStudents.Name = "lblStatTotalStudents";
            this.lblStatTotalStudents.Size = new System.Drawing.Size(127, 21);
            this.lblStatTotalStudents.TabIndex = 3;
            this.lblStatTotalStudents.Text = "Toplam Öğrenci: 0";
            //
            // lblStatTotalTeachers
            //
            this.lblStatTotalTeachers.AutoSize = true;
            this.lblStatTotalTeachers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatTotalTeachers.Location = new System.Drawing.Point(220, 40);
            this.lblStatTotalTeachers.Name = "lblStatTotalTeachers";
            this.lblStatTotalTeachers.Size = new System.Drawing.Size(134, 21);
            this.lblStatTotalTeachers.TabIndex = 2;
            this.lblStatTotalTeachers.Text = "Toplam Eğitmen: 0";
            //
            // lblStatTotalWorkshops
            //
            this.lblStatTotalWorkshops.AutoSize = true;
            this.lblStatTotalWorkshops.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatTotalWorkshops.Location = new System.Drawing.Point(100, 40);
            this.lblStatTotalWorkshops.Name = "lblStatTotalWorkshops";
            this.lblStatTotalWorkshops.Size = new System.Drawing.Size(120, 21);
            this.lblStatTotalWorkshops.TabIndex = 1;
            this.lblStatTotalWorkshops.Text = "Toplam Atölye: 0";
            //
            // lblStatTotalCourses
            //
            this.lblStatTotalCourses.AutoSize = true;
            this.lblStatTotalCourses.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatTotalCourses.Location = new System.Drawing.Point(20, 40);
            this.lblStatTotalCourses.Name = "lblStatTotalCourses";
            this.lblStatTotalCourses.Size = new System.Drawing.Size(104, 21);
            this.lblStatTotalCourses.TabIndex = 0;
            this.lblStatTotalCourses.Text = "Toplam Kurs: 0";
            //
            // tabPageSchedule
            //
            this.tabPageSchedule.Controls.Add(this.btnNewLesson);
            this.tabPageSchedule.Controls.Add(this.tableLayoutPanelSchedule);
            this.tabPageSchedule.Location = new System.Drawing.Point(4, 24);
            this.tabPageSchedule.Name = "tabPageSchedule";
            this.tabPageSchedule.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSchedule.Size = new System.Drawing.Size(1256, 733);
            this.tabPageSchedule.TabIndex = 1;
            this.tabPageSchedule.Text = "Program";
            this.tabPageSchedule.UseVisualStyleBackColor = true;
            //
            // btnNewLesson
            //
            this.btnNewLesson.Location = new System.Drawing.Point(8, 6);
            this.btnNewLesson.Name = "btnNewLesson";
            this.btnNewLesson.Size = new System.Drawing.Size(111, 23);
            this.btnNewLesson.TabIndex = 1;
            this.btnNewLesson.Text = "Yeni Ders Ekle";
            this.btnNewLesson.UseVisualStyleBackColor = true;
            //
            // tableLayoutPanelSchedule
            //
            this.tableLayoutPanelSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelSchedule.AutoScroll = true;
            this.tableLayoutPanelSchedule.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelSchedule.ColumnCount = 8;
            this.tableLayoutPanelSchedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelSchedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanelSchedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanelSchedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanelSchedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanelSchedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanelSchedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanelSchedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanelSchedule.Location = new System.Drawing.Point(8, 35);
            this.tableLayoutPanelSchedule.Name = "tableLayoutPanelSchedule";
            this.tableLayoutPanelSchedule.RowCount = 1;
            this.tableLayoutPanelSchedule.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSchedule.Size = new System.Drawing.Size(1240, 690);
            this.tableLayoutPanelSchedule.TabIndex = 0;
            //
            // tabPageCourses
            //
            this.tabPageCourses.Controls.Add(this.btnDeleteCourse);
            this.tabPageCourses.Controls.Add(this.btnEditCourse);
            this.tabPageCourses.Controls.Add(this.btnNewCourse);
            this.tabPageCourses.Controls.Add(this.dataGridViewCourses);
            this.tabPageCourses.Location = new System.Drawing.Point(4, 24);
            this.tabPageCourses.Name = "tabPageCourses";
            this.tabPageCourses.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCourses.Size = new System.Drawing.Size(1256, 733);
            this.tabPageCourses.TabIndex = 2;
            this.tabPageCourses.Text = "Kurslar";
            this.tabPageCourses.UseVisualStyleBackColor = true;
            //
            // btnDeleteCourse
            //
            this.btnDeleteCourse.Location = new System.Drawing.Point(190, 6);
            this.btnDeleteCourse.Name = "btnDeleteCourse";
            this.btnDeleteCourse.Size = new System.Drawing.Size(85, 23);
            this.btnDeleteCourse.TabIndex = 3;
            this.btnDeleteCourse.Text = "Sil";
            this.btnDeleteCourse.UseVisualStyleBackColor = true;
            //
            // btnEditCourse
            //
            this.btnEditCourse.Location = new System.Drawing.Point(99, 6);
            this.btnEditCourse.Name = "btnEditCourse";
            this.btnEditCourse.Size = new System.Drawing.Size(85, 23);
            this.btnEditCourse.TabIndex = 2;
            this.btnEditCourse.Text = "Düzenle";
            this.btnEditCourse.UseVisualStyleBackColor = true;
            //
            // btnNewCourse
            //
            this.btnNewCourse.Location = new System.Drawing.Point(8, 6);
            this.btnNewCourse.Name = "btnNewCourse";
            this.btnNewCourse.Size = new System.Drawing.Size(85, 23);
            this.btnNewCourse.TabIndex = 1;
            this.btnNewCourse.Text = "Yeni Ekle";
            this.btnNewCourse.UseVisualStyleBackColor = true;
            //
            // dataGridViewCourses
            //
            this.dataGridViewCourses.AllowUserToAddRows = false;
            this.dataGridViewCourses.AllowUserToDeleteRows = false;
            this.dataGridViewCourses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewCourses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCourses.Location = new System.Drawing.Point(8, 35);
            this.dataGridViewCourses.MultiSelect = false;
            this.dataGridViewCourses.Name = "dataGridViewCourses";
            this.dataGridViewCourses.ReadOnly = true;
            this.dataGridViewCourses.RowTemplate.Height = 25;
            this.dataGridViewCourses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCourses.Size = new System.Drawing.Size(1240, 690);
            this.dataGridViewCourses.TabIndex = 0;
            //
            // tabPageWorkshops
            //
            this.tabPageWorkshops.Controls.Add(this.btnDeleteWorkshop);
            this.tabPageWorkshops.Controls.Add(this.btnEditWorkshop);
            this.tabPageWorkshops.Controls.Add(this.btnNewWorkshop);
            this.tabPageWorkshops.Controls.Add(this.dataGridViewWorkshops);
            this.tabPageWorkshops.Location = new System.Drawing.Point(4, 24);
            this.tabPageWorkshops.Name = "tabPageWorkshops";
            this.tabPageWorkshops.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWorkshops.Size = new System.Drawing.Size(1256, 733);
            this.tabPageWorkshops.TabIndex = 3;
            this.tabPageWorkshops.Text = "Atölyeler";
            this.tabPageWorkshops.UseVisualStyleBackColor = true;
            //
            // btnDeleteWorkshop
            //
            this.btnDeleteWorkshop.Location = new System.Drawing.Point(190, 6);
            this.btnDeleteWorkshop.Name = "btnDeleteWorkshop";
            this.btnDeleteWorkshop.Size = new System.Drawing.Size(85, 23);
            this.btnDeleteWorkshop.TabIndex = 6;
            this.btnDeleteWorkshop.Text = "Sil";
            this.btnDeleteWorkshop.UseVisualStyleBackColor = true;
            //
            // btnEditWorkshop
            //
            this.btnEditWorkshop.Location = new System.Drawing.Point(99, 6);
            this.btnEditWorkshop.Name = "btnEditWorkshop";
            this.btnEditWorkshop.Size = new System.Drawing.Size(85, 23);
            this.btnEditWorkshop.TabIndex = 5;
            this.btnEditWorkshop.Text = "Düzenle";
            this.btnEditWorkshop.UseVisualStyleBackColor = true;
            //
            // btnNewWorkshop
            //
            this.btnNewWorkshop.Location = new System.Drawing.Point(8, 6);
            this.btnNewWorkshop.Name = "btnNewWorkshop";
            this.btnNewWorkshop.Size = new System.Drawing.Size(85, 23);
            this.btnNewWorkshop.TabIndex = 4;
            this.btnNewWorkshop.Text = "Yeni Ekle";
            this.btnNewWorkshop.UseVisualStyleBackColor = true;
            //
            // dataGridViewWorkshops
            //
            this.dataGridViewWorkshops.AllowUserToAddRows = false;
            this.dataGridViewWorkshops.AllowUserToDeleteRows = false;
            this.dataGridViewWorkshops.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewWorkshops.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewWorkshops.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWorkshops.Location = new System.Drawing.Point(8, 35);
            this.dataGridViewWorkshops.MultiSelect = false;
            this.dataGridViewWorkshops.Name = "dataGridViewWorkshops";
            this.dataGridViewWorkshops.ReadOnly = true;
            this.dataGridViewWorkshops.RowTemplate.Height = 25;
            this.dataGridViewWorkshops.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewWorkshops.Size = new System.Drawing.Size(1240, 690);
            this.dataGridViewWorkshops.TabIndex = 1;
            //
            // tabPageTeachers
            //
            this.tabPageTeachers.Controls.Add(this.btnDeleteTeacher);
            this.tabPageTeachers.Controls.Add(this.btnEditTeacher);
            this.tabPageTeachers.Controls.Add(this.btnNewTeacher);
            this.tabPageTeachers.Controls.Add(this.dataGridViewTeachers);
            this.tabPageTeachers.Location = new System.Drawing.Point(4, 24);
            this.tabPageTeachers.Name = "tabPageTeachers";
            this.tabPageTeachers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTeachers.Size = new System.Drawing.Size(1256, 733);
            this.tabPageTeachers.TabIndex = 4;
            this.tabPageTeachers.Text = "Eğitmenler";
            this.tabPageTeachers.UseVisualStyleBackColor = true;
            //
            // btnDeleteTeacher
            //
            this.btnDeleteTeacher.Location = new System.Drawing.Point(190, 6);
            this.btnDeleteTeacher.Name = "btnDeleteTeacher";
            this.btnDeleteTeacher.Size = new System.Drawing.Size(85, 23);
            this.btnDeleteTeacher.TabIndex = 6;
            this.btnDeleteTeacher.Text = "Sil";
            this.btnDeleteTeacher.UseVisualStyleBackColor = true;
            //
            // btnEditTeacher
            //
            this.btnEditTeacher.Location = new System.Drawing.Point(99, 6);
            this.btnEditTeacher.Name = "btnEditTeacher";
            this.btnEditTeacher.Size = new System.Drawing.Size(85, 23);
            this.btnEditTeacher.TabIndex = 5;
            this.btnEditTeacher.Text = "Düzenle";
            this.btnEditTeacher.UseVisualStyleBackColor = true;
            //
            // btnNewTeacher
            //
            this.btnNewTeacher.Location = new System.Drawing.Point(8, 6);
            this.btnNewTeacher.Name = "btnNewTeacher";
            this.btnNewTeacher.Size = new System.Drawing.Size(85, 23);
            this.btnNewTeacher.TabIndex = 4;
            this.btnNewTeacher.Text = "Yeni Ekle";
            this.btnNewTeacher.UseVisualStyleBackColor = true;
            //
            // dataGridViewTeachers
            //
            this.dataGridViewTeachers.AllowUserToAddRows = false;
            this.dataGridViewTeachers.AllowUserToDeleteRows = false;
            this.dataGridViewTeachers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTeachers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTeachers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTeachers.Location = new System.Drawing.Point(8, 35);
            this.dataGridViewTeachers.MultiSelect = false;
            this.dataGridViewTeachers.Name = "dataGridViewTeachers";
            this.dataGridViewTeachers.ReadOnly = true;
            this.dataGridViewTeachers.RowTemplate.Height = 25;
            this.dataGridViewTeachers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTeachers.Size = new System.Drawing.Size(1240, 690);
            this.dataGridViewTeachers.TabIndex = 1;
            //
            // tabPageStudents
            //
            this.tabPageStudents.Controls.Add(this.btnDeleteStudent);
            this.tabPageStudents.Controls.Add(this.btnEditStudent);
            this.tabPageStudents.Controls.Add(this.btnNewStudent);
            this.tabPageStudents.Controls.Add(this.dataGridViewStudents);
            this.tabPageStudents.Location = new System.Drawing.Point(4, 24);
            this.tabPageStudents.Name = "tabPageStudents";
            this.tabPageStudents.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStudents.Size = new System.Drawing.Size(1256, 733);
            this.tabPageStudents.TabIndex = 5;
            this.tabPageStudents.Text = "Öğrenciler";
            this.tabPageStudents.UseVisualStyleBackColor = true;
            //
            // btnDeleteStudent
            //
            this.btnDeleteStudent.Location = new System.Drawing.Point(190, 6);
            this.btnDeleteStudent.Name = "btnDeleteStudent";
            this.btnDeleteStudent.Size = new System.Drawing.Size(85, 23);
            this.btnDeleteStudent.TabIndex = 6;
            this.btnDeleteStudent.Text = "Sil";
            this.btnDeleteStudent.UseVisualStyleBackColor = true;
            //
            // btnEditStudent
            //
            this.btnEditStudent.Location = new System.Drawing.Point(99, 6);
            this.btnEditStudent.Name = "btnEditStudent";
            this.btnEditStudent.Size = new System.Drawing.Size(85, 23);
            this.btnEditStudent.TabIndex = 5;
            this.btnEditStudent.Text = "Düzenle";
            this.btnEditStudent.UseVisualStyleBackColor = true;
            //
            // btnNewStudent
            //
            this.btnNewStudent.Location = new System.Drawing.Point(8, 6);
            this.btnNewStudent.Name = "btnNewStudent";
            this.btnNewStudent.Size = new System.Drawing.Size(85, 23);
            this.btnNewStudent.TabIndex = 4;
            this.btnNewStudent.Text = "Yeni Ekle";
            this.btnNewStudent.UseVisualStyleBackColor = true;
            //
            // dataGridViewStudents
            //
            this.dataGridViewStudents.AllowUserToAddRows = false;
            this.dataGridViewStudents.AllowUserToDeleteRows = false;
            this.dataGridViewStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudents.Location = new System.Drawing.Point(8, 35);
            this.dataGridViewStudents.MultiSelect = false;
            this.dataGridViewStudents.Name = "dataGridViewStudents";
            this.dataGridViewStudents.ReadOnly = true;
            this.dataGridViewStudents.RowTemplate.Height = 25;
            this.dataGridViewStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStudents.Size = new System.Drawing.Size(1240, 690);
            this.dataGridViewStudents.TabIndex = 1;
            //
            // tabPageReports
            //
            this.tabPageReports.Controls.Add(this.btnExportStudents);
            this.tabPageReports.Controls.Add(this.btnExportTeachers);
            this.tabPageReports.Controls.Add(this.btnExportWorkshops);
            this.tabPageReports.Controls.Add(this.btnExportCourses);
            this.tabPageReports.Location = new System.Drawing.Point(4, 24);
            this.tabPageReports.Name = "tabPageReports";
            this.tabPageReports.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReports.Size = new System.Drawing.Size(1256, 733);
            this.tabPageReports.TabIndex = 6;
            this.tabPageReports.Text = "Raporlar";
            this.tabPageReports.UseVisualStyleBackColor = true;
            //
            // btnExportStudents
            //
            this.btnExportStudents.Location = new System.Drawing.Point(23, 110);
            this.btnExportStudents.Name = "btnExportStudents";
            this.btnExportStudents.Size = new System.Drawing.Size(200, 23);
            this.btnExportStudents.TabIndex = 3;
            this.btnExportStudents.Text = "Öğrenci Listesini Dışa Aktar (CSV)";
            this.btnExportStudents.UseVisualStyleBackColor = true;
            //
            // btnExportTeachers
            //
            this.btnExportTeachers.Location = new System.Drawing.Point(23, 81);
            this.btnExportTeachers.Name = "btnExportTeachers";
            this.btnExportTeachers.Size = new System.Drawing.Size(200, 23);
            this.btnExportTeachers.TabIndex = 2;
            this.btnExportTeachers.Text = "Eğitmen Listesini Dışa Aktar (CSV)";
            this.btnExportTeachers.UseVisualStyleBackColor = true;
            //
            // btnExportWorkshops
            //
            this.btnExportWorkshops.Location = new System.Drawing.Point(23, 52);
            this.btnExportWorkshops.Name = "btnExportWorkshops";
            this.btnExportWorkshops.Size = new System.Drawing.Size(200, 23);
            this.btnExportWorkshops.TabIndex = 1;
            this.btnExportWorkshops.Text = "Atölye Listesini Dışa Aktar (CSV)";
            this.btnExportWorkshops.UseVisualStyleBackColor = true;
            //
            // btnExportCourses
            //
            this.btnExportCourses.Location = new System.Drawing.Point(23, 23);
            this.btnExportCourses.Name = "btnExportCourses";
            this.btnExportCourses.Size = new System.Drawing.Size(200, 23);
            this.btnExportCourses.TabIndex = 0;
            this.btnExportCourses.Text = "Kurs Listesini Dışa Aktar (CSV)";
            this.btnExportCourses.UseVisualStyleBackColor = true;
            //
            // tabPageSettings
            //
            this.tabPageSettings.Controls.Add(this.btnRestoreData);
            this.tabPageSettings.Controls.Add(this.btnBackupData);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 24);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(1256, 733);
            this.tabPageSettings.TabIndex = 7;
            this.tabPageSettings.Text = "Ayarlar";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            //
            // btnRestoreData
            //
            this.btnRestoreData.Location = new System.Drawing.Point(23, 52);
            this.btnRestoreData.Name = "btnRestoreData";
            this.btnRestoreData.Size = new System.Drawing.Size(150, 23);
            this.btnRestoreData.TabIndex = 1;
            this.btnRestoreData.Text = "Verileri İçe Aktar (Yedek)";
            this.btnRestoreData.UseVisualStyleBackColor = true;
            //
            // btnBackupData
            //
            this.btnBackupData.Location = new System.Drawing.Point(23, 23);
            this.btnBackupData.Name = "btnBackupData";
            this.btnBackupData.Size = new System.Drawing.Size(150, 23);
            this.btnBackupData.TabIndex = 0;
            this.btnBackupData.Text = "Verileri Dışa Aktar (Yedek)";
            this.btnBackupData.UseVisualStyleBackColor = true;
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.tabControlMain);
            this.Name = "MainForm";
            this.Text = "Kurs Yönetim Sistemi";
            this.tabControlMain.ResumeLayout(false);
            this.tabPageDashboard.ResumeLayout(false);
            this.tabPageDashboard.PerformLayout();
            this.groupBoxStats.ResumeLayout(false);
            this.groupBoxStats.PerformLayout();
            this.tabPageSchedule.ResumeLayout(false);
            this.tabPageCourses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCourses)).EndInit();
            this.tabPageWorkshops.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorkshops)).EndInit();
            this.tabPageTeachers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeachers)).EndInit();
            this.tabPageStudents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).EndInit();
            this.tabPageReports.ResumeLayout(false);
            this.tabPageSettings.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageDashboard;
        private System.Windows.Forms.TabPage tabPageSchedule;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSchedule;
        private System.Windows.Forms.TabPage tabPageCourses;
        private System.Windows.Forms.DataGridView dataGridViewCourses;
        private System.Windows.Forms.TabPage tabPageWorkshops;
        private System.Windows.Forms.DataGridView dataGridViewWorkshops;
        private System.Windows.Forms.TabPage tabPageTeachers;
        private System.Windows.Forms.DataGridView dataGridViewTeachers;
        private System.Windows.Forms.TabPage tabPageStudents;
        private System.Windows.Forms.DataGridView dataGridViewStudents;
        private System.Windows.Forms.TabPage tabPageReports;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.Button btnNewCourse;
        private System.Windows.Forms.Button btnEditCourse;
        private System.Windows.Forms.Button btnDeleteCourse;
        private System.Windows.Forms.Button btnDeleteWorkshop;
        private System.Windows.Forms.Button btnEditWorkshop;
        private System.Windows.Forms.Button btnNewWorkshop;
        private System.Windows.Forms.Button btnDeleteTeacher;
        private System.Windows.Forms.Button btnEditTeacher;
        private System.Windows.Forms.Button btnNewTeacher;
        private System.Windows.Forms.Button btnDeleteStudent;
        private System.Windows.Forms.Button btnEditStudent;
        private System.Windows.Forms.Button btnNewStudent;
        private System.Windows.Forms.Button btnNewLesson;
        private System.Windows.Forms.Button btnBackupData;
        private System.Windows.Forms.Button btnRestoreData;
        private System.Windows.Forms.Button btnExportCourses;
        private System.Windows.Forms.Button btnExportStudents;
        private System.Windows.Forms.Button btnExportTeachers;
        private System.Windows.Forms.Button btnExportWorkshops;
        private System.Windows.Forms.GroupBox groupBoxStats;
        private System.Windows.Forms.Label lblStatTotalCourses;
        private System.Windows.Forms.Label lblStatTotalStudents;
        private System.Windows.Forms.Label lblStatTotalTeachers;
        private System.Windows.Forms.Label lblStatTotalWorkshops;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTodayLessons;
        private System.Windows.Forms.Label lblTodayLessons;
    }
}

namespace Abiturient_MPT
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.EnrolleePage = new System.Windows.Forms.TabPage();
            this.deleteEnrolleeButton = new System.Windows.Forms.Button();
            this.editEnrolleeButton = new System.Windows.Forms.Button();
            this.addEnrolleeButton = new System.Windows.Forms.Button();
            this.enrolleeGridView = new System.Windows.Forms.DataGridView();
            this.EnrolleeListPage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.DisciplinesPage = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.SpecialitiesPage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.AchievementsPage = new System.Windows.Forms.TabPage();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.AddAchievementButton = new System.Windows.Forms.Button();
            this.achGridView = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.achRecGridView = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.EnrolleePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.enrolleeGridView)).BeginInit();
            this.EnrolleeListPage.SuspendLayout();
            this.DisciplinesPage.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.SpecialitiesPage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.AchievementsPage.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.achGridView)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.achRecGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.EnrolleePage);
            this.tabControl1.Controls.Add(this.EnrolleeListPage);
            this.tabControl1.Controls.Add(this.DisciplinesPage);
            this.tabControl1.Controls.Add(this.SpecialitiesPage);
            this.tabControl1.Controls.Add(this.AchievementsPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 48);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1011, 642);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // EnrolleePage
            // 
            this.EnrolleePage.Controls.Add(this.deleteEnrolleeButton);
            this.EnrolleePage.Controls.Add(this.editEnrolleeButton);
            this.EnrolleePage.Controls.Add(this.addEnrolleeButton);
            this.EnrolleePage.Controls.Add(this.enrolleeGridView);
            this.EnrolleePage.Location = new System.Drawing.Point(4, 22);
            this.EnrolleePage.Name = "EnrolleePage";
            this.EnrolleePage.Padding = new System.Windows.Forms.Padding(3);
            this.EnrolleePage.Size = new System.Drawing.Size(1003, 616);
            this.EnrolleePage.TabIndex = 0;
            this.EnrolleePage.Text = "Абитуриенты";
            this.EnrolleePage.UseVisualStyleBackColor = true;
            // 
            // deleteEnrolleeButton
            // 
            this.deleteEnrolleeButton.Location = new System.Drawing.Point(909, 115);
            this.deleteEnrolleeButton.Name = "deleteEnrolleeButton";
            this.deleteEnrolleeButton.Size = new System.Drawing.Size(75, 23);
            this.deleteEnrolleeButton.TabIndex = 3;
            this.deleteEnrolleeButton.Text = "Удалить";
            this.deleteEnrolleeButton.UseVisualStyleBackColor = true;
            this.deleteEnrolleeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // editEnrolleeButton
            // 
            this.editEnrolleeButton.Location = new System.Drawing.Point(909, 67);
            this.editEnrolleeButton.Name = "editEnrolleeButton";
            this.editEnrolleeButton.Size = new System.Drawing.Size(75, 23);
            this.editEnrolleeButton.TabIndex = 2;
            this.editEnrolleeButton.Text = "Изменить";
            this.editEnrolleeButton.UseVisualStyleBackColor = true;
            this.editEnrolleeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // addEnrolleeButton
            // 
            this.addEnrolleeButton.Location = new System.Drawing.Point(909, 24);
            this.addEnrolleeButton.Name = "addEnrolleeButton";
            this.addEnrolleeButton.Size = new System.Drawing.Size(75, 23);
            this.addEnrolleeButton.TabIndex = 1;
            this.addEnrolleeButton.Text = "Добавить";
            this.addEnrolleeButton.UseVisualStyleBackColor = true;
            this.addEnrolleeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // enrolleeGridView
            // 
            this.enrolleeGridView.AllowUserToAddRows = false;
            this.enrolleeGridView.AllowUserToDeleteRows = false;
            this.enrolleeGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.enrolleeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.enrolleeGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.enrolleeGridView.Location = new System.Drawing.Point(15, 15);
            this.enrolleeGridView.MultiSelect = false;
            this.enrolleeGridView.Name = "enrolleeGridView";
            this.enrolleeGridView.Size = new System.Drawing.Size(880, 595);
            this.enrolleeGridView.TabIndex = 0;
            // 
            // EnrolleeListPage
            // 
            this.EnrolleeListPage.Controls.Add(this.label1);
            this.EnrolleeListPage.Controls.Add(this.comboBox1);
            this.EnrolleeListPage.Location = new System.Drawing.Point(4, 22);
            this.EnrolleeListPage.Name = "EnrolleeListPage";
            this.EnrolleeListPage.Padding = new System.Windows.Forms.Padding(3);
            this.EnrolleeListPage.Size = new System.Drawing.Size(1003, 616);
            this.EnrolleeListPage.TabIndex = 1;
            this.EnrolleeListPage.Text = "Формирование списков на поступление";
            this.EnrolleeListPage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Специальность";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(137, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(346, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // DisciplinesPage
            // 
            this.DisciplinesPage.Controls.Add(this.groupBox4);
            this.DisciplinesPage.Controls.Add(this.groupBox3);
            this.DisciplinesPage.Location = new System.Drawing.Point(4, 22);
            this.DisciplinesPage.Name = "DisciplinesPage";
            this.DisciplinesPage.Size = new System.Drawing.Size(1003, 616);
            this.DisciplinesPage.TabIndex = 2;
            this.DisciplinesPage.Text = "Дисциплины";
            this.DisciplinesPage.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button9);
            this.groupBox4.Controls.Add(this.button8);
            this.groupBox4.Controls.Add(this.button7);
            this.groupBox4.Controls.Add(this.dataGridView5);
            this.groupBox4.Location = new System.Drawing.Point(500, 15);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(475, 580);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Приоритеты и профили";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(182, 31);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 4;
            this.button9.Text = "Удалить";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(101, 31);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 3;
            this.button8.Text = "Изменить";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(20, 31);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 2;
            this.button7.Text = "Добавить";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // dataGridView5
            // 
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Location = new System.Drawing.Point(20, 60);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.Size = new System.Drawing.Size(440, 450);
            this.dataGridView5.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.dataGridView4);
            this.groupBox3.Location = new System.Drawing.Point(15, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(475, 580);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Дисциаплины";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(182, 31);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 3;
            this.button6.Text = "Удалить";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(101, 31);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 2;
            this.button5.Text = "Изменить";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(20, 31);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "Добавить";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // dataGridView4
            // 
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(20, 60);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(440, 450);
            this.dataGridView4.TabIndex = 0;
            // 
            // SpecialitiesPage
            // 
            this.SpecialitiesPage.Controls.Add(this.groupBox2);
            this.SpecialitiesPage.Controls.Add(this.groupBox1);
            this.SpecialitiesPage.Location = new System.Drawing.Point(4, 22);
            this.SpecialitiesPage.Name = "SpecialitiesPage";
            this.SpecialitiesPage.Size = new System.Drawing.Size(1003, 616);
            this.SpecialitiesPage.TabIndex = 3;
            this.SpecialitiesPage.Text = "Специальности";
            this.SpecialitiesPage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button13);
            this.groupBox2.Controls.Add(this.button14);
            this.groupBox2.Controls.Add(this.button15);
            this.groupBox2.Controls.Add(this.dataGridView3);
            this.groupBox2.Location = new System.Drawing.Point(500, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(475, 580);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Специальности";
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(182, 31);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 23);
            this.button13.TabIndex = 6;
            this.button13.Text = "Удалить";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(101, 31);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(75, 23);
            this.button14.TabIndex = 5;
            this.button14.Text = "Изменить";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(20, 31);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(75, 23);
            this.button15.TabIndex = 4;
            this.button15.Text = "Добавить";
            this.button15.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(20, 60);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(440, 450);
            this.dataGridView3.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Controls.Add(this.button11);
            this.groupBox1.Controls.Add(this.button12);
            this.groupBox1.Controls.Add(this.dataGridView2);
            this.groupBox1.Location = new System.Drawing.Point(15, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(475, 580);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Группы специальностей";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(182, 31);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 6;
            this.button10.Text = "Удалить";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(101, 31);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 5;
            this.button11.Text = "Изменить";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(20, 31);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 23);
            this.button12.TabIndex = 4;
            this.button12.Text = "Добавить";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(20, 60);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(440, 450);
            this.dataGridView2.TabIndex = 0;
            // 
            // AchievementsPage
            // 
            this.AchievementsPage.Controls.Add(this.groupBox5);
            this.AchievementsPage.Controls.Add(this.groupBox6);
            this.AchievementsPage.Location = new System.Drawing.Point(4, 22);
            this.AchievementsPage.Name = "AchievementsPage";
            this.AchievementsPage.Size = new System.Drawing.Size(1003, 616);
            this.AchievementsPage.TabIndex = 4;
            this.AchievementsPage.Text = "Достижения";
            this.AchievementsPage.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button16);
            this.groupBox5.Controls.Add(this.button17);
            this.groupBox5.Controls.Add(this.AddAchievementButton);
            this.groupBox5.Controls.Add(this.achGridView);
            this.groupBox5.Location = new System.Drawing.Point(506, 18);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(475, 580);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Словарь достижений";
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(182, 31);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(75, 23);
            this.button16.TabIndex = 6;
            this.button16.Text = "Удалить";
            this.button16.UseVisualStyleBackColor = true;
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(101, 31);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(75, 23);
            this.button17.TabIndex = 5;
            this.button17.Text = "Изменить";
            this.button17.UseVisualStyleBackColor = true;
            // 
            // AddAchievementButton
            // 
            this.AddAchievementButton.Location = new System.Drawing.Point(20, 31);
            this.AddAchievementButton.Name = "AddAchievementButton";
            this.AddAchievementButton.Size = new System.Drawing.Size(75, 23);
            this.AddAchievementButton.TabIndex = 4;
            this.AddAchievementButton.Text = "Добавить";
            this.AddAchievementButton.UseVisualStyleBackColor = true;
            this.AddAchievementButton.Click += new System.EventHandler(this.AddAchievementButton_Click);
            // 
            // achGridView
            // 
            this.achGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.achGridView.Location = new System.Drawing.Point(20, 60);
            this.achGridView.Name = "achGridView";
            this.achGridView.Size = new System.Drawing.Size(440, 450);
            this.achGridView.TabIndex = 1;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button19);
            this.groupBox6.Controls.Add(this.button20);
            this.groupBox6.Controls.Add(this.button21);
            this.groupBox6.Controls.Add(this.achRecGridView);
            this.groupBox6.Location = new System.Drawing.Point(21, 18);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(475, 580);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Врямя учёта";
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(182, 31);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(75, 23);
            this.button19.TabIndex = 6;
            this.button19.Text = "Удалить";
            this.button19.UseVisualStyleBackColor = true;
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(101, 31);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(75, 23);
            this.button20.TabIndex = 5;
            this.button20.Text = "Изменить";
            this.button20.UseVisualStyleBackColor = true;
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(20, 31);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(75, 23);
            this.button21.TabIndex = 4;
            this.button21.Text = "Добавить";
            this.button21.UseVisualStyleBackColor = true;
            // 
            // achRecGridView
            // 
            this.achRecGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.achRecGridView.Location = new System.Drawing.Point(20, 60);
            this.achRecGridView.Name = "achRecGridView";
            this.achRecGridView.Size = new System.Drawing.Size(440, 450);
            this.achRecGridView.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 702);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Абитуриент МПТ";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.EnrolleePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.enrolleeGridView)).EndInit();
            this.EnrolleeListPage.ResumeLayout(false);
            this.EnrolleeListPage.PerformLayout();
            this.DisciplinesPage.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.SpecialitiesPage.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.AchievementsPage.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.achGridView)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.achRecGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage EnrolleePage;
        private System.Windows.Forms.TabPage EnrolleeListPage;
        private System.Windows.Forms.TabPage DisciplinesPage;
        private System.Windows.Forms.TabPage SpecialitiesPage;
        private System.Windows.Forms.Button deleteEnrolleeButton;
        private System.Windows.Forms.Button editEnrolleeButton;
        private System.Windows.Forms.Button addEnrolleeButton;
        private System.Windows.Forms.DataGridView enrolleeGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TabPage AchievementsPage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button AddAchievementButton;
        private System.Windows.Forms.DataGridView achGridView;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.DataGridView achRecGridView;
    }
}


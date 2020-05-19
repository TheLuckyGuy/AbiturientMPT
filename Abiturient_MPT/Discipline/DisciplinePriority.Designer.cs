namespace Abiturient_MPT
{
    partial class DisciplinePriority
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.disciplinePriorityGroupBox = new System.Windows.Forms.GroupBox();
            this.endDateLabel = new System.Windows.Forms.Label();
            this.startDateLabel = new System.Windows.Forms.Label();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.saveButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.priorityUpDown = new System.Windows.Forms.NumericUpDown();
            this.specialityComboBox = new System.Windows.Forms.ComboBox();
            this.disciplineComboBox = new System.Windows.Forms.ComboBox();
            this.priorityLabel = new System.Windows.Forms.Label();
            this.specialityGroupLabel = new System.Windows.Forms.Label();
            this.disciplineLabel = new System.Windows.Forms.Label();
            this.disciplinePriorityGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priorityUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // disciplinePriorityGroupBox
            // 
            this.disciplinePriorityGroupBox.Controls.Add(this.endDateLabel);
            this.disciplinePriorityGroupBox.Controls.Add(this.startDateLabel);
            this.disciplinePriorityGroupBox.Controls.Add(this.endDateTimePicker);
            this.disciplinePriorityGroupBox.Controls.Add(this.startDateTimePicker);
            this.disciplinePriorityGroupBox.Controls.Add(this.saveButton);
            this.disciplinePriorityGroupBox.Controls.Add(this.textBox1);
            this.disciplinePriorityGroupBox.Controls.Add(this.priorityUpDown);
            this.disciplinePriorityGroupBox.Controls.Add(this.specialityComboBox);
            this.disciplinePriorityGroupBox.Controls.Add(this.disciplineComboBox);
            this.disciplinePriorityGroupBox.Controls.Add(this.priorityLabel);
            this.disciplinePriorityGroupBox.Controls.Add(this.specialityGroupLabel);
            this.disciplinePriorityGroupBox.Controls.Add(this.disciplineLabel);
            this.disciplinePriorityGroupBox.Location = new System.Drawing.Point(12, 12);
            this.disciplinePriorityGroupBox.Name = "disciplinePriorityGroupBox";
            this.disciplinePriorityGroupBox.Size = new System.Drawing.Size(510, 337);
            this.disciplinePriorityGroupBox.TabIndex = 0;
            this.disciplinePriorityGroupBox.TabStop = false;
            this.disciplinePriorityGroupBox.Text = "Приоритеты и профили";
            // 
            // endDateLabel
            // 
            this.endDateLabel.AutoSize = true;
            this.endDateLabel.Location = new System.Drawing.Point(280, 244);
            this.endDateLabel.Name = "endDateLabel";
            this.endDateLabel.Size = new System.Drawing.Size(89, 13);
            this.endDateLabel.TabIndex = 11;
            this.endDateLabel.Text = "Дата окончания";
            // 
            // startDateLabel
            // 
            this.startDateLabel.AutoSize = true;
            this.startDateLabel.Location = new System.Drawing.Point(15, 244);
            this.startDateLabel.Name = "startDateLabel";
            this.startDateLabel.Size = new System.Drawing.Size(71, 13);
            this.startDateLabel.TabIndex = 10;
            this.startDateLabel.Text = "Дата начала";
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDateTimePicker.Location = new System.Drawing.Point(393, 241);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(100, 20);
            this.endDateTimePicker.TabIndex = 8;
            this.endDateTimePicker.Value = new System.DateTime(2020, 5, 7, 0, 0, 0, 0);
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDateTimePicker.Location = new System.Drawing.Point(156, 241);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(100, 20);
            this.startDateTimePicker.TabIndex = 9;
            this.startDateTimePicker.Value = new System.DateTime(2020, 5, 9, 0, 0, 0, 0);
            this.startDateTimePicker.ValueChanged += new System.EventHandler(this.startDateTimePicker_ValueChanged);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(418, 298);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(156, 85);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(337, 100);
            this.textBox1.TabIndex = 6;
            // 
            // priorityUpDown
            // 
            this.priorityUpDown.Location = new System.Drawing.Point(156, 200);
            this.priorityUpDown.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.priorityUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.priorityUpDown.Name = "priorityUpDown";
            this.priorityUpDown.Size = new System.Drawing.Size(120, 20);
            this.priorityUpDown.TabIndex = 5;
            this.priorityUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // specialityComboBox
            // 
            this.specialityComboBox.FormattingEnabled = true;
            this.specialityComboBox.Location = new System.Drawing.Point(156, 58);
            this.specialityComboBox.Name = "specialityComboBox";
            this.specialityComboBox.Size = new System.Drawing.Size(337, 21);
            this.specialityComboBox.TabIndex = 4;
            this.specialityComboBox.SelectedIndexChanged += new System.EventHandler(this.specialityComboBox_SelectedIndexChanged);
            // 
            // disciplineComboBox
            // 
            this.disciplineComboBox.FormattingEnabled = true;
            this.disciplineComboBox.Location = new System.Drawing.Point(156, 31);
            this.disciplineComboBox.Name = "disciplineComboBox";
            this.disciplineComboBox.Size = new System.Drawing.Size(337, 21);
            this.disciplineComboBox.TabIndex = 3;
            // 
            // priorityLabel
            // 
            this.priorityLabel.AutoSize = true;
            this.priorityLabel.Location = new System.Drawing.Point(15, 202);
            this.priorityLabel.Name = "priorityLabel";
            this.priorityLabel.Size = new System.Drawing.Size(61, 13);
            this.priorityLabel.TabIndex = 2;
            this.priorityLabel.Text = "Приоритет";
            // 
            // specialityGroupLabel
            // 
            this.specialityGroupLabel.AutoSize = true;
            this.specialityGroupLabel.Location = new System.Drawing.Point(15, 66);
            this.specialityGroupLabel.Name = "specialityGroupLabel";
            this.specialityGroupLabel.Size = new System.Drawing.Size(128, 13);
            this.specialityGroupLabel.TabIndex = 1;
            this.specialityGroupLabel.Text = "Группа специальностей";
            // 
            // disciplineLabel
            // 
            this.disciplineLabel.AutoSize = true;
            this.disciplineLabel.Location = new System.Drawing.Point(15, 31);
            this.disciplineLabel.Name = "disciplineLabel";
            this.disciplineLabel.Size = new System.Drawing.Size(52, 13);
            this.disciplineLabel.TabIndex = 0;
            this.disciplineLabel.Text = "Предмет";
            // 
            // DisciplinePriority
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 361);
            this.Controls.Add(this.disciplinePriorityGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DisciplinePriority";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Приоритеты и профили";
            this.Load += new System.EventHandler(this.DisciplinePriority_Load);
            this.disciplinePriorityGroupBox.ResumeLayout(false);
            this.disciplinePriorityGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priorityUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox disciplinePriorityGroupBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown priorityUpDown;
        private System.Windows.Forms.ComboBox specialityComboBox;
        private System.Windows.Forms.ComboBox disciplineComboBox;
        private System.Windows.Forms.Label priorityLabel;
        private System.Windows.Forms.Label specialityGroupLabel;
        private System.Windows.Forms.Label disciplineLabel;
        private System.Windows.Forms.Label endDateLabel;
        private System.Windows.Forms.Label startDateLabel;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
    }
}
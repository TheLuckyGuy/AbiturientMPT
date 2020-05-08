namespace Abiturient_MPT
{
    partial class RecAchievements
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
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.achievementLabel = new System.Windows.Forms.Label();
            this.startDateLabel = new System.Windows.Forms.Label();
            this.endDateLabel = new System.Windows.Forms.Label();
            this.achievementGroupBox = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.achievementComboBox = new System.Windows.Forms.ComboBox();
            this.achievementGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDateTimePicker.Location = new System.Drawing.Point(380, 252);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(100, 20);
            this.endDateTimePicker.TabIndex = 2;
            this.endDateTimePicker.Value = new System.DateTime(2020, 5, 7, 0, 0, 0, 0);
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDateTimePicker.Location = new System.Drawing.Point(101, 252);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(100, 20);
            this.startDateTimePicker.TabIndex = 3;
            this.startDateTimePicker.ValueChanged += new System.EventHandler(this.startDateTimePicker_ValueChanged);
            // 
            // achievementLabel
            // 
            this.achievementLabel.AutoSize = true;
            this.achievementLabel.Location = new System.Drawing.Point(6, 36);
            this.achievementLabel.Name = "achievementLabel";
            this.achievementLabel.Size = new System.Drawing.Size(71, 13);
            this.achievementLabel.TabIndex = 4;
            this.achievementLabel.Text = "Достижение";
            // 
            // startDateLabel
            // 
            this.startDateLabel.AutoSize = true;
            this.startDateLabel.Location = new System.Drawing.Point(6, 255);
            this.startDateLabel.Name = "startDateLabel";
            this.startDateLabel.Size = new System.Drawing.Size(71, 13);
            this.startDateLabel.TabIndex = 5;
            this.startDateLabel.Text = "Дата начала";
            // 
            // endDateLabel
            // 
            this.endDateLabel.AutoSize = true;
            this.endDateLabel.Location = new System.Drawing.Point(267, 255);
            this.endDateLabel.Name = "endDateLabel";
            this.endDateLabel.Size = new System.Drawing.Size(89, 13);
            this.endDateLabel.TabIndex = 6;
            this.endDateLabel.Text = "Дата окончания";
            // 
            // achievementGroupBox
            // 
            this.achievementGroupBox.Controls.Add(this.achievementComboBox);
            this.achievementGroupBox.Controls.Add(this.textBox1);
            this.achievementGroupBox.Controls.Add(this.button1);
            this.achievementGroupBox.Controls.Add(this.achievementLabel);
            this.achievementGroupBox.Controls.Add(this.endDateLabel);
            this.achievementGroupBox.Controls.Add(this.startDateLabel);
            this.achievementGroupBox.Controls.Add(this.endDateTimePicker);
            this.achievementGroupBox.Controls.Add(this.startDateTimePicker);
            this.achievementGroupBox.Location = new System.Drawing.Point(12, 12);
            this.achievementGroupBox.Name = "achievementGroupBox";
            this.achievementGroupBox.Size = new System.Drawing.Size(510, 340);
            this.achievementGroupBox.TabIndex = 7;
            this.achievementGroupBox.TabStop = false;
            this.achievementGroupBox.Text = "Учитываемые достижения";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(405, 288);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(101, 63);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(379, 183);
            this.textBox1.TabIndex = 9;
            // 
            // achievementComboBox
            // 
            this.achievementComboBox.FormattingEnabled = true;
            this.achievementComboBox.Location = new System.Drawing.Point(101, 36);
            this.achievementComboBox.Name = "achievementComboBox";
            this.achievementComboBox.Size = new System.Drawing.Size(379, 21);
            this.achievementComboBox.TabIndex = 10;
            this.achievementComboBox.SelectedValueChanged += new System.EventHandler(this.achievementComboBox_SelectedValueChanged);
            // 
            // RecAchievements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 361);
            this.Controls.Add(this.achievementGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RecAchievements";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Учитываемые достижения";
            this.Load += new System.EventHandler(this.RecAchievements_Load);
            this.achievementGroupBox.ResumeLayout(false);
            this.achievementGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.Label achievementLabel;
        private System.Windows.Forms.Label startDateLabel;
        private System.Windows.Forms.Label endDateLabel;
        private System.Windows.Forms.GroupBox achievementGroupBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox achievementComboBox;
    }
}
namespace Abiturient_MPT
{
    partial class RecOlympiad
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
            this.achievementGroupBox = new System.Windows.Forms.GroupBox();
            this.olympiadComboBox = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.olympiadLabel = new System.Windows.Forms.Label();
            this.endDateLabel = new System.Windows.Forms.Label();
            this.startDateLabel = new System.Windows.Forms.Label();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.achievementGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // achievementGroupBox
            // 
            this.achievementGroupBox.Controls.Add(this.olympiadComboBox);
            this.achievementGroupBox.Controls.Add(this.textBox1);
            this.achievementGroupBox.Controls.Add(this.saveButton);
            this.achievementGroupBox.Controls.Add(this.olympiadLabel);
            this.achievementGroupBox.Controls.Add(this.endDateLabel);
            this.achievementGroupBox.Controls.Add(this.startDateLabel);
            this.achievementGroupBox.Controls.Add(this.endDateTimePicker);
            this.achievementGroupBox.Controls.Add(this.startDateTimePicker);
            this.achievementGroupBox.Location = new System.Drawing.Point(12, 12);
            this.achievementGroupBox.Name = "achievementGroupBox";
            this.achievementGroupBox.Size = new System.Drawing.Size(510, 340);
            this.achievementGroupBox.TabIndex = 8;
            this.achievementGroupBox.TabStop = false;
            this.achievementGroupBox.Text = "Учитываемые олимпиады";
            // 
            // olympiadComboBox
            // 
            this.olympiadComboBox.FormattingEnabled = true;
            this.olympiadComboBox.Location = new System.Drawing.Point(101, 36);
            this.olympiadComboBox.Name = "olympiadComboBox";
            this.olympiadComboBox.Size = new System.Drawing.Size(379, 21);
            this.olympiadComboBox.TabIndex = 10;
            this.olympiadComboBox.SelectedValueChanged += new System.EventHandler(this.olympiadComboBox_SelectedValueChanged);
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
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(405, 288);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // olympiadLabel
            // 
            this.olympiadLabel.AutoSize = true;
            this.olympiadLabel.Location = new System.Drawing.Point(6, 36);
            this.olympiadLabel.Name = "olympiadLabel";
            this.olympiadLabel.Size = new System.Drawing.Size(65, 13);
            this.olympiadLabel.TabIndex = 4;
            this.olympiadLabel.Text = "Олимпиада";
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
            // startDateLabel
            // 
            this.startDateLabel.AutoSize = true;
            this.startDateLabel.Location = new System.Drawing.Point(6, 255);
            this.startDateLabel.Name = "startDateLabel";
            this.startDateLabel.Size = new System.Drawing.Size(71, 13);
            this.startDateLabel.TabIndex = 5;
            this.startDateLabel.Text = "Дата начала";
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
            // 
            // RecOlympiad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 361);
            this.Controls.Add(this.achievementGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RecOlympiad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RecOlympiad";
            this.Load += new System.EventHandler(this.RecOlympiad_Load);
            this.achievementGroupBox.ResumeLayout(false);
            this.achievementGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox achievementGroupBox;
        private System.Windows.Forms.ComboBox olympiadComboBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label olympiadLabel;
        private System.Windows.Forms.Label endDateLabel;
        private System.Windows.Forms.Label startDateLabel;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
    }
}
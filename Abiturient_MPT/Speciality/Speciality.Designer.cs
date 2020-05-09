namespace Abiturient_MPT
{
    partial class Speciality
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
            this.specialityGroupBox = new System.Windows.Forms.GroupBox();
            this.specialityComboBox = new System.Windows.Forms.ComboBox();
            this.specialityLabel = new System.Windows.Forms.Label();
            this.codeMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.organizerLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.specialityGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // specialityGroupBox
            // 
            this.specialityGroupBox.Controls.Add(this.textBox1);
            this.specialityGroupBox.Controls.Add(this.specialityComboBox);
            this.specialityGroupBox.Controls.Add(this.specialityLabel);
            this.specialityGroupBox.Controls.Add(this.codeMaskedTextBox);
            this.specialityGroupBox.Controls.Add(this.organizerLabel);
            this.specialityGroupBox.Controls.Add(this.nameTextBox);
            this.specialityGroupBox.Controls.Add(this.saveButton);
            this.specialityGroupBox.Controls.Add(this.nameLabel);
            this.specialityGroupBox.Location = new System.Drawing.Point(12, 12);
            this.specialityGroupBox.Name = "specialityGroupBox";
            this.specialityGroupBox.Size = new System.Drawing.Size(455, 289);
            this.specialityGroupBox.TabIndex = 3;
            this.specialityGroupBox.TabStop = false;
            this.specialityGroupBox.Text = "Специальности";
            // 
            // specialityComboBox
            // 
            this.specialityComboBox.FormattingEnabled = true;
            this.specialityComboBox.Location = new System.Drawing.Point(109, 40);
            this.specialityComboBox.Name = "specialityComboBox";
            this.specialityComboBox.Size = new System.Drawing.Size(331, 21);
            this.specialityComboBox.TabIndex = 8;
            this.specialityComboBox.SelectedIndexChanged += new System.EventHandler(this.specialityComboBox_SelectedIndexChanged);
            // 
            // specialityLabel
            // 
            this.specialityLabel.AutoSize = true;
            this.specialityLabel.Location = new System.Drawing.Point(11, 35);
            this.specialityLabel.Name = "specialityLabel";
            this.specialityLabel.Size = new System.Drawing.Size(90, 26);
            this.specialityLabel.TabIndex = 7;
            this.specialityLabel.Text = "Группа \r\nспециальностей";
            // 
            // codeMaskedTextBox
            // 
            this.codeMaskedTextBox.Location = new System.Drawing.Point(109, 127);
            this.codeMaskedTextBox.Mask = "00.00.00";
            this.codeMaskedTextBox.Name = "codeMaskedTextBox";
            this.codeMaskedTextBox.Size = new System.Drawing.Size(55, 20);
            this.codeMaskedTextBox.TabIndex = 6;
            // 
            // organizerLabel
            // 
            this.organizerLabel.AutoSize = true;
            this.organizerLabel.Location = new System.Drawing.Point(11, 166);
            this.organizerLabel.Name = "organizerLabel";
            this.organizerLabel.Size = new System.Drawing.Size(57, 13);
            this.organizerLabel.TabIndex = 5;
            this.organizerLabel.Text = "Название";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameTextBox.Location = new System.Drawing.Point(109, 166);
            this.nameTextBox.MaxLength = 500;
            this.nameTextBox.Multiline = true;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(331, 70);
            this.nameTextBox.TabIndex = 4;
            this.nameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nameTextBox_KeyPress);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(365, 251);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(11, 127);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(26, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Код";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(109, 67);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(331, 54);
            this.textBox1.TabIndex = 9;
            // 
            // Speciality
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 313);
            this.Controls.Add(this.specialityGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Speciality";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Специальности";
            this.Load += new System.EventHandler(this.Speciality_Load);
            this.specialityGroupBox.ResumeLayout(false);
            this.specialityGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox specialityGroupBox;
        private System.Windows.Forms.MaskedTextBox codeMaskedTextBox;
        private System.Windows.Forms.Label organizerLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.ComboBox specialityComboBox;
        private System.Windows.Forms.Label specialityLabel;
        private System.Windows.Forms.TextBox textBox1;
    }
}
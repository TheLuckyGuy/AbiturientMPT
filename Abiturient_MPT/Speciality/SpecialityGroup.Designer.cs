namespace Abiturient_MPT
{
    partial class SpecialityGroup
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
            this.codeMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.specialityCodeLabel = new System.Windows.Forms.Label();
            this.specialityGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // specialityGroupBox
            // 
            this.specialityGroupBox.Controls.Add(this.codeMaskedTextBox);
            this.specialityGroupBox.Controls.Add(this.nameLabel);
            this.specialityGroupBox.Controls.Add(this.nameTextBox);
            this.specialityGroupBox.Controls.Add(this.saveButton);
            this.specialityGroupBox.Controls.Add(this.specialityCodeLabel);
            this.specialityGroupBox.Location = new System.Drawing.Point(12, 12);
            this.specialityGroupBox.Name = "specialityGroupBox";
            this.specialityGroupBox.Size = new System.Drawing.Size(455, 187);
            this.specialityGroupBox.TabIndex = 4;
            this.specialityGroupBox.TabStop = false;
            this.specialityGroupBox.Text = "Группа специальностей";
            // 
            // codeMaskedTextBox
            // 
            this.codeMaskedTextBox.Location = new System.Drawing.Point(90, 29);
            this.codeMaskedTextBox.Mask = "00.00.00";
            this.codeMaskedTextBox.Name = "codeMaskedTextBox";
            this.codeMaskedTextBox.Size = new System.Drawing.Size(55, 20);
            this.codeMaskedTextBox.TabIndex = 6;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(11, 68);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(57, 13);
            this.nameLabel.TabIndex = 5;
            this.nameLabel.Text = "Название";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameTextBox.Location = new System.Drawing.Point(90, 68);
            this.nameTextBox.MaxLength = 500;
            this.nameTextBox.Multiline = true;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(350, 70);
            this.nameTextBox.TabIndex = 4;
            this.nameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nameTextBox_KeyPress);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(365, 153);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // specialityCodeLabel
            // 
            this.specialityCodeLabel.AutoSize = true;
            this.specialityCodeLabel.Location = new System.Drawing.Point(11, 29);
            this.specialityCodeLabel.Name = "specialityCodeLabel";
            this.specialityCodeLabel.Size = new System.Drawing.Size(26, 13);
            this.specialityCodeLabel.TabIndex = 0;
            this.specialityCodeLabel.Text = "Код";
            // 
            // SpecialityGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 211);
            this.Controls.Add(this.specialityGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SpecialityGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Группа специальностей";
            this.Load += new System.EventHandler(this.SpecialityGroup_Load);
            this.specialityGroupBox.ResumeLayout(false);
            this.specialityGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox specialityGroupBox;
        private System.Windows.Forms.MaskedTextBox codeMaskedTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label specialityCodeLabel;
    }
}
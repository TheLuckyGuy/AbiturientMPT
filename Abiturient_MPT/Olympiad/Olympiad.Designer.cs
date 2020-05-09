namespace Abiturient_MPT
{
    partial class Olympiad
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
            this.olympiadGroupBox = new System.Windows.Forms.GroupBox();
            this.organizerLabel = new System.Windows.Forms.Label();
            this.organizerTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.olympiadGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // olympiadGroupBox
            // 
            this.olympiadGroupBox.Controls.Add(this.organizerLabel);
            this.olympiadGroupBox.Controls.Add(this.organizerTextBox);
            this.olympiadGroupBox.Controls.Add(this.saveButton);
            this.olympiadGroupBox.Controls.Add(this.nameTextBox);
            this.olympiadGroupBox.Controls.Add(this.nameLabel);
            this.olympiadGroupBox.Location = new System.Drawing.Point(12, 12);
            this.olympiadGroupBox.Name = "olympiadGroupBox";
            this.olympiadGroupBox.Size = new System.Drawing.Size(455, 223);
            this.olympiadGroupBox.TabIndex = 2;
            this.olympiadGroupBox.TabStop = false;
            this.olympiadGroupBox.Text = "Предмет";
            // 
            // organizerLabel
            // 
            this.organizerLabel.AutoSize = true;
            this.organizerLabel.Location = new System.Drawing.Point(10, 105);
            this.organizerLabel.Name = "organizerLabel";
            this.organizerLabel.Size = new System.Drawing.Size(73, 13);
            this.organizerLabel.TabIndex = 5;
            this.organizerLabel.Text = "Организатор";
            // 
            // organizerTextBox
            // 
            this.organizerTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.organizerTextBox.Location = new System.Drawing.Point(93, 100);
            this.organizerTextBox.MaxLength = 500;
            this.organizerTextBox.Multiline = true;
            this.organizerTextBox.Name = "organizerTextBox";
            this.organizerTextBox.Size = new System.Drawing.Size(337, 50);
            this.organizerTextBox.TabIndex = 4;
            this.organizerTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nameTextBox_KeyPress);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(353, 176);
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
            this.nameLabel.Location = new System.Drawing.Point(10, 40);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(57, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Название";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameTextBox.Location = new System.Drawing.Point(93, 35);
            this.nameTextBox.MaxLength = 500;
            this.nameTextBox.Multiline = true;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(335, 50);
            this.nameTextBox.TabIndex = 1;
            this.nameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nameTextBox_KeyPress);
            // 
            // Olympiad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 241);
            this.Controls.Add(this.olympiadGroupBox);
            this.Name = "Olympiad";
            this.Text = "Олимпиада";
            this.Load += new System.EventHandler(this.Olympiad_Load);
            this.olympiadGroupBox.ResumeLayout(false);
            this.olympiadGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox olympiadGroupBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label organizerLabel;
        private System.Windows.Forms.TextBox organizerTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
    }
}
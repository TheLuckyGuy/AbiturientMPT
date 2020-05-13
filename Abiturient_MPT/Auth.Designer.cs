namespace Abiturient_MPT
{
    partial class Auth
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
            this.authRegisterButton = new System.Windows.Forms.Button();
            this.authEnterButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.authLoginTextBox = new System.Windows.Forms.TextBox();
            this.authPassTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.regPass2TextBox = new System.Windows.Forms.TextBox();
            this.regEnterButton = new System.Windows.Forms.Button();
            this.registerButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // authRegisterButton
            // 
            this.authRegisterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.authRegisterButton.Location = new System.Drawing.Point(147, 326);
            this.authRegisterButton.Name = "authRegisterButton";
            this.authRegisterButton.Size = new System.Drawing.Size(123, 35);
            this.authRegisterButton.TabIndex = 0;
            this.authRegisterButton.Text = "Регистрация";
            this.authRegisterButton.UseVisualStyleBackColor = true;
            this.authRegisterButton.Click += new System.EventHandler(this.authRegisterButton_Click);
            // 
            // authEnterButton
            // 
            this.authEnterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.authEnterButton.Location = new System.Drawing.Point(276, 326);
            this.authEnterButton.Name = "authEnterButton";
            this.authEnterButton.Size = new System.Drawing.Size(84, 35);
            this.authEnterButton.TabIndex = 1;
            this.authEnterButton.Text = "Вход";
            this.authEnterButton.UseVisualStyleBackColor = true;
            this.authEnterButton.Click += new System.EventHandler(this.authEnterButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 279);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Пароль";
            // 
            // authLoginTextBox
            // 
            this.authLoginTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.authLoginTextBox.Location = new System.Drawing.Point(89, 235);
            this.authLoginTextBox.Name = "authLoginTextBox";
            this.authLoginTextBox.Size = new System.Drawing.Size(272, 29);
            this.authLoginTextBox.TabIndex = 4;
            this.authLoginTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.authLoginTextBox_KeyPress);
            // 
            // authPassTextBox
            // 
            this.authPassTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.authPassTextBox.Location = new System.Drawing.Point(89, 276);
            this.authPassTextBox.Name = "authPassTextBox";
            this.authPassTextBox.Size = new System.Drawing.Size(272, 29);
            this.authPassTextBox.TabIndex = 5;
            this.authPassTextBox.UseSystemPasswordChar = true;
            this.authPassTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.authLoginTextBox_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Abiturient_MPT.Properties.Resources.logoq;
            this.pictureBox1.Location = new System.Drawing.Point(110, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 135);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 321);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Пароль";
            this.label3.Visible = false;
            // 
            // regPass2TextBox
            // 
            this.regPass2TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.regPass2TextBox.Location = new System.Drawing.Point(89, 318);
            this.regPass2TextBox.Name = "regPass2TextBox";
            this.regPass2TextBox.Size = new System.Drawing.Size(272, 29);
            this.regPass2TextBox.TabIndex = 8;
            this.regPass2TextBox.UseSystemPasswordChar = true;
            this.regPass2TextBox.Visible = false;
            this.regPass2TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.authLoginTextBox_KeyPress);
            // 
            // regEnterButton
            // 
            this.regEnterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.regEnterButton.Location = new System.Drawing.Point(147, 359);
            this.regEnterButton.Name = "regEnterButton";
            this.regEnterButton.Size = new System.Drawing.Size(84, 35);
            this.regEnterButton.TabIndex = 10;
            this.regEnterButton.Text = "Вход";
            this.regEnterButton.UseVisualStyleBackColor = true;
            this.regEnterButton.Visible = false;
            this.regEnterButton.Click += new System.EventHandler(this.regEnterButton_Click);
            // 
            // registerButton
            // 
            this.registerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.registerButton.Location = new System.Drawing.Point(237, 359);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(123, 35);
            this.registerButton.TabIndex = 9;
            this.registerButton.Text = "Регистрация";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Visible = false;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(164, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "Вход";
            // 
            // Auth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 413);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.regEnterButton);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.regPass2TextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.authPassTextBox);
            this.Controls.Add(this.authLoginTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.authEnterButton);
            this.Controls.Add(this.authRegisterButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Auth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.Auth_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button authRegisterButton;
        private System.Windows.Forms.Button authEnterButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox authLoginTextBox;
        private System.Windows.Forms.TextBox authPassTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox regPass2TextBox;
        private System.Windows.Forms.Button regEnterButton;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Label label4;
    }
}
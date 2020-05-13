using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Liphsoft.Crypto.Argon2;


namespace Abiturient_MPT
{
    public partial class Auth : Form
    {
        public db data = new db();
        public User currentUser = new User();


        public Auth()
        {
            InitializeComponent();
        }

        private void authRegisterButton_Click(object sender, EventArgs e)
        {
            this.Text = "Регистрация";
            label4.Text = "Регистрация";

            authLoginTextBox.Text = String.Empty;
            authPassTextBox.Text = String.Empty;

            authEnterButton.Visible = false;
            authRegisterButton.Visible = false;

            regEnterButton.Visible = true;
            registerButton.Visible = true;
            regPass2TextBox.Visible = true;
            label3.Visible = true;

            label4.Location = new Point(this.ClientSize.Width / 2 - label4.Width / 2, label4.Location.Y);
        }

        private void regEnterButton_Click(object sender, EventArgs e)
        {
            this.Text = "Авторизация";
            label4.Text = "Авторизация";

            authLoginTextBox.Text = String.Empty;
            authPassTextBox.Text = String.Empty;
            regPass2TextBox.Text = String.Empty;

            authEnterButton.Visible = true;
            authRegisterButton.Visible = true;

            regEnterButton.Visible = false;
            registerButton.Visible = false;
            regPass2TextBox.Visible = false;
            label3.Visible = false;

            label4.Location = new Point(this.ClientSize.Width / 2 - label4.Width / 2, label4.Location.Y);
        }

        private void Auth_Load(object sender, EventArgs e)
        {
            label4.Location = new Point(this.ClientSize.Width / 2 - label4.Width / 2, label4.Location.Y);
        }

        private void authLoginTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '+') || (e.KeyChar == '=') || (e.KeyChar == '[') || (e.KeyChar == ']') || (e.KeyChar == '<') || (e.KeyChar == '>') || (e.KeyChar == '?') ||
                (e.KeyChar == '&') || (e.KeyChar == '^') || (e.KeyChar == '$') || (e.KeyChar == '@') || (e.KeyChar == '#') || (e.KeyChar == ';') || (e.KeyChar == '/') || (e.KeyChar == '|') || 
                (e.KeyChar == ':')) e.Handled = true;
            else { return; }
        }

        private void authEnterButton_Click(object sender, EventArgs e)
        {
            int roleID = 0;
            roleID = data.Authorization(authLoginTextBox.Text, authPassTextBox.Text);

            switch (roleID)
            {
                case 1:
                    currentUser = data.getUserRole(roleID);
                    currentUser.Name = authLoginTextBox.Text;
                    MainForm mainForm = new MainForm(this);
                    //mainForm.Parent = this;
                    this.Hide();
                    mainForm.Show();
                    break;
                case 0:
                    MessageBox.Show("Ошибка авторизации. Неправильные логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    break;
                case -1:
                    MessageBox.Show("Ошибка авторизации. Проблемы при подключении к базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    break;
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if ((authLoginTextBox.Text != String.Empty) & (regPass2TextBox.Text != String.Empty) & (authPassTextBox.Text != String.Empty))
            {
                if (authPassTextBox.Text == regPass2TextBox.Text)
                {   
                    int result = data.Registration(authLoginTextBox.Text, authPassTextBox.Text);
                    switch (result)
                    {
                        case 1:
                            MessageBox.Show("Вы успешно зарегистрированы", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            break;
                        case 0:
                            MessageBox.Show("Ошибка регистрации. Пользователь с таким логином уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            break;
                        case -1:
                            MessageBox.Show("Ошибка регистрации. Проблемы при подключении к базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка пароли не совпадают", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}

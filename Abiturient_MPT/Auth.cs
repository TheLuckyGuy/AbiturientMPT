using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Abiturient_MPT
{
    public partial class Auth : Form
    {
        public User currentUser = new User();
        DBData authData = new DBData();
        public db data;


        public Auth()
        {
            InitializeComponent();
        }

        private int readAuthData() // Функция для чтения данных из бинарного файла
        {
            try
            {
                if (!File.Exists(Application.StartupPath + "\\data.xml"))
                {
                    const string message =
                        "Программа не обнаружила конфигурационный файл. Скорее всего это произошло из-за того, что " +
                        "вы запускаете программу впервые \nХотите открыть конфигуратор?";
                    const string caption = "Конфигурационный файл не найден";
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

                    
                    if (result == DialogResult.Yes) // Если ответ "Да"
                    {
                        Process.Start(Application.StartupPath + "\\Configurator.exe");

                    }
                    else
                    {
                        Application.Exit();
                    }                  
                }
                else
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(DBData));
                    if (File.Exists(Application.StartupPath + "\\data.xml")) // Проверка существования файла
                    {
                        using (Stream fStream = new FileStream("data.xml", FileMode.Open, FileAccess.Read, FileShare.None)) // Открытие потока на чтение файла
                        {
                            authData = (DBData)serializer.Deserialize(fStream); // Чтение данных из файла
                        }
                        data = new db(authData);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
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
            readAuthData(); // Считываются данные из файла конфигурации
        }

        private void authLoginTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '+') || (e.KeyChar == '=') || (e.KeyChar == '[') || (e.KeyChar == ']') || (e.KeyChar == '<') || (e.KeyChar == '>') || (e.KeyChar == '?') ||
                (e.KeyChar == '&') || (e.KeyChar == '^') || (e.KeyChar == '$') || (e.KeyChar == '@') || (e.KeyChar == '#') || (e.KeyChar == ';') || (e.KeyChar == '/') || (e.KeyChar == '|') || 
                (e.KeyChar == ':')) e.Handled = true;
            else { return; }
        }

        private void authEnterButton_Click(object sender, EventArgs e) // Действие при нажатии кнопки авторизации
        {
            readAuthData(); // Считываются данные из файла конфигурации

            int roleID = 0; // Переменная для хранения роли
            roleID = data.Authorization(authLoginTextBox.Text, authPassTextBox.Text); // Выполнение функции авторизации, результатом которой будет получение ID роли

            switch (roleID)
            {
                default: // Если значение не 0 и не -1, то пользователь авторизован
                    currentUser = data.getUserRole(roleID);
                    currentUser.Name = authLoginTextBox.Text;
                    MainForm mainForm = new MainForm(this); // Создание дочерней формы, которая будет открыта далее, в качестве параметра передаётся ссылка на родителя
                    this.Hide(); // Форма авторизации скрывается
                    authPassTextBox.Text = String.Empty; // Форма пароля очищается
                    mainForm.Show(); // На экран выводится новая форма
                    break;
                case 0: // Если значение роли равно 0, то была введена неправильная комбинация логина и пароля, выводится сообщение об ошибке
                    MessageBox.Show("Ошибка авторизации. Неправильные логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    break;
                case -1: // Если значение роли равно -1, то это означает, что программа не смогла подключиться к бд, выводится сообщение об ошибке
                    MessageBox.Show("Ошибка авторизации. Проблемы при подключении к базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    break;
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            readAuthData(); // Считываются данные из файла конфигурации
            if ((authLoginTextBox.Text != String.Empty) & (regPass2TextBox.Text != String.Empty) & (authPassTextBox.Text != String.Empty))
            {
                if (authPassTextBox.Text == regPass2TextBox.Text)
                {   
                    int result = data.Registration(authLoginTextBox.Text, authPassTextBox.Text);
                    switch (result)
                    {
                        case 1:
                            MessageBox.Show("Вы успешно зарегистрированы", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            authPassTextBox.Text = String.Empty;
                            authLoginTextBox.Text = String.Empty;
                            regPass2TextBox.Text = String.Empty;
                            regEnterButton_Click(this, e);
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

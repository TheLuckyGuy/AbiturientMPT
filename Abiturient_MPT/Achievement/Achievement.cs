using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abiturient_MPT
{
    public partial class NewAchievement : Form
    {
        MainForm parent = new MainForm(null);
        int mode = 0; // 0 - новое достижение, 1 - редактирование достижения
        int id = 0; // ID редактируемой записи, этот параметр используется для режима редактирования
        public NewAchievement(MainForm p, int formMode, int achID)
        {
            mode = formMode;
            id = achID;
            parent = p;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (mode)
            {
                case 0:
                    if(nameTextBox.Text != String.Empty)
                    {
                        parent.data.achievementAdd(nameTextBox.Text);
                    }
                    else
                    {
                        MessageBox.Show("Не все необходимые поля ввода заполнены", "Незаполнены поля");
                        return;
                    }
                    break;
                case 1:
                    if (nameTextBox.Text != String.Empty)
                    {
                        parent.data.achievementUpdate(id, nameTextBox.Text);
                    }
                    else
                    {
                        MessageBox.Show("Не все необходимые поля ввода заполнены", "Незаполнены поля");
                        return;
                    }
                    break;
            }
            parent.tabControl1_SelectedIndexChanged(this, e);
            this.Close();
        }

        private void NewAchievement_Load(object sender, EventArgs e)
        {
            switch (mode)
            {
                case 0:
                    achievementGroupBox.Text = "Добавить достижение";
                    break;
                case 1:
                    achievementGroupBox.Text = "Редактирование достижения";
                    DataTable tbl1 = new DataTable();
                    tbl1 = parent.data.getCurrentAchievement(id);
                    nameTextBox.Text = tbl1.Rows[0][0].ToString();
                    break;
            }
        }

        private void nameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9') || (e.KeyChar >= 'а') && (e.KeyChar <= 'я') || (e.KeyChar >= 'А') && (e.KeyChar <= 'Я') || (e.KeyChar == 'ё') ||
               (e.KeyChar == 'Ё') || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == '.') || (e.KeyChar == ',') || (e.KeyChar == '-') || (e.KeyChar == (char)Keys.Space) ||
               (e.KeyChar == '(') || (e.KeyChar == ')') || (e.KeyChar >= 'a') && (e.KeyChar <= 'z') || (e.KeyChar >= 'A') && (e.KeyChar <= 'Z') || (e.KeyChar == (int)Keys.Control)) return;
            else { e.Handled = true; }


        }
    }
}

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
    public partial class Discipline : Form
    {
        MainForm parent = new MainForm();
        int mode = 0; // 0 - новый предмет, 1 - редактирование предмета
        int id = 0; // ID редактируемой записи, этот параметр используется для режима редактирования
        public Discipline(MainForm p, int formMode, int achID)
        {
            mode = formMode;
            id = achID;
            parent = p;
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            switch (mode)
            {
                case 0:
                    if (nameTextBox.Text != String.Empty)
                    {
                        parent.data.disciplineAdd(nameTextBox.Text);
                    }
                    else
                    {
                        MessageBox.Show("Не все необходимые поля ввода заполнены", "Незаполнены поля");
                    }
                    break;
                case 1:
                    if (nameTextBox.Text != String.Empty)
                    {
                        parent.data.disciplineUpdate(id, nameTextBox.Text);
                    }
                    else
                    {
                        MessageBox.Show("Не все необходимые поля ввода заполнены", "Незаполнены поля");
                    }
                    break;
            }
            parent.tabControl1_SelectedIndexChanged(this, e);
            this.Close();
        }

        private void nameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '+') || (e.KeyChar == '=') || (e.KeyChar == '[') || (e.KeyChar == ']') || (e.KeyChar == '<') || (e.KeyChar == '>') || (e.KeyChar == '?') || 
                (e.KeyChar == '&') || (e.KeyChar == '^') || (e.KeyChar == '$') || (e.KeyChar == '@') || (e.KeyChar == '#') ) e.Handled = true;
            else { return; }
        }

        private void Discipline_Load(object sender, EventArgs e)
        {
            switch (mode)
            {
                case 0:
                    disciplineGroupBox.Text = "Добавление предмета";
                    break;
                case 1:
                    disciplineGroupBox.Text = "Редактирование предмета";
                    DataTable tbl1 = new DataTable();
                    tbl1 = parent.data.getCurrentDiscipline(id);
                    nameTextBox.Text = tbl1.Rows[0][0].ToString();
                    break;
            }
        }
    }
}

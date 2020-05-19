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
    public partial class Olympiad : Form
    {

        MainForm parent = new MainForm(null);
        int mode = 0; // 0 - новая олимпиада, 1 - редактирование олимпиады
        int id = 0; // ID редактируемой записи, этот параметр используется для режима редактирования

        public Olympiad(MainForm p, int formMode, int olympID)
        {
            mode = formMode;
            id = olympID;
            parent = p;

            InitializeComponent();
        }

        private void Olympiad_Load(object sender, EventArgs e)
        {
            switch (mode)
            {
                case 0:
                    olympiadGroupBox.Text = "Добавление олимпиады";
                    break;
                case 1:
                    olympiadGroupBox.Text = "Редактирование олимпиады";
                    DataTable tbl1 = new DataTable();
                    tbl1 = parent.parent.data.getCurrentOlympiad(id);
                    nameTextBox.Text = tbl1.Rows[0][1].ToString();
                    organizerTextBox.Text = tbl1.Rows[0][2].ToString();
                    break;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            switch (mode)
            {
                case 0:
                    if (nameTextBox.Text != String.Empty)
                    {
                        parent.parent.data.olympiadAdd(nameTextBox.Text, organizerTextBox.Text);
                    }
                    else
                    {
                        MessageBox.Show("Не все необходимые поля ввода заполнены", "Незаполнены поля");
                    }
                    break;
                case 1:
                    if (nameTextBox.Text != String.Empty)
                    {
                        parent.parent.data.olympiadUpdate(id, nameTextBox.Text, organizerTextBox.Text);
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
                (e.KeyChar == '&') || (e.KeyChar == '^') || (e.KeyChar == '$') || (e.KeyChar == '@') || (e.KeyChar == '#') || (e.KeyChar == ';')) e.Handled = true;
            else { return; }
        }
    }
}

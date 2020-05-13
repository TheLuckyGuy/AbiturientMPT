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
    public partial class SpecialityGroup : Form
    {
        MainForm parent = new MainForm(null);
        int mode = 0; // 0 - новая группа специальностей, 1 - редактирование группы специльностей
        int id = 0; // ID редактируемой записи, этот параметр используется для режима редактирования

        public SpecialityGroup(MainForm p, int formMode, int specGroupID)
        {
            mode = formMode;
            id = specGroupID;
            parent = p;

            InitializeComponent();
        }

        private void SpecialityGroup_Load(object sender, EventArgs e)
        {
            switch (mode)
            {
                case 0:
                    specialityGroupBox.Text = "Добавление группы специальностей";
                    break;
                case 1:
                    specialityGroupBox.Text = "Редактирование группы специальностей";
                    DataTable tbl1 = new DataTable();
                    tbl1 = parent.data.getCurrentSpecialityGroup(id);
                    codeMaskedTextBox.Text = tbl1.Rows[0][1].ToString();
                    nameTextBox.Text = tbl1.Rows[0][2].ToString();
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
                        parent.data.specialityGroupAdd(codeMaskedTextBox.Text, nameTextBox.Text);
                    }
                    else
                    {
                        MessageBox.Show("Не все необходимые поля ввода заполнены", "Незаполнены поля");
                    }
                    break;
                case 1:
                    if (nameTextBox.Text != String.Empty)
                    {
                        parent.data.specialityGroupUpdate(id, codeMaskedTextBox.Text, nameTextBox.Text);
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

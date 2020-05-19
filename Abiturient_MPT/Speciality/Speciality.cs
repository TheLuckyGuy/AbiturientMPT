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
    public partial class Speciality : Form
    {
        MainForm parent = new MainForm(null);
        int mode = 0; // 0 - новая группа специальностей, 1 - редактирование группы специльностей
        int id = 0; // ID редактируемой записи, этот параметр используется для режима редактирования

        public Speciality(MainForm p, int formMode, int specID)
        {
            mode = formMode;
            id = specID;
            parent = p;

            InitializeComponent();
        }

        private void Speciality_Load(object sender, EventArgs e)
        {
            DataTable tbl1 = new DataTable();
            tbl1 = parent.parent.data.GetData((byte)db.Tables.GetSpecialityGroupShort);
            specialityComboBox.DataSource = tbl1;
            specialityComboBox.DisplayMember = "Название";  // столбец для отображения
            specialityComboBox.ValueMember = "ID";

            switch (mode)
            {
                case 0:
                    specialityGroupBox.Text = "Добавление специальности";
                    break;
                case 1:
                    specialityGroupBox.Text = "Редактирование специальности";

                    DataTable tbl2 = new DataTable();
                    tbl2 = parent.parent.data.getCurrentSpeciality(id);

                    codeMaskedTextBox.Text = tbl2.Rows[0][1].ToString();
                    nameTextBox.Text = tbl2.Rows[0][2].ToString();

                    int index = specialityComboBox.FindString(tbl1.Rows[0][1].ToString());
                    specialityComboBox.SelectedIndex = index;
                    break;
            }

        }

        private void specialityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = specialityComboBox.Text;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            switch (mode)
            {
                case 0:
                    if ((specialityComboBox.SelectedIndex != -1) && (codeMaskedTextBox.Text != String.Empty) && (nameTextBox.Text != String.Empty))
                    {
                        parent.parent.data.specialityAdd(codeMaskedTextBox.Text, nameTextBox.Text, specialityComboBox.SelectedValue.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Не все необходимые поля ввода заполнены", "Незаполнены поля");
                        return;
                    }
                    break;
                case 1:
                    if ((specialityComboBox.SelectedIndex != -1) && (codeMaskedTextBox.Text != String.Empty) && (nameTextBox.Text != String.Empty))
                    {
                        parent.parent.data.specialityUpdate(id, codeMaskedTextBox.Text, nameTextBox.Text, specialityComboBox.SelectedValue.ToString());
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

        private void nameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '+') || (e.KeyChar == '=') || (e.KeyChar == '[') || (e.KeyChar == ']') || (e.KeyChar == '<') || (e.KeyChar == '>') || (e.KeyChar == '?') ||
            (e.KeyChar == '&') || (e.KeyChar == '^') || (e.KeyChar == '$') || (e.KeyChar == '@') || (e.KeyChar == '#') || (e.KeyChar == ';') || (e.KeyChar == '/') || (e.KeyChar == '|')
            || (e.KeyChar == ':')) e.Handled = true;
            else { return; }
        }
    }
}

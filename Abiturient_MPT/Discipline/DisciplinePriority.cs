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
    public partial class DisciplinePriority : Form
    {
        MainForm parent = new MainForm();
        int mode = 0; // 0 - новый приоритет, 1 - редактирование приоритета
        int id = 0; // ID редактируемой записи, этот параметр используется для режима редактирования

        public DisciplinePriority(MainForm p, int formMode, int priorID)
        {
            mode = formMode;
            id = priorID;
            parent = p;

            InitializeComponent();
        }

        private void DisciplinePriority_Load(object sender, EventArgs e)
        {
            DataTable tbl1 = new DataTable();
            tbl1 = parent.data.GetData((byte)db.Tables.GetSpecialityGroupShort);
            specialityComboBox.DataSource = tbl1;
            specialityComboBox.DisplayMember = "Название";  // столбец для отображения
            specialityComboBox.ValueMember = "ID";

            DataTable tbl2 = new DataTable();
            tbl2 = parent.data.GetData((byte)db.Tables.GetDiscipline);
            disciplineComboBox.DataSource = tbl2;
            disciplineComboBox.DisplayMember = "Название";  // столбец для отображения
            disciplineComboBox.ValueMember = "ID";

            switch (mode)
            {
                case 0:
                    disciplinePriorityGroupBox.Text = "Добавление специальности";
                    break;
                case 1:
                    disciplinePriorityGroupBox.Text = "Редактирование специальности";

                    DataTable tbl3 = new DataTable();
                    tbl3 = parent.data.getCurrentPriority(id);

                    DateTime startDate = DateTime.Parse(tbl2.Rows[0][4].ToString());
                    DateTime endDate = DateTime.Parse(tbl2.Rows[0][5].ToString());


                    disciplineComboBox.SelectedIndex = disciplineComboBox.FindString(tbl3.Rows[0][1].ToString());
                    specialityComboBox.SelectedIndex = specialityComboBox.FindString(tbl3.Rows[0][2].ToString());
                    priorityUpDown.Value = Convert.ToInt32(tbl3.Rows[0][3].ToString());
                    startDateTimePicker.Value = startDate;
                    endDateTimePicker.Value = endDate;
                    break;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            switch (mode)
            {
                case 0:
                    if ((disciplineComboBox.SelectedIndex != -1) && (specialityComboBox.SelectedIndex != -1))
                    {
                        parent.data.priorityAdd((int)specialityComboBox.SelectedValue, (int)disciplineComboBox.SelectedValue, (int)priorityUpDown.Value, startDateTimePicker.Value.ToShortDateString(), endDateTimePicker.Value.ToShortDateString());
                    }
                    else
                    {
                        MessageBox.Show("Не все необходимые поля ввода заполнены", "Незаполнены поля");
                        return;
                    }
                    break;
                case 1:
                    if ((disciplineComboBox.SelectedIndex != -1) && (specialityComboBox.SelectedIndex != -1))
                    {
                        parent.data.priorityUpdate(id, (int)specialityComboBox.SelectedValue, (int)disciplineComboBox.SelectedValue, (int)priorityUpDown.Value, startDateTimePicker.Value.ToShortDateString(), endDateTimePicker.Value.ToShortDateString());
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

        private void specialityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = specialityComboBox.Text;
        }
    }
}

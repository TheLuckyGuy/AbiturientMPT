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
        MainForm parent = new MainForm(null);
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
            tbl1 = parent.parent.data.GetData((byte)db.Tables.GetSpecialityGroupShort);
            specialityComboBox.DataSource = tbl1;
            specialityComboBox.DisplayMember = "Название";  // столбец для отображения
            specialityComboBox.ValueMember = "ID"; // столбец значений

            DataTable tbl2 = new DataTable();
            tbl2 = parent.parent.data.GetData((byte)db.Tables.GetDiscipline);
            disciplineComboBox.DataSource = tbl2;
            disciplineComboBox.DisplayMember = "Название";  // столбец для отображения
            disciplineComboBox.ValueMember = "ID"; // столбец значений

            switch (mode)
            {
                case 0: // Режим добавления 
                    disciplinePriorityGroupBox.Text = "Добавление специальности";
                    break;
                case 1: // Режим редактирования
                    disciplinePriorityGroupBox.Text = "Редактирование специальности";

                    DataTable tbl3 = new DataTable();                       // Получение записи 
                    tbl3 = parent.parent.data.getCurrentPriority(id);       // о приоритете предмете

                    // Заполнение полей данными
                    DateTime startDate = DateTime.Parse(tbl3.Rows[0][4].ToString());
                    DateTime endDate = DateTime.Parse(tbl3.Rows[0][5].ToString());

                    disciplineComboBox.SelectedIndex = disciplineComboBox.FindString(tbl3.Rows[0][2].ToString());
                    specialityComboBox.SelectedIndex = specialityComboBox.FindString(tbl3.Rows[0][1].ToString());
                    priorityUpDown.Value = Convert.ToInt32(tbl3.Rows[0][3].ToString());
                    startDateTimePicker.Value = startDate;
                    endDateTimePicker.Value = endDate;
                    break;
            }
        }

        private void saveButton_Click(object sender, EventArgs e) // Действия при нажатии кнопки сохраненния
        {
            switch (mode)
            {
                case 0: // Если в режиме добавления нажата кнопка сохранить, то будет добавлена новая заись
                    if ((disciplineComboBox.SelectedIndex != -1) && (specialityComboBox.SelectedIndex != -1))
                    {
                        parent.parent.data.priorityAdd((int)specialityComboBox.SelectedValue, (int)disciplineComboBox.SelectedValue, (int)priorityUpDown.Value, startDateTimePicker.Value.ToShortDateString(), endDateTimePicker.Value.ToShortDateString());
                    }
                    else // Если не все необходимые поля заполнены, то выводится ошибка и выполнение функции останавливается
                    {
                        MessageBox.Show("Не все необходимые поля ввода заполнены", "Незаполнены поля");
                        return;
                    }
                    break;
                case 1: // если же кнопка нажата в режиме редактирования, то данные записи будут заменены новыми
                    if ((disciplineComboBox.SelectedIndex != -1) && (specialityComboBox.SelectedIndex != -1))
                    {
                        parent.parent.data.priorityUpdate(id, (int)specialityComboBox.SelectedValue, (int)disciplineComboBox.SelectedValue, (int)priorityUpDown.Value, startDateTimePicker.Value.ToShortDateString(), endDateTimePicker.Value.ToShortDateString());
                    }
                    else
                    {
                        MessageBox.Show("Не все необходимые поля ввода заполнены", "Незаполнены поля");
                        return;
                    }
                    break;
            }
            parent.tabControl1_SelectedIndexChanged(this, e); // Происходит обновление данных на родительской форме
            this.Close();
        }

        private void specialityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = specialityComboBox.Text;
        }

        private void startDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            endDateTimePicker.MinDate = startDateTimePicker.Value;
        }
    }
}

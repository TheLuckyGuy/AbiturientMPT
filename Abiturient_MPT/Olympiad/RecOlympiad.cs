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
    public partial class RecOlympiad : Form
    {
        MainForm parent = new MainForm(null);
        int mode = 0; // 0 - новая учитываемая олимпиада, 1 - редактирование учитываемой олимпиады
        int id = 0; // ID редактируемой записи, этот параметр используется для режима редактирования

        public RecOlympiad(MainForm p, int formMode, int olympID)
        {
            mode = formMode;
            id = olympID;
            parent = p;
            InitializeComponent();
        }

        private void RecOlympiad_Load(object sender, EventArgs e)
        {
            endDateTimePicker.MinDate = startDateTimePicker.Value;

            DataTable tbl1 = new DataTable();
            tbl1 = parent.parent.data.GetData((byte)db.Tables.GetOlympiads);
            olympiadComboBox.DataSource = tbl1;
            olympiadComboBox.DisplayMember = "Название";  // столбец для отображения
            olympiadComboBox.ValueMember = "ID";  //столбец с id

            switch (mode)
            {
                case 0:
                    recOlympiadGroupBox.Text = "Добавить учитываемум олимпиаду";
                    break;
                case 1:
                    recOlympiadGroupBox.Text = "Редактирование учитываемой олипиады";


                    DataTable tbl2 = new DataTable();
                    tbl2 = parent.parent.data.getCurrentRecOlympiad(id);

                    DateTime startDate = DateTime.Parse(tbl2.Rows[0][2].ToString());
                    DateTime endDate = DateTime.Parse(tbl2.Rows[0][3].ToString());

                    startDateTimePicker.Value = startDate;
                    endDateTimePicker.Value = endDate;
                    int index = olympiadComboBox.FindString(tbl2.Rows[0][1].ToString());
                    olympiadComboBox.SelectedIndex = index;
                    break;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            switch (mode)
            {
                case 0:
                    if (olympiadComboBox.SelectedIndex != -1)
                    {
                        parent.parent.data.recOlympiadAdd(startDateTimePicker.Value.ToShortDateString(), endDateTimePicker.Value.ToShortDateString(), olympiadComboBox.SelectedValue.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Не все необходимые поля ввода заполнены", "Незаполнены поля");
                        return;
                    }
                    break;
                case 1:
                    if (olympiadComboBox.SelectedIndex != -1)
                    {
                        parent.parent.data.recOlympiadUpdate(id, startDateTimePicker.Value.ToShortDateString(), endDateTimePicker.Value.ToShortDateString(), olympiadComboBox.SelectedValue.ToString());
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

        private void olympiadComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = olympiadComboBox.Text;
        }

        private void startDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            endDateTimePicker.MinDate = startDateTimePicker.Value;
        }
    }
}

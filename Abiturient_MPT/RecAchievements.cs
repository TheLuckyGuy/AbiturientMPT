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
    public partial class RecAchievements : Form
    {
        MainForm parent = new MainForm();
        int mode = 0; // 0 - новое учитываемое достижение, 1 - редактирование учитываемого достижения
        int id = 0; // ID редактируемой записи, этот параметр используется для режима редактирования

        public RecAchievements(MainForm p, int formMode, int achID)
        {
            mode = formMode;
            id = achID;
            parent = p;
            InitializeComponent();
        }

        private void RecAchievements_Load(object sender, EventArgs e)
        {
            endDateTimePicker.MinDate = startDateTimePicker.Value;

            DataTable tbl1 = new DataTable();
            tbl1 = parent.data.GetData((byte)db.Tables.GetAchievements);
            achievementComboBox.DataSource = tbl1;
            achievementComboBox.DisplayMember = "Имя";  // столбец для отображения
            achievementComboBox.ValueMember = "ID";  //столбец с id
            //achievementComboBox.SelectedIndex = -1;

            switch (mode)
            {
                case 0:
                    achievementGroupBox.Text = "Добавить учитываемое достижение";
                    break;
                case 1:
                    achievementGroupBox.Text = "Редактирование учитываемого достижения";
                    

                    DataTable tbl2 = new DataTable();
                    tbl2 = parent.data.getCurrentRecAchievement(id);

                    DateTime startDate = DateTime.Parse(tbl2.Rows[0][2].ToString());
                    DateTime endDate = DateTime.Parse(tbl2.Rows[0][3].ToString());

                    startDateTimePicker.Value = startDate;
                    endDateTimePicker.Value = endDate;
                    int index = achievementComboBox.FindString(tbl2.Rows[0][1].ToString());
                    achievementComboBox.SelectedIndex = index;
                   // achievementComboBox_SelectedValueChanged(this, e);
                    break;
            }
            
        }

        private void achievementListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
                
        }

        private void achievementListBox_Click(object sender, EventArgs e)
        {
 
        }

        private void achievementComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = achievementComboBox.Text;
        }

        private void startDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            endDateTimePicker.MinDate = startDateTimePicker.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (mode)
            {
                case 0:
                    if (achievementComboBox.SelectedIndex != -1)
                    {
                        parent.data.recAchievementAdd(startDateTimePicker.Value.ToShortDateString(), endDateTimePicker.Value.ToShortDateString(), achievementComboBox.SelectedValue.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Не все необходимые поля ввода заполнены", "Незаполнены поля");
                        return;
                    }
                    break;
                case 1:
                    if (achievementComboBox.SelectedIndex != -1)
                    {
                        parent.data.recAchievementUpdate(id, startDateTimePicker.Value.ToShortDateString(), endDateTimePicker.Value.ToShortDateString(), achievementComboBox.SelectedValue.ToString());
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
    }
}

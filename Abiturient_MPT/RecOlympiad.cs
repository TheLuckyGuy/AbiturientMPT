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
        MainForm parent = new MainForm();
        int mode = 0; // 0 - новый предмет, 1 - редактирование предмета
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
            tbl1 = parent.data.GetData((byte)db.Tables.GetAchievements);
            olympiadComboBox.DataSource = tbl1;
            olympiadComboBox.DisplayMember = "Имя";  // столбец для отображения
            olympiadComboBox.ValueMember = "ID";  //столбец с id
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
                    int index = olympiadComboBox.FindString(tbl2.Rows[0][1].ToString());
                    olympiadComboBox.SelectedIndex = index;
                    // achievementComboBox_SelectedValueChanged(this, e);
                    break;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }

        private void olympiadComboBox_SelectedValueChanged(object sender, EventArgs e)
        {

        }
    }
}

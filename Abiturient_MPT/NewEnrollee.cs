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
    public partial class NewEnrollee : Form
    {
        MainForm parent = new MainForm();
        int mode = 0; // 0 - новый абитуриент, 1 - редактирование абитуриента
        int enrolleeId = 0;

        public NewEnrollee(MainForm p, int m, int enrollID)
        {
            mode = m;
            parent = p;
            enrolleeId = enrollID;

            InitializeComponent();
        }

        

        private void NewEnrollee_Load(object sender, EventArgs e)
        {
            DataTable tbl1 = new DataTable();
            tbl1 = parent.data.GetData((byte)db.Tables.GetRecordedAchievements);
            AchievementComboBox.DataSource = tbl1;
            AchievementComboBox.DisplayMember = "Name";// столбец для отображения
            AchievementComboBox.ValueMember = "ID";//столбец с id
            AchievementComboBox.SelectedIndex = -1;
        }

        private void fieldProtect_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(((sender as TextBox).Name == "passIssuedByTextBox") || ((sender as TextBox).Name == "docIssuedByTextBox"))
            {
                if ((e.KeyChar >= '0') && (e.KeyChar <= '9') || (e.KeyChar >= 'а') && (e.KeyChar <= 'я') || (e.KeyChar >= 'А') && (e.KeyChar <= 'Я') || 
                    (e.KeyChar >= 'a') && (e.KeyChar <= 'z') || (e.KeyChar >= 'A') && (e.KeyChar <= 'Z') || (e.KeyChar == 'ё') ||
                    (e.KeyChar == 'Ё') || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == '.') || (e.KeyChar == ',') || (e.KeyChar == '-') ||
                    (e.KeyChar == '(') || (e.KeyChar == ')') || (e.KeyChar == (char)Keys.Space)) return;
                else { e.Handled = true; }
            }
            else
            {
                if ((e.KeyChar >= 'а') && (e.KeyChar <= 'я') || (e.KeyChar >= 'А') && (e.KeyChar <= 'Я') || (e.KeyChar == 'ё') || 
                    (e.KeyChar == 'Ё') || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Space)) return;
                else { e.Handled = true; }
            }
        }

        private void saveEnrolleeButton_Click(object sender, EventArgs e)
        {
            int education = 0;
            int Targeted_Learning = 0;

            if (targetedLearningCheckBox.Checked == true) Targeted_Learning = 1;
            else Targeted_Learning = 0;

            if (radioButton1.Checked) education = 9;
            if (radioButton2.Checked) education = 11;

            if(!((endYearUpDown.Value >= endYearUpDown.Minimum) && (endYearUpDown.Value <= endYearUpDown.Maximum))){
                MessageBox.Show("Недопустимое значение года окончания! \nВведите значение между " + endYearUpDown.Minimum + " и " + endYearUpDown.Maximum, "Недопустимое значение");
                return;
            }
            if ((surnameTextBox.Text != String.Empty) && (nameTextBox.Text != String.Empty) && (patronymicTextBox.Text != String.Empty) && (birthDatePicker.Text != String.Empty) && (seriesTextBox.Text != String.Empty) &&
                (numberTextBox.Text != String.Empty) && (passIssuedByTextBox.Text != String.Empty) && (passIssuedDatePicker.Text != String.Empty) && (subdivTextBox.Text != String.Empty) && (documentNumberTextBox.Text != String.Empty) &&
                (docIssuedByTextBox.Text != String.Empty) && (docIssuedByTextBox.Text != String.Empty))
            {
                enrolleeId = parent.data.enrolleeAdd(surnameTextBox.Text, nameTextBox.Text, patronymicTextBox.Text, birthDatePicker.Text, seriesTextBox.Text, numberTextBox.Text, passIssuedByTextBox.Text, passIssuedDatePicker.Text,
                    subdivTextBox.Text, education, documentNumberTextBox.Text, docIssuedDatePicker.Text, Convert.ToString(endYearUpDown.Value), docIssuedByTextBox.Text, Targeted_Learning);
                parent.tabControl1_SelectedIndexChanged(this, e);
                if (enrolleeId != -1)
                {

                }
            }
            else
            {
                MessageBox.Show("Не все необходимые поля ввода заполнены" , "Незаполнены поля");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

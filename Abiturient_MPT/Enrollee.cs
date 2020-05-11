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
    public partial class Enrollee : Form
    {
        MainForm parent = new MainForm();
        int mode = 0; // 0 - новый абитуриент, 1 - редактирование абитуриента
        int id = 0;

        public Enrollee(MainForm p, int m, int enrollID)
        {
            mode = m;
            parent = p;
            id = enrollID;

            InitializeComponent();
        }

        

        private void NewEnrollee_Load(object sender, EventArgs e)
        {
            if ((id != -1) && (id != 0))
            {
                achievementsGroupBox.Enabled = true;
                marksGroupBox.Enabled = true;
                olympiadsGroupBox.Enabled = true;
            }

            DataTable tbl1 = new DataTable();
            tbl1 = parent.data.GetData((byte)db.Tables.GetRecordedAchievements);
            achievementComboBox.DataSource = tbl1;
            achievementComboBox.DisplayMember = "Название"; // столбец для отображения
            achievementComboBox.ValueMember = "ID"; //столбец с id
            achievementComboBox.SelectedIndex = -1;

            DataTable tbl2 = new DataTable();
            tbl2 = parent.data.GetData((byte)db.Tables.GetOlympiads);
            olympiadComboBox.DataSource = tbl2;
            olympiadComboBox.DisplayMember = "Название";// столбец для отображения
            olympiadComboBox.ValueMember = "ID";//столбец с id
            olympiadComboBox.SelectedIndex = -1;

            DataTable tbl4 = new DataTable();
            tbl4 = parent.data.GetData((byte)db.Tables.GetDiscipline);
            disciplineComboBox.DataSource = tbl4;
            disciplineComboBox.DisplayMember = "Название";// столбец для отображения
            disciplineComboBox.ValueMember = "ID";//столбец с id
            disciplineComboBox.SelectedIndex = -1;

            DataTable tbl5 = new DataTable();
            tbl5 = parent.data.GetData((byte)db.Tables.GetSpeciality);
            specialityComboBox.DataSource = tbl5;
            specialityComboBox.DisplayMember = "Название";// столбец для отображения
            specialityComboBox.ValueMember = "ID";//столбец с id
            specialityComboBox.SelectedIndex = -1;

            achievementGridView.DataSource = parent.data.getIndividualAchievements(id);
            markGridView.DataSource = parent.data.getenrolleeMarks(id);

            switch (mode)
            {
                case 0:

                    break;

                case 1:
                    DataTable tbl3 = new DataTable();
                    tbl3 = parent.data.getCurrentEnrollee(id);
                    DateTime birthDate = DateTime.Parse(tbl3.Rows[0][4].ToString());
                    DateTime passIssueDate = DateTime.Parse(tbl3.Rows[0][8].ToString());
                    DateTime docIssueDate = DateTime.Parse(tbl3.Rows[0][12].ToString());

                    surnameTextBox.Text = tbl3.Rows[0][1].ToString();
                    nameTextBox.Text = tbl3.Rows[0][2].ToString();
                    patronymicTextBox.Text = tbl3.Rows[0][3].ToString();
                    birthDatePicker.Value = birthDate;
                    seriesTextBox.Text = tbl3.Rows[0][5].ToString();
                    numberTextBox.Text = tbl3.Rows[0][6].ToString();
                    passIssuedByTextBox.Text = tbl3.Rows[0][7].ToString();
                    passIssuedDatePicker.Value = passIssueDate;
                    subdivTextBox.Text = tbl3.Rows[0][9].ToString();


                    documentNumberTextBox.Text = tbl3.Rows[0][11].ToString();
                    if ((int)tbl3.Rows[0][10] == 9)
                    {
                        radioButton1.Checked = true;
                    }
                    else
                    {
                        radioButton2.Checked = true;
                    }
                    docIssuedDatePicker.Value = docIssueDate;

                    endYearUpDown.Value = Convert.ToUInt32(tbl3.Rows[0][13].ToString());
                    docIssuedByTextBox.Text = tbl3.Rows[0][14].ToString();

                    if((int)tbl3.Rows[0][15] == 0)
                    {
                        targetedLearningCheckBox.Checked = false;
                    }
                    else
                    {
                        targetedLearningCheckBox.Checked = true;
                    }

                    specialityGridView.DataSource = parent.data.getEnrolleeSpeciality(id);

                    break;
            }
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
            switch (mode)
            {
                case 0:

                    if (targetedLearningCheckBox.Checked == true) Targeted_Learning = 1;
                    else Targeted_Learning = 0;

                    if (radioButton1.Checked) education = 9;
                    if (radioButton2.Checked) education = 11;

                    if (!((endYearUpDown.Value >= endYearUpDown.Minimum) && (endYearUpDown.Value <= endYearUpDown.Maximum)))
                    {
                        MessageBox.Show("Недопустимое значение года окончания! \nВведите значение между " + endYearUpDown.Minimum + " и " + endYearUpDown.Maximum, "Недопустимое значение");
                        return;
                    }
                    if ((surnameTextBox.Text != String.Empty) && (nameTextBox.Text != String.Empty) && (patronymicTextBox.Text != String.Empty) && (birthDatePicker.Text != String.Empty) && (seriesTextBox.Text != String.Empty) &&
                        (numberTextBox.Text != String.Empty) && (passIssuedByTextBox.Text != String.Empty) && (passIssuedDatePicker.Text != String.Empty) && (subdivTextBox.Text != String.Empty) && (documentNumberTextBox.Text != String.Empty) &&
                        (docIssuedByTextBox.Text != String.Empty) && (docIssuedByTextBox.Text != String.Empty))
                    {
                        id = parent.data.enrolleeAdd(surnameTextBox.Text, nameTextBox.Text, patronymicTextBox.Text, birthDatePicker.Text, seriesTextBox.Text, numberTextBox.Text, passIssuedByTextBox.Text, passIssuedDatePicker.Text,
                            subdivTextBox.Text, education, documentNumberTextBox.Text, docIssuedDatePicker.Text, Convert.ToString(endYearUpDown.Value), docIssuedByTextBox.Text, Targeted_Learning);
                        parent.tabControl1_SelectedIndexChanged(this, e);
                        if ((id != -1) && (id != 0))
                        {
                            achievementsGroupBox.Enabled = true;
                            marksGroupBox.Enabled = true;
                            olympiadsGroupBox.Enabled = true;
                        }
                        mode = 1;
                        NewEnrollee_Load(this, e);
                    }
                    else
                    {
                        MessageBox.Show("Не все необходимые поля ввода заполнены", "Незаполнены поля");
                    }
                    break;
                case 1:

                    if (targetedLearningCheckBox.Checked == true) Targeted_Learning = 1;
                    else Targeted_Learning = 0;

                    if (radioButton1.Checked) education = 9;
                    if (radioButton2.Checked) education = 11;

                    if (!((endYearUpDown.Value >= endYearUpDown.Minimum) && (endYearUpDown.Value <= endYearUpDown.Maximum)))
                    {
                        MessageBox.Show("Недопустимое значение года окончания! \nВведите значение между " + endYearUpDown.Minimum + " и " + endYearUpDown.Maximum, "Недопустимое значение");
                        return;
                    }
                    if ((surnameTextBox.Text != String.Empty) && (nameTextBox.Text != String.Empty) && (patronymicTextBox.Text != String.Empty) && (birthDatePicker.Text != String.Empty) && (seriesTextBox.Text != String.Empty) &&
                        (numberTextBox.Text != String.Empty) && (passIssuedByTextBox.Text != String.Empty) && (passIssuedDatePicker.Text != String.Empty) && (subdivTextBox.Text != String.Empty) && (documentNumberTextBox.Text != String.Empty) &&
                        (docIssuedByTextBox.Text != String.Empty) && (docIssuedByTextBox.Text != String.Empty))
                    {
                        id = parent.data.enrolleeAdd(surnameTextBox.Text, nameTextBox.Text, patronymicTextBox.Text, birthDatePicker.Text, seriesTextBox.Text, numberTextBox.Text, passIssuedByTextBox.Text, passIssuedDatePicker.Text,
                            subdivTextBox.Text, education, documentNumberTextBox.Text, docIssuedDatePicker.Text, Convert.ToString(endYearUpDown.Value), docIssuedByTextBox.Text, Targeted_Learning);
                        parent.tabControl1_SelectedIndexChanged(this, e);
                        if ((id != -1) && (id != 0))
                        {
                            achievementsGroupBox.Enabled = true;
                            marksGroupBox.Enabled = true;
                            olympiadsGroupBox.Enabled = true;
                        }
                        mode = 1;
                        NewEnrollee_Load(this, e);
                    }
                    else
                    {
                        MessageBox.Show("Не все необходимые поля ввода заполнены", "Незаполнены поля");
                    }
                    break;
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void AchievementComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(achievementComboBox.SelectedIndex != 1)
            {
                if(parent.data.individualAchievementAdd(id, (int)achievementComboBox.SelectedValue) == 0)
                {
                    NewEnrollee_Load(this, e);
                }

            }
            else
            {
                MessageBox.Show("Не все необходимые поля ввода заполнены", "Незаполнены поля");
            }

        }

        private void olympiadComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = olympiadComboBox.Text;
        }

        private void deleteIndAchButton_Click(object sender, EventArgs e)
        {
            const string message = "Вы действительно хотите удалить запись (записи)?";
            const string caption = "Удаление";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return;
            }


            if (achievementGridView.SelectedRows.Count >= 1)
            {
                for (int i = 0; i < achievementGridView.SelectedRows.Count; i++)
                {
                    if (achievementGridView.SelectedRows[i].Cells["ID"].Value.ToString() != null)
                    {
                        if (parent.data.individualAchievementDelete((int)achievementGridView.SelectedRows[i].Cells["ID"].Value) == 0)
                        {
                            NewEnrollee_Load(this, e);
                        }
                    }
                }
            }
            if (achievementGridView.SelectedCells.Count > 0)
            {
                if (parent.data.individualAchievementDelete((int)achievementGridView.CurrentCell.OwningRow.Cells["ID"].Value) == 0)
                {
                    NewEnrollee_Load(this, e);
                }

            }
        }

        private void addMarkButton_Click(object sender, EventArgs e)
        {
            if (disciplineComboBox.SelectedIndex != -1)
            {
                if (parent.data.enrolleeMarkAdd(id, (int)disciplineComboBox.SelectedValue, (int)markUpDown.Value) == 0)
                {
                    NewEnrollee_Load(this, e);
                }
                else
                {
                    return;
                }
                
            }
            else
            {
                MessageBox.Show("Не все необходимые поля ввода заполнены", "Незаполнены поля");
            }
        }

        private void deleteMarkButton_Click(object sender, EventArgs e)
        {
            const string message = "Вы действительно хотите удалить запись (записи)?";
            const string caption = "Удаление";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return;
            }


            if (markGridView.SelectedRows.Count >= 1)
            {
                for (int i = 0; i < markGridView.SelectedRows.Count; i++)
                {
                    if (markGridView.SelectedRows[i].Cells["ID"].Value.ToString() != null)
                    {
                        if (parent.data.individualAchievementDelete((int)markGridView.SelectedRows[i].Cells["ID"].Value) == 0)
                        {
                            NewEnrollee_Load(this, e);
                        }
                    }
                }
            }
            if (markGridView.SelectedCells.Count > 0) parent.data.individualAchievementDelete((int)markGridView.CurrentCell.OwningRow.Cells["ID"].Value);
        }

        private void addSpecialityButton_Click(object sender, EventArgs e)
        {
            if(specialityComboBox.SelectedIndex != 1)
            {
                if(parent.data.enrolleeSpecialityAdd(id, (int)specialityComboBox.SelectedValue) == 0)
                {
                    NewEnrollee_Load(this, e);
                }
                
            }
            else
            {
                MessageBox.Show("Не все необходимые поля ввода заполнены", "Незаполнены поля");
            }
        }
    }
}

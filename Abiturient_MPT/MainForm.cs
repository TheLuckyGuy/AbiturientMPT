using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Abiturient_MPT
{
    public partial class MainForm : Form
    {
        //public db data = new db();

        public Auth parent = new Auth();

        public MainForm(Auth p)
        {
            parent = p;
            InitializeComponent();
            //data = p.data;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            enrolleeGroupBox.Enabled = parent.currentUser.Enrollee;
            listGroupBox.Enabled = parent.currentUser.EnrolleeList;
            disciplineGroupBox.Enabled = parent.currentUser.Disciplines;
            priorityGroupBox.Enabled = parent.currentUser.Disciplines;
            specialityGroupBox.Enabled = parent.currentUser.Specialities;
            specialityGroupGroupBox.Enabled = parent.currentUser.Specialities;
            achievementsGroupBox.Enabled = parent.currentUser.Achievements;
            recAchievementsGroupBox.Enabled = parent.currentUser.Achievements;
            olympiadsGroupBox.Enabled = parent.currentUser.Olympiads;
            recOlympiadsGroupBox.Enabled = parent.currentUser.Olympiads;
            statsGroupBox.Enabled = parent.currentUser.Statistics;

            roleLabel.Text = parent.currentUser.Role;
            tabControl1_SelectedIndexChanged(this, e);
        }



        public void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedTab.Name)
            {
                case "EnrolleePage":
                    if (parent.currentUser.Enrollee)
                    {
                        enrolleeGridView.DataSource = parent.data.GetData((byte)db.Tables.GetEnrollees);
                    }                  
                    break;
                case "EnrolleeListPage":
                    if (parent.currentUser.EnrolleeList)
                    {
                        DataTable tbl5 = new DataTable();
                        tbl5 = parent.data.GetData((byte)db.Tables.GetSpeciality);
                        specialityComboBox.DataSource = tbl5;
                        specialityComboBox.DisplayMember = "Название";// столбец для отображения
                        specialityComboBox.ValueMember = "ID";//столбец с id
                        specialityComboBox.SelectedIndex = -1;
                    }
                    break;
                case "DisciplinesPage":
                    if (parent.currentUser.Disciplines)
                    {
                        disciplineGridView.DataSource = parent.data.GetData((byte)db.Tables.GetDiscipline);
                        priorityGridView.DataSource = parent.data.GetData((byte)db.Tables.GetDisciplinePriority);
                    }

                    break;
                case "SpecialitiesPage":
                    if (parent.currentUser.Specialities)
                    {
                        specialityGridView.DataSource = parent.data.GetData((byte)db.Tables.GetSpeciality);
                        specialityGroupGridView.DataSource = parent.data.GetData((byte)db.Tables.GetSpecialityGroup);
                    }

                    break;
                case "AchievementsPage":
                    if (parent.currentUser.Achievements)
                    {
                        achRecGridView.DataSource = parent.data.GetData((byte)db.Tables.GetRecordedAchievements);
                        achGridView.DataSource = parent.data.GetData((byte)db.Tables.GetAchievements);
                    }
                    
                    break;
                case "OlympiadsPage":
                    if (parent.currentUser.Olympiads)
                    {
                        olymiadGridView.DataSource = parent.data.GetData((byte)db.Tables.GetOlympiads);
                        recOlympiadGridView.DataSource = parent.data.GetData((byte)db.Tables.GetRecordedOlympiad);
                    }
                    
                    break;
                case "StatisticsPage":
                    if (parent.currentUser.Statistics)
                    {
                        DataTable tbl6 = new DataTable();
                        tbl6 = parent.data.GetData((byte)db.Tables.GetSpeciality);
                        specStatComboBox.DataSource = tbl6;
                        specStatComboBox.DisplayMember = "Название";// столбец для отображения
                        specStatComboBox.ValueMember = "ID";//столбец с id
                        specStatComboBox.SelectedIndex = -1;
                    }

                    break;
            }
        }

        private void EnrolleeButton_Click(object sender, EventArgs e)
        {
            switch ((sender as Button).Name) {
                case "addEnrolleeButton":
                    Enrollee newEnrollee = new Enrollee(this, 0, 0);
                    newEnrollee.Show();
                    break;
                case "editEnrolleeButton":
                    if(enrolleeGridView.CurrentCell != null)
                    {
                    Enrollee editEnrollee = new Enrollee(this, 1, Convert.ToInt32(enrolleeGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString()));
                    editEnrollee.Show();
                    }
                    break;
                case "deleteEnrolleeButton":
                    if (enrolleeGridView.CurrentCell != null)
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


                        if (enrolleeGridView.SelectedRows.Count >= 1)
                        {
                            for (int i = 0; i < enrolleeGridView.SelectedRows.Count; i++)
                            {
                                if (enrolleeGridView.SelectedRows[i].Cells["ID"].Value.ToString() != null) parent.data.enrolleeDelete(enrolleeGridView.SelectedRows[i].Cells["ID"].Value.ToString());
                            }
                        }
                        if (enrolleeGridView.SelectedCells.Count > 0) parent.data.enrolleeDelete(enrolleeGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString());
                    }
                    break;
            }
            
        }

        private void AchievementButtons_Click(object sender, EventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "addAchievementButton":
                    NewAchievement newAchievement = new NewAchievement(this, 0, 0);
                    newAchievement.Show();
                    break;
                case "editAchievementButton":
                    if(achRecGridView.CurrentCell != null)
                    {
                    NewAchievement editAchievement = new NewAchievement(this, 1, Convert.ToInt32(achGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString()));
                    editAchievement.Show();
                    }
                    break;
                case "deleteAchievementButton":
                    if (achRecGridView.CurrentCell != null)
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


                        if (achGridView.SelectedRows.Count >= 1)
                        {
                            for (int i = 0; i < achGridView.SelectedRows.Count; i++)
                            {
                                if (achGridView.SelectedRows[i].Cells["ID"].Value.ToString() != null) parent.data.achievementDelete(achGridView.SelectedRows[i].Cells["ID"].Value.ToString());
                            }
                        }
                        if (achGridView.SelectedCells.Count > 0) parent.data.achievementDelete(achGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString());
                    }
                    break;
                   
            }
        }

        private void SpecialityButtons_Click(object sender, EventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "addSpecialityButton":
                    Speciality addSpeciality = new Speciality(this, 0, 0);
                    addSpeciality.Show();
                    break;
                case "editSpecialityButton":
                    if(specialityGridView.CurrentCell != null)
                    {
                    Speciality editSpeciality = new Speciality(this, 1, Convert.ToInt32(specialityGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString()));
                    editSpeciality.Show();
                    }
                    break;
                case "deleteSpecialityButton":
                    if (specialityGridView.CurrentCell != null)
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


                        if (specialityGridView.SelectedRows.Count >= 1)
                        {
                            for (int i = 0; i < specialityGridView.SelectedRows.Count; i++)
                            {
                                if (specialityGridView.SelectedRows[i].Cells["ID"].Value.ToString() != null) parent.data.specialityDelete(specialityGridView.SelectedRows[i].Cells["ID"].Value.ToString());
                            }
                        }
                        if (specialityGridView.SelectedCells.Count > 0) parent.data.specialityDelete(specialityGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString());
                    }
                    break;
            }
        }

        private void DisciplineButtons_Click(object sender, EventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "addDisciplineButton":
                    Discipline newDiscipline = new Discipline(this, 0, 0);
                    newDiscipline.Show();
                    break;
                case "editDisciplineButton":
                    if(disciplineGridView.CurrentCell != null)
                    {
                    Discipline editDiscipline = new Discipline(this, 1, Convert.ToInt32(disciplineGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString()));
                    editDiscipline.Show();
                    }

                    break;
                case "deleteDisciplineButton":
                    if (disciplineGridView.CurrentCell != null)
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


                        if (enrolleeGridView.SelectedRows.Count >= 1)
                        {
                            for (int i = 0; i < enrolleeGridView.SelectedRows.Count; i++)
                            {
                                if (enrolleeGridView.SelectedRows[i].Cells["ID"].Value.ToString() != null) parent.data.disciplineDelete(enrolleeGridView.SelectedRows[i].Cells["ID"].Value.ToString());
                            }
                        }
                        if (enrolleeGridView.SelectedCells.Count > 0) parent.data.disciplineDelete(enrolleeGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString());
                    }
                    break;
            }
        }

        private void AchRecButtons_Click(object sender, EventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "addAchRecButton":
                    RecAchievements newRecAchievements = new RecAchievements(this, 0, 0);
                    newRecAchievements.Show();
                    break;
                case "editAchRecButton":
                    if(achRecGridView.CurrentCell != null)
                    {
                    RecAchievements editRecAchievements = new RecAchievements(this, 1, Convert.ToInt32(achRecGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString()));
                    editRecAchievements.Show();
                    }
                    break;
                case "deleteAchRecButton":
                    if (achRecGridView.CurrentCell != null)
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


                        if (achRecGridView.SelectedRows.Count >= 1)
                        {
                            for (int i = 0; i < achRecGridView.SelectedRows.Count; i++)
                            {
                                if (achRecGridView.SelectedRows[i].Cells["ID"].Value.ToString() != null) parent.data.recAchievementDelete(achRecGridView.SelectedRows[i].Cells["ID"].Value.ToString());
                            }
                        }
                        if (achRecGridView.SelectedCells.Count > 0) parent.data.recAchievementDelete(achRecGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString());
                    }
                    break;
            }
        }

        private void OlympiadButtons_Click(object sender, EventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "addOlympiadButton":
                    Olympiad addOlympiad = new Olympiad(this, 0, 0);
                    addOlympiad.Show();
                    break;
                case "editOlympiadButton":
                    if(olymiadGridView.CurrentCell != null)
                    {
                        Olympiad editOlympiad = new Olympiad(this, 1, Convert.ToInt32(olymiadGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString()));
                        editOlympiad.Show();
                    }
                    break;
                case "deleteOlympiadButton":
                    if (olymiadGridView.CurrentCell != null)
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


                        if (olymiadGridView.SelectedRows.Count >= 1)
                        {
                            for (int i = 0; i < olymiadGridView.SelectedRows.Count; i++)
                            {
                                if (olymiadGridView.SelectedRows[i].Cells["ID"].Value.ToString() != null) parent.data.olympiadDelete(olymiadGridView.SelectedRows[i].Cells["ID"].Value.ToString());
                            }
                        }
                        if (olymiadGridView.SelectedCells.Count > 0) parent.data.olympiadDelete(olymiadGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString());
                    }
                    break;
            }
        }

        private void SpecialityGroupButtons_Click(object sender, EventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "addSpecialityGroupButton":
                    SpecialityGroup addSpecialityGroup = new SpecialityGroup(this, 0, 0);
                    addSpecialityGroup.Show();
                    break;
                case "editSpecialityGroupButton":
                    if(specialityGridView.CurrentCell != null)
                    {
                    SpecialityGroup editSpecialityGroup = new SpecialityGroup(this, 1, Convert.ToInt32(specialityGroupGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString()));
                    editSpecialityGroup.Show();
                    }
                    break;
                case "deleteSpecialityGroupButton":
                    if (specialityGridView.CurrentCell != null)
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


                        if (specialityGroupGridView.SelectedRows.Count >= 1)
                        {
                            for (int i = 0; i < specialityGroupGridView.SelectedRows.Count; i++)
                            {
                                if (specialityGroupGridView.SelectedRows[i].Cells["ID"].Value.ToString() != null) parent.data.specialityGroupDelete(specialityGroupGridView.SelectedRows[i].Cells["ID"].Value.ToString());
                            }
                        }
                        if (specialityGroupGridView.SelectedCells.Count > 0) parent.data.specialityGroupDelete(specialityGroupGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString());
                    }
                    break;
            }
        }

        private void priorityButtons_Click(object sender, EventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "addPriorityButton":
                    DisciplinePriority addPriority = new DisciplinePriority(this, 0, 0);
                    addPriority.Show();
                    break;
                case "editPriorityButton":
                    if(priorityGridView.CurrentCell != null)
                    {
                    DisciplinePriority editPriority = new DisciplinePriority(this, 1, Convert.ToInt32(priorityGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString()));
                    editPriority.Show();
                    }

                    break;
                case "deletePriorityButton":
                    if (priorityGridView.CurrentCell != null)
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


                        if (priorityGridView.SelectedRows.Count >= 1)
                        {
                            for (int i = 0; i < priorityGridView.SelectedRows.Count; i++)
                            {
                                if (priorityGridView.SelectedRows[i].Cells["ID"].Value.ToString() != null) parent.data.priorityDelete(priorityGridView.SelectedRows[i].Cells["ID"].Value.ToString());
                            }
                        }
                        if (priorityGridView.SelectedCells.Count > 0) parent.data.priorityDelete(priorityGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString());
                    }
                    break;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
            //Application.Exit();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Show();
        }

        private void specialityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void specialityComboBox_SelectedValueChanged(object sender, EventArgs e)
        {

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((specialityComboBox.SelectedIndex != -1))
            {
                //string s = specialityComboBox.SelectedValue.ToString();
                enrolleeListGridView.DataSource = parent.data.GetAcceptedEnrolleeList((int)specialityComboBox.SelectedValue);
            }
        }

        private void recOlympiadButtons_Click(object sender, EventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "addRecOlympiadButton":
                    RecOlympiad newRecOlympiad = new RecOlympiad(this, 0, 0);
                    newRecOlympiad.Show();
                    break;
                case "editRecOlympiadButton":
                    if (recOlympiadGridView.CurrentCell != null)
                    {
                        RecOlympiad editRecOlympiad = new RecOlympiad(this, 1, Convert.ToInt32(recOlympiadGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString()));
                        editRecOlympiad.Show();
                    }
                    break;
                case "deleteRecOlympiadButton":
                    if (recOlympiadGridView.CurrentCell != null)
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


                        if (recOlympiadGridView.SelectedRows.Count >= 1)
                        {
                            for (int i = 0; i < recOlympiadGridView.SelectedRows.Count; i++)
                            {
                                if (recOlympiadGridView.SelectedRows[i].Cells["ID"].Value.ToString() != null) parent.data.recOlympiadDelete(recOlympiadGridView.SelectedRows[i].Cells["ID"].Value.ToString());
                            }
                        }
                        if (recOlympiadGridView.SelectedCells.Count > 0) parent.data.recOlympiadDelete(recOlympiadGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString());
                    }
                    break;
            }
        }

        private void exportListButton_Click(object sender, EventArgs e)
        {
            Excel.Application exApp = new Excel.Application();
            exApp.Visible = true;
            exApp.SheetsInNewWorkbook = 1;
            Excel.Workbook workBook = exApp.Workbooks.Add();
            Excel.Worksheet workSheet = (Excel.Worksheet)exApp.Worksheets.get_Item(1);
            Excel.Range range1 = (Excel.Range)exApp.Range[workSheet.Cells[1, 1], workSheet.Cells[1, 9]];

            for (int i = 1; i <= enrolleeListGridView.Columns.Count; i++)
            {
                workSheet.Cells[1, i] = enrolleeListGridView.Columns[i - 1].HeaderText;
                workSheet.Cells[1, i].ColumnWidth = enrolleeListGridView.Columns[i - 1].Width / 2;

            }


            int rowExcel = 2; //начать со второй строки.
            for (int i = 0; i < enrolleeListGridView.Rows.Count; i++)
            {
                for (int k = 1; k <= enrolleeListGridView.Columns.Count; k++)
                {
                    workSheet.Cells[rowExcel, k] = enrolleeListGridView.Rows[i].Cells[k - 1].Value;
                }


                ++rowExcel;
            }
            //string pathToXmlFile;
            //pathToXmlFile = Environment.CurrentDirectory + "\\" + "MyFile.xls";
            exApp.Quit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((specStatComboBox.SelectedIndex != -1))
            {
                //string s = specialityComboBox.SelectedValue.ToString();
                statsGridView.DataSource = parent.data.GetSpecialityStats((int)specStatComboBox.SelectedValue);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Excel.Application exApp = new Excel.Application();
            exApp.Visible = true;
            exApp.SheetsInNewWorkbook = 1;
            Excel.Workbook workBook = exApp.Workbooks.Add();
            Excel.Worksheet workSheet = (Excel.Worksheet)exApp.Worksheets.get_Item(1);
            Excel.Range range1 = (Excel.Range)exApp.Range[workSheet.Cells[1, 1], workSheet.Cells[1, 9]];

            for (int i = 1; i <= statsGridView.Columns.Count; i++)
            {
                workSheet.Cells[1, i] = statsGridView.Columns[i - 1].HeaderText;
                workSheet.Cells[1, i].ColumnWidth = statsGridView.Columns[i - 1].Width / 2;

            }


            int rowExcel = 2; //начать со второй строки.
            for (int i = 0; i < statsGridView.Rows.Count; i++)
            {
                for (int k = 1; k <= statsGridView.Columns.Count; k++)
                {
                    workSheet.Cells[rowExcel, k] = statsGridView.Rows[i].Cells[k - 1].Value;
                }


                ++rowExcel;
            }
            //string pathToXmlFile;
            //pathToXmlFile = Environment.CurrentDirectory + "\\" + "MyFile.xls";
            exApp.Quit();
        }
    }
}

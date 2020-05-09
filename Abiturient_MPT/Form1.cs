﻿using System;
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
    public partial class MainForm : Form
    {
        public db data = new db();

        public MainForm()
        {
            InitializeComponent();
        }
        
        public void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedTab.Name)
            {
                case "EnrolleePage":
                    enrolleeGridView.DataSource = data.GetData((byte)db.Tables.GetEnrollees);
                    break;
                case "EnrolleeListPage":

                    break;
                case "DisciplinesPage":
                    disciplineGridView.DataSource = data.GetData((byte)db.Tables.GetDiscipline);
                    priorityGridView.DataSource = data.GetData((byte)db.Tables.GetDisciplinePriority);
                    break;
                case "SpecialitiesPage":
                    specialityGridView.DataSource = data.GetData((byte)db.Tables.GetSpeciality);
                    specialityGroupGridView.DataSource = data.GetData((byte)db.Tables.GetSpecialityGroup);
                    break;
                case "AchievementsPage":
                    achRecGridView.DataSource = data.GetData((byte)db.Tables.GetRecordedAchievements);
                    achGridView.DataSource = data.GetData((byte)db.Tables.GetAchievements);
                    break;
                case "OlympiadsPage":
                    olymiadGridView.DataSource = data.GetData((byte)db.Tables.GetOlympiads);
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
                    Enrollee editEnrollee = new Enrollee(this, 1, Convert.ToInt32(enrolleeGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString()));
                    editEnrollee.Show();
                    break;
                case "deleteEnrolleeButton":
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
                            if (enrolleeGridView.SelectedRows[i].Cells["ID"].Value.ToString() != null) data.enrolleeDelete(enrolleeGridView.SelectedRows[i].Cells["ID"].Value.ToString());
                        }
                    }
                    if (enrolleeGridView.SelectedCells.Count > 0) data.enrolleeDelete(enrolleeGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString());
                    break;
            }
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tabControl1_SelectedIndexChanged(this, e);
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
                    NewAchievement editAchievement = new NewAchievement(this, 1, Convert.ToInt32(achGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString()));
                    editAchievement.Show();
                    break;
                case "deleteAchievementButton":
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
                            if (achGridView.SelectedRows[i].Cells["ID"].Value.ToString() != null) data.achievementDelete(achGridView.SelectedRows[i].Cells["ID"].Value.ToString());
                        }
                    }
                    if (achGridView.SelectedCells.Count > 0) data.achievementDelete(achGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString());
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
                    Speciality editSpeciality = new Speciality(this, 1, Convert.ToInt32(specialityGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString()));
                    editSpeciality.Show();
                    break;
                case "deleteSpecialityButton":
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
                            if (specialityGridView.SelectedRows[i].Cells["ID"].Value.ToString() != null) data.specialityDelete(specialityGridView.SelectedRows[i].Cells["ID"].Value.ToString());
                        }
                    }
                    if (specialityGridView.SelectedCells.Count > 0) data.specialityDelete(specialityGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString());
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
                    Discipline editDiscipline = new Discipline(this, 1, Convert.ToInt32(disciplineGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString()));
                    editDiscipline.Show();
                    break;
                case "deleteDisciplineButton":
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
                            if (enrolleeGridView.SelectedRows[i].Cells["ID"].Value.ToString() != null) data.disciplineDelete(enrolleeGridView.SelectedRows[i].Cells["ID"].Value.ToString());
                        }
                    }
                    if (enrolleeGridView.SelectedCells.Count > 0) data.disciplineDelete(enrolleeGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString());
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
                    RecAchievements editRecAchievements = new RecAchievements(this, 1, Convert.ToInt32(achRecGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString()));
                    editRecAchievements.Show();
                    break;
                case "deleteAchRecButton":
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
                            if (achRecGridView.SelectedRows[i].Cells["ID"].Value.ToString() != null) data.recAchievementDelete(achRecGridView.SelectedRows[i].Cells["ID"].Value.ToString());
                        }
                    }
                    if (achRecGridView.SelectedCells.Count > 0) data.recAchievementDelete(achRecGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString());
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
                    Olympiad editOlympiad = new Olympiad(this, 1, Convert.ToInt32(olymiadGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString()));
                    editOlympiad.Show();
                    break;
                case "deleteOlympiadButton":
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
                            if (olymiadGridView.SelectedRows[i].Cells["ID"].Value.ToString() != null) data.olympiadDelete(olymiadGridView.SelectedRows[i].Cells["ID"].Value.ToString());
                        }
                    }
                    if (olymiadGridView.SelectedCells.Count > 0) data.olympiadDelete(olymiadGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString());
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
                case "editSpecialityButton":
                    SpecialityGroup editSpecialityGroup = new SpecialityGroup(this, 1, Convert.ToInt32(specialityGroupGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString()));
                    editSpecialityGroup.Show();
                    break;
                case "deleteSpecialityButton":
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
                            if (specialityGroupGridView.SelectedRows[i].Cells["ID"].Value.ToString() != null) data.specialityDelete(specialityGroupGridView.SelectedRows[i].Cells["ID"].Value.ToString());
                        }
                    }
                    if (specialityGroupGridView.SelectedCells.Count > 0) data.specialityDelete(specialityGroupGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString());
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
                    DisciplinePriority editPriority = new DisciplinePriority(this, 1, Convert.ToInt32(priorityGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString()));
                    editPriority.Show();
                    break;
                case "deletePriorityButton":
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
                            if (priorityGridView.SelectedRows[i].Cells["ID"].Value.ToString() != null) data.priorityDelete(priorityGridView.SelectedRows[i].Cells["ID"].Value.ToString());
                        }
                    }
                    if (priorityGridView.SelectedCells.Count > 0) data.priorityDelete(priorityGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString());
                    break;
            }
        }
    }
}

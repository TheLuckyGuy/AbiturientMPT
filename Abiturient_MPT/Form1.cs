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

                    break;
                case "SpecialitiesPage":

                    break;
                case "AchievementsPage":
                    achRecGridView.DataSource = data.GetData((byte)db.Tables.GetRecordedAchievements);
                    achGridView.DataSource = data.GetData((byte)db.Tables.GetAchievements);
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch ((sender as Button).Name) {
                case "addEnrolleeButton":
                    NewEnrollee newEnrollee = new NewEnrollee(this, 0, 0);
                    newEnrollee.Show();
                    break;
                case "editEnrolleeButton":
                    NewEnrollee editEnrollee = new NewEnrollee(this, 1, Convert.ToInt32(enrolleeGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString()));
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
                            if (achGridView.SelectedRows[i].Cells["ID"].Value.ToString() != null) data.enrolleeDelete(achGridView.SelectedRows[i].Cells["ID"].Value.ToString());
                        }
                    }
                    if (achGridView.SelectedCells.Count > 0) data.achievementDelete(achGridView.CurrentCell.OwningRow.Cells["ID"].Value.ToString());
                    break;
                   
            }
        }
    }
}

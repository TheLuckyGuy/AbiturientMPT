using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Abiturient_MPT
{
    public class db
    {
        public SqlConnection sql = new SqlConnection("Data Source = LAPTOP-KPGPB2J6; " +
            "initial Catalog = Abiturient_MPT; Persist Security Info = true; User ID = sa; Password = \"17455688\"");

        public enum RoleID
        {
            superior = 1
        }

        public db()
        {
            //sql.Open();
        }

        public enum Tables
        {
            Achievement,
            Discipline,
            Discipline_Priority,
            Enrollee,
            Enrollee_Mark,
            Enrollee_Speciality,
            Individual_Achievements,
            Olympiad,
            Recorded_Achievement,
            Recorded_Olympiad,
            Speciality,
            Speciality_Group,
            Winned_Olympiad,
            GetEnrollees,
            GetRecordedAchievements,
            GetAchievements,
            GetDiscipline,
            GetOlympiads,
            GetSpecialityGroup,
            GetSpeciality,
            GetSpecialityGroupShort,
            GetDisciplinePriority
        }

        static List<string> commands = new List<string>()
        {
            "select * from dbo.Achievement",
            "select * from dbo.Discipline",
            "select * from dbo.Discipline_Priority",
            "select * from dbo.Enrollee",
            "select * from dbo.Enrollee_Mark",
            "select * from dbo.Enrollee_Speciality",
            "select * from dbo.Individual_Achievements",
            "select * from dbo.Olympiad",
            "select * from dbo.Recorded_Achievement",
            "select * from dbo.Recorded_Olympiad",
            "select * from dbo.Speciality",
            "select * from dbo.Speciality_Group",
            "select * from dbo.Winned_Olympiad",
            "exec dbo.GetEnrollees",
            "exec dbo.GetRecordedAchievements",
            "exec dbo.GetAchievements",
            "exec dbo.GetDiscipline",
            "exec dbo.GetOlympiads",
            "exec dbo.GetSpecialityGroup",
            "exec dbo.GetSpeciality",
            "exec dbo.GetSpecialityGroupShort",
            "exec dbo.GetDisciplinePriority"
        };

        static string md5(string text)
        {
            using (var md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(text));

                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }

        public DataTable GetFilledTable(byte index)
        {
            DataTable tempDT = new DataTable();
            tempDT.Load((SqlDataReader)new SqlCommand(commands[index], sql).ExecuteReader());
            return tempDT;
        }

        public DataTable GetData(byte index)
        {
            try
            {
                sql.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(commands[index], sql);
                // Создаем объект Dataset
                DataSet ds = new DataSet();
                // Заполняем Dataset
                adapter.Fill(ds);
                // Возвращаем данные
                return ds.Tables[0];
            }
            catch
            {
                return null;
            }
            finally
            {
                sql.Close();
            }
        }
        public int enrolleeAdd(string surname, string name, string patronymic, string birthDate, string Pass_Series, string Pass_Number, string Pass_Issued_By, string Pass_Issue_Date,
            string Subdiv_Code, int Education, string Certificate_Num, string Issue_Date, string End_Year, string Cert_Issued_By, int Targeted_Learning)
        {
            int enrolleeId = 0;
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Insert_Enrollee @Surname, @Name, @Patronymic, @Birth_Date, @Pass_Series, @Pass_Number, @Pass_Issued_By, @Pass_Issue_Date, @Subdiv_Code, @Education, @Certificate_Num, @Issue_Date, @End_Year, @Cert_Issued_By, @Targeted_Learning", sql);

                SqlParameter enrolleeSurname = new SqlParameter("@Surname", surname);
                command.Parameters.Add(enrolleeSurname);

                SqlParameter enrolleeName = new SqlParameter("@Name", name);
                command.Parameters.Add(enrolleeName);

                SqlParameter enrolleePatronymic = new SqlParameter("@Patronymic", patronymic);
                command.Parameters.Add(enrolleePatronymic);

                SqlParameter enrolleeBirthDate = new SqlParameter("@Birth_Date", birthDate);
                command.Parameters.Add(enrolleeBirthDate);

                SqlParameter enrolleePassSeries = new SqlParameter("@Pass_Series", Pass_Series);
                command.Parameters.Add(enrolleePassSeries);

                SqlParameter enrolleePassNumber = new SqlParameter("@Pass_Number", Pass_Number);
                command.Parameters.Add(enrolleePassNumber);
            
                SqlParameter enrolleePIssuedBy = new SqlParameter("@Pass_Issued_By", Pass_Issued_By);
                command.Parameters.Add(enrolleePIssuedBy);

                SqlParameter enrolleePassIssueDate = new SqlParameter("@Pass_Issue_Date", Pass_Issue_Date);
                command.Parameters.Add(enrolleePassIssueDate);

                SqlParameter enrolleeSubdivCode = new SqlParameter("@Subdiv_Code", Subdiv_Code);
                command.Parameters.Add(enrolleeSubdivCode);

                SqlParameter enrolleeEducation = new SqlParameter("@Education", Education);
                command.Parameters.Add(enrolleeEducation);

                SqlParameter enrolleeCertificateNum = new SqlParameter("@Certificate_Num", Certificate_Num);
                command.Parameters.Add(enrolleeCertificateNum);

                SqlParameter enrolleeCertIssueDate = new SqlParameter("@Issue_Date", Issue_Date);
                command.Parameters.Add(enrolleeCertIssueDate);

                SqlParameter enrolleeEndYear = new SqlParameter("@End_Year", End_Year);
                command.Parameters.Add(enrolleeEndYear);

                SqlParameter enrolleeCertIssuedBy = new SqlParameter("@Cert_Issued_By", Cert_Issued_By);
                command.Parameters.Add(enrolleeCertIssuedBy);

                SqlParameter enrolleeTargetedLearningIssuedBy = new SqlParameter("@Targeted_Learning", Targeted_Learning);
                command.Parameters.Add(enrolleeTargetedLearningIssuedBy);

                enrolleeId = (Int32)command.ExecuteScalar();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                sql.Close();
            }
            return enrolleeId;
        }

        public DataTable getCurrentEnrollee(string enrolleeID)
        {
            DataTable tempDT = new DataTable();
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec getCurrentEnrollee @Enrollee_ID", sql);

                SqlParameter EnrolleeIDParam = new SqlParameter("@Enrollee_ID", enrolleeID);
                command.Parameters.Add(EnrolleeIDParam);
                
                tempDT.Load((SqlDataReader)command.ExecuteReader());
            }
            catch { return null; }
            finally
            {
                sql.Close();
                
            }
            return tempDT;
            //return 0;
        }

        public int enrolleeDelete(string enrolleeID)
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Delete_Enrollee @Enrollee_ID", sql);

                SqlParameter EnrolleeIDParam = new SqlParameter("@Enrollee_ID", enrolleeID);
                command.Parameters.Add(EnrolleeIDParam);

                command.ExecuteNonQuery();
            }
            catch { return -1; }
            finally
            {
                sql.Close();
            }
            return 0;
        }

        public int achievementAdd(string name)
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Insert_Achievement @Name", sql);

                SqlParameter nameParam = new SqlParameter("@Name", name);
                command.Parameters.Add(nameParam);

                command.ExecuteNonQuery();
            }
            catch { return -1; }
            finally
            {
                sql.Close();
            }
            return 0;
        }
        public int achievementUpdate(int achID, string name)
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Update_Achievement @ID_Achievement, @Name", sql);

                SqlParameter idParam = new SqlParameter("@ID_Achievement", achID);
                command.Parameters.Add(idParam);

                SqlParameter nameParam = new SqlParameter("@Name", name);
                command.Parameters.Add(nameParam);

                command.ExecuteNonQuery();
            }
            catch { return -1; }
            finally
            {
                sql.Close();
            }
            return 0;
        }
        public int achievementDelete(string achievementID)
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Delete_Achievement @Achievement_ID", sql);

                SqlParameter idParam = new SqlParameter("@Achievement_ID", achievementID);
                command.Parameters.Add(idParam);

                command.ExecuteNonQuery();
            }
            catch { return -1; }
            finally
            {
                sql.Close();
            }
            return 0;
        }
        public DataTable getCurrentAchievement(int achievementID)
        {
            DataTable tempDT = new DataTable();
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec getCurrentAchievement @Enrollee_ID", sql);

                SqlParameter idParam = new SqlParameter("@Enrollee_ID", achievementID);
                command.Parameters.Add(idParam);

                tempDT.Load((SqlDataReader)command.ExecuteReader());
            }
            catch { return null; }
            finally
            {
                sql.Close();

            }
            return tempDT;
        }

        public int disciplineAdd(string name)
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Insert_Discipline @Name", sql);

                SqlParameter nameParam = new SqlParameter("@Name", name);
                command.Parameters.Add(nameParam);

                command.ExecuteNonQuery();
            }
            catch { return -1; }
            finally
            {
                sql.Close();
            }
            return 0;
        }
        public int disciplineUpdate(int disciplineID, string name)
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Update_Discipline @ID_Discipline, @Name", sql);

                SqlParameter idParam = new SqlParameter("@ID_Discipline", disciplineID);
                command.Parameters.Add(idParam);

                SqlParameter nameParam = new SqlParameter("@Name", name);
                command.Parameters.Add(nameParam);

                command.ExecuteNonQuery();
            }
            catch { return -1; }
            finally
            {
                sql.Close();
            }
            return 0;
        }
        public int disciplineDelete(string disciplineID)
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Delete_Discipline @Discipline_ID", sql);

                SqlParameter idParam = new SqlParameter("@Discipline_ID", disciplineID);
                command.Parameters.Add(idParam);

                command.ExecuteNonQuery();
            }
            catch { return -1; }
            finally
            {
                sql.Close();
            }
            return 0;
        }
        public DataTable getCurrentDiscipline(int disciplineID)
        {
            DataTable tempDT = new DataTable();
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec getCurrentDiscipline @Discipline_ID", sql);

                SqlParameter idParam = new SqlParameter("@Discipline_ID", disciplineID);
                command.Parameters.Add(idParam);


                tempDT.Load((SqlDataReader)command.ExecuteReader());
            }
            catch { return null; }
            finally
            {
                sql.Close();

            }
            return tempDT;
        }

        public int recAchievementAdd(string StartDate, string EndDate, string AchievementID)
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Insert_Recorded_Achievement @StartDate, @EndDate, @Achievement_ID", sql);

                SqlParameter startDateParam = new SqlParameter("@StartDate", StartDate);
                command.Parameters.Add(startDateParam);

                SqlParameter endDateParam = new SqlParameter("@EndDate", EndDate);
                command.Parameters.Add(endDateParam);

                SqlParameter achievementIDParam = new SqlParameter("@Achievement_ID", AchievementID);
                command.Parameters.Add(achievementIDParam);

                command.ExecuteNonQuery();
            }
            catch { return -1; }
            finally
            {
                sql.Close();
            }
            return 0;
        }
        public int recAchievementUpdate(int recAchievementID, string StartDate, string EndDate, string AchievementID)
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Update_Recorded_Achievement @RecordedAchievement_ID, @StartDate, @EndDate, @Achievement_ID", sql);

                SqlParameter recAchievementIDParam = new SqlParameter("@RecordedAchievement_ID", recAchievementID);
                command.Parameters.Add(recAchievementIDParam);

                SqlParameter startDateParam = new SqlParameter("@StartDate", StartDate);
                command.Parameters.Add(startDateParam);

                SqlParameter endDateParam = new SqlParameter("@EndDate", EndDate);
                command.Parameters.Add(endDateParam);

                SqlParameter achievementIDParam = new SqlParameter("@Achievement_ID", AchievementID);
                command.Parameters.Add(achievementIDParam);

                command.ExecuteNonQuery();
            }
            catch { return -1; }
            finally
            {
                sql.Close();
            }
            return 0;
        }
        public int recAchievementDelete(string recAchievementID)
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Delete_Recorded_Achievement @RecordedAchievement_ID", sql);

                SqlParameter idParam = new SqlParameter("@RecordedAchievement_ID", recAchievementID);
                command.Parameters.Add(idParam);

                command.ExecuteNonQuery();
            }
            catch { return -1; }
            finally
            {
                sql.Close();
            }
            return 0;
        }
        public DataTable getCurrentRecAchievement(int recAchievementID)
        {
            DataTable tempDT = new DataTable();
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec GetCurrentRecAchievement1 @RecordedAchievement_ID", sql);

                SqlParameter idParam = new SqlParameter("@RecordedAchievement_ID", recAchievementID);
                command.Parameters.Add(idParam);


                tempDT.Load((SqlDataReader)command.ExecuteReader());
            }
            catch { return null; }
            finally
            {
                sql.Close();

            }
            return tempDT;
        }

        public int recOlympiadAdd(string StartDate, string EndDate, string OlympiadID)
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Insert_Recorded_Olympiad @StartDate, @EndDate, @Olympiad_ID", sql);

                SqlParameter startDateParam = new SqlParameter("@StartDate", StartDate);
                command.Parameters.Add(startDateParam);

                SqlParameter endDateParam = new SqlParameter("@EndDate", EndDate);
                command.Parameters.Add(endDateParam);

                SqlParameter achievementIDParam = new SqlParameter("@Olympiad_ID", OlympiadID);
                command.Parameters.Add(achievementIDParam);

                command.ExecuteNonQuery();
            }
            catch { return -1; }
            finally
            {
                sql.Close();
            }
            return 0;
        }
        public int recOlympiadUpdate(int recOlympiadID, string StartDate, string EndDate, string AchievementID)
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Update_Recorded_Olympiad @RecordedOlympiad_ID, @StartDate, @EndDate, @Olympiad_ID", sql);

                SqlParameter recOlympiadIDParam = new SqlParameter("@RecordedOlympiad_ID", recOlympiadID);
                command.Parameters.Add(recOlympiadIDParam);

                SqlParameter startDateParam = new SqlParameter("@StartDate", StartDate);
                command.Parameters.Add(startDateParam);

                SqlParameter endDateParam = new SqlParameter("@EndDate", EndDate);
                command.Parameters.Add(endDateParam);

                SqlParameter OlympiadIDParam = new SqlParameter("@Olympiad_ID", AchievementID);
                command.Parameters.Add(OlympiadIDParam);

                command.ExecuteNonQuery();
            }
            catch { return -1; }
            finally
            {
                sql.Close();
            }
            return 0;
        }
        public int recOlympiadDelete(string recOlympiadID)
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Delete_Recorded_Olympiad @RecordedOlympiad_ID", sql);

                SqlParameter idParam = new SqlParameter("@RecordedOlympiad_ID", recOlympiadID);
                command.Parameters.Add(idParam);

                command.ExecuteNonQuery();
            }
            catch { return -1; }
            finally
            {
                sql.Close();
            }
            return 0;
        }
        public DataTable getCurrentRecOlympiad(int recOlympiadID)
        {
            DataTable tempDT = new DataTable();
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec GetCurrentRecOlympiad @RecordedAchievement_ID", sql);

                SqlParameter idParam = new SqlParameter("@RecordedAchievement_ID", recOlympiadID);
                command.Parameters.Add(idParam);


                tempDT.Load((SqlDataReader)command.ExecuteReader());
            }
            catch { return null; }
            finally
            {
                sql.Close();

            }
            return tempDT;
        }

        public int olympiadAdd(string name, string organizer)
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Insert_Olympiad @Name, @Organizer", sql);

                SqlParameter nameParam = new SqlParameter("@Name", name);
                command.Parameters.Add(nameParam);

                SqlParameter organizerParam = new SqlParameter("@Organizer", organizer);
                command.Parameters.Add(organizerParam);

                command.ExecuteNonQuery();
            }
            catch { return -1; }
            finally
            {
                sql.Close();
            }
            return 0;
        }
        public int olympiadUpdate(int olympiadID, string name, string organizer)
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Update_Olympiad @ID_Olympiad, @Name, @Organizer", sql);

                SqlParameter idParam = new SqlParameter("@ID_Discipline", olympiadID);
                command.Parameters.Add(idParam);

                SqlParameter nameParam = new SqlParameter("@Name", name);
                command.Parameters.Add(nameParam);

                SqlParameter organizerParam = new SqlParameter("@Organizer", organizer);
                command.Parameters.Add(organizerParam);

                command.ExecuteNonQuery();
            }
            catch { return -1; }
            finally
            {
                sql.Close();
            }
            return 0;
        }
        public int olympiadDelete(string olympiadID)
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Delete_Olympiad @Olympiad_ID", sql);

                SqlParameter idParam = new SqlParameter("@Olympiad_ID", olympiadID);
                command.Parameters.Add(idParam);

                command.ExecuteNonQuery();
            }
            catch { return -1; }
            finally
            {
                sql.Close();
            }
            return 0;
        }
        public DataTable getCurrentOlympiad(int olympiadID)
        {
            DataTable tempDT = new DataTable();
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec getCurrentOlympiad @Olympiad_ID", sql);

                SqlParameter idParam = new SqlParameter("@Olympiad_ID", olympiadID);
                command.Parameters.Add(idParam);


                tempDT.Load((SqlDataReader)command.ExecuteReader());
            }
            catch { return null; }
            finally
            {
                sql.Close();

            }
            return tempDT;
        }

        public int specialityGroupAdd(string code, string name)
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Insert_Speciality_Group @Code, @Name", sql);

                SqlParameter codeParam = new SqlParameter("@Code", code);
                command.Parameters.Add(codeParam);

                SqlParameter nameParam = new SqlParameter("@Name", name);
                command.Parameters.Add(nameParam);

                command.ExecuteNonQuery();
            }
            catch { return -1; }
            finally
            {
                sql.Close();
            }
            return 0;
        }
        public int specialityGroupUpdate(int specialityGroupID, string code, string name)
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Update_Speciality_Group @SpecialityGroupID, @Code, @Name", sql);

                SqlParameter idParam = new SqlParameter("@SpecialityGroupID", specialityGroupID);
                command.Parameters.Add(idParam);

                SqlParameter codeParam = new SqlParameter("@Code", code);
                command.Parameters.Add(codeParam);

                SqlParameter nameParam = new SqlParameter("@Name", name);
                command.Parameters.Add(nameParam);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                sql.Close();
            }
            return 0;
        }
        public int specialityGroupDelete(string specialityGroupID)
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Delete_Speciality_Group @Speciality_Group_ID", sql);

                SqlParameter idParam = new SqlParameter("@Speciality_Group_ID", specialityGroupID);
                command.Parameters.Add(idParam);

                command.ExecuteNonQuery();
            }
            catch { return -1; }
            finally
            {
                sql.Close();
            }
            return 0;
        }
        public DataTable getCurrentSpecialityGroup(int specialityGroupID)
        {
            DataTable tempDT = new DataTable();
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec getCurrentSpecialityGroup @Speciality_Group_ID", sql);

                SqlParameter idParam = new SqlParameter("@Speciality_Group_ID", specialityGroupID);
                command.Parameters.Add(idParam);


                tempDT.Load((SqlDataReader)command.ExecuteReader());
            }
            catch { return null; }
            finally
            {
                sql.Close();

            }
            return tempDT;
        }

        public int specialityAdd(string code, string name, string specialityGroupID)
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Insert_Speciality @Code, @Name, @SpecialityGroupID", sql);

                SqlParameter codeParam = new SqlParameter("@Code", code);
                command.Parameters.Add(codeParam);

                SqlParameter nameParam = new SqlParameter("@Name", name);
                command.Parameters.Add(nameParam);

                SqlParameter specGroupIDParam = new SqlParameter("@SpecialityGroupID", specialityGroupID);
                command.Parameters.Add(specGroupIDParam);

                command.ExecuteNonQuery();
            }
            catch { return -1; }
            finally
            {
                sql.Close();
            }
            return 0;
        }
        public int specialityUpdate(int specialityID, string code, string name, string specialityGroupID)
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Update_Speciality @SpecialityID, @Code, @Name, @SpecialityGroupID", sql);

                SqlParameter idParam = new SqlParameter("@SpecialityGroupID", specialityID);
                command.Parameters.Add(idParam);

                SqlParameter codeParam = new SqlParameter("@Code", code);
                command.Parameters.Add(codeParam);

                SqlParameter nameParam = new SqlParameter("@Name", name);
                command.Parameters.Add(nameParam);

                SqlParameter specGroupIDParam = new SqlParameter("@SpecialityGroupID", specialityGroupID);
                command.Parameters.Add(specGroupIDParam);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                sql.Close();
            }
            return 0;
        }
        public int specialityDelete(string specialityGroupID)
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Delete_Speciality @Speciality__ID", sql);

                SqlParameter idParam = new SqlParameter("@Speciality__ID", specialityGroupID);
                command.Parameters.Add(idParam);

                command.ExecuteNonQuery();
            }
            catch { return -1; }
            finally
            {
                sql.Close();
            }
            return 0;
        }
        public DataTable getCurrentSpeciality(int specialityID)
        {
            DataTable tempDT = new DataTable();
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec getCurrentSpeciality @Speciality_ID", sql);

                SqlParameter idParam = new SqlParameter("@Speciality_ID", specialityID);
                command.Parameters.Add(idParam);


                tempDT.Load((SqlDataReader)command.ExecuteReader());
            }
            catch { return null; }
            finally
            {
                sql.Close();

            }
            return tempDT;
        }

        public int priorityAdd(int specialityGroupID, int disciplineID, int priority, string StartDate, string EndDate)
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Insert_Priority @SpecialityGroupID, @DisciplineID, @Priority, @StartDate, @EndDate", sql);

                SqlParameter specialityGroupIDParam = new SqlParameter("@SpecialityGroupID", specialityGroupID);
                command.Parameters.Add(specialityGroupIDParam);

                SqlParameter disciplineIDParam = new SqlParameter("@DisciplineID", disciplineID);
                command.Parameters.Add(disciplineIDParam);

                SqlParameter priorityParam = new SqlParameter("@Priority", priority);
                command.Parameters.Add(priorityParam);

                SqlParameter startDateParam = new SqlParameter("@StartDate", StartDate);
                command.Parameters.Add(startDateParam);

                SqlParameter endDateParam = new SqlParameter("@EndDate", EndDate);
                command.Parameters.Add(endDateParam);

                command.ExecuteNonQuery();
            }
            catch { return -1; }
            finally
            {
                sql.Close();
            }
            return 0;
        }
        public int priorityUpdate(int priorityID, int specialityGroupID, int disciplineID, int priority, string StartDate, string EndDate)
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Update_Priority @Priority, @SpecialityGroupID, @DisciplineID, @Priority, @StartDate, @EndDate", sql);

                SqlParameter priorityIDParam = new SqlParameter("@Priority", priorityID);
                command.Parameters.Add(priorityIDParam);

                SqlParameter specialityGroupIDParam = new SqlParameter("@SpecialityGroupID", specialityGroupID);
                command.Parameters.Add(specialityGroupIDParam);

                SqlParameter disciplineIDParam = new SqlParameter("@DisciplineID", disciplineID);
                command.Parameters.Add(disciplineIDParam);

                SqlParameter priorityParam = new SqlParameter("@Priority", priority);
                command.Parameters.Add(priorityParam);

                SqlParameter startDateParam = new SqlParameter("@StartDate", StartDate);
                command.Parameters.Add(startDateParam);

                SqlParameter endDateParam = new SqlParameter("@EndDate", EndDate);
                command.Parameters.Add(endDateParam);

                command.ExecuteNonQuery();
            }
            catch { return -1; }
            finally
            {
                sql.Close();
            }
            return 0;
        }
        public int priorityDelete(string priorityID)
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Delete_Priority @Priority", sql);

                SqlParameter idParam = new SqlParameter("@Priority", priorityID);
                command.Parameters.Add(idParam);

                command.ExecuteNonQuery();
            }
            catch { return -1; }
            finally
            {
                sql.Close();
            }
            return 0;
        }
        public DataTable getCurrentPriority(int priorityID)
        {
            DataTable tempDT = new DataTable();
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec GetCurrentPriority @Priority", sql);

                SqlParameter idParam = new SqlParameter("@Priority", priorityID);
                command.Parameters.Add(idParam);


                tempDT.Load((SqlDataReader)command.ExecuteReader());
            }
            catch { return null; }
            finally
            {
                sql.Close();

            }
            return tempDT;
        }
    }
}

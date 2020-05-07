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
            GetAchievements
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
    }
}

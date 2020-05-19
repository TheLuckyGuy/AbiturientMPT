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
using Liphsoft.Crypto.Argon2;


namespace Abiturient_MPT
{
    public class db
    {
        public string dataSource = "";
        public string initialCatalog = "";

        public string user = "";
        public string password = "";


        public SqlConnection sql = new SqlConnection("Data Source = LAPTOP-KPGPB2J6; " +
            "initial Catalog = Abiturient_MPT; Persist Security Info = true; User ID = sa; Password = \"17455688\""); // Строка подключения к БД


        public db()
        {
            //sql.Open();
        }

        public enum Tables // Перечисление используемых таблиц
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
            GetRecordedOlympiad,
            GetAchievements,
            GetDiscipline,
            GetOlympiads,
            GetSpecialityGroup,
            GetSpeciality,
            GetSpecialityGroupShort,
            GetDisciplinePriority
        }

        static List<string> commands = new List<string>() // Комманды SQL
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
            "exec dbo.GetRecordedOlympiad",
            "exec dbo.GetAchievements",
            "exec dbo.GetDiscipline",
            "exec dbo.GetOlympiads",
            "exec dbo.GetSpecialityGroup",
            "exec dbo.GetSpeciality",
            "exec dbo.GetSpecialityGroupShort",
            "exec dbo.GetDisciplinePriority"
        };

        static string md5(string text) // Функция хеширования в MD5
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

        public DataTable GetData(byte index) // Команда для получения данных из бд в виде заполненой таблицы
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Вывод ошибки на экран
                return null;
            }
            finally
            {
                sql.Close();
            }
        }

        public int Authorization(string Login, string Password) // Функция авторизации
        {
            string result = String.Empty; // Строка, хранящая код результата (результат - ID роли)
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand("SELECT [dbo].[Auth] (@Login , @Password)", sql); // SQL  запрос с обозначенными параметрами

                // Добавление параметров SQL запроса
                SqlParameter usrLogin = new SqlParameter("@Login", Login);
                command.Parameters.Add(usrLogin);

                SqlParameter usrPassword = new SqlParameter("@Password", md5(Password + Login));
                command.Parameters.Add(usrPassword);

                result = command.ExecuteScalar().ToString(); // Выполнение Запроса


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

            if (result == String.Empty)
            {
                return 0; // В случае, если логин и пароль не совпали, будет возвращён 0
            }
            else
            {
                return int.Parse(result); // В противном случае возвращается ID роли
            }
            
        }
        public int Registration(string Login, string Password, int Role_Id = 1) // Функция регистрации
        {
            string result = String.Empty;
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Registration @Login, @Password, @Role_ID", sql);

                // Добавление параметров SQL запроса
                SqlParameter usrLogin = new SqlParameter("@Login", Login);
                command.Parameters.Add(usrLogin);

                SqlParameter usrPassword = new SqlParameter("@Password", md5(Password + Login));
                command.Parameters.Add(usrPassword);

                SqlParameter roleId = new SqlParameter("@Role_ID", Role_Id);
                command.Parameters.Add(roleId);

                result = command.ExecuteScalar().ToString();
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
            return Convert.ToInt32(result); // Возвращение результата регистрации (1 - Успех, 0 - Логин уже существует, -1 - Ошибка подключения к БД)
        }
        public User getUserRole(int Role_ID) // Функция для получения информации о роли пользователя
        {
            DataTable tempDT = new DataTable();
            User user = new User();
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "select * from dbo.GetUserRole (@ID_Role)", sql);

                // Добавление параметров SQL запроса
                SqlParameter RoleIDParam = new SqlParameter("@ID_Role", Role_ID);
                command.Parameters.Add(RoleIDParam);               

                tempDT.Load((SqlDataReader)command.ExecuteReader()); // Выполнение SQL команды с записью таблицы результата 

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                sql.Close();

            }
            // В случае успеха полученнные данные о разрешенных пользователю функциях сохраняются в user
            user.Role = tempDT.Rows[0][1].ToString();
            user.Enrollee = Convert.ToBoolean(tempDT.Rows[0][2]);
            user.EnrolleeList = Convert.ToBoolean(tempDT.Rows[0][3]);
            user.Disciplines = Convert.ToBoolean(tempDT.Rows[0][4]);
            user.Specialities = Convert.ToBoolean(tempDT.Rows[0][5]);
            user.Achievements = Convert.ToBoolean(tempDT.Rows[0][6]);
            user.Olympiads = Convert.ToBoolean(tempDT.Rows[0][7]);
            user.Statistics = Convert.ToBoolean(tempDT.Rows[0][8]);
            return user;
            //return 0;
        }


        public int enrolleeAdd(string surname, string name, string patronymic, string birthDate, string Pass_Series, string Pass_Number, string Pass_Issued_By, string Pass_Issue_Date,
            string Subdiv_Code, int Education, string Certificate_Num, string Issue_Date, string End_Year, string Cert_Issued_By, int Targeted_Learning) // Добавление абитуриента
        {
            int enrolleeId = 0;
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Insert_Enrollee @Surname, @Name, @Patronymic, @Birth_Date, @Pass_Series, @Pass_Number, @Pass_Issued_By, @Pass_Issue_Date, " +
                   "@Subdiv_Code, @Education, @Certificate_Num, @Issue_Date, @End_Year, @Cert_Issued_By, @Targeted_Learning", sql);

                // Добавление параметров SQL запроса
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

                enrolleeId = int.Parse(command.ExecuteScalar().ToString()); // Выполнение команды и получение результата
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                sql.Close();
            }
            return enrolleeId; // Возвращается ID записи абитуриента
        }
        public int enrolleeUpdate(int enrolleeID, string surname, string name, string patronymic, string birthDate, string Pass_Series, string Pass_Number, string Pass_Issued_By, string Pass_Issue_Date,
            string Subdiv_Code, int Education, string Certificate_Num, string Issue_Date, string End_Year, string Cert_Issued_By, int Targeted_Learning) // Изменение абитуриента
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Update_Enrollee @ID_Enrollee, @Surname, @Name, @Patronymic, @Birth_Date, @Pass_Series, @Pass_Number, @Pass_Issued_By, " +
                   "@Pass_Issue_Date, @Subdiv_Code, @Education, @Certificate_Num, @Issue_Date, @End_Year, @Cert_Issued_By, @Targeted_Learning", sql);

                // Добавление параметров SQL запроса
                SqlParameter enrolleeIdParam = new SqlParameter("@ID_Enrollee", enrolleeID);
                command.Parameters.Add(enrolleeIdParam);

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
            return 1;
        }
        public int enrolleeDelete(string enrolleeID) // Удаление абитуриента
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Delete_Enrollee @Enrollee_ID", sql);

                // Добавление параметров SQL запроса
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
        public DataTable getCurrentEnrollee(int enrolleeID) // Получение записи абитуриента
        {
            DataTable tempDT = new DataTable();
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec getCurrentEnrollee @Enrollee_ID", sql);

                // Добавление параметров SQL запроса
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

        public int achievementAdd(string name) // Добавление достижения
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Insert_Achievement @Name", sql);

                // Добавление параметров SQL запроса
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
        public int achievementUpdate(int achID, string name) // Изменение абитуриента
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Update_Achievement @ID_Achievement, @Name", sql);

                // Добавление параметров SQL запроса
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
        public int achievementDelete(string achievementID) // Удаление абитуриента
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Delete_Achievement @Achievement_ID", sql);

                // Добавление параметров SQL запроса
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
        public DataTable getCurrentAchievement(int achievementID) // Получение записи о достижении
        {
            DataTable tempDT = new DataTable();
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec getCurrentAchievement @Enrollee_ID", sql);

                // Добавление параметров SQL запроса
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

        public int disciplineAdd(string name) // Добавление предмета
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Insert_Discipline @Name", sql);

                // Добавление параметров SQL запроса
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
        public int disciplineUpdate(int disciplineID, string name) // Изменение предмета
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Update_Discipline @ID_Discipline, @Name", sql);

                // Добавление параметров SQL запроса
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
        public int disciplineDelete(string disciplineID) // Удаление предмета
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Delete_Discipline @Discipline_ID", sql);

                // Добавление параметров SQL запроса
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
        public DataTable getCurrentDiscipline(int disciplineID) // Получение записи предмета
        {
            DataTable tempDT = new DataTable();
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec getCurrentDiscipline @Discipline_ID", sql);

                // Добавление параметров SQL запроса
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

        public int recAchievementAdd(string StartDate, string EndDate, string AchievementID) // Добавление учитываемого достижения
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Insert_Recorded_Achievement @StartDate, @EndDate, @Achievement_ID", sql);

                // Добавление параметров SQL запроса
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
        public int recAchievementUpdate(int recAchievementID, string StartDate, string EndDate, string AchievementID) // Изменение учитываемого достижения
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Update_Recorded_Achievement @RecordedAchievement_ID, @StartDate, @EndDate, @Achievement_ID", sql);

                // Добавление параметров SQL запроса
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
        public int recAchievementDelete(string recAchievementID) // Удаление учитываемого достижения
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Delete_Recorded_Achievement @RecordedAchievement_ID", sql);

                // Добавление параметров SQL запроса
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
        public DataTable getCurrentRecAchievement(int recAchievementID) // Получение записи учитываемого достижения
        {
            DataTable tempDT = new DataTable();
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec GetCurrentRecAchievement1 @RecordedAchievement_ID", sql);

                // Добавление параметров SQL запроса
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

        public int recOlympiadAdd(string StartDate, string EndDate, string OlympiadID) // Добавление записи олимпиады
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Insert_Recorded_Olympiad @StartDate, @EndDate, @Olympiad_ID", sql);

                // Добавление параметров SQL запроса
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
        public int recOlympiadUpdate(int recOlympiadID, string StartDate, string EndDate, string AchievementID) // Изменение записи олимпиады
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Update_Recorded_Olympiad @RecordedOlympiad_ID, @StartDate, @EndDate, @Olympiad_ID", sql);

                // Добавление параметров SQL запроса
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
        public int recOlympiadDelete(string recOlympiadID) // Удаление записи учитываемой олимпиады
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Delete_Recorded_Olympiad @RecordedOlympiad_ID", sql);

                // Добавление параметров SQL запроса
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
        public DataTable getCurrentRecOlympiad(int recOlympiadID) // Получение записи учитываемой олимпиады
        {
            DataTable tempDT = new DataTable();
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec GetCurrentRecOlympiad @RecordedAchievement_ID", sql);

                // Добавление параметров SQL запроса
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

        public int olympiadAdd(string name, string organizer) // Добавление записи олимпиады
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Insert_Olympiad @Name, @Organizer", sql);

                // Добавление параметров SQL запроса
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
        public int olympiadUpdate(int olympiadID, string name, string organizer) // Изменение записи олимпиады
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Update_Olympiad @ID_Olympiad, @Name, @Organizer", sql);

                // Добавление параметров SQL запроса
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
        public int olympiadDelete(string olympiadID) // Удаление олимпиады
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Delete_Olympiad @Olympiad_ID", sql);

                // Добавление параметров SQL запроса
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
        public DataTable getCurrentOlympiad(int olympiadID) // Получение записи олимпиады
        {
            DataTable tempDT = new DataTable();
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec getCurrentOlympiad @Olympiad_ID", sql);

                // Добавление параметров SQL запроса
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

        public int specialityGroupAdd(string code, string name) // Добавление группы специальностей
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Insert_Speciality_Group @Code, @Name", sql);

                // Добавление параметров SQL запроса
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
        public int specialityGroupUpdate(int specialityGroupID, string code, string name) // Измение записи группы специальностей
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Update_Speciality_Group @SpecialityGroupID, @Code, @Name", sql);

                // Добавление параметров SQL запроса
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
        public int specialityGroupDelete(string specialityGroupID) // Удаление записи о группе специальностей
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Delete_Speciality_Group @Speciality_Group_ID", sql);

                // Добавление параметров SQL запроса
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
        public DataTable getCurrentSpecialityGroup(int specialityGroupID) // Получение записи группы специальностей
        {
            DataTable tempDT = new DataTable();
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec getCurrentSpecialityGroup @Speciality_Group_ID", sql);

                // Добавление параметров SQL запроса
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

        public int specialityAdd(string code, string name, string specialityGroupID) // Добавление записи о специальности
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Insert_Speciality @Code, @Name, @SpecialityGroupID", sql);

                // Добавление параметров SQL запроса
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
        public int specialityUpdate(int specialityID, string code, string name, string specialityGroupID) // Изменение записи специальности 
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Update_Speciality @SpecialityID, @Code, @Name, @SpecialityGroupID", sql);

                // Добавление параметров SQL запроса
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
        public int specialityDelete(string specialityGroupID) // Удаление записи специальности
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Delete_Speciality @Speciality__ID", sql);

                // Добавление параметров SQL запроса
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
        public DataTable getCurrentSpeciality(int specialityID) // Получение записи специальности 
        {
            DataTable tempDT = new DataTable();
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec getCurrentSpeciality @Speciality_ID", sql);

                // Добавление параметров SQL запроса
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

        public int priorityAdd(int specialityGroupID, int disciplineID, int priority, string StartDate, string EndDate) // Добавление записи о приоритете предмета
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Insert_Priority @SpecialityGroupID, @DisciplineID, @Priority, @StartDate, @EndDate", sql);

                // Добавление параметров SQL запроса
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
        public int priorityUpdate(int priorityID, int specialityGroupID, int disciplineID, int priority, string StartDate, string EndDate) // Изменение записи о приоритете
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Update_Priority @PriorityID, @SpecialityGroupID, @DisciplineID, @Priority, @StartDate, @EndDate", sql);

                // Добавление параметров SQL запроса
                SqlParameter priorityIDParam = new SqlParameter("@PriorityID", priorityID);
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
        public int priorityDelete(string priorityID) // Удаление записи о приоритете предмета
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Delete_Priority @Priority", sql);

                // Добавление параметров SQL запроса
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
        public DataTable getCurrentPriority(int priorityID) // Получение записи о приоритете предмета
        {
            DataTable tempDT = new DataTable();
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec GetCurrentPriority @Priority", sql);

                // Добавление параметров SQL запроса
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

        public int individualAchievementAdd(int enrolleeID, int achievementID) // Добавление индивидуального достижения
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Insert_Individual_Achievement @Enrollee_ID, @Achievement_ID", sql);

                // Добавление параметров SQL запроса
                SqlParameter codeParam = new SqlParameter("@Enrollee_ID", enrolleeID);
                command.Parameters.Add(codeParam);

                SqlParameter nameParam = new SqlParameter("@Achievement_ID", achievementID);
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
        public int individualAchievementUpdate(int individualAchievementID, string enrolleeID, string achievementID) // Изменение индивидуального достижения
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Update_Individual_Achievement @IndividualAchievement_ID, @Enrollee_ID, @Achievement_ID", sql);

                // Добавление параметров SQL запроса
                SqlParameter idParam = new SqlParameter("@IndividualAchievement_ID", individualAchievementID);
                command.Parameters.Add(idParam);

                SqlParameter codeParam = new SqlParameter("@Enrollee_ID", enrolleeID);
                command.Parameters.Add(codeParam);

                SqlParameter nameParam = new SqlParameter("@Achievement_ID", achievementID);
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
        public int individualAchievementDelete(int individualAchievementID) // Удаление индивидуального достижения
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Delete_Individual_Achievement @IndividualAchievement_ID", sql);

                // Добавление параметров SQL запроса
                SqlParameter idParam = new SqlParameter("@IndividualAchievement_ID", individualAchievementID);
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
        public DataTable getIndividualAchievements(int enrolleeID) // Получение индивидуальных достижений
        {
            DataTable tempDT = new DataTable();
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec getIndividualAchievements @Enrollee_ID", sql);

                // Добавление параметров SQL запроса
                SqlParameter idParam = new SqlParameter("@Enrollee_ID", enrolleeID);
                command.Parameters.Add(idParam);


                tempDT.Load((SqlDataReader)command.ExecuteReader());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                sql.Close();

            }
            return tempDT;
        }

        public int enrolleeMarkAdd(int enrolleeID, int disciplineID, int mark) // Добавление оценки абитуриента
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Insert_Enrollee_Mark @Enrollee_ID, @Discipline_ID, @Mark", sql);

                // Добавление параметров SQL запроса
                SqlParameter enrolleeIDParam = new SqlParameter("@Enrollee_ID", enrolleeID);
                command.Parameters.Add(enrolleeIDParam);

                SqlParameter disciplineParam = new SqlParameter("@Discipline_ID", disciplineID);
                command.Parameters.Add(disciplineParam);

                SqlParameter markParam = new SqlParameter("@Mark", mark);
                command.Parameters.Add(markParam);

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
        public int enrolleeMarkUpdate(int markID, int enrolleeID, int disciplineID, int mark) // Изменение оценки абитуриента
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Update_Enrollee_Mark @Mark_ID, @Enrollee_ID, @Discipline_ID, @Mark", sql);

                // Добавление параметров SQL запроса
                SqlParameter idParam = new SqlParameter("@Mark_ID", markID);
                command.Parameters.Add(idParam);

                SqlParameter enrolleeIDParam = new SqlParameter("@Enrollee_ID", enrolleeID);
                command.Parameters.Add(enrolleeIDParam);

                SqlParameter disciplineParam = new SqlParameter("@Discipline_ID", disciplineID);
                command.Parameters.Add(disciplineParam);

                SqlParameter markParam = new SqlParameter("@Mark", mark);
                command.Parameters.Add(markParam);

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
        public int enrolleeMarkDelete(int MarkID) // Удаление оценки абитуриента
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Delete_Enrollee_Mark @Mark_ID", sql);

                // Добавление параметров SQL запроса
                SqlParameter idParam = new SqlParameter("@Mark_ID", MarkID);
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
        public DataTable getenrolleeMarks(int enrolleeID) // Получение оценок абитуриента
        {
            DataTable tempDT = new DataTable();
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec getEnrolleeMarks @Enrollee_ID", sql);

                // Добавление параметров SQL запроса
                SqlParameter idParam = new SqlParameter("@Enrollee_ID", enrolleeID);
                command.Parameters.Add(idParam);


                tempDT.Load((SqlDataReader)command.ExecuteReader());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                sql.Close();

            }
            return tempDT;
        }

        public int enrolleeSpecialityAdd(int enrolleeID, int specialityID) // Добавление специальности студента
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Insert_Enrollee_Speciality @Enrollee_ID, @Speciality_ID", sql);

                // Добавление параметров SQL запроса
                SqlParameter codeParam = new SqlParameter("@Enrollee_ID", enrolleeID);
                command.Parameters.Add(codeParam);

                SqlParameter nameParam = new SqlParameter("@Speciality_ID", specialityID);
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
        public int enrolleeSpecialityUpdate(int enrolleeSpecialityID, string enrolleeID, string specialityID) // Изменение специальности студента
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Update_Enrollee_Speciality @ID_Enrollee_Spec, @Enrollee_ID, @Speciality_ID", sql);

                // Добавление параметров SQL запроса
                SqlParameter idParam = new SqlParameter("@ID_Enrollee_Spec", enrolleeSpecialityID);
                command.Parameters.Add(idParam);

                SqlParameter enrolleeParam = new SqlParameter("@Enrollee_ID", enrolleeID);
                command.Parameters.Add(enrolleeParam);

                SqlParameter specialityParam = new SqlParameter("@Speciality_ID", specialityID);
                command.Parameters.Add(specialityParam);

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
        public int enrolleeSpecialityDelete(int enrolleeSpecialityID)
        {
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec Delete_Enrollee_Speciality @ID_Enrollee_Spec", sql);

                // Добавление параметров SQL запроса
                SqlParameter idParam = new SqlParameter("@ID_Enrollee_Spec", enrolleeSpecialityID);
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
        public DataTable getEnrolleeSpeciality(int enrolleeSpecialityID) // Получение специальностей абитуриента
        {
            DataTable tempDT = new DataTable();
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec getEnrolleeSpeciality @ID_Enrollee_Spec", sql);

                // Добавление параметров SQL запроса
                SqlParameter idParam = new SqlParameter("@ID_Enrollee_Spec", enrolleeSpecialityID);
                command.Parameters.Add(idParam);


                tempDT.Load((SqlDataReader)command.ExecuteReader());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                sql.Close();

            }
            return tempDT;
        }

        public DataTable GetAcceptedEnrolleeList(int specialityID) // Получение списка поступающих
        {
            DataTable tempDT = new DataTable();
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec GetAcceptedEnrolleeList @ID_Spec", sql);

                // Добавление параметров SQL запроса
                SqlParameter idParam = new SqlParameter("@ID_Spec", specialityID);
                command.Parameters.Add(idParam);


                tempDT.Load((SqlDataReader)command.ExecuteReader());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                sql.Close();

            }
            return tempDT;
        }
        public DataTable GetSpecialityStats(int specialityID) // Получение статичтических данных
        {
            DataTable tempDT = new DataTable();
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(
                   "exec GetSpecialityStats @ID_Spec", sql);

                // Добавление параметров SQL запроса
                SqlParameter idParam = new SqlParameter("@ID_Spec", specialityID);
                command.Parameters.Add(idParam);


                tempDT.Load((SqlDataReader)command.ExecuteReader());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                sql.Close();

            }
            return tempDT;
        }
    }
}

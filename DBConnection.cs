using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Questionnaire
{
    public class DBConnection
    {
        public static SqlConnection connection = new SqlConnection("Data Source = DESKTOP-666\\MYSERVER; " +     //Добавляем таблицы 
           "Initial Catalog = Questionnaire; Persist Security Info = true; User ID = sa; Password = \"KatrinRain\"");
        public DataTable dtPost = new DataTable("Post");
        public DataTable dtEmployee = new DataTable("Employee");
        public DataTable dtRespondent = new DataTable("Respondent");
        public DataTable dtSetting = new DataTable("Setting");
        public DataTable dtComment = new DataTable("Comment");
        public DataTable dtQuestions = new DataTable("Questions");
        public DataTable dtAnswers = new DataTable("Answers");
        public DataTable dtQuestionnaire = new DataTable("Questionnaire");
        public DataTable dtDistribution = new DataTable("Distribution");


        //прописываем столбцы к подключаемым таблицам
        public static string qrPost = "SELECT [ID_Post], [Name_Post] as \"Название должности\" FROM [dbo].[Post]",

            qrEmployee = " SELECT [ID_Employee], [Employee_Surname] as \"Фамилия\", [Employee_Name] as \"Имя\", " +
            "[Employee_Last_Name] as \"Отчество\", [Post_ID], [dbo].[Post].[Name_Post] as \"Должность\", " +
            "[Employee_Login] as \"Логие\", [Employee_Password] as \"Пароль\" FROM [dbo].[Employee]" +
            "INNER JOIN [dbo].[Post] ON [dbo].[Employee].[Post_ID] = [dbo].[Post].[ID_Post]",

            qrRespondent = "SELECT [ID_Respondent], [Respondent_Surname] as \"Фамилия\", [Respondent_Name] as \"Имя\", " +
            "[Respondent_Last_Name] as \"Отчество\", [Login] as \"Логин\", [Password] as \"Пароль\" FROM [dbo].[Respondent]",

            qrSetting = "SELECT [ID_Setting], [Name] as \"Название опроса\", [Theme] as \"Тема опроса\", " +
            "[Start_Date] as \"Дата начала\" , [End_Date] as \"Дата окончания\", [Employee_ID], " +
            " [dbo].[Employee].[ID_Employee] as \"Фамилия сотрудника\" FROM [dbo].[Setting]" +
            "INNER JOIN [dbo].[Employee] ON [dbo].[Setting].[Employee_ID] = [dbo].[Employee].[ID_Employee]",

            qrComment = "SELECT [ID_Comment], [Text] as \"Комментарий\", [Setting_ID], " +
            "[dbo].[Setting].[Name] as \"Название опроса\" FROM [dbo].[Comment]" +
            "INNER JOIN [dbo].[Setting] ON [dbo].[Comment].[Setting_ID] = [dbo].[Setting].[ID_Setting]",

            qrQuestions = "SELECT [ID_Questions], [Question] as \"Вопрос\", [Setting_ID]," +
            " [dbo].[Setting].[Name] as \"Название опроса\" FROM [dbo].[Questions]" +
            "INNER JOIN [dbo].[Setting] ON [dbo].[Questions].[Setting_ID] = [dbo].[Setting].[ID_Setting]",

            qrAnswers = "SELECT [ID_Answers], [Answer] as \"Ответ\", [Questions_ID], " +
            "[dbo].[Questions].[Question] as \"Вопрос\" FROM [dbo].[Answers]" +
            "INNER JOIN [dbo].[Questions] ON [dbo].[Answers].[Questions_ID] = [dbo].[Questions].[ID_Questions]",

            qrQuestionnaire = "SELECT [ID_Questionnaire], [Setting_ID], [dbo].[Setting].[Name] as \"Название опроса\", " +
            " [Questions_ID], [dbo].[Questions].[Question] as \"Вопрос\", [Answers_ID], [dbo].[Answers].[Answer] as \"Ответ\" , " +
            "[Comment_ID], [dbo].[Comment].[Text] as \"Комментарий\" FROM [dbo].[Questionnaire]" +
            "INNER JOIN [dbo].[Setting] ON [dbo].[Questionnaire].[Setting_ID] = [dbo].[Setting].[ID_Setting]" +
            "INNER JOIN [dbo].[Questions] ON [dbo].[Questionnaire].[Questions_ID] = [dbo].[Questions].[ID_Questions]" +
            "INNER JOIN [dbo].[Answers] ON [dbo].[Questionnaire].[Answers_ID] = [dbo].[Answers].[ID_Answers]" +
            "INNER JOIN [dbo].[Comment] ON [dbo].[Questionnaire].[Comment_ID] = [dbo].[Comment].[ID_Comment]",


            qrDistribution = "SELECT [ID_Distribution], [Questionnaire_ID], [dbo].[Setting].[Name] as \"Название опроса\", [Hotel_ID] as \"Оте\", [dbo].[City].[Name_City] as \"Город\" , [dbo].[Hotel].[Hotel] as \"Отель\" FROM [dbo].[City_of_Hotel]" +
            "INNER JOIN [dbo].[City] ON [dbo].[City_of_Hotel].[City_ID] = [dbo].[City].[ID_City]" +
            "INNER JOIN [dbo].[Hotel] ON [dbo].[City_of_Hotel].[Hotel_ID] = [dbo].[Hotel].[ID_Hotel]";


        private SqlCommand command = new SqlCommand("", connection);

        public static Int32 IDrecord, IDUser, PostID, IDPol, IDResp, IDAuto;           //объявляем переменные



        public void dbEnter(string login, string password)          //Пишем авторизацию
        {
            command.CommandText = "SELECT count(*) FROM [dbo].[Employee]" +
                "where [Employee_Login] = '" + login + "' and [Employee_Password] = '" + password + "'";
            connection.Open();
            IDUser = Convert.ToInt32(command.ExecuteScalar().ToString());
            connection.Close();
        }

        public void dbEnterResp(string log, string pass)          //Пишем авторизацию
        {
            command.CommandText = "SELECT count(*) FROM [dbo].[Respondent]" +
                "where [Login] = '" + log + "' and [Password] = '" + pass + "'";
            connection.Open();
            IDResp = Convert.ToInt32(command.ExecuteScalar().ToString());
            connection.Close();
        }

        public void dbDostup(string login)       //прописываем доступ сотрудникам
        {
            command.CommandText = "SELECT [Post_ID] FROM [dbo].[Employee] where [Employee_Login] ='" + login + "'";
            connection.Open();
            PostID = Convert.ToInt32(command.ExecuteScalar().ToString());
            connection.Close();
        }

        public void dtAutoResp(string login) //count(*)    //различие клиентов при входе
        {
            connection.Open();
            command.CommandText = "select [ID_Respondent] FROM [dbo].[Respondent]" +
                "where [Login] = '" + login + "'";
            try
            {
                IDAuto = Convert.ToInt32(command.ExecuteScalar().ToString());
            }
            catch { }
            connection.Close();
        }

        public void dtAuto(string login) //count(*)    //различие клиентов при входе
        {
            connection.Open();
            command.CommandText = "select [ID_Employee] FROM [dbo].[Employee]" +
                "where [Employee_Login] = '" + login + "'";
            try
            {
                IDAuto = Convert.ToInt32(command.ExecuteScalar().ToString());
            }
            catch { }
            connection.Close();
        }


        public string RespNameInfo(Int32 ID_record) //вывод имени авторизировавшегося пользователя
        {
            string user = " ";
            command.CommandText = "select [Respondent_Name]+' ' " + "from [dbo].[Respondent] where [ID_Respondent]= " + IDAuto; 
            connection.Open();
            user = command.ExecuteScalar().ToString();
            connection.Close();
            return user;
        }

        public string EmployeeNameInfo(Int32 ID_record) //вывод имени сотрудника
        {
            string user = " ";
            command.CommandText = "select [Employee_Name]+' ' " + "from [dbo].[Employee] where [ID_Employee]= " + IDAuto;
            connection.Open();
            user = command.ExecuteScalar().ToString();
            connection.Close();
            return user;
        }

        private void dtFill(DataTable table, string query)   //доступ к таблицам
        {
            command.CommandText = query;
            command.Notification = null;

            //dependency.AddCommandDependency(command);
            SqlDependency.Start(connection.ConnectionString);
            connection.Open();
            table.Load(command.ExecuteReader());
            SqlDependency.Stop(connection.ConnectionString);
            connection.Close();
        }

        //заполнение таблиц
        public void PostFill()
        {
            dtFill(dtPost, qrPost);
        }

        public void EmployeeFill()
        {
            dtFill(dtEmployee, qrEmployee);
        }

        public void RespondentFill()
        {
            dtFill(dtRespondent, qrRespondent);
        }

        public void SettingFill()
        {
            dtFill(dtSetting, qrSetting);
        }

        public void CommentFill()
        {
            dtFill(dtComment, qrComment);
        }

        public void QuestionsFill()
        {
            dtFill(dtQuestions, qrQuestions);
        }

        public void AnswersFill()
        {
            dtFill(dtAnswers, qrAnswers);
        }

        public void QuestionnaireFill()
        {
            dtFill(dtQuestionnaire, qrQuestionnaire);
        }

        public void DistributionFill()
        {
            dtFill(dtDistribution, qrDistribution);
        }




    }
}
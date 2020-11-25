using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Questionnaire
{
    public partial class Respondent_LK : System.Web.UI.Page
    {
        private string QR = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            QR = DBConnection.qrQuestionnaire;
            if (!IsPostBack) ;
            {
                //gvFill(QR);
            }
            DBConnection connection = new DBConnection();                            //заполнение данных о вошедшем клиенте 
            Label1.Text = connection.RespNameInfo(DBConnection.IDAuto);
        }

        private void gvFill(string qr) //заполнение таблицы
        {
            sdsQ.ConnectionString =
                DBConnection.connection.ConnectionString;
            sdsQ.SelectCommand = qr;
            sdsQ.DataSourceMode = SqlDataSourceMode.DataReader;
            gvTP.DataSource = sdsQ;
            gvTP.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }

        protected void btShow_Click(object sender, EventArgs e)
        {

        }

        protected void gvTP_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvTP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvTP_Sorting(object sender, GridViewSortEventArgs e)
        {

        }
    }
}
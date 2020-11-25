using System;
using System.Drawing;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Questionnaire
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DBConnection connection = new DBConnection();
            connection.dbEnterResp(TextBox1.Text, TextBox2.Text);
            connection.dtAutoResp(TextBox1.Text);
            switch (DBConnection.IDResp)
            {
                case (0):
                    TextBox1.BackColor = System.Drawing.Color.Red;
                    TextBox2.BackColor = System.Drawing.Color.Red;
                    TextBox2.Text = "";
                    TextBox1.Text = "";
                    break;
                default:
                    Response.Redirect("RespondentLK.aspx");
                    break;

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DBConnection connection = new DBConnection();
            connection.dbEnter(TextBox1.Text, TextBox2.Text);
            connection.dtAuto(TextBox1.Text);
            switch (DBConnection.IDUser)
            {
                case (0):
                    TextBox1.BackColor = System.Drawing.Color.Red;
                    TextBox2.BackColor = System.Drawing.Color.Red;
                    TextBox2.Text = "";
                    TextBox1.Text = "";
                    break;
                default:
                    Response.Redirect("EmployeeLK.aspx");
                    break;

            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Sklep
{
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-9EOJGT1\Typcio;Initial Catalog=Shop;User ID=sa;Password=1234");




            SqlCommand command, command2;
            SqlDataReader dataReader;
            String sql, Output = "";


            sql = "SELECT login, email FROM users where id = " + Session["UserID"] + "";
            sqlCon.Open();
            command = new SqlCommand(sql, sqlCon);

            SqlDataReader dr = command.ExecuteReader();

            if (dr.Read())
            {

                //dataReader = command.ExecuteReader();

                TBLogin.Text = dr.GetValue(0).ToString();
                TBEmail.Text = dr.GetValue(1).ToString();

                sqlCon.Close();
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {


            bool StopFlag = false; 
            String sql2="";
            SqlCommand command2;

            SqlConnection sqlCon2 = new SqlConnection(@"Data Source=DESKTOP-9EOJGT1\Typcio;Initial Catalog=shop;User ID=sa;Password=1234");


            sqlCon2.Open();
            if(TBPassword.Text.Trim() != "")
            {
                if (TBPassword.Text.Length < 3)
                {
                    TBPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#D63E3E");
                    TBPassword.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                    StopFlag = true;
                }
                else
                {
                    TBPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                    TBPassword.ForeColor = System.Drawing.ColorTranslator.FromHtml("#212529");
                }

                if (TBRepPassword.Text != TBPassword.Text)
                {
                    TBRepPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#D63E3E");
                    TBRepPassword.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                    StopFlag = true;
                }
                else
                {
                    TBRepPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                    TBRepPassword.ForeColor = System.Drawing.ColorTranslator.FromHtml("#212529");
                }
                if (StopFlag == false)
                {
                    Response.Write("<script>alert('" + TBEmail.Text.ToString() + "');</script>");
                    sql2 = "Update users set email = '" + TBEmail.Text.Trim() + "', pass_word = '" + TBPassword.Text.Trim() + "' where id =  " + Session["UserID"] + "";
                    command2 = new SqlCommand(sql2, sqlCon2);
                    command2.ExecuteNonQuery();
                    sqlCon2.Close();

                    Response.Redirect("UserProfile.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('" + TBEmail.Text.ToString() + "');</script>");
                sql2 = "Update users set email = '" + TBEmail.Text.Trim() + "' where id = " + Session["UserID"] + "";
                command2 = new SqlCommand(sql2, sqlCon2);
                command2.ExecuteNonQuery();
                sqlCon2.Close();
            }
            
        }
    }
}
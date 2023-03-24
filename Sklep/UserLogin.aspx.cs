using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Sklep
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-9EOJGT1\Typcio;Initial Catalog=Shop;User ID=sa;Password=1234");




            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";


            sql = "SELECT id, is_admin FROM users where login = '" + TBLogin.Text.Trim() + "' and pass_word ='" + TBPassword.Text.Trim() + "'";
            sqlCon.Open();
            command = new SqlCommand(sql, sqlCon);

            //dataReader = command.ExecuteReader();

            SqlDataReader dr = command.ExecuteReader();
            if(dr.Read())
            {
                Session["UserID"] = dr.GetValue(0).ToString();
                Session["IsAdmin"] = dr.GetValue(1).ToString();
                sqlCon.Close();
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                TBLogin.BackColor = System.Drawing.ColorTranslator.FromHtml("#D63E3E");
                TBLogin.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                TBPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#D63E3E");
                TBPassword.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            }


            /* while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + "";
            }

            if (Int32.Parse(Output) == 1)
            {
                sqlCon.Close();
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                TBLogin.BackColor = System.Drawing.ColorTranslator.FromHtml("#D63E3E");
                TBLogin.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                TBPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#D63E3E");
                TBPassword.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            }*/
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Sklep
{
    public partial class UserRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand command, command2;
            SqlDataReader dataReader;
            String sql, sql2, Output = "";
            bool StopFlag;
            string HashedPassword = "";

            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-9EOJGT1\Typcio;Initial Catalog=Shop;User ID=sa;Password=1234");

            StopFlag = false;
            sql = "SELECT count(id) FROM users where login = '" + TBLogin.Text.Trim() + "' and email ='" + TBEmail.Text.Trim() + "'";
            
            sqlCon.Open();
            command = new SqlCommand(sql, sqlCon);

            dataReader = command.ExecuteReader();

            if (TBLogin.Text == "")
            {
                TBLogin.BackColor = System.Drawing.ColorTranslator.FromHtml("#D63E3E");
                TBLogin.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                StopFlag = true;
            }
            else if (TBLogin.Text.Length < 3)
            {
                TBLogin.BackColor = System.Drawing.ColorTranslator.FromHtml("#D63E3E");
                TBLogin.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                StopFlag = true;
            }
            else
            {
                TBLogin.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                TBLogin.ForeColor = System.Drawing.ColorTranslator.FromHtml("#212529");
            }

            if (TBEmail.Text == "")
            {
                TBEmail.BackColor = System.Drawing.ColorTranslator.FromHtml("#D63E3E");
                TBEmail.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                StopFlag = true;
            }
            else
            {
                TBEmail.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                TBEmail.ForeColor = System.Drawing.ColorTranslator.FromHtml("#212529");
            }

            if (TBPassword.Text == "")
            {
                TBPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#D63E3E");
                TBPassword.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                StopFlag = true;
            }
            else if (TBPassword.Text.Length < 3)
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

            if (TBRepPassword.Text == "")
            {
                TBRepPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#D63E3E");
                TBRepPassword.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                StopFlag = true;
            }
            else if (TBRepPassword.Text != TBPassword.Text)
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

            /* Nie widzie TextBoxa CBTaC
            if (CBTaC.Checked == false)
            {
                CBTaC.ForeColor = System.Drawing.ColorTranslator.FromHtml("#D63E3E");
                StopFlag = true;
            }
            else
            {
                CBTaC.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            }*/


            if (StopFlag == false)
            {
                while (dataReader.Read())
                {
                    Output = Output + dataReader.GetValue(0) + "";
                }
                dataReader.Close();
                sqlCon.Close();

                //HashedPassword = MD5(TBPassword.Text);

                if (Int32.Parse(Output) == 0)
                {
                    SqlConnection sqlCon2 = new SqlConnection(@"Data Source=DESKTOP-9EOJGT1\Typcio;Initial Catalog=shop;User ID=sa;Password=1234");


                    sqlCon2.Open();
                    sql2 = "Insert into users(login,email,pass_word,tac_accept) values ( '" + TBLogin.Text.Trim() + "' ,'" + TBEmail.Text.Trim() + "' ,'" + TBPassword.Text.Trim() + "' ,1)";
                    command2 = new SqlCommand(sql2, sqlCon2);
                    command2.ExecuteNonQuery();
                    sqlCon2.Close();


                    Response.Redirect("UserLogin.aspx");

                }
                else
                {
                    TBLogin.BackColor = System.Drawing.ColorTranslator.FromHtml("#D63E3E");
                    TBLogin.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");

                    TBEmail.BackColor = System.Drawing.ColorTranslator.FromHtml("#D63E3E");
                    TBEmail.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                }
            }


            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

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
                TBLogin.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CF0000");
                TBLogin.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7D6D6");
                StopFlag = true;
            }
            else if (TBLogin.Text.Length < 3)
            {
                TBLogin.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CF0000");
                TBLogin.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7D6D6");
                StopFlag = true;
            }
            else
            {
                TBRepPassword.BorderColor = System.Drawing.ColorTranslator.FromHtml("#DFDFDF");
                TBLogin.BackColor = System.Drawing.Color.White;
            }

            if (TBEmail.Text == "")
            {
                TBEmail.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CF0000");
                TBEmail.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7D6D6");
                StopFlag = true;
            }
            else
            {
                TBRepPassword.BorderColor = System.Drawing.ColorTranslator.FromHtml("#DFDFDF");
                TBEmail.BackColor = System.Drawing.Color.White;
            }

            if (TBPassword.Text == "")
            {
                TBPassword.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CF0000");
                TBPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7D6D6");
                StopFlag = true;
            }
            else if (TBPassword.Text.Length < 3)
            {
                TBPassword.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CF0000");
                TBPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7D6D6");
                StopFlag = true;
            }
            else
            {
                TBRepPassword.BorderColor = System.Drawing.ColorTranslator.FromHtml("#DFDFDF");
                TBPassword.BackColor = System.Drawing.Color.White;
            }

            if (TBRepPassword.Text == "")
            {
                TBRepPassword.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CF0000");
                TBRepPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7D6D6");
                StopFlag = true;
            }
            else if (TBRepPassword.Text != TBPassword.Text)
            {
                TBRepPassword.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CF0000");
                TBRepPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7D6D6");
                StopFlag = true;
            }
            else
            {
                TBRepPassword.BorderColor = System.Drawing.ColorTranslator.FromHtml("#DFDFDF");
                TBRepPassword.BackColor = System.Drawing.Color.White;
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
                    sql2 = "Insert into users(login,email,pass_word,tac_accept,is_admin) values ( '" + TBLogin.Text.Trim() + "' ,'" + TBEmail.Text.Trim() + "' ,'" + MD5Hashing(TBPassword.Text.Trim()) + "' ,1,0)";
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
        string MD5Hashing(string Password)
        {
            MD5 Md5Passowrd = new MD5CryptoServiceProvider();
            Md5Passowrd.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Password));
            byte[] HashedPassword = Md5Passowrd.Hash;
            StringBuilder StringBuilder = new StringBuilder();

            for (int i = 0; i < HashedPassword.Length; i++)
            {
                StringBuilder.Append(HashedPassword[i].ToString("x2"));
            }

            return StringBuilder.ToString();
        }
    }
}
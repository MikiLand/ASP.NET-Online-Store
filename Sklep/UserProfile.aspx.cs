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

        protected void BtnUpdateEmail_Click(object sender, EventArgs e)
        {
            bool StopFlag = false; 
            String sql2="";
            SqlCommand command2;

            SqlConnection sqlCon2 = new SqlConnection(@"Data Source=DESKTOP-9EOJGT1\Typcio;Initial Catalog=shop;User ID=sa;Password=1234");


            sqlCon2.Open();
            if (TBEmail.Text.Trim().Contains("@") == false)
            {
                TBEmail.BackColor = System.Drawing.ColorTranslator.FromHtml("#D63E3E");
                TBEmail.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                //LblErrorRegisterMessage.Text = "Email must contain @ character!";
                StopFlag = true;
            }
            else if (TBEmail.Text.Trim().Contains(".") == false && StopFlag == false)
            {
                TBEmail.BackColor = System.Drawing.ColorTranslator.FromHtml("#D63E3E");
                TBEmail.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                //LblErrorRegisterMessage.Text = "Email must contain . character!";
                StopFlag = true;
            }
            else
            {
                TBEmail.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                TBEmail.ForeColor = System.Drawing.ColorTranslator.FromHtml("#212529");
            }

            if (TBName.Text == "")
            {
                TBName.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CF0000");
                TBName.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7D6D6");
                StopFlag = true;
            }
            else if (TBName.Text.Length < 2)
            {
                TBLogin.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CF0000");
                TBLogin.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7D6D6");
                StopFlag = true;
            }
            else
            {
                TBName.BorderColor = System.Drawing.ColorTranslator.FromHtml("#DFDFDF");
                TBName.BackColor = System.Drawing.Color.White;
            }

            if (TBSurname.Text == "")
            {
                TBSurname.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CF0000");
                TBSurname.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7D6D6");
                StopFlag = true;
            }
            else if (TBName.Text.Length < 2)
            {
                TBSurname.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CF0000");
                TBSurname.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7D6D6");
                StopFlag = true;
            }
            else
            {
                TBSurname.BorderColor = System.Drawing.ColorTranslator.FromHtml("#DFDFDF");
                TBSurname.BackColor = System.Drawing.Color.White;
            }

            if (StopFlag == false)
            {
                //Response.Write("<script>alert('" + TBEmail.Text.ToString() + "');</script>");
                sql2 = "Update users (email, name, surname) values ('" + TBEmail.Text.Trim() + "','" + TBName.Text.Trim() + "','" + TBSurname.Text.Trim() + "') where id =  " + Session["UserID"] + "";
                command2 = new SqlCommand(sql2, sqlCon2);
                command2.ExecuteNonQuery();
                sqlCon2.Close();

                Response.Redirect("UserProfile.aspx");
            }
            else
            {
                TBEmail.BackColor = System.Drawing.ColorTranslator.FromHtml("#D63E3E");
                TBEmail.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                //LblErrorRegisterMessage.Text = "Email can't be empty!";

                /*Response.Write("<script>alert('" + TBEmail.Text.ToString() + "');</script>");
                sql2 = "Update users set email = '" + TBEmail.Text.Trim() + "' where id = " + Session["UserID"] + "";
                command2 = new SqlCommand(sql2, sqlCon2);
                command2.ExecuteNonQuery();
                sqlCon2.Close();*/
            }
            
        }

        protected void BtnUpdatePassword_Click(object sender, EventArgs e)
        {
            bool StopFlag = false;
            String sql2 = "", CurrentPassword = "", DatabaseCurrentPassword = "";
            SqlCommand command2;

            SqlConnection sqlCon2 = new SqlConnection(@"Data Source=DESKTOP-9EOJGT1\Typcio;Initial Catalog=shop;User ID=sa;Password=1234");

            if(TBCurrentPassword.Text != "")
            {
                CurrentPassword = MD5Hashing(TBCurrentPassword.Text);

                SqlDataReader dataReader;
                String sql, Output = "";


                sql = "SELECT pass_word FROM users where id = " + Session["UserID"] + "";
                sqlCon2.Open();
                command2 = new SqlCommand(sql, sqlCon2);

                SqlDataReader dr = command2.ExecuteReader();

                if (dr.Read())
                {

                    //dataReader = command.ExecuteReader();

                    DatabaseCurrentPassword = dr.GetValue(0).ToString();

                    sqlCon2.Close();
                }


                if (DatabaseCurrentPassword == CurrentPassword)
                {
                    if (TBPassword.Text.Length < 8)
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
                        sqlCon2.Open();

                        sql2 = "Update users set pass_word = '" + MD5Hashing(TBPassword.Text.Trim()) + "' where id =  " + Session["UserID"] + "";
                        command2 = new SqlCommand(sql2, sqlCon2);
                        command2.ExecuteNonQuery();

                        sqlCon2.Close();

                        Response.Redirect("UserProfile.aspx");
                    }
                }
                else
                {
                    TBCurrentPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#D63E3E");
                    TBCurrentPassword.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                }

            }
            else
            {
                TBCurrentPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#D63E3E");
                TBCurrentPassword.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
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
﻿using System;
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
    public partial class UserLogin : System.Web.UI.Page
    {

        public static SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-9EOJGT1\Typcio;Initial Catalog=Shop;User ID=sa;Password=1234");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand command;
           // SqlDataReader dataReader;
            String sql, Output = "";


            sql = "SELECT id, is_admin FROM users where login = '" + TBLogin.Text.Trim() + "' and pass_word ='" + MD5Hashing(TBPassword.Text.Trim()) + "'";
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
                TBLogin.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CF0000");
                TBPassword.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CF0000");
                TBLogin.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7D6D6");
                TBPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7D6D6");
                sqlCon.Close();
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
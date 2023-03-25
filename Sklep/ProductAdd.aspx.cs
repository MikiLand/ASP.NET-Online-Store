using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Sklep
{
    public partial class ProductAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DDLProductTypeOnSelect(object sender, EventArgs e)
        {
            BtnAdd.Text = "Clicked";
        }


        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand command, command2;
            SqlDataReader dataReader;
            String sql, sql2, Output = "";
            bool StopFlag;
            string HashedPassword = "";
            string ProductTypeString;
            int ProductType = 0;

            

            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-9EOJGT1\Typcio;Initial Catalog=Shop;User ID=sa;Password=1234");

            StopFlag = false;
            sql = "SELECT count(id) FROM product where name = '" + TBName.Text.Trim() + "' and type ='" + TBProductType.Text.Trim() + "'";

            sqlCon.Open();
            command = new SqlCommand(sql, sqlCon);

            dataReader = command.ExecuteReader();

            if (TBName.Text == "")
            {
                TBName.BackColor = System.Drawing.ColorTranslator.FromHtml("#D63E3E");
                TBName.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                StopFlag = true;
            }
            else
            {
                TBName.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                TBName.ForeColor = System.Drawing.ColorTranslator.FromHtml("#212529");
            }

            if (TBProductType.Text == "")
            {
                TBProductType.BackColor = System.Drawing.ColorTranslator.FromHtml("#D63E3E");
                TBProductType.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                StopFlag = true;
            }
            else
            {
                TBProductType.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                TBProductType.ForeColor = System.Drawing.ColorTranslator.FromHtml("#212529");
            }

            if (TBPrice.Text == "")
            {
                TBPrice.BackColor = System.Drawing.ColorTranslator.FromHtml("#D63E3E");
                TBPrice.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                StopFlag = true;
            }
            else
            {
                TBPrice.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                TBPrice.ForeColor = System.Drawing.ColorTranslator.FromHtml("#212529");
            }

            if (StopFlag == false)
            {
                while (dataReader.Read())
                {
                    Output = Output + dataReader.GetValue(0) + "";
                }
                dataReader.Close();
                sqlCon.Close();

                if (Int32.Parse(Output) == 0)
                {

                    ProductTypeString = TBProductType.Text.Trim();

                    switch (ProductTypeString)
                    {
                        case "Candle":
                            ProductType = 1;
                            break;
                        case "Scent":
                            ProductType = 2;
                            break;
                        case "Other":
                            ProductType = 3;
                            break;
                    }


                    SqlConnection sqlCon2 = new SqlConnection(@"Data Source=DESKTOP-9EOJGT1\Typcio;Initial Catalog=shop;User ID=sa;Password=1234");


                    sqlCon2.Open();
                    sql2 = "Insert into products(name,description,type,price) values ( '" + TBName.Text.Trim() + "' ,'" + TBDescription.Text.Trim() + "' ,'" + ProductType +"' ,'"+TBPrice.Text.Trim() + "')";
                    command2 = new SqlCommand(sql2, sqlCon2);
                    command2.ExecuteNonQuery();
                    sqlCon2.Close();


                    Response.Redirect("ProductAdd.aspx");

                }
                else
                {
                    TBName.BackColor = System.Drawing.ColorTranslator.FromHtml("#D63E3E");
                    TBName.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");

                    TBProductType.BackColor = System.Drawing.ColorTranslator.FromHtml("#D63E3E");
                    TBProductType.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                }
            }

        }
    }
}
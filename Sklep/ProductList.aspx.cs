using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sklep
{
    public partial class ProductList : System.Web.UI.Page
    {
        public static SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-9EOJGT1\Typcio;Initial Catalog=Shop;User ID=sa;Password=1234");
        protected void Page_Load(object sender, EventArgs e)
        {
            ////RangePrice.Min = 1;
            ////TBSearch.Text = "reee";

            SqlCommand command;
            // SqlDataReader dataReader;
            String sql;
            string PriceMin, PriceMax;


            sql = "select round(min(price),0)-1 as MinPrice, round(max(price),0)+1 as MixPrice from Product";
            sqlCon.Open();
            command = new SqlCommand(sql, sqlCon);

            SqlDataReader dr = command.ExecuteReader();

            if (dr.Read())
            {
                PriceMin = dr.GetValue(0).ToString();
                PriceMax = dr.GetValue(1).ToString();
                sqlCon.Close();
            }

            //RangePrice.
        }

        protected void ProductPicture_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            string SQLWhere = " where";
            string SQLWhereProductType = "";

            if (TBSearch.Text != "")
            {
                SQLWhere = "p.Name like '%" + TBSearch.Text.Trim() + "%'";
            }

            if (CBCandle.Checked)
            {
                SQLWhereProductType = " p.type in (1";
            }

            if (CBScent.Checked)
            {
                if (SQLWhereProductType == "")
                {
                    SQLWhereProductType = " and p.type in (2";
                }
                else
                {
                    SQLWhereProductType += ",2";
                }
            }

            if (CBOther.Checked)
            {
                if (SQLWhereProductType == "")
                {
                    SQLWhereProductType = " and p.type in (3";
                }
                else
                {
                    SQLWhereProductType += ",3";
                }
            }

            if(SQLWhereProductType != "")
            {
                SQLWhereProductType += ")";
            }

            if(SQLWhere == " where")
            {
                SQLWhere += SQLWhereProductType + " and p.Price <" + RangePrice.Value.Trim() + "";
            }
            else
            {
                SQLWhere += " and " + SQLWhereProductType + " and p.Price <" + RangePrice.Value.Trim() + "";
            }
            

            SqlDataProducts.SelectCommand = "select p.Name, p.Description, tp.TypeName as Type, p.Price, pic.Path from Product p left join ProductType tp on tp.id = p.Type left join Pictures Pic on Pic.IDCard = P.id" + SQLWhere + "Order by p.name";




        }
    }
}
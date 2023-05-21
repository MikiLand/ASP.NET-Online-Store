using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sklep
{
    public partial class ProductDetails : System.Web.UI.Page
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

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if(e.CommandName == "ToProductPage")
            {
                Response.Redirect("ProductDetails.aspx?id=" + e.CommandArgument.ToString());
            }
        }
    }
}
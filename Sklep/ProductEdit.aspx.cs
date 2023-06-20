using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sklep
{
    public partial class ProductEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSearchOnClick(object sender, EventArgs e)
        {
            SqlCommand command;
            String sql;

            sql = "SELECT top 1 name, type, description, price from product where name like '%" + TBProductName.Text.Trim() + "%' order by name";
            UserLogin.sqlCon.Open();
            command = new SqlCommand(sql, UserLogin.sqlCon);

            SqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                TBProductName.Text = dr.GetValue(0) + "";
                //TBProductName.Text = dr.GetValue(1) + "";

                switch (dr.GetValue(1))
                {
                    case 1:
                        TBProductType.Text = "Candle";

                        break;
                    case 2:
                        TBProductType.Text = "Scent";
                        break;
                    default:
                        TBProductType.Text = "Other";
                        break;
                }
                TBDescription.Text = dr.GetValue(2) + "";
                TBPrice.Text = dr.GetValue(3).ToString();
            }

            dr.Close();
            UserLogin.sqlCon.Close();
        }

        /*protected void DDLOptionCandle(object sender, EventArgs e)
        {
            TBProductType.Text = "Candle";
        }*/

        protected void BtnUpdateOnClick(object sender, EventArgs e)
        {
            SqlCommand command;
            String sql;
            int ProductType = 0;
            string Price;
            

            switch (DDLProductType.Text)
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
            };

            Price = TBPrice.Text.Trim();
            Price = Price.Replace(',', '.');

            sql = "Update product set type = " + DDLProductType.SelectedValue + ", description = '" + TBDescription.Text.Trim() + "', price = " + Price + " where name ='" + TBProductName.Text.Trim() + "'";
            UserLogin.sqlCon.Open();
            command = new SqlCommand(sql, UserLogin.sqlCon);
            command.ExecuteNonQuery();
            UserLogin.sqlCon.Close();

            //Response.Write("<script>alert('Product has been updated!');</script>");
            GVProducts.DataBind();

        }

        protected void BtnDeleteOnClick(object sender, EventArgs e)
        {
            SqlCommand command;
            String sql;

            sql = "Delete product where name ='" + TBProductName.Text.Trim() + "'";
            UserLogin.sqlCon.Open();
            command = new SqlCommand(sql, UserLogin.sqlCon);
            command.ExecuteNonQuery();
            UserLogin.sqlCon.Close();

            Response.Write("<script>alert('Product has been deleted!');</script>");
            GVProducts.DataBind();
        }

        protected void SqlProductsList_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}
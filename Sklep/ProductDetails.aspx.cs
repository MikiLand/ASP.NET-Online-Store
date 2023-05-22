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
            if (!IsPostBack)
            {
                if(Request.QueryString["id"] == null)
                {
                    Response.Redirect("ProductList.aspx");
                }
            }
        }

        protected void BtnAddToBasketOnClick(object sender, EventArgs e)
        {
            SqlCommand command;
            String sql;

            sql = "INSERT INTO Basket(id_user, id_product, amount) VALUES(" + Session["UserID"] + "," + Request.QueryString["id"] + ", 1)";
            sqlCon.Open();
            command = new SqlCommand(sql, sqlCon);
            command.ExecuteNonQuery();

            sqlCon.Close();

            Response.Redirect("Basket.aspx");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sklep
{
    public partial class Basket : System.Web.UI.Page
    {
        public static SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-9EOJGT1\Typcio;Initial Catalog=Shop;User ID=sa;Password=1234");
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataBasket.SelectCommand = "select id_user, p.Name, p.Description, p.Price, b.Amount, p.Price * b.Amount as Value, pic.Path  from Basket b left join Product p on p.id = b.id_product left join Pictures Pic on Pic.IDCard = P.id where id_user =" + Session["UserID"] + "";
            BasketSummary();
            //SqlDataBasketSummary.SelectCommand = "select sum(p.Price* b.Amount) as Total  from Basket b left join Product p on p.id = b.id_product where id_user" + Session["UserID"] + "";
        }

        protected void ProductPicture_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void BtnBasketMoreOnClick(object sender, EventArgs e)
        {
            BasketSummary();
        }

        protected void BtnBasketLessOnClick(object sender, EventArgs e)
        {
            BasketSummary();
        }

        protected void BtnDeleteFromBasketOnClick(object sender, EventArgs e)
        {
            BasketSummary();
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            
        }

        public void BasketSummary()
        {
            SqlCommand command;
            // SqlDataReader dataReader;
            String sql;
            string PriceMin, PriceMax;
            float Total, Delivery;
            int ProductAmount;


            sql = "select sum(p.Price* b.Amount) as Total, sum(b.Amount) as ProductAmount  from Basket b left join Product p on p.id = b.id_product where id_user = " + Session["UserID"] + "";
            sqlCon.Open();
            command = new SqlCommand(sql, sqlCon);

            SqlDataReader dr = command.ExecuteReader();

            if (dr.Read())
            {
                Total = Double(dr.GetValue(0));
                ProductAmount = dr.GetValue(1);
                LblTotal.Text 

                if(dr.GetValue(0) > 500)
                {
                    LblDelivery = "Free";
                }
                else
                {
                    Delivery = 25 + 3 * ProductAmount;
                    LblDelivery.Text = Delivery;
                }

                sqlCon.Close();
            }
        }
    }
}
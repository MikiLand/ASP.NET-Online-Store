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

        protected void BtnReedemOnClick(object sender, EventArgs e)
        {

        }

        public void BasketSummary()
        {
            SqlCommand command;
            // SqlDataReader dataReader;
            String sql;
            float PartialPrice = 0;
            float Total = 0;
            float Delivery = 0;
            int ProductAmount;


            sql = "select sum(p.Price* b.Amount) as PartialPrice, sum(b.Amount) as ProductAmount  from Basket b left join Product p on p.id = b.id_product where id_user = " + Session["UserID"] + "";
            sqlCon.Open();
            command = new SqlCommand(sql, sqlCon);

            SqlDataReader dr = command.ExecuteReader();

            if (dr.Read())
            {
                PartialPrice = float.Parse(dr.GetValue(0).ToString());
                ProductAmount = int.Parse(dr.GetValue(1).ToString());
                LblTotal.Text = Total.ToString();

                if (PartialPrice > 500)
                {
                    LblDelivery.Text = "Free";
                }
                else
                {
                    Delivery = 25 + (3 * ProductAmount);
                    LblDelivery.Text = Delivery.ToString();
                }

                Total = PartialPrice + Delivery;

                LblTotal.Text = Total.ToString();

                sqlCon.Close();
            }
        }
    }
}
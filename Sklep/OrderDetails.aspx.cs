using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sklep
{
    public partial class OrderDetails : System.Web.UI.Page
    {
        public static SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-9EOJGT1\Typcio;Initial Catalog=Shop;User ID=sa;Password=1234");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("ProductList.aspx");
                }
            }

            SqlDataOrder.SelectCommand = "select OP.id_order as id, op.net * op.amount as net, op.gross * op.amount as gross, p.name, p.description, Pic.Path, op.amount from OrderPosition OP left join Product p on p.id = op.id_product left join Pictures Pic on Pic.IDCard = P.id where id_order = " + Request.QueryString["id"]  + "";
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
            float PartialPrice = 0;
            float Total = 0;
            float Delivery = 0;
            int ProductAmount, CodeValue, CodePercent;


            sql = "select top 1 O.net, O.gross, sum(op.amount) as amount, pc.code_name, pc.code_value, pc.code_percent from [Order] O left join PromoCodes PC on PC.id = O.id_promocode left join OrderPosition OP on OP.id_order = O.id where o.id = " + Request.QueryString["id"] + " group by o.net, o.gross, pc.code_name, pc.code_value, pc.code_percent ";
            sqlCon.Open();
            command = new SqlCommand(sql, sqlCon);

            SqlDataReader dr = command.ExecuteReader();

            if (dr.Read())
            {
                PartialPrice = float.Parse(dr.GetValue(1).ToString());
                ProductAmount = int.Parse(dr.GetValue(2).ToString());
                CodeValue = int.Parse(dr.GetValue(4).ToString());
                CodePercent = int.Parse(dr.GetValue(5).ToString());
                



                if (PartialPrice > 500)
                {
                    LblDelivery.Text = "Free";
                }
                else
                {
                    Delivery = 15 + (3 * ProductAmount);
                    LblDelivery.Text = Delivery.ToString();
                }

                Total = PartialPrice + Delivery;

                LblPartialPrice.Text = PartialPrice.ToString();
                LblTotal.Text = Total.ToString();

                if (CodeValue > 0)
                {
                    LblPromoCodeValue.Text = CodeValue + "$";
                    LblTotal.Text = (float.Parse(LblTotal.Text) - CodeValue).ToString();
                    LblPromoCodeDescription.Visible = true;
                    LblPromoCodeValue.Visible = true;
                }
                else if (CodePercent > 0)
                {
                    LblPromoCodeValue.Text = CodePercent + "%";
                    LblTotal.Text = Math.Round((float.Parse(LblTotal.Text) - (float.Parse(LblTotal.Text) * (CodePercent / 100))), 2).ToString();
                    LblPromoCodeDescription.Visible = true;
                    LblPromoCodeValue.Visible = true;
                };
            }

            sqlCon.Close();
        }
    }
}
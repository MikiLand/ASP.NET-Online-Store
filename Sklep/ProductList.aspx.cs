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
            string PriceMin = "0";
            string PriceMax = "100";


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

            RangePrice.Attributes.Add("min", PriceMin);
            RangePrice.Attributes.Add("min", PriceMax);
            RangeCurrentAmount.Text = PriceMax.ToString();
        }

        protected void ProductPicture_Click(object sender, EventArgs e)
        {

        }

        protected void DataListProduct_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if(e.CommandName == "ToProductPage")
            {
                Response.Redirect("ProductDetails.aspx?id=" + e.CommandArgument.ToString());
            }
        }

        protected void RangeOnChange(object sender, EventArgs e)
        { 
            RangeCurrentAmount.Text = RangePrice.Value.ToString();
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            string SQLWhere = " where p.Price <" + RangePrice.Value.Trim() + "";
            string SQLWhereProductType = "", SQLOrderBy ="";

            if (TBSearch.Text != "")
            {
                SQLWhere += " and p.Name like '%" + TBSearch.Text.Trim() + "%'";
            }

            if (CBCandle.Checked)
            {
                SQLWhereProductType = " and p.type in (1";
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
                    SQLWhereProductType = "and p.type in (3";
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

            if (RadioNameAsc.Checked)
                SQLOrderBy = " order by p.Name asc";
            else if (RadioNameDesc.Checked)
                SQLOrderBy = " order by p.Name desc";
            else if (RadioPriceAsc.Checked)
                SQLOrderBy = " order by p.Price asc";
            else if (RadioPriceDesc.Checked)
                SQLOrderBy = " order by p.Price desc";
            else if (RadioProductType.Checked)
                SQLOrderBy = " order by tp.TypeName";

            SqlDataProducts.SelectCommand = "select p.id, p.Name, p.Description, tp.TypeName as Type, p.Price, pic.Path from Product p left join ProductType tp on tp.id = p.Type left join Pictures Pic on Pic.IDCard = P.id" + SQLWhere + SQLWhereProductType + SQLOrderBy + "";
        }

        protected void ImgBtnProductOnClick(object sender, ImageClickEventArgs e)
        {

        }
    }
}
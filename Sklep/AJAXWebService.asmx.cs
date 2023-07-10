using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Serialization;

namespace Sklep
{
    /// <summary>
    /// Summary description for AJAXWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AJAXWebService : System.Web.Services.WebService
    {
        public static SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-9EOJGT1\Typcio;Initial Catalog=Shop;User ID=sa;Password=1234");

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        public string GetProducts(String TBSearch, bool CBCandle, bool CBScent, bool CBOther, int RadioOrder)
        {
            string SQLWhere = " where p.Price < 1000"; //+ RangePrice.Value.Trim() + "";
            string SQLWhereProductType = "", SQLOrderBy = "";

            if (TBSearch != "")
            {
                SQLWhere += " and p.Name like '%" + TBSearch.Trim() + "%'";
            }

            if (CBCandle == true)
            {
                SQLWhereProductType = " and p.type in (1";
            }

            if (CBScent == true)
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

            if (CBOther == true)
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

            if (SQLWhereProductType != "")
            {
                SQLWhereProductType += ")";
            }

            if (RadioOrder == 1)
                SQLOrderBy = " order by p.Name asc";
            else if (RadioOrder == 2)
                SQLOrderBy = " order by p.Name desc";
            else if (RadioOrder == 3)
                SQLOrderBy = " order by p.Price asc";
            else if (RadioOrder == 4)
                SQLOrderBy = " order by p.Price desc";
            else if (RadioOrder == 5)
                SQLOrderBy = " order by tp.TypeName";

            return "select p.id, p.Name, p.Description, tp.TypeName as Type, p.Price, pic.Path from Product p left join ProductType tp on tp.id = p.Type left join Pictures Pic on Pic.IDCard = P.id" + SQLWhere + SQLWhereProductType + SQLOrderBy + "";
        }
    }
}

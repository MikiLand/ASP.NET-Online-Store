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
        public void GetAllEmployee()
        {
            List<EmployeesRecord> employeelist = new List<EmployeesRecord>();

            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    EmployeesRecord employee = new EmployeesRecord();
                    employee.ID = Convert.ToInt32(rdr["ID"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Position = rdr["Position"].ToString();
                    employee.Office = rdr["Office"].ToString();
                    employee.Age = Convert.ToInt32(rdr["Age"]);
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);

                    employeelist.Add(employee);
                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(employeelist));
        }

        [WebMethod]
        public void GetProducts()
        {
            string SQLWhere = " where p.Price < 1000"; //+ RangePrice.Value.Trim() + "";
            string SQLWhereProductType = "", SQLOrderBy = "";
            SqlCommand command;
            String sql;
            List<Products> ProductList = new List<Products>();

            String TBSearch = "";
                bool CBCandle = true;
                bool CBScent = true;
                bool CBOther = true;
                int RadioOrder = 1;

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
            sqlCon.Open();
            command = new SqlCommand(sql, sqlCon);

            SqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                Products Product = new Products();
                Product.ID = Convert.ToInt32(dr["ID"]);
                Product.Name = dr["Name"].ToString();
                Product.Description = dr["Description"].ToString();
                Product.TypeName = dr["Type"].ToString();
                Product.Price = float.Parse(dr["Price"].ToString());
                Product.Path = dr["Path"].ToString();

            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(ProductList));








            /*List<EmployeesRecord> employeelist = new List<EmployeesRecord>();

            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    EmployeesRecord employee = new EmployeesRecord();
                    employee.ID = Convert.ToInt32(rdr["ID"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Position = rdr["Position"].ToString();
                    employee.Office = rdr["Office"].ToString();
                    employee.Age = Convert.ToInt32(rdr["Age"]);
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);

                    employeelist.Add(employee);
                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(employeelist));*/
        }

        /*[WebMethod]
        public string GetProducts(String TBSearch, bool CBCandle, bool CBScent, bool CBOther, int RadioOrder)
        {
            string SQLWhere = " where p.Price < 1000"; //+ RangePrice.Value.Trim() + "";
            string SQLWhereProductType = "", SQLOrderBy = "";
            SqlCommand command;
            String sql;
            List<Products> ProductList = new List<Products>();

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
            sqlCon.Open();
            command = new SqlCommand(sql, sqlCon);

            SqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                Products Product = new Products();
                Product.ID = Convert.ToInt32(dr["ID"]);
                Product.Name = dr["Name"].ToString();
                Product.Description = dr["Description"].ToString();
                Product.TypeName = dr["Type"].ToString();
                Product.Price = float.Parse(dr["Price"].ToString());
                Product.Path = dr["Path"].ToString();

            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(ProductList));
        }*/
    }
}

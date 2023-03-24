using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sklep
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NavAddProduct.Visible = false;
            NavEditProduct.Visible = false;
            NavLogin.Visible = true;
            NavRegister.Visible = true;
            NavLogout.Visible = false;
            NavUser.Visible = false;

            

            if (Session["UserID"] != null) 
            {
                //Response.Write("<script>alert('" + Session["UserID"].ToString() + "');</script>");
                if (Session["IsAdmin"].ToString() == "1")
                {
                    NavAddProduct.Visible = true;
                    NavEditProduct.Visible = true;
                    NavLogin.Visible = false;
                    NavRegister.Visible = false;
                    NavLogout.Visible = true;
                    NavLogout.Visible = true;
                    NavUser.Visible = true;
                }
                else
                {
                    NavAddProduct.Visible = false;
                    NavEditProduct.Visible = false;
                    NavLogin.Visible = false;
                    NavRegister.Visible = false;
                    NavLogout.Visible = true;
                    NavUser.Visible = true;
                }
            
            }
        }

        protected void NavAddProduct_Click1(object sender, EventArgs e)
        {
            Response.Redirect("ProductAdd.aspx");
        }

        protected void NavEditProduct_Click1(object sender, EventArgs e)
        {
            Response.Redirect("ProductEdit.aspx");
        }

        protected void NavLogin_Click1(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx");
        }

        protected void NavRegister_Click1(object sender, EventArgs e)
        {
            Response.Redirect("UserRegister.aspx");
        }

        protected void NavLogout_Click1(object sender, EventArgs e)
        {
            Session["UserID"] = null;
            Session["IsAdmin"] = null;
            NavAddProduct.Visible = false;
            NavEditProduct.Visible = false;
            NavLogin.Visible = true;
            NavRegister.Visible = true;
            NavLogout.Visible = false;
            NavUser.Visible = false;
            Response.Redirect("HomePage.aspx");
        }

        protected void NavUser_Click1(object sender, EventArgs e)
        {
            Response.Redirect("UserProfile.aspx");
        }
    }
}
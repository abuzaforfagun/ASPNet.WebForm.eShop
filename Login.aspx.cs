using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["user"] != null)
        {
            if(Session["type"].ToString() == "host")
            {
                Response.Redirect("products.aspx");

            }
            else
            {
                Response.Redirect("Availableproducts.aspx");

            }
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        UserLogin user = new UserLogin();
        user.Email = txtUserId.Text;
        user.Password = txtPassword.Text;
        if (user.Login())
        {
            Session["user"] = user.Id;
            if(user.Type == "host")
            {
                Session["type"] = "host";
                Response.Redirect("products.aspx");
            }
            else
            {
                Session["type"] = "contractor";
                Response.Redirect("Availableproducts.aspx");
            }
        }
        else
        {
            lblMessage.Text = "Login Failed";
        }
    }
}
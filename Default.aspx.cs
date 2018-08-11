using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["user"] == null)
        {
            Response.Redirect("login.aspx");
        }

        if(Session["type"].ToString() == "host")
        {
            Response.Redirect("products.aspx");
        }
        else
        {
            Response.Redirect("availableproducts.aspx");
        }
    }
}
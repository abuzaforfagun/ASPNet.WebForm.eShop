using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["user"] != null)
        {
            if(Session["type"].ToString() == "host")
            {
                divContractor.Visible = false;
                divHost.Visible = true;
            }
            else
            {
                divHost.Visible = false;
                divContractor.Visible = true;
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
}

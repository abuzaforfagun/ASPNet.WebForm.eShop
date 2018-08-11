using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegisterBuyer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Buyer buyer = new Buyer();
        buyer.Name = txtName.Text.ToString();
        buyer.Email = txtEmail.Text.ToString();
        buyer.Password = txtPassword.Text.ToString();
        var registerHost = buyer.Add();
        Session["user"] = registerHost.Id;
        Session["type"] = "contractor";
        Response.Redirect("availableproducts.aspx");
    }
}
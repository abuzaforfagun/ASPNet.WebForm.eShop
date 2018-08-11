using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegisterSeller: System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Seller seller = new Seller();
        seller.Name = txtName.Text.ToString();
        seller.Email = txtEmail.Text.ToString();
        seller.Password = txtPassword.Text.ToString();
        var registerHost = seller.Add();
        Session["user"] = registerHost.Id;
        Session["type"] = "host";
        
        Response.Redirect("products.aspx");
    }
}
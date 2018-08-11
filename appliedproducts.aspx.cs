using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AppliedProducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userId = "";
        if (!IsPostBack)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx");
            }
            userId = Session["user"].ToString();
            List<AppliedProduct> availableProducts = Product.LoadAppliedProducts(userId);

            string html = "";
            int sl = 0;
            foreach (var t in availableProducts)
            {
                sl++;
                html = "<tr>";
                html += "<td>" + sl + "</td>";
                html += "<td><a href = 'single.aspx?id=" + t.Product.Id + "'>" + t.Product.Title + "</a></td>";
                html += "<td>" + t.Product.Seller.Name + "</td>";
                html += "<td>" + t.Product.Description + "</td>";
                html += "<td>" + t.Price + "</td>";

                html += "<td>" + t.Product.LastDate + "</td>";
                html += "<td>" + t.Product.PublishDate + "</td>";
                html += "</tr>";
            }
            placeHolderTenderList.Text = html;
        }
    }
}
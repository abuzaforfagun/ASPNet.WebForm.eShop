using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.QueryString["query"] == null)
        {
            Response.Redirect("availableproducts.aspx");
            return;
        }
        string query = Request.QueryString["query"].ToString();
        lblSearch.Text = query;
        if (!IsPostBack)
        {
            if(Session["user"] == null)
            {
                Response.Redirect("login.aspx");
            }
            List<Product> availableProducts = Product.LoadSearchProducts(query);
            int sl = 0;
            string html = "";
            foreach (var t in availableProducts)
            {
                sl++;
                html = "<tr>";
                html += "<td>" + sl + "</td>";
                html += "<td><a href = 'single.aspx?id=" + t.Id + "'>" + t.Title + "</a></td>";
                html += "<td>" + t.Seller.Name + "</td>";
                html += "<td>" + t.Description + "</td>";
                html += "<td>" + t.LastDate + "</td>";
                html += "<td>" + t.PublishDate + "</td>";
                html += "</tr>";
            }
            placeHolderTenderList.Text = html;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string query = txtSearch.Text;
        Response.Redirect("search.aspx?query=" + query);
    }
}
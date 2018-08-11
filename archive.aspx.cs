using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Archive : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<Product> Products = new List<Product>();
            if(Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            var _host = Session["user"].ToString();
            int host = int.Parse(_host);
            Products = Product.LoadArchiveProducts(host, DateTime.Now.ToShortDateString());
            string html = "";
            int sl = 0;
            foreach(var t in Products)
            {
                sl++;
                html += "<tr>";
                html += "<td>" + sl + "</td>";
                html += "<td><img style = 'max-width:80px; max-height:80px;' src = 'data/" + t.Image + "'/></td>";
                if(DateTime.Now < t.LastDate)
                {
                    html += "<td><a href = 'edit.aspx?id=" + t.Id + "'>" + t.Title + "</a></td>";

                }
                else
                {
                    html += "<td>" + t.Title + "</td>";

                }
                html += "<td>" + t.Price + "</td>";
                html += "<td>" + t.Description + "</td>";
                html += "<td>" + t.LastDate + "</td>";
                html += "<td>" + t.PublishDate + "</td>";

                if(DateTime.Now < t.LastDate)
                {
                    html += "<td> ---- </td>";
                    html += "<td> ---- </td>";
                }
                else
                {
                    html += "<td>" + t.Winner.Buyer.Name + "</td>";
                    html += "<td>" + t.Winner.Price + "</td>";

                }
                html += "</tr>";
            }
            placeHolderTenderList.Text = html;
        }
    }
}
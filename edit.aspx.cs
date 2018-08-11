using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditProduct : System.Web.UI.Page
{
    string productId = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Product product = new Product();
        if (!IsPostBack)
        {
            if(Request.QueryString["id"] != null)
            {
                productId = Request.QueryString["id"].ToString();
            }
            else
            {
                Response.Redirect("products.aspx");
                return;
            }
            int _id = int.Parse(productId);
            product.Id = _id;
            product.Get();
            txtDescription.Text = product.Description;
            txtLastDate.Text = product.LastDate.ToShortDateString();
            txtPrice.Text = product.Price.ToString();
            txtTitle.Text = product.Title.ToString();
            lblImage.Text = product.Image;
            lblDate.Text = product.LastDate.ToShortDateString();
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            productId = Request.QueryString["id"].ToString();
        }
        else
        {
            Response.Redirect("products.aspx");
            return;
        }
        Product product = new Product();
        product.Id = int.Parse(productId);
        product.Description = txtDescription.Text;
        product.SellerId = Session["user"].ToString();
        try
        {
            product.LastDate = Convert.ToDateTime(txtLastDate.Text);
        }
        catch
        {
            product.LastDate = Convert.ToDateTime(lblDate.Text);

        }

        product.Price = int.Parse(txtPrice.Text);
        product.PublishDate = DateTime.Now;
        product.Title = txtTitle.Text;

        string imageUrl = "";
        if (fileImage.HasFiles)
        {

            var uploadFile = fileImage.PostedFile;
            string _filename = DateTime.Now.Ticks.ToString();
            string path = System.IO.Path.Combine(Server.MapPath("~/data/"), _filename + uploadFile.FileName);
            uploadFile.SaveAs(path);
            var fileUrl = _filename + uploadFile.FileName;
            imageUrl = fileUrl;
            product.Image = imageUrl;

        }
        else
        {
            product.Image = lblImage.Text;
        }
        
        product.Update();
        lblMessage.Text = "Updated Successfully";
        


    }
}
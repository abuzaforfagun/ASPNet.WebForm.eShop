using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Product product = new Product();
        product.Description = txtDescription.Text;
        product.SellerId = Session["user"].ToString();
        product.LastDate = Convert.ToDateTime(txtLastDate.Text);
        product.Price = int.Parse(txtPrice.Text);
        product.PublishDate = Convert.ToDateTime(DateTime.Now);
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


        product.Add();
        lblMessage.Text = "Added Successfully";
        txtTitle.Text = "";
        txtDescription.Text = "";
        txtLastDate.Text = "";
        txtPrice.Text = "";
        txtTitle.Text = "";
        

    }
}
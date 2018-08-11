using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Single : System.Web.UI.Page
{
    string id;
    string userId;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request.QueryString["id"].ToString();
        int _id = int.Parse(id);
        if (!IsPostBack)
        {

            Product product = new Product();
            product.Id = _id;
            product.Get();

            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            userId = Session["user"].ToString();

            lblHost.Text = product.Seller.Name;
            lblDescription.Text = product.Description;
            lblLastDate.Text = product.LastDate.ToString();
            lblPrice.Text = product.Price.ToString();
            lblPostDate.Text = product.PublishDate.ToString();
            lblTitle.Text = product.Title;
            var bids = Bids.isAlreadyBid(userId, id);
            if (bids != null)
            {
                divBidAmount.Visible = true;
                divBidNow.Visible = false;
                lblYourBid.Text = bids.Price.ToString();

            }

            if(product.LastDate < DateTime.Now)
            {
                divBidNow.Visible = false;
                divWinning.Visible = true;
                var bid = Contract.GetWinner(id);
                bid.Buyer = Buyer.Get(bid.BuyerId.ToString());
                lblWiningPrice.Text = bid.Price.ToString();
                lblWinner.Text = bid.Buyer.Name;
            }

            product.Seller = new Seller();
            product.Seller.Id = int.Parse(product.SellerId);
            product.Seller.Get();
        }
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        Bids bid = new Bids();
        var _userId = Session["user"].ToString();
        bid.BuyerId = int.Parse(_userId);
        bid.Date = DateTime.Now;
        bid.Price = int.Parse(txtAmount.Text);
        id = Request.QueryString["id"];
        bid.ProductId = int.Parse(id);
        bid.Add();
        divBidAmount.Visible = true;
        divBidNow.Visible = false;
        lblYourBid.Text = bid.Price.ToString();

        Contract contract = new Contract();
        contract.Bid = bid;

        contract.Add();
    }
}
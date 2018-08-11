using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


public class Bids
{
    public int Id { get; set; }
    public Product Tender { get; set; }
    public int ProductId { get; set; }
    public Buyer Buyer { get; set; }
    public int BuyerId { get; set; }
    public double Price { get; set; }
    public DateTime Date { get; set; }

    public Bids Add()
    {
        string sql = @"INSERT INTO Bids (productId, buyerId, Price, Date) VALUES 
                    (" + ProductId + ", " + BuyerId + "," + Price + ", '" + Date + "')";
        var _id = Db.executeandGetId(sql);
        sql = "SELECT top 1 * FROM Bids order by id desc";
        var row = Db.getOne(sql);


        Id = int.Parse(row["id"].ToString());
        return this;
    }

    public void Get()
    {
        string sql = "SELECT * FROM Bids WHERE id = " + Id;
        DataRow row = Db.getOne(sql);
        var _productId = row["productid"].ToString();
        ProductId = int.Parse(_productId);
        Tender = new Product();
        Tender.Id = ProductId;
        Tender.Get();

        var _buyer = row["buyerid"].ToString();
        BuyerId = int.Parse(_buyer);
        var _price = row["price"].ToString();
        Price = int.Parse(_price);
        Date = Convert.ToDateTime(row["date"].ToString());
    }

    public static Bids isAlreadyBid(string buyerid, string productid)
    {
        Bids bid = new Bids();
        string sql = "SELECT * FROM Bids WHERE buyerid = " + buyerid + " and productid = " + productid;
        DataRow row = Db.getOne(sql);
        if(row.Table.Rows.Count > 0)
        {
            var _id = row["id"].ToString();
            bid.Id = int.Parse(_id);
            bid.Get();
            return bid;
        }
        bid = null;
        return bid;
    }
}

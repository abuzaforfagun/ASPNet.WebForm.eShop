using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


public class Contract
{
    public int Id { get; set; }
    public Product Tender { get; set; }
    public int ProductId { get; set; }
    public Bids Bid { get; set; }
    public int BidId { get; set; }
    public int Price { get; set; }

    public void Add()
    {
        string sql = "SELECT MIN(price) as price FROM contract WHERE productid = " + Bid.ProductId;
        DataRow row = Db.getOne(sql);
        var _price = row["price"].ToString();
        if(_price == "NULL" || _price == "")
        {
            sql = "INSERT INTO contract (productid, BidId, Price) VALUES (" + Bid.ProductId + "," + Bid.Id + "," + Bid.Price + ")";
            Db.execute(sql);
            return;
        }
        int price = int.Parse(_price);
        if(Bid.Price < price)
        {
            sql = "INSERT INTO contract (productid, BidId, Price) VALUES (" + ProductId + "," + BidId + "," + Price + ")";
            Db.execute(sql);
            return;
        }
        
    }

    public static Bids GetWinner(string ProductId)
    {
        string sql = "SELECT * FROM Contract WHERE productId = " + ProductId;
        DataRow row = Db.getOne(sql);
        if(row == null)
        {
            return null;
        }
        Bids bid = new Bids();
        var _id = row["bidid"].ToString();
        bid.Id = int.Parse(_id);
        bid.Get();
        return bid;
    }
}

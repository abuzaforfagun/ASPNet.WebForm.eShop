using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


public class Product
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public DateTime PublishDate { get; set; }
    public DateTime LastDate { get; set; }
    public string SellerId { get; set; }
    public Seller Seller { get; set; }
    public string Image { get; set; }
    public Product Add()
    {
        string sql = @"INSERT INTO Product (Title, Description, Price, PublishDate, LastDate, SellerId, Image) VALUES
                    ('" + Title + "', '" + Description + "', " + Price  + ", " + PublishDate.ToString("dd-mm-yyyy") + ", " + LastDate.ToString("dd-mm-yyyy") + ", " + SellerId + ", '" + Image +"')";
        var _id = Db.executeandGetId(sql);
        Id = int.Parse(_id);
        return this;
    }

    public Product Update()
    {

        string sql = @"Update Product 
                        SET
                        Title = '" + Title + @"',
                        Description = '" + Description + @"',
                        Price = " + Price + @",
                        PublishDate = '" + PublishDate + @"',
                        LastDate = '" + LastDate + @"',
                        Image = '" + Image + @"' 
                        WHERE Id = " + Id;
        var _id = Db.executeandGetId(sql);
        Id = int.Parse(_id);
        return this;
    }

    public static List<AppliedProduct> LoadAppliedProducts(string buyer, bool isWinning = false)
    {
        List<AppliedProduct> List = new List<AppliedProduct>();
        string sql = "";
        
        if (buyer != "")
        {
            sql = @"select product.*, bids.price as bidprice from product, bids, buyer
                  where
                  bids.buyerid = " + buyer + @"
                  and
                  bids.productid = Product.id
                  and
                  bids.buyerid = buyer.id";
        }
        if (isWinning)
        {
            sql = @"select Product.*, bids.price as bidprice from contract, bids, Product
                    where
                    bids.buyerid = " + buyer + @"
                    and
                    contract.bidid = bids.id
                    and
                    Product.id = bids.productid
                    and product.lastdate < '"+ DateTime.Now.ToShortDateString() +"'" ;
        }
        DataTable tenderTable = Db.getAll(sql);
        foreach (DataRow row in tenderTable.Rows)
        {
            AppliedProduct appliedProduct = new AppliedProduct();
            var _id = row["id"].ToString();
            appliedProduct.Product = new Product();
            appliedProduct.Product.Id = int.Parse(_id);
            appliedProduct.Product.Seller = new Seller();
            string _seller = row["sellerid"].ToString();
            appliedProduct.Product.Seller.Id = int.Parse(_seller);
            appliedProduct.Product.Seller.Get();
            appliedProduct.Product.Description = row["description"].ToString();
            var _lastDate = row["lastdate"].ToString();
            appliedProduct.Product.LastDate = Convert.ToDateTime(_lastDate);
            var _postDate = row["publishdate"].ToString();
            appliedProduct.Product.PublishDate = Convert.ToDateTime(_postDate);
            var price = row["price"].ToString();
            appliedProduct.Product.Image = row["image"].ToString();
            appliedProduct.Product.Price = int.Parse(price);
            appliedProduct.Product.Title = row["title"].ToString();
            appliedProduct.Price = row["bidprice"].ToString();
            List.Add(appliedProduct);
        }
        return List;
    }
    


    public static List<Product> LoadSearchProducts(string query)
    {
        List<Product> List = new List<Product>();
        string sql = "";
        if (query != "")
        {
            sql = "SELECT * FROM Product where id = " + query + " or title like '%"+query+"%' OR description like '%"+query+"%'" ;
        }
        else
        {
            return null;
        }
        DataTable tenderTable = Db.getAll(sql);
        foreach (DataRow row in tenderTable.Rows)
        {
            Product product = new Product();
            var _id = row["id"].ToString();
            product.Id = int.Parse(_id);
            product.Seller = new Seller();
            string _seller = row["sellerid"].ToString();
            product.Seller.Id = int.Parse(_seller);
            product.Seller.Get();
            product.Description = row["description"].ToString();
            var _lastDate = row["lastdate"].ToString();
            product.LastDate = Convert.ToDateTime(_lastDate);
            var _postDate = row["publishdate"].ToString();
            product.PublishDate = Convert.ToDateTime(_postDate);
            var price = row["price"].ToString();
            product.Image = row["image"].ToString();
            product.Price = int.Parse(price);
            product.Title = row["title"].ToString();

            List.Add(product);
        }
        return List;

    }

    public static List<Product> LoadProducts(int seller = 0, string date = "", string buyer = "")
    {
        List<Product> List = new List<Product>();
        string sql;
        if(seller == 0)
        {
            sql = "SELECT * FROM Product ";
        }
        else
        {
            sql = "SELECT * FROM Product WHERE sellerid = " + seller ;
        }
        if(buyer != "")
        {
            sql = @"select product.*, bids.price from product, bids, buyer
                  where
                  bids.buyerid = " + buyer + @"
                  and
                  bids.productid = Product.id
                  and
                  bids.buyerid = buyer.id";
        }
        if (date != "")
        {
            sql += " where lastdate <= '" + date + "'";
        }

        sql += " Order by Id DESC";
        DataTable tenderTable = Db.getAll(sql);
        foreach (DataRow row in tenderTable.Rows)
        {
            Product product = new Product();
            var _id = row["id"].ToString();
            product.Id = int.Parse(_id);
            product.Seller = new Seller();
            string _seller = row["sellerid"].ToString();
            product.Seller.Id = int.Parse(_seller);
            product.Seller.Get();
            product.Description = row["description"].ToString();
            var _lastDate = row["lastdate"].ToString();
            product.LastDate = Convert.ToDateTime(_lastDate);
            var _postDate = row["publishdate"].ToString();
            product.PublishDate = Convert.ToDateTime(_postDate);
            var price= row["price"].ToString();
            product.Image = row["image"].ToString();
            product.Price = int.Parse(price);
            product.Title = row["title"].ToString();

            List.Add(product);
        }
        return List;

    }

    public static List<Product> LoadArchiveProducts(int seller = 0, string date = "")
    {
        List<Product> List = new List<Product>();
        string sql;
        if (seller == 0)
        {
            sql = "SELECT * FROM Product ";
        }
        else
        {
            sql = "SELECT * FROM Product WHERE sellerid = " + seller;
        }
        
        if (date != "")
        {
            if(seller != 0)
            {
                sql += " and lastdate >= '" + date + "'";
            }
            else
            {
                sql += " where lastdate >= '" + date + "'";

            }
        }

        sql += " Order by Id DESC";
        DataTable tenderTable = Db.getAll(sql);
        foreach (DataRow row in tenderTable.Rows)
        {
            Product product = new Product();
            var _id = row["id"].ToString();
            product.Id = int.Parse(_id);
            product.Seller = new Seller();
            string _seller = row["sellerid"].ToString();
            product.Seller.Id = int.Parse(_seller);
            product.Seller.Get();
            product.Description = row["description"].ToString();
            var _lastDate = row["lastdate"].ToString();
            product.LastDate = Convert.ToDateTime(_lastDate);
            var _postDate = row["publishdate"].ToString();
            product.PublishDate = Convert.ToDateTime(_postDate);
            var price = row["price"].ToString();
            product.Image = row["image"].ToString();
            product.Price = int.Parse(price);
            product.Title = row["title"].ToString();

            List.Add(product);
        }
        return List;

    }

    public Product Get()
    {

        string sql = "SELECT * FROM Product WHERE id = " + Id ;
        DataRow row = Db.getOne(sql);
        Seller = new Seller();
        string _seller = row["sellerid"].ToString();
        Seller.Id = int.Parse(_seller);
        Seller.Get();
        SellerId = _seller;
        Description = row["description"].ToString();
        var _lastDate = row["lastdate"].ToString();
        LastDate = Convert.ToDateTime(_lastDate);
        var _postDate = row["publishdate"].ToString();
        PublishDate = Convert.ToDateTime(_postDate);
        var _price = row["price"].ToString();
        Price = int.Parse(_price);
        Image = row["image"].ToString();
        Title = row["title"].ToString();

        return this;
    }

    public WinningBid Winner
    {
        get
        {
            string sql = @"select buyer.*, bids.price from buyer, bids, contract
                            where
                            contract.productId = " +  Id + @"
                            and
                            bids.id = Contract.bidid
                            and
                            buyer.id = bids.buyerid";
            DataRow row = Db.getOne(sql);
            Buyer buyer = new Buyer();
            WinningBid bid = new WinningBid();

            if (row.Table.Rows.Count == 0)
            {
                buyer.Name = "";
                buyer.Email = "";
                bid.Buyer = buyer;
                bid.Price = "";
                return bid;
            }
            buyer.Name = row["name"].ToString();
            buyer.Email = row["email"].ToString();

            bid.Buyer = buyer;
            bid.Price = row["price"].ToString();
            return bid;
        }

    }

}

    

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


public class Buyer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }



    public Buyer Add()
    {
        string sql = @"Insert Into buyer (Name, Email, Password) VALUES 
                        ('" + Name + "', '" + Email + "', '" + Password + "')";
        var _id = Db.executeandGetId(sql);
        Id = int.Parse(_id);

        sql = "SELECT TOP 1 * FROM Contractor Order By Id DESC";
        DataRow row = Db.getOne(sql);
        var id = row["Id"].ToString();
        Id = int.Parse(id);

        return this;
    }

    public static Buyer Get(string id)
    {
        string sql = "SELECT * FROM buyer WHERE Id = " + id;
        var row = Db.getOne(sql);
        if(row["id"] == null)
        {
            return null;
        }
        Buyer buyer = new Buyer();
        buyer.Id = int.Parse(id);
        buyer.Email = row["email"].ToString();
        buyer.Name = row["name"].ToString();
        buyer.Password = row["password"].ToString();
        return buyer;
    }
}

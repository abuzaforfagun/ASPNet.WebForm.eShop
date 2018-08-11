using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
/// Summary description for TenderHost
/// </summary>
public class Seller
{

    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    public void Get()
    {
        string sql = "SELECT * FROM Seller WHERE id = " + Id;
        DataRow row = Db.getOne(sql);

        if (!row.IsNull(0))
        {
            Name = row["name"].ToString();
            Email = row["email"].ToString();
            Password = row["password"].ToString();

        }
    }

    public Seller Add()
    {
        string sql = @"Insert Into Seller (Name, Email, Password) VALUES 
                        ('" + Name  + "', '" + Email + "', '" + Password + "')";
        Db.execute(sql);
        sql = "SELECT TOP 1 * FROM Seller Order By Id DESC";
        DataRow row = Db.getOne(sql);
        var id = row["Id"].ToString();
        Id = int.Parse(id);

        return this;
    }
    
}

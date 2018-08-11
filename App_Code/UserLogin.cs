using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class UserLogin
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Type { get; set; }
    public UserLogin()
    {
        //
        // TODO: Add constructor logic here
        //

    }

    public bool Login()
    {
        string sql = "SELECT * FROM  Seller WHERE  email = '" + Email + "' and Password = '" + Password +"'";
        DataRow row = Db.getOne(sql);
        if(row.Table.Rows.Count > 0)
        {
            Id = row["id"].ToString();
            Type = "host";
            return true;
        }
        else
        {
            sql = "SELECT * FROM Buyer WHERE  email = '" + Email + "' and Password = '" + Password +"'";
            row = Db.getOne(sql);
            if (row.Table.Rows.Count > 0)
            {
                Id = row["id"].ToString();

                Type = "contractor";
                return true;

            }
        }
        return false;
    }
}
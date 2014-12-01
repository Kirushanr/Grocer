using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ConnectionManager
/// </summary>
public class ConnectionManager
{
	

    public static SqlConnection Connect()
    {
        string connectString = "Data Source=MYLAPTOP\\SQLEXPRESS2;Initial Catalog=Checkout;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectString);

        connection.Open();
        return connection;
    }
}
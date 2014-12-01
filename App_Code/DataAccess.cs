using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebSite2;
using System.Windows;
/// <summary>
/// Summary description for DataAccess
/// </summary>
public class DataAccess
{
    SqlConnection connection;
	public DataAccess()
	{

         connection = ConnectionManager.Connect();
   
	}

    public Boolean login(String username,String password)
    {

        Boolean result = false;
        //MessageBox.Show(username);
        if (connection.State.ToString().Equals("Closed"))
        {
            connection.Open();
        }
        //MessageBox.Show(Connection.ToString());
        
        SqlCommand command = new SqlCommand("SP_LOGIN", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
        command.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
        SqlDataReader reader = command.ExecuteReader();
        //MessageBox.Show(username);



        if (reader.HasRows)
        {
            result = true;
            //MessageBox.Show("Success");
        }
        else
        {
            //MessageBox.Show("Failed");
            result = false;
        }
        connection.Close();
        return result;

    }
    public bool getUsername(string Username)
    {
        bool status = false;
        if (connection.State.ToString().Equals("Closed"))
        {
            connection.Open();
        }

        SqlCommand command = new SqlCommand("SP_USERNAME", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add("@username", SqlDbType.VarChar).Value = Username;
        SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            status = true;
        }
        reader.Close();
        connection.Close();
        return status;
    }
    
    public Boolean Register(string Username, string Password)
    {

        Boolean result = false;

        string password = Password;
        string username = Username;
        if (connection.State.ToString().Equals("Closed"))
        {
            connection.Open();
        }

        bool value = getUsername(username);
        if (value)
        {
            result = false;
        }
        else
        {
            if (connection.State.ToString().Equals("Closed"))
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand("SP_REGISTER", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
            int returnvalue = command.ExecuteNonQuery();
            if (returnvalue > 0)
            {
                result = true;
            }

        }
       

        connection.Close();
        return result;

    }
    public Boolean Cart(string Username, string Password)
    {

        Boolean result = false;

        string password = Password;
        string username = Username;
        if (connection.State.ToString().Equals("Closed"))
        {
            connection.Open();
        }

        bool value = getUsername(username);
        if (value)
        {
            result = false;
        }
        else
        {
            if (connection.State.ToString().Equals("Closed"))
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand("SP_REGISTER", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
            int returnvalue = command.ExecuteNonQuery();
            if (returnvalue > 0)
            {
                result = true;
            }

        }


        connection.Close();
        return result;

    }






    public int retrive(string username)
    {

        DataTable dt = new DataTable();
        dt.Columns.Add("cartid", typeof(int));
        int Question = 0;
        try
        {
            if (connection.State.ToString().Equals("Closed"))
            {
                connection.Open();
            }
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select cartid from carts where username='" + username + "'";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dt.Rows.Add(dr["cartid"]);
            }
            
            if (dr.HasRows)
            {
                Question = Convert.ToInt32(dt.Rows[0]["cartid"]);
                dr.Close();
                connection.Close();

            }
            else
            {
                dr.Close();
                connection.Close();
                Question = 0;


            }
        }
        catch
        {
            Question = 0;

        }
        return Question;

    }
}
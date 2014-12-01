using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.UI;
using WebSite2;

public partial class Account_Register : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Forum"] != null)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
    protected void CreateUser_Click(object sender, EventArgs e)
    {
       

        var manager = new UserManager();
        var user = new ApplicationUser() { UserName = UserName.Text };
        IdentityResult result = manager.Create(user, Password.Text);
        DataAccess da = new DataAccess();
        string username = UserName.Text;
        string password = Password.Text;
        bool r = da.Register(username,password);

        if (r)
        {
            Session["Forum"] = username;
            Response.Redirect("~/Default.aspx");
        }
        else
        {
            ErrorMessage.Text = result.Errors.FirstOrDefault();
        }
    }
}
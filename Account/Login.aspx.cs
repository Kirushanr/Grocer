using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.UI;
using WebSite2;

public partial class Account_Login : Page
{
        DataAccess Data;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Forum"] != null)
            {
                Response.Redirect("~/Default.aspx");
            }

            RegisterHyperLink.NavigateUrl = "Register";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }

           Data = new DataAccess();
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                var manager = new UserManager();
                ApplicationUser user = manager.Find(UserName.Text, Password.Text);
                //if (user != null)
                //{
                //    IdentityHelper.SignIn(manager, user, RememberMe.Checked);
                //    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                //}
                //else
                //{
                //    FailureText.Text = "Invalid username or password.";
                //    ErrorMessage.Visible = true;
                //}

                string UsernameText = UserName.Text;
                string PasswordText = Password.Text;

                bool result=Data.login(UsernameText, PasswordText);
                if (result)
                {
                    Session["Forum"] = UsernameText;

                    int cartid = Data.retrive(UsernameText);

                    Session["cartid"] = cartid;
                    ////IdentityHelper.SignIn(manager, user, RememberMe.Checked);
                    ////IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                    Response.Redirect("~/Default.aspx");
                    
                }
                else
                {
                    FailureText.Text = "Invalid username or password.";
                    ErrorMessage.Visible = true;;
                }

            }
        }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Forum"]==null)
        {
            Response.Redirect("~/Account/Login.aspx");
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int pagesize = GridView1.PageSize;
        int pageindex = GridView1.PageIndex;
        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "Cancel")
        {
           
            
          
                //GridViewRow row = GridView1.Rows[index];
                //string username = Session["Ketaka"].ToString();
                //String id = GridView1.Rows[index].Cells[1].Text;

                //bool value = dba.cancel(username, id);
            }
        }
    
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class ProductDisplay : System.Web.UI.Page
{
    Products p = new Products();
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = Request.QueryString["field1"];
        Label2.Text = "Rs. "+Request.QueryString["field2"];
        Image1.ImageUrl = Request.QueryString["field3"];
        //MessageBox.Show(Request.QueryString["field1"]);
    }
}

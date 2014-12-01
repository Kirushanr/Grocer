using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Forms;
using WebSite2;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LinkButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ProductDisplay.aspx?field1=" + "yoghurt" + "&field2=" + "200" + "&field3=" + "images/home/product4.jpg");
    }
    protected void LinkButton10_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ProductDisplay.aspx?field1=" + "Smoked Sausage" + "&field2=" + "150" + "&field3=" + "images/home/product5.jpg");
    }
    protected void LinkButton12Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ProductDisplay.aspx?field1=" + "White vinegar" + "&field2=" + "360" + "&field3=" + "images/home/product6.jpg");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ProductDisplay.aspx?field1=" + "Non Fat Yogurt" + "&field2=" + "200" + "&field3=" + "images/home/product4.jpg");
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ProductDisplay.aspx?field1=" + "Kerry Gold Butter" + "&field2=" + "400" + "&field3=" + "images/home/product1.jpg");
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ProductDisplay.aspx?field1=" + "Coca Cola (1.5L)" + "&field2=" + "210" + "&field3=" + "images/home/product2.jpg");
    }
    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ProductDisplay.aspx?field1=" + "Milk" + "&field2=" + "175" + "&field3=" + "images/home/product3.jpg");
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ProductDisplay.aspx?field1=" + "Kerry gold butter" + "&field2=" + "400" + "&field3=" + "images/home/product1.jpg");
    }
    protected void LinkButton11_Click(object sender, EventArgs e)
    {

        //new Products("smoked sausages", "150", "images/home/product5.jpg");
        Response.Redirect("~/ProductDisplay.aspx?field1=" + "smoked sausages" + "&field2=" + "150" + "&field3=" + "images/home/product5.jpg");
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ProductDisplay.aspx?field1=" + "Coca Cola (1.5)" + "&field2=" + "210" + "&field3=" + "images/home/product2.jpg");
    }
    protected void LinkButton9_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ProductDisplay.aspx?field1=" + "Milk" + "&field2=" + "175" + "&field3=" + "images/home/product3.jpg");
    }
}
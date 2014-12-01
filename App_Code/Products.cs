using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Products
/// </summary>
public class Products
{

    private string productname;
    private string price;
    private string url;

	public Products()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string productname_ 
        { 
            get
            {
                return this.productname;
            }
            set
            {
                this.productname = productname_;
            } 
        
        }

        public string price_
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = price_;
            }

        }


        public string url_ 
        { 
            get 
            {
                return this.url;
            } 
            set 
            {
                this.url = url_;
            } 
        
        }


        public Products(string productname, string price, string url)
        {
            this.productname = productname;
            this.price = price;
            this.url = url;
        }

}
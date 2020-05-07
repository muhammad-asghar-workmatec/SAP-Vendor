using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WPClient;
using System.Data;
using System.IO;
using SAP_Vendor.Data;
using System.Data.Entity;
using System.Collections.Specialized;
using Telerik.Web.UI;

namespace SAP_Vendor
{
    public partial class Message : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {                      
            this.lblError.Text = "";      
           
        }
     
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Session["Message"]!=null)
                this.lblError.Text = (string)Session["Message"];
        }
    }
}
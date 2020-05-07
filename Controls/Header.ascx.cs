using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAP_Vendor.Controls
{
    public partial class Header : System.Web.UI.UserControl
    {
        public string Title
        {
            get
            {
                return lblTitle.Text;
            }
            set
            {
                lblTitle.Text = value;
            }
        }
        public string TaskId
        {
            get
            {
                return (string)ViewState["TaskId"];
            }
            set
            {
                ViewState["TaskId"] = value;
                if (!string.IsNullOrEmpty(value))
                {
                    btnPrint.Visible = true;                   
                    btnPrint.NavigateUrl =ResolveUrl("~/Print.aspx?TaskID=" + value);                  
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Response.Redirect("Print.aspx?TaskID=" + TaskId, false);
            return;
        }
    }
}
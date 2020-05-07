using SAP_Vendor.Data;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using WPClient;

namespace SAP_Vendor.Controls
{
    public class RequestListItemBase : System.Web.UI.UserControl
    {
        public VendorRepository db = new VendorRepository();
        protected WPClient.OUQuery dalOU = new OUQuery(Settings.BPMConnectionString);
        //public int Id { get; set; }
        public string UserId
        {
            get
            {
                if (ViewState["UserId"] != null)
                    return (string)ViewState["UserId"];
                return null;
            }
            set
            {
                ViewState["UserId"] = value;
            }
        }
        public string Category { get; set; }
        public string ErrorMessage { get; set; }
       virtual protected void PageLoad()
        {
            try
            {
                if (!IsPostBack)
                {
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                Session["Message"] = ex.Message;
                Response.Redirect("Message.aspx", false); return;
            }
            if (Request.QueryString["User"] != null)
                this.UserId = Request.QueryString["User"].ToString();
        }
       
        protected void BindListItems(ListView listView, string category)
        {
            try
            {
                listView.DataSource = db.GetTQListItems(category: category);
                listView.DataBind();
               
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
            }
        }
        protected void LoadCategories(ListControl list)
        {
            list.DataSource = CATEGORY.List;
            list.DataBind();           
            list.Items.Insert(0, new ListItem("", ""));
        }
        protected void LoadListItems(ListControl list, string category)
        {
            list.DataSource = db.GetListItemTitles(category: category);
            list.DataBind();
            list.Items.Insert(0, new ListItem("", ""));
        }
       

        protected void LoadBPMGroup(ListControl list)
        {
            list.Items.Clear();
            dalOU.LoadGroups(list);           
        }
    }
}
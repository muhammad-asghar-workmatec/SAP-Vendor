using SAP_Vendor.Data;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Composition;

using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace SAP_Vendor
{
    public class PageListItemBase : System.Web.UI.Page
    {
        [Import] public SAP_Vendor.Data.VendorRepository db { get; set; } = new VendorRepository();
        protected WPClient.OUQuery dalOU = new WPClient.OUQuery(Settings.BPMConnectionString);
        public int Id { get; set; }
        public string UserId { get; set; }
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
       
        //protected void BindListItems(GridView gridView, string category)
        //{
        //    try
        //    {
        //        gridView.DataSource = db.GetTQListItems(category: category);
        //        gridView.DataBind();
               
        //    }
        //    catch (Exception ex)
        //    {
        //        this.ErrorMessage = ex.Message;
        //    }
        //}
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
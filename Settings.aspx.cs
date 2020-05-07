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

namespace SAP_Vendor
{
    public partial class ListItemSettings : PageListItemBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.ErrorMessage = "";
                if (ddlCategory.SelectedIndex > 0)
                    this.Category = ddlCategory.SelectedValue;
                else
                    this.Category = "";
                if (!string.IsNullOrEmpty(hidRecordID.Value))
                    this.Id = int.Parse(hidRecordID.Value);
                else
                    this.Id = 0;
                this.UserId = hidUserID.Value;
                if (!IsPostBack)
                {
                    LoadControls();
                }
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
            }
        }
        void LoadControls()
        {
            try
            {
                this.LoadCategories(ddlCategory);              
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SAP_Vendor_Items obj = new SAP_Vendor_Items();
            try
            {
                if (!Validation())
                    return;
                bool isExisted = false;
                if (this.Id > 0)
                {
                    obj = db.SAP_Vendor_Items.Find(this.Id);
                    if (obj != null)
                    {
                        isExisted = true;
                    }
                    else
                        obj = new SAP_Vendor_Items();
                }
                
                obj.Description = txtTitle.Text;
                obj.Value = txtTitle.Text;
                obj.Category = this.Category;                
                obj.Enable ="1";
                if (isExisted)
                {
                    db.SAP_Vendor_Items.Attach(obj);
                    db.Entry(obj).State = EntityState.Modified;
                }
                else
                {                    
                    db.SAP_Vendor_Items.Add(obj);
                }
                db.SaveChanges();

                this.ErrorMessage = "Record successfully saved.";                
                gvListItems.DataBind();
                btnReset_Click(btnReset, e);
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            this.Id = 0;
            hidRecordID.Value = "";
            txtTitle.Text = "";
            txtValue.Text = "";
            gvListItems.SelectedIndex = -1;
        }

        protected void DeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = sender as LinkButton;
                switch (btn.CommandName)
                {
                    case "Delete":
                        try
                        {
                            int id = Convert.ToInt32(btn.CommandArgument);
                            SAP_Vendor_Items obj = db.SAP_Vendor_Items.Find(id);
                            db.SAP_Vendor_Items.Remove(obj);
                            db.SaveChanges();
                            this.ErrorMessage = "Record successfully deleted.";
                            //BindListItems(this.gvListItems, this.Category);
                            gvListItems.DataBind();
                        }
                        catch (Exception ex)
                        {
                            this.ErrorMessage = ex.Message;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
            }
        }
        protected void SelectItem(SAP_Vendor_Items obj)
        {
            try
            {

                if (obj == null)
                    return;
                if (!string.IsNullOrEmpty(obj.Category))
                    General.SelectItemByValue(ddlCategory, obj.Category);
                
                this.Category = obj.Category;
                txtTitle.Text = obj.Description;
                txtValue.Text = obj.Value;
                this.Id = obj.Id;
                this.hidRecordID.Value = obj.Id.ToString();
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
            }
        }
        bool Validation()
        {
            bool _result = true;
            try
            {
                if (ddlCategory.SelectedIndex <= -1)
                {
                    this.ErrorMessage = "Please select category.";
                    return false;
                }
                if (txtTitle.Text.Equals(""))
                {
                    this.ErrorMessage = "Please enter title.";
                    return false;
                }
                if (txtValue.Text.Equals(""))
                {
                    this.ErrorMessage = "Please enter value.";
                    return false;
                }
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
            }
            return _result;
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.ErrorMessage))
                this.lblError.Text = this.ErrorMessage;
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedIndex > 0)
                this.Category = ddlCategory.SelectedValue;
            else
                this.Category = "";                      
        }

        protected void gvListItems_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void gvListItems_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridView gridView = sender as GridView;
                int index = -1;
                SAP_Vendor_Items obj = null;
                switch (e.CommandName)
                {
                    case "Delete":

                        try
                        {
                            index = Convert.ToInt32(e.CommandArgument);
                            gridView.SelectedIndex = index;
                            obj = db.SAP_Vendor_Items.Find((int)gridView.SelectedDataKey["Id"]);
                            
                                db.SAP_Vendor_Items.Remove(obj);
                                db.SaveChanges();
                                gridView.SelectedIndex = -1;
                                this.ErrorMessage = "Record successfully deleted.";
                                gridView.DataBind();                           
                        }
                        catch (Exception ex)
                        {
                            this.ErrorMessage = ex.Message;
                        }
                        break;
                    case "Select":
                        index = Convert.ToInt32(e.CommandArgument);
                        gridView.SelectedIndex = index;
                        obj = db.SAP_Vendor_Items.Find((int)gridView.SelectedDataKey["Id"]);
                        SelectItem(obj);
                        break;
                }
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
            }
        }

        
    }
}
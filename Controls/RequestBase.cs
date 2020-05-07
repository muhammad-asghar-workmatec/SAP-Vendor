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
    public class RequestBase : RequestListItemBase
    {
         protected BPMQuery bpmQuery = new BPMQuery(SAP_Vendor.Settings.BPMConnectionString);
        // public BPMExecution dalBPM = null;
        public string EncryptQueryString
        {
            get
            {
                if (ViewState["EncryptQueryString"] != null)
                    return (string)ViewState["EncryptQueryString"];
                return null;
            }
            set
            {
                ViewState["EncryptQueryString"] = value;
            }
        }
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
        public int IncidentNo
        {
            get
            {
                if (ViewState["IncidentNo"] != null)
                    return (int)ViewState["IncidentNo"];
                return 0;
            }
            set
            {
                ViewState["IncidentNo"] = value;
            }
        }
        public string ProcessName
        {
            get
            {
                if (ViewState["ProcessName"] != null)
                    return (string)ViewState["ProcessName"];
                return null;
            }
            set
            {
                ViewState["ProcessName"] = value;
            }
        }
        public string RequestId
        {
            get
            {
                if (ViewState["RequestId"] != null)
                    return (string)ViewState["RequestId"];
                return null;
            }
            set
            {
                ViewState["RequestId"] = value;
            }
        }
        //override protected void PageLoad()
        //{
        //    try
        //    {
        //        if (!IsPostBack)
        //        {
        //            if (Request.QueryString["TaskID"] == null)
        //            {
        //                this.EncryptQueryString = Page.Request.Url.ToString().Split(new char[] { '?' }, 2)[1];
        //                dalBPM = new WPClient.BPMExecution(page: Page, connectionString: Settings.BPMConnectionString);
        //            }
        //            else
        //            {
        //                dalBPM = new WPClient.BPMExecution(taskID: Request.QueryString["TaskID"].ToString(), connectionString: Settings.BPMConnectionString);
        //            }
        //            this.TaskID = dalBPM.TaskID;
        //        }
        //        else
        //        {
        //            if (!string.IsNullOrEmpty(this.TaskID))
        //            {
        //                dalBPM = new WPClient.BPMExecution(taskID: this.TaskID, connectionString: Settings.BPMConnectionString);

        //            }
        //            else if (!string.IsNullOrEmpty(this.EncryptQueryString))
        //            {
        //                NameValueCollection queryString = HttpUtility.ParseQueryString(EncryptDecrypt.Decrypt(this.EncryptQueryString));
        //                dalBPM = new WPClient.BPMExecution(queryString, Settings.BPMConnectionString);
        //            }
        //        }
        //        this.RequestId = dalBPM.RecordID;
        //        this.UserId = dalBPM.UserID;
        //    }
        //    catch (Exception ex)
        //    {
        //        Session["Message"] = ex.Message;
        //        Response.Redirect("Message.aspx", false); return;
        //    }

        //}
        
        protected DataTable GetGroupUsers(string group)
        {
            return dalOU.GetGroupUsers(group);
        }


        protected void Upload(FileUpload fileUpload, string description,string userId, string userName)
        {
            try
            {

                if (fileUpload.HasFile)
                {
                    var file = fileUpload.PostedFile;
                    if (description.Equals(""))
                    {
                        this.ErrorMessage = "Please enter file description.";
                        return;
                    }
                    SAP_VendorAttachment obj = new SAP_VendorAttachment();
                    //int iFileSize = file.ContentLength;
                    //if (iFileSize > 2000000)  // 2MB approx (actually less though)
                    //{
                    //    this.ErrorMessage = "File size should be less than 2 MB.";
                    //    return;
                    //}
                    string path;
                    path = Server.MapPath("../");
                    string _folderPath = path + @"\Documents\" + this.RequestId;
                    DirectoryInfo _folder = new DirectoryInfo(_folderPath);
                    if (!_folder.Exists)
                        _folder.Create();

                    fileUpload.SaveAs(_folderPath + @"\" + fileUpload.FileName);
                    obj.RequestId = this.RequestId;
                    obj.FileName = fileUpload.FileName;
                    obj.UserId = userId;
                    obj.UserName = userName;
                    obj.Description = description;
                    obj.CreatedDate = DateTime.Now;
                    obj.Path = @"Documents/" + this.RequestId + @"/" + obj.FileName;
                    db.SAP_VendorAttachment.Add(obj);
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
            }
        }
        public void Upload(UploadedFile fileUpload, string description, string userId, string userName)
        {
            try
            {

                if (fileUpload.ContentLength > 0)
                {
                    var file = fileUpload;
                    if (description.Equals(""))
                    {
                        this.ErrorMessage = "Please enter file description.";
                        return;
                    }
                    SAP_VendorAttachment obj = new SAP_VendorAttachment();
                    //int iFileSize = file.ContentLength;
                    //if (iFileSize > 2000000)  // 2MB approx (actually less though)
                    //{
                    //    this.ErrorMessage = "File size should be less than 2 MB.";
                    //    return;
                    //}
                    string path;
                    path = Server.MapPath("../");
                    string _folderPath = path + @"\Documents\" + this.RequestId;
                    DirectoryInfo _folder = new DirectoryInfo(_folderPath);
                    if (!_folder.Exists)
                        _folder.Create();

                    fileUpload.SaveAs(_folderPath + @"\" + fileUpload.FileName);
                    obj.RequestId = this.RequestId;
                    obj.FileName = fileUpload.FileName;
                    obj.UserId = userId;
                    obj.UserName = userName;
                    obj.Description = description;
                    obj.CreatedDate = DateTime.Now;
                    obj.Path = @"Documents/" + this.RequestId + @"/" + obj.FileName;
                    db.SAP_VendorAttachment.Add(obj);
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
            }
        }
        protected void BindAttachments(GridView gridView)
        {
            try
            {
                gridView.DataSource = db.SAP_VendorAttachment.Where(d => d.RequestId == this.RequestId).ToList();
                gridView.DataBind();
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
            }
        }
        protected void Attachments_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    SAP_VendorAttachment rowView = (SAP_VendorAttachment)e.Row.DataItem;
                    HyperLink lnk = (HyperLink)e.Row.FindControl("lnkAttachment");
                    lnk.Text = rowView.FileName;
                    string HttpFilePath = Request.ApplicationPath + @"/" + rowView.Path;
                    lnk.NavigateUrl = HttpFilePath;
                }
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
            }
        }
        protected void Attachments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridView gridView = sender as GridView;
                switch (e.CommandName)
                {
                    case "AEDelete":
                        try
                        {
                            int index = Convert.ToInt32(e.CommandArgument);
                            gridView.SelectedIndex = index;
                            int Id = (int)gridView.SelectedDataKey["Id"]; SAP_VendorAttachment obj = db.SAP_VendorAttachment.Where(d => d.Id == Id).FirstOrDefault();
                            if (obj != null)
                            {
                                if (this.UserId == obj.UserId)
                                {
                                    db.SAP_VendorAttachment.Remove(obj);
                                    db.SaveChanges();
                                    gridView.SelectedIndex = -1;
                                    this.ErrorMessage = "Record successfully deleted.";
                                    BindAttachments(gridView);
                                }
                                else
                                {
                                    this.ErrorMessage = "Not Allow.";
                                }
                            }
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
        protected string GetActivityUser(int FacilityId)
        {
            string activityUser = "";
            ////Get Site Users               
            //var objUser = db.TQOpActivityUsers.Find(FacilityId);
            //if (objUser != null)
            //{
            //    switch (objUser.ActivityName)
            //    {
            //        case "FM":
            //            activityUser = objUser.ActivityUser;
            //            break;
            //    }
            //}

            return activityUser;
        }
        protected void LoadFacility(ListControl list)
        {
            //var facilities = db.TQOpSites.Where(d => d.Enable == 1).OrderBy(d => d.Description).ToList();
            //list.DataSource = facilities;
            //list.DataTextField = "Description";
            //list.DataValueField = "Id";
            //list.DataBind();
            list.Items.Insert(0, new ListItem("--Select--", ""));
        }
        protected void LoadRadEditor(RadEditor editor)
        {
            editor.Skin = "Bootstrap";
            editor.ImageManager.ViewPaths = new string[] { @"~/Documents/" + this.RequestId, @"~/Documents" };
            editor.ImageManager.UploadPaths = new string[] { @"~/Documents/" + this.RequestId };
            editor.ImageManager.DeletePaths = new string[] { @"~/Documents/" + this.RequestId };
            editor.TemplateManager.ViewPaths = new string[] { @"~/Documents/" + this.RequestId, @"~/Documents/Templates" };
            editor.TemplateManager.UploadPaths = new string[] { @"~/Documents/" + this.RequestId, @"~/Documents/Templates" };
            editor.TemplateManager.DeletePaths = new string[] { @"~/Documents/" + this.RequestId, @"~/Documents/Templates" };
            editor.DocumentManager.ViewPaths = new string[] { @"~/Documents/" + this.RequestId, @"~/Documents" };
            editor.DocumentManager.UploadPaths = new string[] { @"~/Documents/" + this.RequestId };
            editor.DocumentManager.DeletePaths = new string[] { @"~/Documents/" + this.RequestId };
        }
        //protected int SubmitTask(string summary, string recordID, string action, string remarks)
        //{
        //    return dalBPM.SubmitTask(summary: summary, recordID: recordID, action: action, remarks: remarks);
        //}
    }
}
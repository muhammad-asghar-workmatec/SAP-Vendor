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

namespace SAP_Vendor
{
    public class PageBase : PageListItemBase
    {
        protected BPMExecution dalBPM = null;
        protected string EncryptQueryString {
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
        protected string TaskID
        {
            get
            {
                if (ViewState["TaskID"] != null)
                    return (string)ViewState["TaskID"];
                return null;
            }
            set
            {
                ViewState["TaskID"] = value;
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
        override protected void PageLoad()
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["TaskID"] == null)
                    {
                        this.EncryptQueryString = Page.Request.Url.ToString().Split(new char[] { '?' }, 2)[1];
                        dalBPM = new WPClient.BPMExecution(page: Page, connectionString: Settings.BPMConnectionString);
                    }
                    else
                    {
                        dalBPM = new WPClient.BPMExecution(taskID: Request.QueryString["TaskID"].ToString(), connectionString: Settings.BPMConnectionString);
                    }
                    this.TaskID = dalBPM.TaskID;
                }
                else
                {
                    if (!string.IsNullOrEmpty(this.TaskID))
                    {
                        dalBPM = new WPClient.BPMExecution(taskID: this.TaskID, connectionString: Settings.BPMConnectionString);

                    }
                    else if (!string.IsNullOrEmpty(this.EncryptQueryString))
                    {
                        NameValueCollection queryString = HttpUtility.ParseQueryString(EncryptDecrypt.Decrypt(this.EncryptQueryString));
                        dalBPM = new WPClient.BPMExecution(queryString, Settings.BPMConnectionString);
                    }
                }
            }
            catch (Exception ex)
            {
                Session["Message"] = ex.Message;
                Response.Redirect("Message.aspx", false); return;
            }
            if (dalBPM.TaskStatus != BPMExecution.TASK_STATUS_NEW)
                this.RequestId = dalBPM.RecordID;
            this.UserId = dalBPM.UserID;
        }
        
        protected DataTable GetGroupUsers(string group)
        {
            return dalOU.GetGroupUsers(group);
        }
       protected void GetGroupUsers(DropDownList ddlTo)
        {
            try
            {

                string _Group =Settings.ApproverGroup;
                var dr = this.GetGroupUsers(_Group);
                ddlTo.DataSource = dr;
                ddlTo.DataTextField = "T9F0007";
                ddlTo.DataValueField = "T9F0003";
                ddlTo.DataBind();
                ddlTo.Items.Insert(0, new ListItem("--Select--"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void BindListItems(ListControl list, string category)
        {
            try
            {
                list.Items.Clear();
                list.DataSource = db.SAP_Vendor_Items.Where(d => d.Category == category && d.Enable == "1").ToList();
                list.DataTextField = "Value";
                list.DataValueField = "Value";
                list.DataBind();
                list.Items.Insert(0, new ListItem("", ""));
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
            }
        }      
        
        //protected void Upload(FileUpload fileUpload, string description)
        //{
        //    try
        //    {

        //        if (fileUpload.HasFile)
        //        {
        //            var file = fileUpload.PostedFile;
        //            if (description.Equals(""))
        //            {
        //                this.ErrorMessage = "Please enter file description.";
        //                return;
        //            }
        //            SAP_VendorAttachment obj = new SAP_VendorAttachment();
        //            int iFileSize = file.ContentLength;
        //            if (iFileSize > 2000000)  // 2MB approx (actually less though)
        //            {
        //                this.ErrorMessage = "File size should be less than 2 MB.";
        //                return;
        //            }
        //            string path;
        //            path = Server.MapPath("../");
        //            string _folderPath = path + @"\Documents\" + this.RequestId;
        //            DirectoryInfo _folder = new DirectoryInfo(_folderPath);
        //            if (!_folder.Exists)
        //                _folder.Create();

        //            fileUpload.SaveAs(_folderPath + @"\" + fileUpload.FileName);
        //            obj.RequestId = this.RequestId;
        //            obj.FileName = fileUpload.FileName;
        //            obj.UserId = dalBPM.UserID.Trim();
        //            obj.UserName = dalBPM.UserName;
        //            obj.Description = description;
        //            obj.CreatedDate = DateTime.Now;
        //            obj.Path = @"Documents/" + this.RequestId + @"/" + obj.FileName;
        //            db.SAP_VendorAttachment.Add(obj);
        //            db.SaveChanges();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        this.ErrorMessage = ex.Message;
        //    }
        //}
        //protected void Upload(UploadedFile fileUpload, string description)
        //{
        //    try
        //    {

        //        if (fileUpload.ContentLength>0)
        //        {
        //            var file = fileUpload;
        //            if (description.Equals(""))
        //            {
        //                this.ErrorMessage = "Please enter file description.";
        //                return;
        //            }
        //            SAP_VendorAttachment obj = new SAP_VendorAttachment();
        //            //int iFileSize = file.ContentLength;
        //            //if (iFileSize > 2000000)  // 2MB approx (actually less though)
        //            //{
        //            //    this.ErrorMessage = "File size should be less than 2 MB.";
        //            //    return;
        //            //}
        //            string path;
        //            path = Server.MapPath("../");
        //            string _folderPath = path + @"\Documents\" + this.RequestId;
        //            DirectoryInfo _folder = new DirectoryInfo(_folderPath);
        //            if (!_folder.Exists)
        //                _folder.Create();

        //            fileUpload.SaveAs(_folderPath + @"\" + fileUpload.FileName);
        //            obj.RequestId = this.RequestId;
        //            obj.FileName = fileUpload.FileName;
        //            obj.UserId = dalBPM.UserID.Trim();
        //            obj.UserName = dalBPM.UserName;
        //            obj.Description = description;
        //            obj.CreatedDate = DateTime.Now;
        //            obj.Path = @"Documents/" + this.RequestId + @"/" + obj.FileName;
        //            db.SAP_VendorAttachment.Add(obj);
        //            db.SaveChanges();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        this.ErrorMessage = ex.Message;
        //    }
        //}
        //protected void BindAttachments(GridView gridView)
        //{
        //    try
        //    {
        //        gridView.DataSource = db.SAP_VendorAttachment.Where(d => d.RequestId == this.RequestId).ToList();
        //        gridView.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        this.ErrorMessage = ex.Message;
        //    }
        //}
        //protected void Attachments_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Row.RowType == DataControlRowType.DataRow)
        //        {
        //            SAP_VendorAttachment rowView = (SAP_VendorAttachment)e.Row.DataItem;
        //            HyperLink lnk = (HyperLink)e.Row.FindControl("lnkAttachment");
        //            lnk.Text = rowView.FileName;
        //            string HttpFilePath = Request.ApplicationPath + @"/" + rowView.Path;
        //            lnk.NavigateUrl = HttpFilePath;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        this.ErrorMessage = ex.Message;
        //    }
        //}
        //protected void Attachments_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {
        //        GridView gridView = sender as GridView;
        //        switch (e.CommandName)
        //        {
        //            case "AEDelete":
        //                try
        //                {
        //                    int index = Convert.ToInt32(e.CommandArgument);
        //                    gridView.SelectedIndex = index;
        //                    SAP_VendorAttachment obj = db.SAP_VendorAttachment.Find(gridView.SelectedDataKey["Id"].ToString());
        //                    db.SAP_VendorAttachment.Remove(obj);
        //                    db.SaveChanges();
        //                    gridView.SelectedIndex = -1;
        //                    this.ErrorMessage = "Record successfully deleted.";
        //                    BindAttachments(gridView);
        //                }
        //                catch (Exception ex)
        //                {
        //                    this.ErrorMessage = ex.Message;
        //                }
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        this.ErrorMessage = ex.Message;
        //    }
        //}
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
        protected int SubmitTask(string summary, string recordID, string action, string remarks)
        {
            return dalBPM.SubmitTask(summary: summary, recordID: recordID, action: action, remarks: remarks);
        }
        protected string GetNewTaskSubject(string processName, string activity,int incidentNo)
        {
           return "BPM New Task Notification, " + processName + " - " + activity + " # " + incidentNo.ToString();
        }
        protected string GetNewTaskMessage(string title,string sender,string note="")
        {
            string message = $@"eTQ Title: {title}
 <br/>
You have received above task in your inbox from "" {sender} ""
 <br/>
      <p style = 'background: white; line-height: normal; margin-bottom: 0pt;' > 
        <span style = 'font-size: 8.5pt; font-family: Arial,sans-serif;' >
  Please <a href = '{AppSettings.BPM_URL + "/Default/Main.aspx"}' > Click here
                                                  </a> to view the BPM task.
        </span>
    </p> ";
            if (!string.IsNullOrWhiteSpace(note))
            {
                message = $@"eTQ Title: {title}
 <br/>
You have received above task in your inbox from "" {sender} ""
 <br/><br/>
Note: {note}
 <br/>
      <p style = 'background: white; line-height: normal; margin-bottom: 0pt;' > 
        <span style = 'font-size: 8.5pt; font-family: Arial,sans-serif;' >
  Please <a href = '{AppSettings.BPM_URL + "/Default/Main.aspx"}' > Click here
                                                  </a> to view the BPM task.
        </span>
    </p> ";
            }
            return message;
        }
        protected string GetCancelTaskSubject(string processName, string activity, int incidentNo)
        {
            return "Cancel Notification, " + processName + " - " + activity + " # " + incidentNo.ToString();
        }
        protected string GetCancelTaskMessage(string title, string sender, string note)
        {
            string message = $@"eTQ Title: {title}
  <p style='background: white; line-height: normal; margin-bottom: 0pt;'>
        <span style='font-size: 8.5pt; font-family: Arial,sans-serif;'>
Above task has been rejected by "" {sender} ""
</span>
</p>
<p>
<span style='font-size: 8.5pt; font-family: Arial,sans-serif;'>
 Dear eTQ Initiator,</span></p>
           
<p style='background: white; line-height: normal; margin-bottom: 0pt;'>
<span style='font-size: 8.5pt; font-family: Arial,sans-serif;'>
Subject eTQ is rejected by "" {sender} ""
</p>
 <br/>
<p style = 'background: white; line-height: normal; margin-bottom: 0pt;' > 
<span style = 'font-size: 8.5pt; font-family: Arial,sans-serif;' >
  Please <a href = '{AppSettings.BPM_URL + "/Default/Main.aspx"}' > Click here
                                                  </a> to view the BPM task.
        </span>
    </p> ";
            if (!string.IsNullOrWhiteSpace(note))
            {
                message = $@"eTQ Title: {title}
 <p style='background: white; line-height: normal; margin-bottom: 0pt;'>
        <span style='font-size: 8.5pt; font-family: Arial,sans-serif;'>
Above task has been rejected by "" {sender} ""
</span>
</p>
<p>
<span style='font-size: 8.5pt; font-family: Arial,sans-serif;'>
Dear eTQ Initiator,</span></p>
<p style='background: white; line-height: normal; margin-bottom: 0pt;'>
<span style='font-size: 8.5pt; font-family: Arial,sans-serif;'>
Subject eTQ is rejected by "" {sender} ""
</p>
 <br/><br/>
Note: {note}
 <br/>
<p style = 'background: white; line-height: normal; margin-bottom: 0pt;' > 
<span style = 'font-size: 8.5pt; font-family: Arial,sans-serif;' >
  Please <a href = '{AppSettings.BPM_URL + "/Default/Main.aspx"}' > Click here
                                                  </a> to view the BPM task.
        </span>
    </p> ";
            }
            return message;
        }
        protected string GetReturnTaskSubject(string processName, string activity, int incidentNo)
        {
            return "Return/ Cancel Notification, " + processName + " - " + activity + " # " + incidentNo.ToString();
        }
        protected string GetReturnTaskMessage(string title, string sender, string note)
        {
            string message = $@"eTQ Title: {title}
  <p style='background: white; line-height: normal; margin-bottom: 0pt;'>
        <span style='font-size: 8.5pt; font-family: Arial,sans-serif;'>
You have received above rejected/return task in your inbox from "" {sender} ""
</span>
</p>
<p>
                                    <span style='font-size: 8.5pt; font-family: Arial,sans-serif;'>
                                        Dear eTQ Initiator,</span></p>
           
                  <p style='background: white; line-height: normal; margin-bottom: 0pt;'>
        <span style='font-size: 8.5pt; font-family: Arial,sans-serif;'>
Subject eTQ is return by "" {sender} ""
</p>
 <br/>

      <p style = 'background: white; line-height: normal; margin-bottom: 0pt;' > 
        <span style = 'font-size: 8.5pt; font-family: Arial,sans-serif;' >
  Please <a href = '{AppSettings.BPM_URL + "/Default/Main.aspx"}' > Click here
                                                  </a> to view the BPM task.
        </span>
    </p> ";
            if (!string.IsNullOrWhiteSpace(note))
            {
                message = $@"eTQ Title: {title}
 <p style='background: white; line-height: normal; margin-bottom: 0pt;'>
        <span style='font-size: 8.5pt; font-family: Arial,sans-serif;'>
You have received above rejected/return task in your inbox from "" {sender} ""
</span>
</p>
<p>
                                    <span style='font-size: 8.5pt; font-family: Arial,sans-serif;'>
                                        Dear eTQ Initiator,</span></p>
           
                  <p style='background: white; line-height: normal; margin-bottom: 0pt;'>
        <span style='font-size: 8.5pt; font-family: Arial,sans-serif;'>
Subject eTQ is return by "" {sender} ""
</p>
 <br/><br/>
Note: {note}
 <br/>
      <p style = 'background: white; line-height: normal; margin-bottom: 0pt;' > 
        <span style = 'font-size: 8.5pt; font-family: Arial,sans-serif;' >
  Please <a href = '{AppSettings.BPM_URL + "/Default/Main.aspx"}' > Click here
                                                  </a> to view the BPM task.
        </span>
    </p> ";
            }
            return message;
        }
        protected string GetParkedTaskSubject(string processName, string activity, int incidentNo)
        {
            return "Notification, " + processName + " # " + incidentNo.ToString();
        }
        protected string GetParkedTaskMessage(string title, string sender, string note)
        {
            string message = $@"eTQ Title: {title}
  <p style='background: white; line-height: normal; margin-bottom: 0pt;'>
        <span style='font-size: 8.5pt; font-family: Arial,sans-serif;'>
Above task has been parked in Hopper by "" {sender} ""
</span>
</p>
 <br/>

      <p style = 'background: white; line-height: normal; margin-bottom: 0pt;' > 
        <span style = 'font-size: 8.5pt; font-family: Arial,sans-serif;' >
  Please <a href = '{AppSettings.BPM_URL + "/Default/Main.aspx"}' > Click here
                                                  </a> to view the BPM task.
        </span>
    </p> ";
            if (!string.IsNullOrWhiteSpace(note))
            {
                message = $@"eTQ Title: {title}
<p style='background: white; line-height: normal; margin-bottom: 0pt;'>
        <span style='font-size: 8.5pt; font-family: Arial,sans-serif;'>
Above task has been parked in Hopper by "" {sender} ""
</span>
</p>
 <br/><br/>
Note: {note}
 <br/>
      <p style = 'background: white; line-height: normal; margin-bottom: 0pt;' > 
        <span style = 'font-size: 8.5pt; font-family: Arial,sans-serif;' >
  Please <a href = '{AppSettings.BPM_URL + "/Default/Main.aspx"}' > Click here
                                                  </a> to view the BPM task.
        </span>
    </p> ";
            }
            return message;
        }
        protected string GetAcceptanceTaskSubject(string processName, string activity, int incidentNo)
        {
            return "Acceptance Notification, " + processName + " - " + activity + " # " + incidentNo.ToString();
        }
        protected string GetAcceptanceTaskMessage(string title, string sender, string note)
        {
          string  message = $@"eTQ Title: {title}
 <br/>
Above task has been accepted by "" {sender} ""
 <br/>
      <p style = 'background: white; line-height: normal; margin-bottom: 0pt;' > 
        <span style = 'font-size: 8.5pt; font-family: Arial,sans-serif;' >
  Please <a href = '{AppSettings.BPM_URL + "/Default/Main.aspx"}' > Click here
                                                  </a> to view the BPM task.
        </span>
    </p> ";
            if (!string.IsNullOrWhiteSpace(note))
            {
                message = $@"eTQ Title: {title}
 <br/>
Above task has been accepted by "" {sender} ""
 <br/><br/>
Note: {note}
 <br/>
      <p style = 'background: white; line-height: normal; margin-bottom: 0pt;' > 
        <span style = 'font-size: 8.5pt; font-family: Arial,sans-serif;' >
  Please <a href = '{AppSettings.BPM_URL + "/Default/Main.aspx"}' > Click here
                                                  </a> to view the BPM task.
        </span>
    </p> ";
            }
            return message;
        }
        protected string GetApprovedTaskSubject(string processName, string activity, int incidentNo)
        {
            return "Approval Notification, " + processName + " - " + activity + " # " + incidentNo.ToString();
        }
        protected string GetApprovedTaskMessage(string title, string sender, string note)
        {
            string message = $@"eTQ Title: {title}
 <br/>
Above task has been approved by "" {sender} ""
 <br/>
      <p style = 'background: white; line-height: normal; margin-bottom: 0pt;' > 
        <span style = 'font-size: 8.5pt; font-family: Arial,sans-serif;' >
  Please <a href = '{AppSettings.BPM_URL + "/Default/Main.aspx"}' > Click here
                                                  </a> to view the BPM task.
        </span>
    </p> ";
            if (!string.IsNullOrWhiteSpace(note))
            {
                message = $@"eTQ Title: {title}
 <br/>
Above task has been approved by "" {sender} ""
 <br/><br/>
Note: {note}
 <br/>
      <p style = 'background: white; line-height: normal; margin-bottom: 0pt;' > 
        <span style = 'font-size: 8.5pt; font-family: Arial,sans-serif;' >
  Please <a href = '{AppSettings.BPM_URL + "/Default/Main.aspx"}' > Click here
                                                  </a> to view the BPM task.
        </span>
    </p> ";
            }
            return message;
        }
        protected List<string> GetUserIdsByRequestId(string requestId)
        {          
            return db.SAP_VendorCreationLog.Where(d => d.RequestId == requestId).Select(d => d.UserId.Trim()).Distinct().ToList();           
        }
        protected List<string> GetEmailsByRequestId(string requestId)
        {
            var userIds= db.SAP_VendorCreationLog.Where(d => d.RequestId == requestId).Select(d => d.UserId).Distinct().ToList();
            return GetEmailsByIds(userIds);
        }
        protected List<string> GetEmailsByGroup(string groupName)
        {
            List<string> Emails = new List<string>();
            string query = @"SELECT distinct T00012.T12F0009
FROM         T00004 INNER JOIN
                      T00005 ON T00004.T4F0002 = T00005.T5F0001 INNER JOIN                     
                      T00012 ON T00004.T4F0003 = T00012.T12F0001 
WHERE     (T00005.T5F0002 = @T5F0002)";
            dalBPM.QOU.ClearParameters();
            dalBPM.QOU.AddParameter("@T5F0002", groupName);//T12F0009:email
            var dtUsers = dalBPM.QOU.GetDataTable(query);
            foreach (DataRow user in dtUsers.Rows)
            {
                if (user["T12F0009"] != null)
                {
                    if (!Emails.Contains(((string)user["T12F0009"]).Trim()))
                        Emails.Add(((string)user["T12F0009"]).Trim());
                }
            }
            return Emails;
        }
        protected List<string> GetEmailsByIds(List<string> userIds)
        {
            List<string> Emails = new List<string>();
            if (userIds != null && userIds.Count > 0)
            {
                userIds = userIds.Distinct().ToList();
                string ids = string.Join(",", userIds.Select(d => $"'{d}'").ToList());
                string query = $"SELECT distinct  T00012.T12F0009 FROM  T00012 where RTrim(LTrim(T00012.T12F0001)) in({ids}) ";
                dalBPM.QOU.ClearParameters();
                var dtUsers = dalBPM.QOU.GetDataTable(query);
                foreach (DataRow user in dtUsers.Rows)
                {
                    if (user["T12F0009"] != null)
                    {
                        if (!Emails.Contains(((string)user["T12F0009"]).Trim()))
                            Emails.Add(((string)user["T12F0009"]).Trim());
                    }
                }
            }
            return Emails;
        }
        protected List<string> GetUserIdsByGroup(string groupName)
        {
            List<string> userIds = new List<string>();
            string query = @"SELECT T00004.T4F0003
FROM         T00004 INNER JOIN
                      T00005 ON T00004.T4F0002 = T00005.T5F0001 
WHERE     (T00005.T5F0002 = @T5F0002)";
            dalBPM.QOU.ClearParameters();
            dalBPM.QOU.AddParameter("@T5F0002", groupName);//T4F0003:userId
            var dtUsers = dalBPM.QOU.GetDataTable(query);
            foreach (DataRow user in dtUsers.Rows)
            {
                if (user["T4F0003"] != null)
                {
                    if (!userIds.Contains(((string)user["T4F0003"]).Trim()))
                        userIds.Add(((string)user["T4F0003"]).Trim());
                }
            }
            return userIds;
        }
        protected List<string> GetUserIdsByGroups(List<string> groupNames)
        {
            List<string> userIds = new List<string>();
            if (groupNames != null && groupNames.Count > 0)
            {
                groupNames = groupNames.Distinct().ToList();
                string ids = string.Join(",", groupNames.Select(d => $"'{d}'").ToList());
                string query = $@"SELECT distinct T00004.T4F0003
FROM         T00004 INNER JOIN
                      T00005 ON T00004.T4F0002 = T00005.T5F0001 
WHERE     T00005.T5F0002 in({ids}) ";
                dalBPM.QOU.ClearParameters();
                var dtUsers = dalBPM.QOU.GetDataTable(query);
                foreach (DataRow user in dtUsers.Rows)
                {
                    if (user["T4F0003"] != null)
                    {
                        if (!userIds.Contains((string)user["T4F0003"]))
                            userIds.Add((string)user["T4F0003"]);
                    }
                }
            }
            return userIds;
        }
        protected List<string> GetEmailsByGroups(List<string> groupNames)
        {
            List<string> Emails = new List<string>();
            List<string> userIds = new List<string>();
            if (groupNames != null && groupNames.Count > 0)
            {
                groupNames = groupNames.Distinct().ToList();
                string ids = string.Join(",", groupNames.Select(d => $"'{d}'").ToList());
                string query = $@"SELECT distinct T00012.T12F0009
FROM         T00004 INNER JOIN
                      T00005 ON T00004.T4F0002 = T00005.T5F0001 INNER JOIN                     
                      T00012 ON T00004.T4F0003 = T00012.T12F0001  
WHERE     T00005.T5F0002 in({ids}) ";
                dalBPM.QOU.ClearParameters();
                var dtUsers = dalBPM.QOU.GetDataTable(query);
                foreach (DataRow user in dtUsers.Rows)
                {
                    if (user["T12F0009"] != null)
                    {
                        if (!Emails.Contains((string)user["T12F0009"]))
                            Emails.Add((string)user["T12F0009"]);
                    }
                }
            }
            return Emails;
        }
        protected void Upload(FileUpload fileUpload, string description, string userId, string userName)
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
                    path = Server.MapPath("./");
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
    }
}
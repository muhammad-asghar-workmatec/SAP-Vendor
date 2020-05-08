using SAP_Vendor.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using WPClient;
using WPCommon;

namespace SAP_Vendor
{
    public partial class Finance : PageBase
    {
       
        string query = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               
                lblError.Text = "";
                PageLoad();
                if (!IsPostBack && dalBPM != null)
                {
                    if (dalBPM.TaskStatus.Equals(BPMExecution.TASK_STATUS_IN_QUEUE) || dalBPM.TaskStatus.Equals(BPMExecution.TASK_STATUS_RETURN) || dalBPM.TaskStatus.Equals(BPMExecution.TASK_STATUS_COMPLETE))
                    {
                        Response.Redirect("~/CompletedView.aspx?" + EncryptQueryString, false);
                        return;
                    }
                    else
                    {
                        if (dalBPM.TaskStatus.Equals(BPMExecution.TASK_STATUS_COMPLETE))
                            btSubmit.Enabled = false;
                        hidUserID.Value = dalBPM.UserID;
                        hidRecordID.Value = dalBPM.RecordID;
                        this.Header1.TaskId = dalBPM.TaskID;
                        UserRemarks1.LoadRemarks(dalBPM);
                        InitControls();
                    }
                }
            }
            catch (Exception ex)
            {
                
                lblError.Text = ex.Message;
            }
        }
        void InitControls()
        {
            try
            {
                //db.BindListItems(ddlCountry, CATEGORY.COUNTRY);
                //db.BindListItems(ddlPaymentTerms, CATEGORY.PAYMENT);
                //db.BindListItems(ddlCurrency, CATEGORY.CURRENCY);
                //db.BindListItems(ddlWitholdingTaxField, CATEGORY.WITHOLDING_TAX_FIELD);
                //db.Load(ddlCountry, "Description", "Value", @"Select Description,Value from SAP_Vendor_Items Where category = 'country' and enable = '1' Order by Description");
                //db.Load(ddlBankCountry1, "Description", "Value", @"Select Description,Value from SAP_Vendor_Items Where category = 'country' and enable = '1' Order by Description");
                //db.Load(ddlBankCountry2, "Description", "Value", @"Select Description,Value from SAP_Vendor_Items Where category = 'country' and enable = '1' Order by Description");
                // db.Load(ddlPaymentTerms, "Description", "Value", @"Select Description,Value from SAP_Vendor_Items Where category = 'Payment' and enable = '1' Order by Description");
                // db.Load(ddlCurrency, "Description", "Value", @"Select Description,Value from SAP_Vendor_Items Where category = 'Currency' and enable = '1' Order by Description");
                //db.Load(ddlRecepientType, "Description", "Value", @"Select Description,Value from SAP_Vendor_Items Where category = 'Recipient' and enable = '1' Order by Description");
                //ddlBankCountry1.Items.Insert(0, new ListItem("--Select--"));
                //ddlBankCountry2.Items.Insert(0, new ListItem("--Select--"));
                LoadForm();               
                BindAttachments(dgAttachment);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                

            }

        }
        void BindAttachmentGrid()
        {
            try
            {
                dsAttachment.SelectCommand = $@"Select * From SAP_VendorAttachment Where RequestID ='{hidRecordID.Value}'";
                dgAttachment.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                
            }
        }
        protected void dgAttachment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "AEDelete":
                        try
                        {
                            int index = Convert.ToInt32(e.CommandArgument);
                            SAP_VendorAttachment obj = new SAP_VendorAttachment();

                            dgAttachment.SelectedIndex = index;
                            obj.Id = int.Parse(dgAttachment.SelectedValue.ToString());
                            db.SAP_VendorAttachment.Remove(obj);
                            db.SaveChanges();
                            dgAttachment.SelectedIndex = -1;
                            lblError.Text = "Record successfully deleted.";
                            BindAttachments(dgAttachment);
                        }
                        catch (Exception ex)
                        {
                            lblError.Text = ex.Message;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        protected void btSubmit_Click(object sender, EventArgs e)
        {
            try
            {
              
                SAP_VendorCreation obj = db.SAP_VendorCreation.Find(hidRecordID.Value);
                string AppStatus = "", _Action = "";
                    AppStatus = "1";
                    _Action = "Closed";
                  
                dalBPM.SetVarValue("AppStatus", AppStatus);
               int IncidentNo =  dalBPM.SubmitTask(_Action, txtRemarks.Content);
                if (IncidentNo > 0)
                {                   
                    obj.UpdatedDate = DateTime.Now;
                    obj.Status = 3;
                    obj.IncidentNo = dalBPM.IncidentNo;
                    obj.Activity = dalBPM.ActivityName;
                    obj.TaskId = dalBPM.TaskID;
                    obj.UserId = dalBPM.UserID.Trim();
                    obj.UserName = dalBPM.UserName;
                    obj.Remarks = txtRemarks.Content;

                    if (db.Entry(obj).State == EntityState.Detached)
                    {
                        db.SAP_VendorCreation.Attach(obj);
                    }
                    db.Entry(obj).State = EntityState.Modified;
                    var log = db.GetVendorCreationLog(main: obj, activity: dalBPM.ActivityName, taskId: dalBPM.TaskID);
                    if (log.Id == 0)
                        db.SAP_VendorCreationLog.Add(log);
                    else
                    {
                        if (db.Entry(log).State == EntityState.Detached)
                        {
                            db.SAP_VendorCreationLog.Attach(log);
                        }
                        db.Entry(log).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                     Response.Redirect("~/View.aspx?TaskID=" + dalBPM.TaskID, false);
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        void AddFlow(string RequestID, string ActivityName)
        {

            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        void LoadForm()
        {
            try
            {
                SAP_VendorCreation obj = db.SAP_VendorCreation.Find(dalBPM.RecordID);
                hidRecordID.Value = obj.RequestId;
                txtIBAN.Text = obj.AccountNoIBAN;
                txtAddress.Text = obj.Address;
                txtBankAddress.Text = obj.BankAddress;
                txtCountry.Text = obj.Country;
                txtPostalCode.Text = obj.PostalCode;
                txtCity.Text = obj.City;
                txtBenificaryName.Text = obj.BenificaryName;
                txtBusinessName.Text = obj.BusinessName;
                Common.SelectItemByValue(rblClassification, string.IsNullOrEmpty(obj.Classification) ? string.Empty : obj.Classification);
                Common.SelectItemByValue(rblType, string.IsNullOrEmpty(obj.CompanyType) ? string.Empty : obj.CompanyType);
                txtContactPerson.Text = obj.ContactPerson;
                txtEmail.Text = obj.Email;
                txtFaxNo.Text = obj.FaxNo;
                Common.SelectItemByValue(rblNaturOfWork, string.IsNullOrEmpty(obj.NatureOfWork) ? string.Empty : obj.NatureOfWork);
                txtNTN.Text = obj.NTNNo;
                txtCurrency.Text = obj.PaymentCurrency;
                Common.SelectItemByValue(rblPaymentMethod, string.IsNullOrEmpty(obj.PaymentMethod) ? string.Empty : obj.PaymentMethod);
                txtPaymentTerms.Text = obj.PaymentTerms;
                txtPeriod.Text = obj.PeriodUpto;
                txtContactNo.Text = obj.PhoneNo;
                Common.SelectItemByValue(rblQualification, string.IsNullOrEmpty(obj.Qualification) ? string.Empty : obj.Qualification);
                if (obj.QuestionnaireCompleted.GetValueOrDefault())
                    rblAttached.SelectedValue = "Yes";
                else
                    rblAttached.SelectedValue = "No";
                txtNA.Checked = obj.RegNA.GetValueOrDefault();
                Common.SelectItemByValue(rblOptions, string.IsNullOrEmpty(obj.RequestType) ? string.Empty : obj.RequestType);
                txtReason.Text = obj.Reason;
                txtRoutingNo.Text = obj.RoutingNo;
                txtState.Text = obj.State;

                txtSwiftCode.Text = obj.SwiftCode;
                txtSaleTaxReg.Text = obj.TaxRegNo;
                hidUserID.Value = obj.UserId;
                txtWHoldingTax.Text = obj.WithholdingTax;

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;

            }
        }
        protected void btEmail_Click(object sender, EventArgs e)
        {
            try
            {
                string _message = "<p>New vendor form has been initiated please click on following link to view the details </p> http://UEISBAP001/vendorcreation/print.aspx?requestid=" + hidRecordID.Value;
                // SendEmail(_message);
                SAP_VendorCreation obj = db.SAP_VendorCreation.Find(hidRecordID.Value);
                obj.EmailSent = true;
                obj.EmailSentDate = DateTime.Now;
                db.SaveChanges();             
                LoadForm();
                lblError.Text = "Email has been successfully sent.";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        public void SendEmail(string Message)
        {
            string To = System.Configuration.ConfigurationManager.AppSettings["ToEmail"];          
            string FromEmail = dalBPM.UserEmail;
            if (FromEmail.Equals(""))
            {
                lblError.Text = "Email address not found, please contact system administrator.";
                return;
            }
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage(FromEmail, To);
            try
            {
                msg.Subject = "PK00 - " + txtBusinessName.Text;
                msg.IsBodyHtml = true;
                msg.Priority = MailPriority.High;
                Message += "<p><b>Regards </b></p>";
                Message += "<p><b>Business Process Manager</b><br>";
                msg.Body = Message;
                SmtpClient sm = new SmtpClient();
                sm.Send(msg);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
   
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.ErrorMessage))
                this.lblError.Text = this.ErrorMessage;
            lblErrorBottom.Text = this.lblError.Text;
        }
       
    }
}
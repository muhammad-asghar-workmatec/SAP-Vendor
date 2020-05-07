using Microsoft.AspNet.FriendlyUrls.Resolvers;
using SAP_Vendor.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WPClient;
using WPCommon;

namespace SAP_Vendor
{
    public partial class DM : PageBase
    {

        string query = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               
                lblError.Text = "";
                PageLoad();
                if (!IsPostBack)
                {
                    if (dalBPM.TaskStatus.Equals(BPMExecution.TASK_STATUS_COMPLETE))
                        btSubmit.Enabled = false;
                    hidUserID.Value = dalBPM.UserID;
                    hidRecordID.Value = dalBPM.RecordID;
                    UserRemarks1.LoadRemarks(dalBPM);
                    InitControls();
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
                LoadForm();
                BindFlowGrid();
                BindAttachments(dgAttachment);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
               

            }

        }
        void BindFlowGrid()
        {
            try
            {
                //dsFlow.SelectCommand = "Select * From VendorFlow Where RequestID = " + hidRecordID.Value + " order by approved_date desc";
                //dgFlow.DataBind();

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

            string EmailSubject = "", EmailMessage = "", ActivityName = "", AppStatus = "", _Action = "";
            string _script = "";
            try
            {
                if (optReturn.Checked || optReject.Checked)
                {
                    if (txtRemarks.Text.Equals(""))
                    {
                        lblError.Text = "Please enter remarks.";
                        return;
                    }
                }
                if (optApprove.Checked)
                {
                    AppStatus = "1";
                    _Action = "Approve";
                }
                else if (optReject.Checked)
                {

                    AppStatus = "2";
                    _Action = "Disapprove";
                    dalBPM.SetVarValue("Message", "Your vendor " + txtBusinessName.Text + " request has been disapproved due to  " + txtRemarks.Text);
                    dalBPM.SetVarValue("Subject", "Vendor Disapproved");
                }
                else
                {
                    AppStatus = "3";
                    _Action = "Return";
                }
                dalBPM.SetVarValue("AppStatus", AppStatus);
                int IncidentNo = dalBPM.SubmitTask(_Action, txtRemarks.Content);
                if (IncidentNo > 0)
                {
                    var obj = db.GetVendorCreation(this.RequestId);
                    obj.UpdatedDate = DateTime.Now;
                    obj.Status = 1;
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
                    Response.Redirect("SuccessfullySubmited.aspx");
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
                txtIBAN.Text =obj.AccountNoIBAN ;
                txtAddress.Text = obj.Address ;
                txtBankAddress.Text= obj.BankAddress;
                txtCountry.Text = obj.Country;
                 txtPostalCode.Text= obj.PostalCode;
                txtCity.Text = obj.City;
                 txtBenificaryName.Text= obj.BenificaryName;
                txtBusinessName.Text = obj.BusinessName;
               Common.SelectItemByValue(rblClassification,string.IsNullOrEmpty( obj.Classification)?string.Empty : obj.Classification);
                 Common.SelectItemByValue(rblType, string.IsNullOrEmpty(obj.CompanyType) ? string.Empty : obj.CompanyType);
                 txtContactPerson.Text= obj.ContactPerson;
                 txtEmail.Text= obj.Email;
                 txtFaxNo.Text= obj.FaxNo;
                Common.SelectItemByValue(rblNaturOfWork, string.IsNullOrEmpty(obj.NatureOfWork) ? string.Empty : obj.NatureOfWork);
                txtNTN.Text= obj.NTNNo;
               txtCurrency.Text= obj.PaymentCurrency;
               Common.SelectItemByValue(rblPaymentMethod, string.IsNullOrEmpty(obj.PaymentMethod) ? string.Empty : obj.PaymentMethod);
                 txtPaymentTerms.Text= obj.PaymentTerms;
                 txtPeriod.Text= obj.PeriodUpto;
                txtContactNo.Text= obj.PhoneNo;
                Common.SelectItemByValue(rblQualification, string.IsNullOrEmpty(obj.Qualification) ? string.Empty : obj.Qualification);
                if(obj.QuestionnaireCompleted.GetValueOrDefault())
                    rblAttached.SelectedValue = "Yes";
                else
                    rblAttached.SelectedValue = "No";
                txtNA.Checked = obj.RegNA.GetValueOrDefault();
                Common.SelectItemByValue( rblOptions, string.IsNullOrEmpty(obj.RequestType) ? string.Empty : obj.RequestType);
                txtReason.Text= obj.Reason;
                txtRoutingNo.Text= obj.RoutingNo;
                txtState.Text= obj.State;
                
                 txtSwiftCode.Text= obj.SwiftCode;
                txtSaleTaxReg.Text= obj.TaxRegNo;
                hidUserID.Value = obj.UserId;
                txtWHoldingTax.Text = obj.WithholdingTax;
                
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                
            }
        }
    }
}
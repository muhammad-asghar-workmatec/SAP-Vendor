using SAP_Vendor.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WPClient;
using WPCommon;

namespace SAP_Vendor
{
    public partial class Finance : System.Web.UI.Page
    {
        BulletSQL db = new BulletSQL(WebConfig.ConnectionString);
        VendorEntities dbVendor = new SAP_Vendor.Data.VendorEntities();
        string query = "";
        BPMExecution dalBPM = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                dalBPM = new BPMExecution(Page, WebConfig.BPMConnectionString);
                lblError.Text = "";
                _Script.InnerHtml = "";
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
                db.Disconnect();
                lblError.Text = ex.Message;
            }
        }
        void InitControls()
        {
            try
            {
                db.Load(ddlCountry, "Description", "Value", @"Select Description,Value from SAP_Vendor_Items Where category = 'country' and enable = '1' Order by Description");
                //db.Load(ddlBankCountry1, "Description", "Value", @"Select Description,Value from SAP_Vendor_Items Where category = 'country' and enable = '1' Order by Description");
                //db.Load(ddlBankCountry2, "Description", "Value", @"Select Description,Value from SAP_Vendor_Items Where category = 'country' and enable = '1' Order by Description");
                //db.Load(ddlPaymentTerms, "Description", "Value", @"Select Description,Value from SAP_Vendor_Items Where category = 'Payment' and enable = '1' Order by Description");
                //db.Load(ddlCurrency, "Description", "Value", @"Select Description,Value from SAP_Vendor_Items Where category = 'Currency' and enable = '1' Order by Description");
                //db.Load(ddlRecepientType, "Description", "Value", @"Select Description,Value from SAP_Vendor_Items Where category = 'Recipient' and enable = '1' Order by Description");
                //ddlBankCountry1.Items.Insert(0, new ListItem("--Select--"));
                //ddlBankCountry2.Items.Insert(0, new ListItem("--Select--"));
                LoadForm();
                BindFlowGrid();
                BindAttachmentGrid();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                db.Disconnect();

            }

        }
        void BindFlowGrid()
        {
            try
            {
                //dsFlow.SelectCommand = "Select * From VendorFlow Where Request_ID = " + hidRecordID.Value + " order by approved_date desc";
                //dgFlow.DataBind();

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                db.Disconnect();
            }
        }
        void BindAttachmentGrid()
        {
            try
            {
                dsAttachment.SelectCommand = @"Select * From Vendor_Attachment Where Request_ID = " + hidRecordID.Value;
                dgAttachment.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                db.Disconnect();
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
                            Vendor_Attachment obj = new Vendor_Attachment();

                            dgAttachment.SelectedIndex = index;
                            obj.ID = decimal.Parse(dgAttachment.SelectedValue.ToString());
                            dbVendor.Vendor_Attachment.Remove(obj);
                            dbVendor.SaveChanges();
                            dgAttachment.SelectedIndex = -1;
                            lblError.Text = "Record successfully deleted.";
                            BindAttachmentGrid();
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
                if (!Validation())
                    return;
                SAP_VendorCreation obj = dbVendor.SAP_VendorCreation.Find(decimal.Parse(hidRecordID.Value));
                if (optApprove.Checked)
                {
                    if (!obj.EmailSent.Equals("1"))
                    {
                        lblError.Text = "Please click on email button to register vendor in SAP.";
                        return;
                    }
                    if (txtVendorID.Text.Equals(""))
                    {
                        lblError.Text = "Please enter SAP vendor ID.";
                        return;
                    }
                }

                if (optReturn.Checked || optReject.Checked)
                {
                    if (txtRemarks.Text.Equals(""))
                    {
                        lblError.Text = "Please enter remarks.";
                        return;
                    }
                }
                string AppStatus = "", _Action = "";
                obj.AccountNoIBAN = txtIBAN.Text;
                obj.Address = txtAddress.Text;
                obj.BankAddress = txtBankAddress.Text;
                obj.Country = ddlCountry.SelectedItem.Value;
                obj.PostalCode = txtPostalCode.Text;
                obj.City = txtCity.Text;
                obj.BenificaryName = txtBenificaryName.Text;
                obj.BusinessName = txtBusinessName.Text;
                obj.Classification = rblClassification.SelectedValue;
                obj.CompanyType = rblType.SelectedValue;
                obj.ContactPerson = txtContactPerson.Text;
                obj.Email = txtEmail.Text;
                obj.FaxNo = txtFaxNo.Text;
                obj.NatureOfWork = rblNaturOfWork.SelectedValue;
                obj.NTNNo = txtNTN.Text;
                obj.PaymentCurrency = rblCurrency.SelectedValue;
                obj.PaymentMethod = rblPaymentMethod.SelectedValue;
                obj.PaymentTerms = txtPaymentTerms.Text;
                obj.PeriodUpto = txtPeriod.Text;
                obj.PhoneNo = txtContactNo.Text;
                obj.Qualification = rblQualification.SelectedValue;
                obj.QuestionnaireCompleted = rblAttached.SelectedValue == "Yes";
                obj.RegNA = txtNA.Checked;
                obj.RequestType = rblOptions.SelectedValue;
                obj.Resion = txtResion.Text;
                obj.RoutingNo = txtRoutingNo.Text;
                obj.State = txtState.Text;
                obj.Status = "1";
                obj.SwiftCode = txtSwiftCode.Text;
                obj.TaxRegNo = txtSaleTaxReg.Text;
                obj.AccountNoIBAN = txtIBAN.Text;
                obj.WHoldingTax = ddlWitholdingTaxField.SelectedValue;
                obj.SAPVendorID = txtVendorID.Text;
                obj.UpdatedDate = DateTime.Now;
                obj.IssuedBy = dalBPM.UserID;
                obj.IssuedOn = DateTime.Now;
                dbVendor.SaveChanges();

                if (optApprove.Checked)
                {
                    AppStatus = "1";
                    _Action = "Approve";
                    dalBPM.SetVarValue("Message", "Your vendor " + txtBusinessName.Text + " request has been has been approved and vendor id is " + txtVendorID.Text);
                    dalBPM.SetVarValue("Subject", "Vendor Approved");
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
                dalBPM.SubmitTask(_Action, txtRemarks.Text);
                Response.Redirect("SuccessfullySubmited.aspx");

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
        protected void dgAttachment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                WebConfig obj = new WebConfig();
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRowView rowView = (DataRowView)e.Row.DataItem;
                    HyperLink lnk = (HyperLink)e.Row.FindControl("lnkAttachment");
                    lnk.Text = rowView["FileName"].ToString();
                    string HttpFilePath = obj.GetApplicationPath() + @"/Upload Files/" + hidRecordID.Value + @"/" + lnk.Text;
                    lnk.NavigateUrl = HttpFilePath;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        void LoadForm()
        {
            try
            {
                SAP_VendorCreation obj = dbVendor.SAP_VendorCreation.Find(decimal.Parse(dalBPM.RecordID));
                hidRecordID.Value = obj.RequestID.ToString();
                txtIBAN.Text = obj.AccountNoIBAN;
                txtAddress.Text = obj.Address;
                txtBankAddress.Text = obj.BankAddress;
                Common.SelectItemByValue(ddlCountry, obj.Country);
                txtPostalCode.Text = obj.PostalCode;
                txtCity.Text = obj.City;
                txtBenificaryName.Text = obj.BenificaryName;
                txtBusinessName.Text = obj.BusinessName;
                Common.SelectItemByValue(rblClassification, obj.Classification);
                Common.SelectItemByValue(rblType, obj.CompanyType);
                txtContactPerson.Text = obj.ContactPerson;
                txtEmail.Text = obj.Email;
                txtFaxNo.Text = obj.FaxNo;
                Common.SelectItemByValue(rblNaturOfWork, obj.NatureOfWork);
                txtNTN.Text = obj.NTNNo;
                Common.SelectItemByValue(rblCurrency, obj.PaymentCurrency);
                Common.SelectItemByValue(rblPaymentMethod, obj.PaymentMethod);
                txtPaymentTerms.Text = obj.PaymentTerms;
                txtPeriod.Text = obj.PeriodUpto;
                txtContactNo.Text = obj.PhoneNo;
                Common.SelectItemByValue(rblQualification, obj.Qualification);
                if (obj.QuestionnaireCompleted.GetValueOrDefault())
                    rblAttached.SelectedValue = "Yes";
                else
                    rblAttached.SelectedValue = "No";
                txtNA.Checked = obj.RegNA.GetValueOrDefault();
                Common.SelectItemByValue(rblOptions, obj.RequestType);
                txtResion.Text = obj.Resion;
                txtRoutingNo.Text = obj.RoutingNo;
                txtState.Text = obj.State;

                txtSwiftCode.Text = obj.SwiftCode;
                txtSaleTaxReg.Text = obj.TaxRegNo;
                hidUserID.Value = obj.UserID;
                Common.SelectItemByValue(ddlWitholdingTaxField, obj.WHoldingTax);
                txtVendorID.Text = obj.SAPVendorID;
                
               // lblEmail.Text = obj.Email_Sent.Equals("1") ? "Yes" : "No";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                db.Disconnect();
            }
        }
        protected void btUpdate_Click(object sender, EventArgs e)
        {
            SAP_VendorCreation obj = dbVendor.SAP_VendorCreation.Find(decimal.Parse(hidRecordID.Value));
            try
            {
                if (!Validation())
                    return;
                if (obj == null)
                    obj = new SAP_VendorCreation();
                obj.RequestID = decimal.Parse(hidRecordID.Value);
                obj.AccountNoIBAN = txtIBAN.Text;
                obj.Address = txtAddress.Text;
                obj.BankAddress = txtBankAddress.Text;
                obj.Country = ddlCountry.SelectedItem.Value;
                obj.PostalCode = txtPostalCode.Text;
                obj.City = txtCity.Text;
                obj.BenificaryName = txtBenificaryName.Text;
                obj.BusinessName = txtBusinessName.Text;
                obj.Classification = rblClassification.SelectedValue;
                obj.CompanyType = rblType.SelectedValue;
                obj.ContactPerson = txtContactPerson.Text;
                obj.Email = txtEmail.Text;
                obj.FaxNo = txtFaxNo.Text;
                obj.NatureOfWork = rblNaturOfWork.SelectedValue;
                obj.NTNNo = txtNTN.Text;
                obj.PaymentCurrency = rblCurrency.SelectedValue;
                obj.PaymentMethod = rblPaymentMethod.SelectedValue;
                obj.PaymentTerms = txtPaymentTerms.Text;
                obj.PeriodUpto = txtPeriod.Text;
                obj.PhoneNo = txtContactNo.Text;
                obj.Qualification = rblQualification.SelectedValue;
                obj.QuestionnaireCompleted = rblAttached.SelectedValue == "Yes";
                obj.RegNA = txtNA.Checked;
                obj.RequestType = rblOptions.SelectedValue;
                obj.Resion = txtResion.Text;
                obj.RoutingNo = txtRoutingNo.Text;
                obj.State = txtState.Text;
                obj.Status = "1";
                obj.SwiftCode = txtSwiftCode.Text;
                obj.TaxRegNo = txtSaleTaxReg.Text;
                obj.UpdatedDate = DateTime.Now;
                obj.AccountNoIBAN = txtIBAN.Text;
                obj.WHoldingTax = ddlWitholdingTaxField.SelectedValue;
                obj.SAPVendorID = txtVendorID.Text;
                dbVendor.SaveChanges();
         
                lblError.Text = "Record successfully updated.";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        bool Validation()
        {
            bool _result = true;
            try
            {
                if (txtBusinessName.Text.Equals(""))
                {
                    lblError.Text = "Please enter bussiness name.";
                    _result = false;
                }

                if (txtCity.Text.Equals(""))
                {
                    lblError.Text = "Please enter city.";
                    _result = false;
                }
                if (txtAddress.Text.Equals(""))
                {
                    lblError.Text = "Please enter address.";
                    _result = false;
                }
                if (txtContactPerson.Text.Equals(""))
                {
                    lblError.Text = "Please enter contact person.";
                    _result = false;
                }
                if (txtContactNo.Text.Equals(""))
                {
                    lblError.Text = "Please enter contact No.";
                    _result = false;
                }
                //if (txtContactPerson.Text.Length > 250)
                //{
                //    lblError.Text = "Please enter contact person less than 250 characters.";
                //    _result = false;
                //}
                //if (txtContactNo.Text.Length > 50)
                //{
                //    lblError.Text = "Please enter con less than 250 characters.";
                //    _result = false;
                //}
                //if (txtPostalCode.Text.Length > 10)
                //{
                //    lblError.Text = "Please enter postal code less than 11 characters.";
                //    _result = false;
                //}
                //if (txtCity.Text.Length > 50)
                //{
                //    lblError.Text = "Please enter city less than 50 characters.";
                //    _result = false;
                //}
                //if (txtHNo.Text.Length > 50)
                //{
                //    lblError.Text = "Please enter street & house no less than 50 characters.";
                //    _result = false;
                //}
                //if (txtStreet.Text.Length > 50)
                //{
                //    lblError.Text = "Please enter street less than 50 characters.";
                //    _result = false;
                //}
                //if (txtDistrict.Text.Length > 50)
                //{
                //    lblError.Text = "Please enter district less than 50 characters.";
                //    _result = false;
                //}
                //if (txtRegion.Text.Length > 20)
                //{
                //    lblError.Text = "Please enter region less than 20 characters.";
                //    _result = false;
                //}
                //if (txtPOBox.Text.Length > 20)
                //{
                //    lblError.Text = "Please enter po box less than 20 characters.";
                //    _result = false;
                //}
                //if (txtSterm1.Text.Length > 40)
                //{
                //    lblError.Text = "Please enter search term1 less than 40 characters.";
                //    _result = false;
                //}
                //if (txtSterm2.Text.Length > 25)
                //{
                //    lblError.Text = "Please enter search term2 less than 26 characters.";
                //    _result = false;
                //}
                //if (txtLanguage.Text.Length > 15)
                //{
                //    lblError.Text = "Please enter language key less than 15 characters.";
                //    _result = false;
                //}
                //if (txtPhone.Text.Length > 20)
                //{
                //    lblError.Text = "Please enter phone less than 20 characters.";
                //    _result = false;
                //}
                //if (txtFax.Text.Length > 61)
                //{
                //    lblError.Text = "Please enter fax less than 62 characters.";
                //    _result = false;
                //}
                //if (txtEmail.Text.Length > 50)
                //{
                //    lblError.Text = "Please enter email less than 50 characters.";
                //    _result = false;
                //}
                //if (txtTaxcode1.Text.Length > 20)
                //{
                //    lblError.Text = "Please enter tax code1 less than 20 characters.";
                //    _result = false;
                //}
                //if (txtTaxCode2.Text.Length > 20)
                //{
                //    lblError.Text = "Please enter tax code2 less than 20 characters.";
                //    _result = false;
                //}
                //if (txtTaxcode3.Text.Length > 20)
                //{
                //    lblError.Text = "Please enter tax code3 less than 20 characters.";
                //    _result = false;
                //}
                //if (txtDunsNumber.Text.Length > 15)
                //{
                //    lblError.Text = "Please enter DUNS No less than 15 characters.";
                //    _result = false;
                //}
                //if (txtVAT.Text.Length > 20)
                //{
                //    lblError.Text = "Please enter VAT reg no less than 21 characters.";
                //    _result = false;
                //}
                //if (txtIndustryKey.Text.Length > 4)
                //{
                //    lblError.Text = "Please enter Industry key less than 5 characters.";
                //    _result = false;
                //}
                //if (txtTradingPart.Text.Length > 6)
                //{
                //    lblError.Text = "Please enter trading partner less than 7 characters.";
                //    _result = false;
                //}
                //if (txtIBAN1.Text.Length > 50)
                //{
                //    lblError.Text = "Please enter IBAN1 less than 51 characters.";
                //    _result = false;
                //}
                ////if (txtBCK1.Text.Length > 3)
                ////{
                ////    lblError.Text = "Please enter bank country key less than 4 characters.";
                ////    _result = false;
                ////}
                //if (txtBNKName1.Text.Length > 50)
                //{
                //    lblError.Text = "Please enter bank name1 less than 51 characters.";
                //    _result = false;
                //}
                //if (txtBCity1.Text.Length > 50)
                //{
                //    lblError.Text = "Please enter bank city1 less than 51 characters.";
                //    _result = false;
                //}
                //if (txtBHNo1.Text.Length > 50)
                //{
                //    lblError.Text = "Please enter street & house no1 less than 51 characters.";
                //    _result = false;
                //}
                //if (txtBBranch1.Text.Length > 50)
                //{
                //    lblError.Text = "Please enter bank branch1 less than 51 characters.";
                //    _result = false;
                //}
                //if (txtBankKey1.Text.Length > 15)
                //{
                //    lblError.Text = "Please enter bank key1 less than 16 characters.";
                //    _result = false;
                //}
                //if (txtAccount1.Text.Length > 18)
                //{
                //    lblError.Text = "Please enter bank account no1 less than 19 characters.";
                //    _result = false;
                //}
                //if (txtSwitCode1.Text.Length > 50)
                //{
                //    lblError.Text = "Please enter swift code1 less than 51 characters.";
                //    _result = false;
                //}
                //if (txtAHName1.Text.Length > 60)
                //{
                //    lblError.Text = "Please enter acoount holder1 name less than 61 characters.";
                //    _result = false;
                //}
                //if (txtABInfo1.Text.Length > 50)
                //{
                //    lblError.Text = "Please enter additional bank info1 name less than 51 characters.";
                //    _result = false;
                //}


                //if (txtIBAN2.Text.Length > 50)
                //{
                //    lblError.Text = "Please enter IBAN2 less than 51 characters.";
                //    _result = false;
                //}
                ////if (txtBCK2.Text.Length > 3)
                ////{
                ////    lblError.Text = "Please enter bank country key2 less than 4 characters.";
                ////    _result = false;
                ////}
                //if (txtBNKName2.Text.Length > 50)
                //{
                //    lblError.Text = "Please enter bank name2 less than 51 characters.";
                //    _result = false;
                //}
                //if (txtBCity2.Text.Length > 50)
                //{
                //    lblError.Text = "Please enter bank city2 less than 51 characters.";
                //    _result = false;
                //}
                //if (txtBHNo2.Text.Length > 50)
                //{
                //    lblError.Text = "Please enter street & house no2 less than 51 characters.";
                //    _result = false;
                //}
                //if (txtBBranch2.Text.Length > 50)
                //{
                //    lblError.Text = "Please enter bank branch2 less than 51 characters.";
                //    _result = false;
                //}
                //if (txtBankKey2.Text.Length > 15)
                //{
                //    lblError.Text = "Please enter bank key2 less than 16 characters.";
                //    _result = false;
                //}
                //if (txtAccount2.Text.Length > 18)
                //{
                //    lblError.Text = "Please enter bank account no2 less than 19 characters.";
                //    _result = false;
                //}
                //if (txtSwitCode2.Text.Length > 50)
                //{
                //    lblError.Text = "Please enter swift code2 less than 51 characters.";
                //    _result = false;
                //}
                //if (txtAHName2.Text.Length > 60)
                //{
                //    lblError.Text = "Please enter acoount holder2 name less than 61 characters.";
                //    _result = false;
                //}
                //if (txtABInfo2.Text.Length > 50)
                //{
                //    lblError.Text = "Please enter additional bank info2 name less than 51 characters.";
                //    _result = false;
                //}


                //if (txtCCode1.Text.Length > 4)
                //{
                //    lblError.Text = "Please enter company code less than 5 characters.";
                //    _result = false;
                //}
                //if (txtRecon.Text.Length > 10)
                //{
                //    lblError.Text = "Please enter reconiliation account less than 11 characters.";
                //    _result = false;
                //}
                //if (txtMSOrt2PK1.Text.Length > 50)
                //{
                //    lblError.Text = "Please enter M.S.OR T 2PK1 less than 51 characters.";
                //    _result = false;
                //}
                //if (txtMSOrt2PK3.Text.Length > 50)
                //{
                //    lblError.Text = "Please enter M.S.OR T 2PK3 less than 51 characters.";
                //    _result = false;
                //}
                //if (txtLTU.Text.Length > 50)
                //{
                //    lblError.Text = "Please enter LTU less than 51 characters.";
                //    _result = false;
                //}
                //if (txtWHTC.Text.Length > 3)
                //{
                //    lblError.Text = "Please enter withholding tax country less than 4 characters.";
                //    _result = false;
                //}
                //if (txtWHTType.Text.Length > 2)
                //{
                //    lblError.Text = "Please enter withholding tax type less than 3 characters.";
                //    _result = false;
                //}
                //if (txtWHTCode.Text.Length > 2)
                //{
                //    lblError.Text = "Please enter withholding tax code less than 3 characters.";
                //    _result = false;
                //}
                //if (txtWHTTID.Text.Length > 16)
                //{
                //    lblError.Text = "Please enter withholding tax id less than 17 characters.";
                //    _result = false;
                //}

                //if (ddlTo.SelectedIndex == 0)
                //{
                //    lblError.Text = "Please select manager for approval.";
                //    _result = false;
                //}

                //if (txtCCate1.Text.Equals(""))
                //{
                //    lblError.Text = "Please enter company category 1.";
                //    _result = false;
                //}
                //if (txtCCate2.Text.Equals(""))
                //{
                //    lblError.Text = "Please enter company category 2.";
                //    _result = false;
                //}

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            return _result;
        }
        protected void btEmail_Click(object sender, EventArgs e)
        {
            try
            {
                string _message = "<p>New vendor form has been initiated please click on following link to view the details </p> http://UEISBAP001/vendorcreation/print.aspx?requestid=" + hidRecordID.Value;
                // SendEmail(_message);
                SAP_VendorCreation obj = dbVendor.SAP_VendorCreation.Find(decimal.Parse(hidRecordID.Value));
                obj.EmailSent = "1";
                obj.EmailSentDate = DateTime.Now;
                dbVendor.SaveChanges();             
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
            WebConfig dalobj = new WebConfig();
            string FromEmail = dalobj.GetUserBPM_Email(hidUserID.Value);
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
    }
}
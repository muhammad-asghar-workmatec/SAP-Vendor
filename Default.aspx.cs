using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using WPClient;
using SAP_Vendor.Data;
using Microsoft.Ajax.Utilities;
using System.Data.Entity.Migrations;
using SAP_Vendor.Controls;
using System.Data.Entity;
using Telerik.Web.UI;
using WPCommon;

namespace SAP_Vendor
{


    public partial class _Default : PageBase
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
                        LoadControls();
                        this.RequestId = dalBPM.RecordID;
                        SAP_VendorCreation objMain = null;
                        if (string.IsNullOrEmpty(dalBPM.RecordID))
                        {
                             objMain = db.AddVendorCreation(dalBPM.UserID, dalBPM.UserName);                                                        
                        }
                        else
                        {
                            objMain = db.GetVendorCreation(dalBPM.RecordID);
                        }
                        if (objMain != null)
                        {
                            this.RequestId = objMain.RequestId;
                            LoadForm(objMain);
                        }
                        hidRecordID.Value = this.RequestId;
                        BindAttachments(dgAttachment);
                       // GetGroupUsers(ddlTo);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                
                lblError.Text = ex.Message;
            }
        }
        void LoadControls()
        {
            try
            {
                db.BindListItems(ddlCountry, CATEGORY.COUNTRY);
                db.BindListItems(ddlPaymentTerms, CATEGORY.PAYMENT);
                db.BindListItems(ddlCurrency, CATEGORY.CURRENCY);
                db.BindListItems(ddlWitholdingTaxField, CATEGORY.WITHOLDING_TAX_FIELD);
                //db.Load(ddlCountry, "Description", "Value", @"Select Description,Value from SAP_Vendor_Items Where category = 'country' and enable = '1' Order by Description");
                //db.Load(ddlBankCountry1, "Description", "Value", @"Select Description,Value from SAP_Vendor_Items Where category = 'country' and enable = '1' Order by Description");
                //db.Load(ddlBankCountry2, "Description", "Value", @"Select Description,Value from SAP_Vendor_Items Where category = 'country' and enable = '1' Order by Description");
                // db.Load(ddlPaymentTerms, "Description", "Value", @"Select Description,Value from SAP_Vendor_Items Where category = 'Payment' and enable = '1' Order by Description");
                // db.Load(ddlCurrency, "Description", "Value", @"Select Description,Value from SAP_Vendor_Items Where category = 'Currency' and enable = '1' Order by Description");
                //db.Load(ddlRecepientType, "Description", "Value", @"Select Description,Value from SAP_Vendor_Items Where category = 'Recipient' and enable = '1' Order by Description");
                //ddlBankCountry1.Items.Insert(0, new ListItem("--Select--"));
                //ddlBankCountry2.Items.Insert(0, new ListItem("--Select--"));
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
     
        private int GetNextIncidentNo()
        {
            dalOU.ClearParameters();
            dalOU.AddParameter("@ProcessName", dalBPM.ProcessName);
            var nextIncidentNo = (int)dalOU.ExecuteScalarDefault("select LastIncidentNo+IncidentIncrement as nextIncidentNo from E_ProcessLastIncident where ProcessName=@ProcessName", 1);
            return nextIncidentNo;
        }
        void Upload_FileUploaded(object sender, Telerik.Web.UI.FileUploadedEventArgs e)
        {
            //Bitmap bitmapImage = ResizeImage(RadAsyncUpload1.UploadedFiles[0].InputStream);
            //System.IO.MemoryStream stream = new System.IO.MemoryStream();
            //bitmapImage.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
            //RadBinaryImage1.DataValue = stream.ToArray();
        }
        protected void btnDraft_Click(object sender, EventArgs e)
        {
            try
            {
                var obj = db.GetVendorCreation(requestId: this.RequestId);
                this.SetData(obj);
                if (db.Entry(obj).State == EntityState.Detached)
                {
                    db.SAP_VendorCreation.Attach(obj);
                }
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
            }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (dalBPM.TaskStatus == BPMExecution.TASK_STATUS_NEW)
                {                  
                    var objMain =db.ClearVendorCreation(requestId: this.RequestId, dalBPM.UserID, dalBPM.UserName);
                    this.RequestId = objMain.RequestId;
                    this.LoadForm(objMain);
                }

            }
            catch (Exception ex)
            {

                this.ErrorMessage = ex.Message;
            }
        }
        
        protected void btUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (fuFile.UploadedFiles.Count > 0)
                {
                    foreach (UploadedFile file in fuFile.UploadedFiles)
                    {
                        this.Upload(fileUpload: file, description: txtFileDesc.Text, dalBPM.UserID, dalBPM.UserName);
                    }
                    txtFileDesc.Text = "";
                    panelNewAttachment.Visible = !panelNewAttachment.Visible;
                    BindAttachments(dgAttachment);
                }
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.ErrorMessage))
                this.lblError.Text = this.ErrorMessage;
            lblErrorBottom.Text = this.lblError.Text;
        }
        void LoadForm(SAP_VendorCreation obj)
        {
            try
            {              
                hidRecordID.Value = obj.RequestId;
                txtIBAN.Text = obj.AccountNoIBAN;
                txtAddress.Text = obj.Address;
                txtBankAddress.Text = obj.BankAddress;
                Common.SelectItemByText(ddlCountry,string.IsNullOrEmpty(obj.Country)?string.Empty:obj.Country);
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
                Common.SelectItemByText(ddlCurrency, string.IsNullOrEmpty(obj.PaymentCurrency) ? string.Empty : obj.PaymentCurrency);
                Common.SelectItemByValue(rblPaymentMethod, string.IsNullOrEmpty(obj.PaymentMethod) ? string.Empty : obj.PaymentMethod);
                Common.SelectItemByText(ddlPaymentTerms, string.IsNullOrEmpty(obj.PaymentTerms) ? string.Empty : obj.PaymentTerms);
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
                Common.SelectItemByText(ddlWitholdingTaxField, string.IsNullOrEmpty(obj.WithholdingTax) ? string.Empty : obj.WithholdingTax);
               // txtVendorID.Text = obj.SAPVendorId;

                // lblEmail.Text = obj.Email_Sent.Equals("1") ? "Yes" : "No";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;

            }
        }
        protected void SetData(SAP_VendorCreation obj)
        {
            if(obj==null)
                 obj = db.SAP_VendorCreation.Find(hidRecordID.Value);
            obj.RequestId = hidRecordID.Value;
            obj.AccountNoIBAN = txtIBAN.Text;
            obj.Address = txtAddress.Text;
            obj.BankAddress = txtBankAddress.Text;
            if (ddlCountry.SelectedIndex != -1)
                obj.Country = ddlCountry.SelectedItem.Text;
            obj.PostalCode = txtPostalCode.Text;
            obj.City = txtCity.Text;
            obj.BenificaryName = txtBenificaryName.Text;
            obj.BusinessName = txtBusinessName.Text;
            if (rblClassification.SelectedIndex != -1)
                obj.Classification = rblClassification.SelectedValue;
            if (rblType.SelectedIndex != -1)
                obj.CompanyType = rblType.SelectedValue;
            obj.ContactPerson = txtContactPerson.Text;
            obj.Email = txtEmail.Text;
            obj.FaxNo = txtFaxNo.Text;
            if (rblNaturOfWork.SelectedIndex != -1)
                obj.NatureOfWork = rblNaturOfWork.SelectedValue;
            obj.NTNNo = txtNTN.Text;
            if (ddlCurrency.SelectedIndex != -1)
                obj.PaymentCurrency = ddlCurrency.SelectedItem.Text;
            if (rblPaymentMethod.SelectedIndex != -1)
                obj.PaymentMethod = rblPaymentMethod.SelectedValue;
            if (ddlPaymentTerms.SelectedIndex != -1)
                obj.PaymentTerms = ddlPaymentTerms.SelectedItem.Text;
            obj.PeriodUpto = txtPeriod.Text;
            obj.PhoneNo = txtContactNo.Text;
            if (rblQualification.SelectedIndex != -1)
                obj.Qualification = rblQualification.SelectedValue;
            if (rblAttached.SelectedIndex != -1)
                obj.QuestionnaireCompleted = rblAttached.SelectedValue == "Yes";
            obj.RegNA = txtNA.Checked;
            if (rblOptions.SelectedIndex != -1)
                obj.RequestType = rblOptions.SelectedValue;
            obj.Reason = txtReason.Text;
            obj.RoutingNo = txtRoutingNo.Text;
            obj.State = txtState.Text;
            if (ddlWitholdingTaxField.SelectedIndex != -1)
                obj.WithholdingTax = ddlWitholdingTaxField.SelectedItem.Text;
            obj.SwiftCode = txtSwiftCode.Text;
            obj.TaxRegNo = txtSaleTaxReg.Text;
            obj.UpdatedDate = DateTime.Now;
            obj.CreatedDate = DateTime.Now;
            obj.UserId = dalBPM.UserID;
            obj.UserName = dalBPM.UserName;
            obj.Remarks = txtRemarks.Content;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SAP_VendorCreation obj = db.SAP_VendorCreation.Find(hidRecordID.Value);
            try
            {
                if (!Validation())
                    return;
                this.SetData(obj);
                obj.Status =1;               
                          
                db.SaveChanges();
               


                string Incident_Summary = "Vendor " + txtBusinessName.Text.Replace("'", "''");
                dalBPM.SetVarValue("INCIDENT_SUMMARY", Incident_Summary);
                dalBPM.SetVarValue("IEmail", dalBPM.UserEmail);
                dalBPM.SetVarValue("I_User", dalBPM.UserID);
                dalBPM.SetVarValue("RecordKey", hidRecordID.Value);
               // dalBPM.SetVarValue("HOD", ddlTo.SelectedValue);
                int IncidentNo = dalBPM.SubmitTask(Incident_Summary, hidRecordID.Value, "Initiated", txtRemarks.Content);
                if (IncidentNo > 0)
                {
                    
                        if (!obj.InitiatedDate.HasValue || obj.IncidentNo == 0)
                        {
                            obj.InitiatedDate = DateTime.Now;
                            obj.UpdatedDate = obj.InitiatedDate;
                        }
                        else
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
                    //  Response.Redirect("~/View.aspx?TaskID=" + dalBPM.TaskID, false);
                    Response.Redirect("~/SuccessfullySubmited.aspx", false);
                    
                }
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

       
        void AddFlow(string ClaimID)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void lnkBankDetails_Click(object sender, EventArgs e)
        {
            //if (spnBank.Visible)
            //    spnBank.Visible = false;
            //else
            //    spnBank.Visible = true;
        }
        protected void btNewFile_Click(object sender, EventArgs e)
        {
            //btnNew.Visible = false;
            panelNewAttachment.Visible = !panelNewAttachment.Visible;
            
        }
    }

   
}
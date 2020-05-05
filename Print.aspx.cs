﻿using SAP_Vendor.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WPClient;
using WPCommon;

namespace SAP_Vendor
{
    public partial class Print : System.Web.UI.Page
    {
        BulletSQL db = new BulletSQL(WebConfig.ConnectionString);
        VendorEntities dbVendor = new SAP_Vendor.Data.VendorEntities();
        string query = "";
        BPMExecution dalBPM = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // dalBPM = new BPMExecution(Page, WebConfig.BPMConnectionString);
                lblError.Text = "";
                if (!IsPostBack)
                {
                    hidRecordID.Value = Request.QueryString["requestid"].ToString();
                    InitControls();
                    //UserRemarks1.LoadRemarks("Vendor Creation",int.Parse(Request.QueryString["IncidentNo"].ToString()),WebConfig.BPMConnectionString);
                    Query objQ = new Query(WebConfig.BPMConnectionString);
                    int IncidentNo = objQ.GetIncidentNo("Vendor Creation", hidRecordID.Value);
                    UserRemarks1.LoadRemarks("Vendor Creation", IncidentNo, WebConfig.BPMConnectionString);
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
                            //int index = Convert.ToInt32(e.CommandArgument);
                            //Vendor_Attachment obj = new Vendor_Attachment();
                            //dgAttachment.SelectedIndex = index;
                            //db.DeleteObject((Vendor_Attachment)obj, Vendor_Attachment.P_ID, dgAttachment.SelectedValue.ToString());
                            //dgAttachment.SelectedIndex = -1;
                            //lblError.Text = "Record successfully deleted.";
                            //BindAttachmentGrid();
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
                txtCountry.Text = obj.Country;
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
                txtWHoldingTax.Text = obj.WHoldingTax;
                txtVendorID.Text = obj.SAPVendorID;
                txtIssedBy.Text = obj.IssuedBy;
                if (!obj.IssuedOn.HasValue)
                    txtIssuedOn.Text = obj.IssuedOn.Value.ToString("dd-MMM-yyyy");               
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                db.Disconnect();
            }
        }
    }
}
using SAP_Vendor.Data;
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
    public partial class Print : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                PageLoad();
                lblError.Text = "";
                if (!IsPostBack)
                {
                    hidRecordID.Value = dalBPM.RecordID;
                    InitControls();
                   
                    UserRemarks1.LoadRemarks(dalBPM);
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
                            //int index = Convert.ToInt32(e.CommandArgument);
                            //SAP_VendorAttachment obj = new SAP_VendorAttachment();
                            //dgAttachment.SelectedIndex = index;
                            //db.DeleteObject((SAP_VendorAttachment)obj, SAP_VendorAttachment.P_ID, dgAttachment.SelectedValue.ToString());
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
                
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRowView rowView = (DataRowView)e.Row.DataItem;
                    HyperLink lnk = (HyperLink)e.Row.FindControl("lnkAttachment");
                    lnk.Text = rowView["FileName"].ToString();
                    string HttpFilePath = @"Documents/" + hidRecordID.Value + @"/" + lnk.Text;
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
                txtVendorID.Text = obj.SAPVendorId;
                txtIssedBy.Text = obj.IssuedBy;
                if (!obj.IssuedOn.HasValue)
                    txtIssuedOn.Text = obj.IssuedOn.Value.ToString("dd-MMM-yyyy");               
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                
            }
        }
    }
}
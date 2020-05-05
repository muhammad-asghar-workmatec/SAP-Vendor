using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WPClient;

namespace SAP_Vendor
{
    public partial class Print : System.Web.UI.Page
    {
        BulletSQL db = new BulletSQL(WebConfig.ConnectionString);
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
                            int index = Convert.ToInt32(e.CommandArgument);
                            Vendor_Attachment obj = new Vendor_Attachment();
                            dgAttachment.SelectedIndex = index;
                            db.DeleteObject((Vendor_Attachment)obj, Vendor_Attachment.P_ID, dgAttachment.SelectedValue.ToString());
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
                SAP_VendorCreation obj = new SAP_VendorCreation();
                WebConfig objConfig = new WebConfig();
                obj = new SAP_VendorCreation(db.GetObject((object)obj, SAP_VendorCreation.P_Request_ID, hidRecordID.Value).Rows[0]);
                txtName1.Text = obj.Name1;
                txtName2.Text = obj.Name2;
                txtCountry.Text = obj.Country;
                txtPostalCode.Text = obj.PostalCode;
                txtCity.Text = obj.City;
                txtHNo.Text = obj.STHNo;
                txtStreet.Text = obj.Street;
                txtDistrict.Text = obj.District;
                txtRegion.Text = obj.Region;
                txtPOBox.Text = obj.POBox;
                txtSterm1.Text = obj.SearchTerm1;
                txtSterm2.Text = obj.SearchTerm2;
                txtLanguage.Text = obj.LanguageKey;
                txtPhone.Text = obj.Phone;
                txtFax.Text = obj.Fax;


                txtEmail.Text = obj.Email;
                txtTaxcode1.Text = obj.TaxCode1;
                txtTaxCode2.Text = obj.TaxCode2;
                txtDunsNumber.Text = obj.DunsNo;
                txtVAT.Text = obj.VATRegNo;
                txtIndustryKey.Text = obj.IndustryKey;

                txtIBAN1.Text = obj.IBAN1;
                txtBCK1.Text = obj.BankKey1;
                txtBNKName1.Text = obj.BankName1;
                txtBCity1.Text = obj.BankCity1;
                txtBHNo1.Text = obj.BankStreet1;
                txtBBranch1.Text = obj.BankBranch1;
                txtBankKey1.Text = obj.BankKey1;
                txtAccount1.Text = obj.BankAccNo1;
                txtSwitCode1.Text = obj.BankSwiftCode1;
                txtAHName1.Text = obj.AccHolderName1;
                txtABInfo1.Text = obj.AdditionalBankInfo1;

                txtIBAN2.Text = obj.IBAN2;
                txtBCK2.Text = obj.BankKey2;
                txtBNKName2.Text = obj.BankName2;
                txtBCity2.Text = obj.BankCity2;
                txtBHNo2.Text = obj.BankStreet2;
                txtBBranch2.Text = obj.BankBranch2;
                txtBankKey2.Text = obj.BankKey2;
                txtAccount2.Text = obj.BankAccNo2;
                txtSwitCode2.Text = obj.BankSwiftCode2;
                txtAHName2.Text = obj.AccHolderName2;
                txtABInfo2.Text = obj.AdditionalBankInfo2;

                txtCCode1.Text = obj.CompanyCode;
                txtRecon.Text = obj.ReconcilliationAccount;

                txtPaymentTerms.Text = obj.TermsofPayment;
                txtMSOrt2PK1.Text = obj.MSORT2PK1;
                txtMSOrt2PK3.Text = obj.MSORT2PK3;
                txtLTU.Text = obj.LTU;
                txtWHTC.Text = obj.WHoldingTaxCounty;
                txtWHTType.Text = obj.WHoldingTaxType;
                txtWHTCode.Text = obj.WHoldingTaxCode;
                txtRecipient.Text = obj.RecipientType;
                txtWHTTID.Text = obj.WithHoldingTaxID;
                txtCurrency.Text = obj.MMOrderCurrency;
                txtVendorID.Text = obj.SAP_Vendor_ID;
                txtIssedBy.Text = obj.IssuedBy;
                if (!obj.IssuedOn.Equals(DateTime.MinValue))
                    txtIssuedOn.Text = obj.IssuedOn.ToString("dd-MMM-yyyy");

                txtCType.Text = obj.CompanyType;

                txtCCate1.Text = obj.ComCate1;
                txtCCate2.Text = obj.ComCate2;
                txtCCate3.Text = obj.ComCate3;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                db.Disconnect();
            }
        }
    }
}
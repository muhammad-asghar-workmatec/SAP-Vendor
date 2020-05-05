using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WPClient;

namespace SAP_Vendor
{
    public partial class Return : System.Web.UI.Page
    {
        BulletSQL db = new BulletSQL(WebConfig.ConnectionString);
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
                    LoadControls();
                    GetGroupUsers();
                }
            }
            catch (Exception ex)
            {
                db.Disconnect();
                lblError.Text = ex.Message;
            }
        }
        void LoadControls()
        {
            try
            {

                db.Load(ddlCountry, "Description", "Value", @"Select Description,Value from SAP_Vendor_Items Where category = 'country' and enable = '1' Order by Description");
                db.Load(ddlBankCountry1, "Description", "Value", @"Select Description,Value from SAP_Vendor_Items Where category = 'country' and enable = '1' Order by Description");
                db.Load(ddlBankCountry2, "Description", "Value", @"Select Description,Value from SAP_Vendor_Items Where category = 'country' and enable = '1' Order by Description");
                db.Load(ddlPaymentTerms, "Description", "Value", @"Select Description,Value from SAP_Vendor_Items Where category = 'Payment' and enable = '1' Order by Description");
                db.Load(ddlCurrency, "Description", "Value", @"Select Description,Value from SAP_Vendor_Items Where category = 'Currency' and enable = '1' Order by Description");
                db.Load(ddlRecepientType, "Description", "Value", @"Select Description,Value from SAP_Vendor_Items Where category = 'Recipient' and enable = '1' Order by Description");
                ddlBankCountry1.Items.Insert(0, new ListItem("--Select--"));
                ddlBankCountry2.Items.Insert(0, new ListItem("--Select--"));
                LoadForm();
                BindAttachment();
                BindFlowGrid();
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
                //dsFlow.SelectCommand = "Select * From VendorFlow Where Request_ID = " + hidRecordID.Value + " order by approved_date desc";
                //dgFlow.DataBind();

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                db.Disconnect();
            }
        }
        void LoadForm()
        {
            try
            {
                SAP_VendorCreation obj = new SAP_VendorCreation();
                obj = new SAP_VendorCreation(db.GetObject((object)obj, SAP_VendorCreation.P_Request_ID, hidRecordID.Value).Rows[0]);
                txtName1.Text = obj.Name1;
                txtName2.Text = obj.Name2;
                ddlCountry.SelectedIndex = ddlCountry.Items.IndexOf(ddlCountry.Items.FindByValue(obj.Country));
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
                ddlBankCountry1.SelectedIndex = ddlBankCountry1.Items.IndexOf(ddlBankCountry1.Items.FindByValue(obj.BankKey1));
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
                ddlBankCountry2.SelectedIndex = ddlBankCountry2.Items.IndexOf(ddlBankCountry2.Items.FindByValue(obj.BankKey2));
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

                ddlPaymentTerms.SelectedIndex = ddlPaymentTerms.Items.IndexOf(ddlPaymentTerms.Items.FindByValue(obj.TermsofPayment));
                txtMSOrt2PK1.Text = obj.MSORT2PK1;
                txtMSOrt2PK3.Text = obj.MSORT2PK3;
                txtLTU.Text = obj.LTU;
                txtWHTC.Text = obj.WHoldingTaxCounty;
                txtWHTType.Text = obj.WHoldingTaxType;
                txtWHTCode.Text = obj.WHoldingTaxCode;
                ddlRecepientType.SelectedIndex = ddlRecepientType.Items.IndexOf(ddlRecepientType.Items.FindByValue(obj.RecipientType));
                txtWHTTID.Text = obj.WithHoldingTaxID;
                ddlCurrency.SelectedIndex = ddlCurrency.Items.IndexOf(ddlCurrency.Items.FindByValue(obj.MMOrderCurrency));

                ddlCType.SelectedIndex = ddlCType.Items.IndexOf(ddlCType.Items.FindByValue(obj.CompanyType));

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
                            BindAttachment();
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
        void BindAttachment()
        {
            try
            {
                dsAttachment.SelectCommand = @"Select * From Vendor_Attachment Where Request_ID = " + hidRecordID.Value;
                dgAttachment.DataBind();
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
        protected void btSubmit_Click(object sender, EventArgs e)
        {
            SAP_VendorCreation obj = new SAP_VendorCreation();
            try
            {
                if (!Validation())
                    return;
                obj = new SAP_VendorCreation(db.GetObject((object)obj, SAP_VendorCreation.P_Request_ID, hidRecordID.Value).Rows[0]);
                obj.Name1 = txtName1.Text;
                obj.Name2 = txtName2.Text;
                obj.Account_Group = "VEND";
                obj.Country = ddlCountry.SelectedItem.Value;
                obj.PostalCode = txtPostalCode.Text;
                obj.City = txtCity.Text;
                obj.STHNo = txtHNo.Text;
                obj.Street = txtStreet.Text;
                obj.District = txtDistrict.Text;
                obj.Region = txtRegion.Text;
                obj.POBox = txtPOBox.Text;
                obj.SearchTerm1 = txtSterm1.Text;
                obj.SearchTerm2 = txtSterm2.Text;
                obj.LanguageKey = txtLanguage.Text;
                obj.Phone = txtPhone.Text;
                obj.Fax = txtFax.Text;
                obj.Email = txtEmail.Text;
                obj.TaxCode1 = txtTaxcode1.Text;
                obj.TaxCode2 = txtTaxCode2.Text;
                obj.DunsNo = txtDunsNumber.Text;
                obj.VATRegNo = txtVAT.Text;
                obj.IndustryKey = txtIndustryKey.Text;
                obj.IBAN1 = txtIBAN1.Text;
                if (ddlBankCountry1.SelectedIndex != 0)
                    obj.BankKey1 = ddlBankCountry1.SelectedItem.Value;
                obj.BankName1 = txtBNKName1.Text;
                obj.BankCity1 = txtBCity1.Text;
                obj.BankStreet1 = txtBHNo1.Text;
                obj.BankBranch1 = txtBBranch1.Text;
                obj.BankKey1 = txtBankKey1.Text;
                obj.BankAccNo1 = txtAccount1.Text;
                obj.BankSwiftCode1 = txtSwitCode1.Text;
                obj.AccHolderName1 = txtAHName1.Text;
                obj.AdditionalBankInfo1 = txtABInfo1.Text;

                obj.IBAN2 = txtIBAN2.Text;
                if (ddlBankCountry2.SelectedIndex != 0)
                    obj.BankKey2 = ddlBankCountry2.SelectedItem.Value;
                obj.BankName2 = txtBNKName2.Text;
                obj.BankCity2 = txtBCity2.Text;
                obj.BankStreet2 = txtBHNo2.Text;
                obj.BankBranch2 = txtBBranch2.Text;
                obj.BankKey2 = txtBankKey2.Text;
                obj.BankAccNo2 = txtAccount2.Text;
                obj.BankSwiftCode2 = txtSwitCode2.Text;
                obj.AccHolderName2 = txtAHName2.Text;
                obj.AdditionalBankInfo2 = txtABInfo2.Text;

                obj.CompanyCode = txtCCode1.Text;
                obj.ReconcilliationAccount = txtRecon.Text;

                obj.TermsofPayment = ddlPaymentTerms.SelectedItem.Value;
                obj.MSORT2PK1 = txtMSOrt2PK1.Text;
                obj.MSORT2PK3 = txtMSOrt2PK3.Text;
                obj.LTU = txtLTU.Text;
                obj.WHoldingTaxCounty = txtWHTC.Text;
                obj.WHoldingTaxType = txtWHTType.Text;
                obj.WHoldingTaxCode = txtWHTCode.Text;
                obj.RecipientType = ddlRecepientType.SelectedItem.Value;
                obj.WithHoldingTaxID = txtWHTTID.Text;
                obj.MMOrderCurrency = ddlCurrency.SelectedItem.Value;

                obj.CompanyType = ddlCType.SelectedItem.Text;
                obj.ComCate1 = txtCCate1.Text;
                obj.ComCate2 = txtCCate2.Text;
                obj.ComCate3 = txtCCate3.Text;

                db.UpdateObject((object)obj, SAP_VendorCreation.P_Request_ID);
                db.ClearParameters();


                string Incident_Summary = "Vendor " + txtName1.Text.Replace("'", "''");
                dalBPM.SetVarValue("INCIDENT_SUMMARY", Incident_Summary);
                dalBPM.SetVarValue("HOD", ddlTo.Value);
                dalBPM.SubmitTask("Resubmitted", txtRemarks.Text);
                Response.Redirect("SuccessfullySubmited.aspx");
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
                if (txtName1.Text.Equals(""))
                {
                    lblError.Text = "Please enter company name1.";
                    _result = false;
                }

                if (txtCity.Text.Equals(""))
                {
                    lblError.Text = "Please enter city.";
                    _result = false;
                }
                if (txtHNo.Text.Equals(""))
                {
                    lblError.Text = "Please enter street & house no.";
                    _result = false;
                }

                if (txtName1.Text.Length > 35)
                {
                    lblError.Text = "Please enter name1 less than 36 characters.";
                    _result = false;
                }
                if (txtName2.Text.Length > 35)
                {
                    lblError.Text = "Please enter name2 less than 36 characters.";
                    _result = false;
                }
                if (txtPostalCode.Text.Length > 10)
                {
                    lblError.Text = "Please enter postal code less than 11 characters.";
                    _result = false;
                }
                if (txtCity.Text.Length > 35)
                {
                    lblError.Text = "Please enter city less than 36 characters.";
                    _result = false;
                }
                if (txtHNo.Text.Length > 25)
                {
                    lblError.Text = "Please enter street & house no less than 26 characters.";
                    _result = false;
                }
                if (txtStreet.Text.Length > 25)
                {
                    lblError.Text = "Please enter street less than 26 characters.";
                    _result = false;
                }
                if (txtDistrict.Text.Length > 35)
                {
                    lblError.Text = "Please enter district less than 36 characters.";
                    _result = false;
                }
                if (txtRegion.Text.Length > 3)
                {
                    lblError.Text = "Please enter region less than 4 characters.";
                    _result = false;
                }
                if (txtPOBox.Text.Length > 10)
                {
                    lblError.Text = "Please enter po box less than 11 characters.";
                    _result = false;
                }
                if (txtSterm1.Text.Length > 25)
                {
                    lblError.Text = "Please enter search term1 less than 26 characters.";
                    _result = false;
                }
                if (txtSterm2.Text.Length > 25)
                {
                    lblError.Text = "Please enter search term2 less than 26 characters.";
                    _result = false;
                }
                if (txtLanguage.Text.Length > 2)
                {
                    lblError.Text = "Please enter language key less than 3 characters.";
                    _result = false;
                }
                if (txtPhone.Text.Length > 16)
                {
                    lblError.Text = "Please enter phone less than 17 characters.";
                    _result = false;
                }
                if (txtFax.Text.Length > 61)
                {
                    lblError.Text = "Please enter fax less than 62 characters.";
                    _result = false;
                }
                if (txtEmail.Text.Length > 30)
                {
                    lblError.Text = "Please enter email less than 31 characters.";
                    _result = false;
                }
                if (txtTaxcode1.Text.Length > 16)
                {
                    lblError.Text = "Please enter tax code1 less than 17 characters.";
                    _result = false;
                }
                if (txtTaxCode2.Text.Length > 11)
                {
                    lblError.Text = "Please enter tax code2 less than 12 characters.";
                    _result = false;
                }
                if (txtTaxcode3.Text.Length > 11)
                {
                    lblError.Text = "Please enter tax code3 less than 12 characters.";
                    _result = false;
                }
                if (txtDunsNumber.Text.Length > 5)
                {
                    lblError.Text = "Please enter DUNS No less than 6 characters.";
                    _result = false;
                }
                if (txtVAT.Text.Length > 20)
                {
                    lblError.Text = "Please enter VAT reg no less than 21 characters.";
                    _result = false;
                }
                if (txtIndustryKey.Text.Length > 4)
                {
                    lblError.Text = "Please enter Industry key less than 5 characters.";
                    _result = false;
                }
                if (txtTradingPart.Text.Length > 6)
                {
                    lblError.Text = "Please enter trading partner less than 7 characters.";
                    _result = false;
                }
                if (txtIBAN1.Text.Length > 50)
                {
                    lblError.Text = "Please enter IBAN1 less than 51 characters.";
                    _result = false;
                }
                //if (txtBCK1.Text.Length > 3)
                //{
                //    lblError.Text = "Please enter bank country key less than 4 characters.";
                //    _result = false;
                //}
                if (txtBNKName1.Text.Length > 50)
                {
                    lblError.Text = "Please enter bank name1 less than 51 characters.";
                    _result = false;
                }
                if (txtBCity1.Text.Length > 50)
                {
                    lblError.Text = "Please enter bank city1 less than 51 characters.";
                    _result = false;
                }
                if (txtBHNo1.Text.Length > 50)
                {
                    lblError.Text = "Please enter street & house no1 less than 51 characters.";
                    _result = false;
                }
                if (txtBBranch1.Text.Length > 50)
                {
                    lblError.Text = "Please enter bank branch1 less than 51 characters.";
                    _result = false;
                }
                if (txtBankKey1.Text.Length > 15)
                {
                    lblError.Text = "Please enter bank key1 less than 16 characters.";
                    _result = false;
                }
                if (txtAccount1.Text.Length > 18)
                {
                    lblError.Text = "Please enter bank account no1 less than 19 characters.";
                    _result = false;
                }
                if (txtSwitCode1.Text.Length > 50)
                {
                    lblError.Text = "Please enter swift code1 less than 51 characters.";
                    _result = false;
                }
                if (txtAHName1.Text.Length > 60)
                {
                    lblError.Text = "Please enter acoount holder1 name less than 61 characters.";
                    _result = false;
                }
                if (txtABInfo1.Text.Length > 50)
                {
                    lblError.Text = "Please enter additional bank info1 name less than 51 characters.";
                    _result = false;
                }


                if (txtIBAN2.Text.Length > 50)
                {
                    lblError.Text = "Please enter IBAN2 less than 51 characters.";
                    _result = false;
                }
                //if (txtBCK2.Text.Length > 3)
                //{
                //    lblError.Text = "Please enter bank country key2 less than 4 characters.";
                //    _result = false;
                //}
                if (txtBNKName2.Text.Length > 50)
                {
                    lblError.Text = "Please enter bank name2 less than 51 characters.";
                    _result = false;
                }
                if (txtBCity2.Text.Length > 50)
                {
                    lblError.Text = "Please enter bank city2 less than 51 characters.";
                    _result = false;
                }
                if (txtBHNo2.Text.Length > 50)
                {
                    lblError.Text = "Please enter street & house no2 less than 51 characters.";
                    _result = false;
                }
                if (txtBBranch2.Text.Length > 50)
                {
                    lblError.Text = "Please enter bank branch2 less than 51 characters.";
                    _result = false;
                }
                if (txtBankKey2.Text.Length > 15)
                {
                    lblError.Text = "Please enter bank key2 less than 16 characters.";
                    _result = false;
                }
                if (txtAccount2.Text.Length > 18)
                {
                    lblError.Text = "Please enter bank account no2 less than 19 characters.";
                    _result = false;
                }
                if (txtSwitCode2.Text.Length > 50)
                {
                    lblError.Text = "Please enter swift code2 less than 51 characters.";
                    _result = false;
                }
                if (txtAHName2.Text.Length > 60)
                {
                    lblError.Text = "Please enter acoount holder2 name less than 61 characters.";
                    _result = false;
                }
                if (txtABInfo2.Text.Length > 50)
                {
                    lblError.Text = "Please enter additional bank info2 name less than 51 characters.";
                    _result = false;
                }


                if (txtCCode1.Text.Length > 4)
                {
                    lblError.Text = "Please enter company code less than 5 characters.";
                    _result = false;
                }
                if (txtRecon.Text.Length > 10)
                {
                    lblError.Text = "Please enter reconiliation account less than 11 characters.";
                    _result = false;
                }
                if (txtMSOrt2PK1.Text.Length > 50)
                {
                    lblError.Text = "Please enter M.S.OR T 2PK1 less than 51 characters.";
                    _result = false;
                }
                if (txtMSOrt2PK3.Text.Length > 50)
                {
                    lblError.Text = "Please enter M.S.OR T 2PK3 less than 51 characters.";
                    _result = false;
                }
                if (txtLTU.Text.Length > 50)
                {
                    lblError.Text = "Please enter LTU less than 51 characters.";
                    _result = false;
                }
                if (txtWHTC.Text.Length > 3)
                {
                    lblError.Text = "Please enter withholding tax country less than 4 characters.";
                    _result = false;
                }
                if (txtWHTType.Text.Length > 2)
                {
                    lblError.Text = "Please enter withholding tax type less than 3 characters.";
                    _result = false;
                }
                if (txtWHTCode.Text.Length > 2)
                {
                    lblError.Text = "Please enter withholding tax code less than 3 characters.";
                    _result = false;
                }
                if (txtWHTTID.Text.Length > 16)
                {
                    lblError.Text = "Please enter withholding tax id less than 17 characters.";
                    _result = false;
                }
                if (txtCCate1.Text.Equals(""))
                {
                    lblError.Text = "Please enter company category 1.";
                    _result = false;
                }
                if (txtCCate2.Text.Equals(""))
                {
                    lblError.Text = "Please enter company category 2.";
                    _result = false;
                }

                if (ddlTo.SelectedIndex == 0)
                {
                    lblError.Text = "Please select manager for approval.";
                    _result = false;
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            return _result;
        }

        void GetGroupUsers()
        {
            try
            {
                WebConfig obj = new WebConfig();
                string _Group = ConfigurationManager.AppSettings["ApproverGroup"].ToString();
                System.Data.SqlClient.SqlDataReader dr = obj.GetGroupUsers(_Group);
                ddlTo.DataSource = dr;
                ddlTo.DataTextField = "T9F0007";
                ddlTo.DataValueField = "T4F0003";
                ddlTo.DataBind();
                dr.Close();
                ddlTo.Items.Insert(0, new ListItem("--Select--"));
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
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
        protected void btUpload_Click(object sender, EventArgs e)
        {
            try
            {
                Vendor_Attachment obj = new Vendor_Attachment();
                if (fuFile.HasFile)
                {

                    string path;
                    path = Server.MapPath(".");
                    string _folderPath = path + @"\Upload Files\" + hidRecordID.Value;
                    DirectoryInfo _folder = new DirectoryInfo(_folderPath);
                    if (!_folder.Exists)
                        _folder.Create();
                    fuFile.SaveAs(_folderPath + @"\" + fuFile.FileName);
                    obj.Request_ID = hidRecordID.Value;
                    obj.FileName = fuFile.FileName;
                    db.AddObject((object)obj, Vendor_Attachment.P_ID);
                    BindAttachment();
                }
            }
            catch (Exception ex)
            {
                db.Disconnect();
                lblError.Text = ex.Message;
            }
        }
        protected void txtFax13_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
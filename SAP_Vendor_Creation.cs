//using System;
//using System.Data;
//namespace SAP_Vendor
//{
//    public partial class SAP_VendorCreation
//    {
//        public SAP_VendorCreation()
//        {
//        }
//        protected string _Request_ID = string.Empty;
//        public string Request_ID
//        {
//            get
//            {
//                return _Request_ID;
//            }
//            set
//            {
//                _Request_ID = value;
//            }
//        }
//        public const string P_Request_ID = "Request_ID";
//        protected string _Account_Group = string.Empty;
//        public string Account_Group
//        {
//            get
//            {
//                return _Account_Group;
//            }
//            set
//            {
//                _Account_Group = value;
//            }
//        }
//        public const string P_Account_Group = "Account_Group";
//        protected string _Name1 = string.Empty;
//        public string Name1
//        {
//            get
//            {
//                return _Name1;
//            }
//            set
//            {
//                _Name1 = value;
//            }
//        }
//        public const string P_Name1 = "Name1";
//        protected string _Name2 = string.Empty;
//        public string Name2
//        {
//            get
//            {
//                return _Name2;
//            }
//            set
//            {
//                _Name2 = value;
//            }
//        }
//        public const string P_Name2 = "Name2";
//        protected string _Country = string.Empty;
//        public string Country
//        {
//            get
//            {
//                return _Country;
//            }
//            set
//            {
//                _Country = value;
//            }
//        }
//        public const string P_Country = "Country";
//        protected string _PostalCode = string.Empty;
//        public string PostalCode
//        {
//            get
//            {
//                return _PostalCode;
//            }
//            set
//            {
//                _PostalCode = value;
//            }
//        }
//        public const string P_PostalCode = "PostalCode";
//        protected string _City = string.Empty;
//        public string City
//        {
//            get
//            {
//                return _City;
//            }
//            set
//            {
//                _City = value;
//            }
//        }
//        public const string P_City = "City";
//        protected string _STHNo = string.Empty;
//        public string STHNo
//        {
//            get
//            {
//                return _STHNo;
//            }
//            set
//            {
//                _STHNo = value;
//            }
//        }
//        public const string P_STHNo = "STHNo";
//        protected string _Street = string.Empty;
//        public string Street
//        {
//            get
//            {
//                return _Street;
//            }
//            set
//            {
//                _Street = value;
//            }
//        }
//        public const string P_Street = "Street";
//        protected string _District = string.Empty;
//        public string District
//        {
//            get
//            {
//                return _District;
//            }
//            set
//            {
//                _District = value;
//            }
//        }
//        public const string P_District = "District";
//        protected string _Region = string.Empty;
//        public string Region
//        {
//            get
//            {
//                return _Region;
//            }
//            set
//            {
//                _Region = value;
//            }
//        }
//        public const string P_Region = "Region";
//        protected string _POBox = string.Empty;
//        public string POBox
//        {
//            get
//            {
//                return _POBox;
//            }
//            set
//            {
//                _POBox = value;
//            }
//        }
//        public const string P_POBox = "POBox";
//        protected string _SearchTerm1 = string.Empty;
//        public string SearchTerm1
//        {
//            get
//            {
//                return _SearchTerm1;
//            }
//            set
//            {
//                _SearchTerm1 = value;
//            }
//        }
//        public const string P_SearchTerm1 = "SearchTerm1";
//        protected string _SearchTerm2 = string.Empty;
//        public string SearchTerm2
//        {
//            get
//            {
//                return _SearchTerm2;
//            }
//            set
//            {
//                _SearchTerm2 = value;
//            }
//        }
//        public const string P_SearchTerm2 = "SearchTerm2";
//        protected string _LanguageKey = string.Empty;
//        public string LanguageKey
//        {
//            get
//            {
//                return _LanguageKey;
//            }
//            set
//            {
//                _LanguageKey = value;
//            }
//        }
//        public const string P_LanguageKey = "LanguageKey";
//        protected string _Phone = string.Empty;
//        public string Phone
//        {
//            get
//            {
//                return _Phone;
//            }
//            set
//            {
//                _Phone = value;
//            }
//        }
//        public const string P_Phone = "Phone";
//        protected string _Fax = string.Empty;
//        public string Fax
//        {
//            get
//            {
//                return _Fax;
//            }
//            set
//            {
//                _Fax = value;
//            }
//        }
//        public const string P_Fax = "Fax";
//        protected string _Email = string.Empty;
//        public string Email
//        {
//            get
//            {
//                return _Email;
//            }
//            set
//            {
//                _Email = value;
//            }
//        }
//        public const string P_Email = "Email";
//        protected string _TaxCode1 = string.Empty;
//        public string TaxCode1
//        {
//            get
//            {
//                return _TaxCode1;
//            }
//            set
//            {
//                _TaxCode1 = value;
//            }
//        }
//        public const string P_TaxCode1 = "TaxCode1";
//        protected string _TaxCode2 = string.Empty;
//        public string TaxCode2
//        {
//            get
//            {
//                return _TaxCode2;
//            }
//            set
//            {
//                _TaxCode2 = value;
//            }
//        }
//        public const string P_TaxCode2 = "TaxCode2";
//        protected string _TaxCode3 = string.Empty;
//        public string TaxCode3
//        {
//            get
//            {
//                return _TaxCode3;
//            }
//            set
//            {
//                _TaxCode3 = value;
//            }
//        }
//        public const string P_TaxCode3 = "TaxCode3";
//        protected string _DunsNo = string.Empty;
//        public string DunsNo
//        {
//            get
//            {
//                return _DunsNo;
//            }
//            set
//            {
//                _DunsNo = value;
//            }
//        }
//        public const string P_DunsNo = "DunsNo";
//        protected string _VATRegNo = string.Empty;
//        public string VATRegNo
//        {
//            get
//            {
//                return _VATRegNo;
//            }
//            set
//            {
//                _VATRegNo = value;
//            }
//        }
//        public const string P_VATRegNo = "VATRegNo";
//        protected string _IndustryKey = string.Empty;
//        public string IndustryKey
//        {
//            get
//            {
//                return _IndustryKey;
//            }
//            set
//            {
//                _IndustryKey = value;
//            }
//        }
//        public const string P_IndustryKey = "IndustryKey";
//        protected string _TradingPartner = string.Empty;
//        public string TradingPartner
//        {
//            get
//            {
//                return _TradingPartner;
//            }
//            set
//            {
//                _TradingPartner = value;
//            }
//        }
//        public const string P_TradingPartner = "TradingPartner";
//        protected string _IBAN1 = string.Empty;
//        public string IBAN1
//        {
//            get
//            {
//                return _IBAN1;
//            }
//            set
//            {
//                _IBAN1 = value;
//            }
//        }
//        public const string P_IBAN1 = "IBAN1";
//        protected string _IBAN2 = string.Empty;
//        public string IBAN2
//        {
//            get
//            {
//                return _IBAN2;
//            }
//            set
//            {
//                _IBAN2 = value;
//            }
//        }
//        public const string P_IBAN2 = "IBAN2";
//        protected string _BNKCountryKey1 = string.Empty;
//        public string BNKCountryKey1
//        {
//            get
//            {
//                return _BNKCountryKey1;
//            }
//            set
//            {
//                _BNKCountryKey1 = value;
//            }
//        }
//        public const string P_BNKCountryKey1 = "BNKCountryKey1";
//        protected string _BankName1 = string.Empty;
//        public string BankName1
//        {
//            get
//            {
//                return _BankName1;
//            }
//            set
//            {
//                _BankName1 = value;
//            }
//        }
//        public const string P_BankName1 = "BankName1";
//        protected string _BankCity1 = string.Empty;
//        public string BankCity1
//        {
//            get
//            {
//                return _BankCity1;
//            }
//            set
//            {
//                _BankCity1 = value;
//            }
//        }
//        public const string P_BankCity1 = "BankCity1";
//        protected string _BankStreet1 = string.Empty;
//        public string BankStreet1
//        {
//            get
//            {
//                return _BankStreet1;
//            }
//            set
//            {
//                _BankStreet1 = value;
//            }
//        }
//        public const string P_BankStreet1 = "BankStreet1";
//        protected string _BankBranch1 = string.Empty;
//        public string BankBranch1
//        {
//            get
//            {
//                return _BankBranch1;
//            }
//            set
//            {
//                _BankBranch1 = value;
//            }
//        }
//        public const string P_BankBranch1 = "BankBranch1";
//        protected string _BankKey1 = string.Empty;
//        public string BankKey1
//        {
//            get
//            {
//                return _BankKey1;
//            }
//            set
//            {
//                _BankKey1 = value;
//            }
//        }
//        public const string P_BankKey1 = "BankKey1";
//        protected string _BankAccNo1 = string.Empty;
//        public string BankAccNo1
//        {
//            get
//            {
//                return _BankAccNo1;
//            }
//            set
//            {
//                _BankAccNo1 = value;
//            }
//        }
//        public const string P_BankAccNo1 = "BankAccNo1";
//        protected string _BankSwiftCode1 = string.Empty;
//        public string BankSwiftCode1
//        {
//            get
//            {
//                return _BankSwiftCode1;
//            }
//            set
//            {
//                _BankSwiftCode1 = value;
//            }
//        }
//        public const string P_BankSwiftCode1 = "BankSwiftCode1";
//        protected string _AccHolderName1 = string.Empty;
//        public string AccHolderName1
//        {
//            get
//            {
//                return _AccHolderName1;
//            }
//            set
//            {
//                _AccHolderName1 = value;
//            }
//        }
//        public const string P_AccHolderName1 = "AccHolderName1";
//        protected string _AdditionalBankInfo1 = string.Empty;
//        public string AdditionalBankInfo1
//        {
//            get
//            {
//                return _AdditionalBankInfo1;
//            }
//            set
//            {
//                _AdditionalBankInfo1 = value;
//            }
//        }
//        public const string P_AdditionalBankInfo1 = "AdditionalBankInfo1";
//        protected string _CompanyCode = string.Empty;
//        public string CompanyCode
//        {
//            get
//            {
//                return _CompanyCode;
//            }
//            set
//            {
//                _CompanyCode = value;
//            }
//        }
//        public const string P_CompanyCode = "CompanyCode";
//        protected string _ReconcilliationAccount = string.Empty;
//        public string ReconcilliationAccount
//        {
//            get
//            {
//                return _ReconcilliationAccount;
//            }
//            set
//            {
//                _ReconcilliationAccount = value;
//            }
//        }
//        public const string P_ReconcilliationAccount = "ReconcilliationAccount";
//        protected string _TermsofPayment = string.Empty;
//        public string TermsofPayment
//        {
//            get
//            {
//                return _TermsofPayment;
//            }
//            set
//            {
//                _TermsofPayment = value;
//            }
//        }
//        public const string P_TermsofPayment = "TermsofPayment";
//        protected string _BankName2 = string.Empty;
//        public string BankName2
//        {
//            get
//            {
//                return _BankName2;
//            }
//            set
//            {
//                _BankName2 = value;
//            }
//        }
//        public const string P_BankName2 = "BankName2";
//        protected string _BankCity2 = string.Empty;
//        public string BankCity2
//        {
//            get
//            {
//                return _BankCity2;
//            }
//            set
//            {
//                _BankCity2 = value;
//            }
//        }
//        public const string P_BankCity2 = "BankCity2";
//        protected string _BankStreet2 = string.Empty;
//        public string BankStreet2
//        {
//            get
//            {
//                return _BankStreet2;
//            }
//            set
//            {
//                _BankStreet2 = value;
//            }
//        }
//        public const string P_BankStreet2 = "BankStreet2";
//        protected string _BankBranch2 = string.Empty;
//        public string BankBranch2
//        {
//            get
//            {
//                return _BankBranch2;
//            }
//            set
//            {
//                _BankBranch2 = value;
//            }
//        }
//        public const string P_BankBranch2 = "BankBranch2";
//        protected string _BankKey2 = string.Empty;
//        public string BankKey2
//        {
//            get
//            {
//                return _BankKey2;
//            }
//            set
//            {
//                _BankKey2 = value;
//            }
//        }
//        public const string P_BankKey2 = "BankKey2";
//        protected string _BankAccNo2 = string.Empty;
//        public string BankAccNo2
//        {
//            get
//            {
//                return _BankAccNo2;
//            }
//            set
//            {
//                _BankAccNo2 = value;
//            }
//        }
//        public const string P_BankAccNo2 = "BankAccNo2";
//        protected string _BankSwiftCode2 = string.Empty;
//        public string BankSwiftCode2
//        {
//            get
//            {
//                return _BankSwiftCode2;
//            }
//            set
//            {
//                _BankSwiftCode2 = value;
//            }
//        }
//        public const string P_BankSwiftCode2 = "BankSwiftCode2";
//        protected string _AccHolderName2 = string.Empty;
//        public string AccHolderName2
//        {
//            get
//            {
//                return _AccHolderName2;
//            }
//            set
//            {
//                _AccHolderName2 = value;
//            }
//        }
//        public const string P_AccHolderName2 = "AccHolderName2";
//        protected string _AdditionalBankInfo2 = string.Empty;
//        public string AdditionalBankInfo2
//        {
//            get
//            {
//                return _AdditionalBankInfo2;
//            }
//            set
//            {
//                _AdditionalBankInfo2 = value;
//            }
//        }
//        public const string P_AdditionalBankInfo2 = "AdditionalBankInfo2";
//        protected string _MSORT2PK1 = string.Empty;
//        public string MSORT2PK1
//        {
//            get
//            {
//                return _MSORT2PK1;
//            }
//            set
//            {
//                _MSORT2PK1 = value;
//            }
//        }
//        public const string P_MSORT2PK1 = "MSORT2PK1";
//        protected string _MSORT2PK3 = string.Empty;
//        public string MSORT2PK3
//        {
//            get
//            {
//                return _MSORT2PK3;
//            }
//            set
//            {
//                _MSORT2PK3 = value;
//            }
//        }
//        public const string P_MSORT2PK3 = "MSORT2PK3";
//        protected string _LTU = string.Empty;
//        public string LTU
//        {
//            get
//            {
//                return _LTU;
//            }
//            set
//            {
//                _LTU = value;
//            }
//        }
//        public const string P_LTU = "LTU";
//        protected string _WHoldingTaxCounty = string.Empty;
//        public string WHoldingTaxCounty
//        {
//            get
//            {
//                return _WHoldingTaxCounty;
//            }
//            set
//            {
//                _WHoldingTaxCounty = value;
//            }
//        }
//        public const string P_WHoldingTaxCounty = "WHoldingTaxCounty";
//        protected string _WHoldingTaxType = string.Empty;
//        public string WHoldingTaxType
//        {
//            get
//            {
//                return _WHoldingTaxType;
//            }
//            set
//            {
//                _WHoldingTaxType = value;
//            }
//        }
//        public const string P_WHoldingTaxType = "WHoldingTaxType";
//        protected string _WHoldingTaxCode = string.Empty;
//        public string WHoldingTaxCode
//        {
//            get
//            {
//                return _WHoldingTaxCode;
//            }
//            set
//            {
//                _WHoldingTaxCode = value;
//            }
//        }
//        public const string P_WHoldingTaxCode = "WHoldingTaxCode";
//        protected string _RecipientType = string.Empty;
//        public string RecipientType
//        {
//            get
//            {
//                return _RecipientType;
//            }
//            set
//            {
//                _RecipientType = value;
//            }
//        }
//        public const string P_RecipientType = "RecipientType";
//        protected string _WithHoldingTaxID = string.Empty;
//        public string WithHoldingTaxID
//        {
//            get
//            {
//                return _WithHoldingTaxID;
//            }
//            set
//            {
//                _WithHoldingTaxID = value;
//            }
//        }
//        public const string P_WithHoldingTaxID = "WithHoldingTaxID";
//        protected DateTime _IssuedOn = new DateTime();
//        public DateTime IssuedOn
//        {
//            get
//            {
//                return _IssuedOn;
//            }
//            set
//            {
//                _IssuedOn = value;
//            }
//        }
//        public const string P_IssuedOn = "IssuedOn";
//        protected string _IssuedBy = string.Empty;
//        public string IssuedBy
//        {
//            get
//            {
//                return _IssuedBy;
//            }
//            set
//            {
//                _IssuedBy = value;
//            }
//        }
//        public const string P_IssuedBy = "IssuedBy";
//        protected string _MMOrderCurrency = string.Empty;
//        public string MMOrderCurrency
//        {
//            get
//            {
//                return _MMOrderCurrency;
//            }
//            set
//            {
//                _MMOrderCurrency = value;
//            }
//        }
//        public const string P_MMOrderCurrency = "MMOrderCurrency";
//        protected string _User_ID = string.Empty;
//        public string User_ID
//        {
//            get
//            {
//                return _User_ID;
//            }
//            set
//            {
//                _User_ID = value;
//            }
//        }
//        public const string P_User_ID = "User_ID";
//        protected string _Status = string.Empty;
//        public string Status
//        {
//            get
//            {
//                return _Status;
//            }
//            set
//            {
//                _Status = value;
//            }
//        }
//        public const string P_Status = "Status";
//        protected DateTime _UpdateDate = new DateTime();
//        public DateTime UpdateDate
//        {
//            get
//            {
//                return _UpdateDate;
//            }
//            set
//            {
//                _UpdateDate = value;
//            }
//        }
//        public const string P_UpdateDate = "UpdateDate";
//        protected string _Email_Sent = string.Empty;
//        public string Email_Sent
//        {
//            get
//            {
//                return _Email_Sent;
//            }
//            set
//            {
//                _Email_Sent = value;
//            }
//        }
//        public const string P_Email_Sent = "Email_Sent";
//        protected DateTime _Email_Sent_Date = new DateTime();
//        public DateTime Email_Sent_Date
//        {
//            get
//            {
//                return _Email_Sent_Date;
//            }
//            set
//            {
//                _Email_Sent_Date = value;
//            }
//        }
//        public const string P_Email_Sent_Date = "Email_Sent_Date";
//        protected string _SAP_Vendor_ID = string.Empty;
//        public string SAP_Vendor_ID
//        {
//            get
//            {
//                return _SAP_Vendor_ID;
//            }
//            set
//            {
//                _SAP_Vendor_ID = value;
//            }
//        }
//        public const string P_SAP_Vendor_ID = "SAP_Vendor_ID";
//        protected string _CompanyType = string.Empty;
//        public string CompanyType
//        {
//            get
//            {
//                return _CompanyType;
//            }
//            set
//            {
//                _CompanyType = value;
//            }
//        }
//        public const string P_CompanyType = "CompanyType";
//        protected string _ComCate1 = string.Empty;
//        public string ComCate1
//        {
//            get
//            {
//                return _ComCate1;
//            }
//            set
//            {
//                _ComCate1 = value;
//            }
//        }
//        public const string P_ComCate1 = "ComCate1";
//        protected string _ComCate2 = string.Empty;
//        public string ComCate2
//        {
//            get
//            {
//                return _ComCate2;
//            }
//            set
//            {
//                _ComCate2 = value;
//            }
//        }
//        public const string P_ComCate2 = "ComCate2";
//        protected string _ComCate3 = string.Empty;
//        public string ComCate3
//        {
//            get
//            {
//                return _ComCate3;
//            }
//            set
//            {
//                _ComCate3 = value;
//            }
//        }
//        public const string P_ComCate3 = "ComCate3";
//        public SAP_VendorCreation(DataRow obj)
//        {
//            try
//            {
//                if (obj == null)
//                    return;
//                if (obj.Table.Columns.Contains(P_Request_ID))
//                    Request_ID = obj[P_Request_ID].ToString();
//                if (obj.Table.Columns.Contains(P_Account_Group))
//                    Account_Group = obj[P_Account_Group].ToString();
//                if (obj.Table.Columns.Contains(P_Name1))
//                    Name1 = obj[P_Name1].ToString();
//                if (obj.Table.Columns.Contains(P_Name2))
//                    Name2 = obj[P_Name2].ToString();
//                if (obj.Table.Columns.Contains(P_Country))
//                    Country = obj[P_Country].ToString();
//                if (obj.Table.Columns.Contains(P_PostalCode))
//                    PostalCode = obj[P_PostalCode].ToString();
//                if (obj.Table.Columns.Contains(P_City))
//                    City = obj[P_City].ToString();
//                if (obj.Table.Columns.Contains(P_STHNo))
//                    STHNo = obj[P_STHNo].ToString();
//                if (obj.Table.Columns.Contains(P_Street))
//                    Street = obj[P_Street].ToString();
//                if (obj.Table.Columns.Contains(P_District))
//                    District = obj[P_District].ToString();
//                if (obj.Table.Columns.Contains(P_Region))
//                    Region = obj[P_Region].ToString();
//                if (obj.Table.Columns.Contains(P_POBox))
//                    POBox = obj[P_POBox].ToString();
//                if (obj.Table.Columns.Contains(P_SearchTerm1))
//                    SearchTerm1 = obj[P_SearchTerm1].ToString();
//                if (obj.Table.Columns.Contains(P_SearchTerm2))
//                    SearchTerm2 = obj[P_SearchTerm2].ToString();
//                if (obj.Table.Columns.Contains(P_LanguageKey))
//                    LanguageKey = obj[P_LanguageKey].ToString();
//                if (obj.Table.Columns.Contains(P_Phone))
//                    Phone = obj[P_Phone].ToString();
//                if (obj.Table.Columns.Contains(P_Fax))
//                    Fax = obj[P_Fax].ToString();
//                if (obj.Table.Columns.Contains(P_Email))
//                    Email = obj[P_Email].ToString();
//                if (obj.Table.Columns.Contains(P_TaxCode1))
//                    TaxCode1 = obj[P_TaxCode1].ToString();
//                if (obj.Table.Columns.Contains(P_TaxCode2))
//                    TaxCode2 = obj[P_TaxCode2].ToString();
//                if (obj.Table.Columns.Contains(P_TaxCode3))
//                    TaxCode3 = obj[P_TaxCode3].ToString();
//                if (obj.Table.Columns.Contains(P_DunsNo))
//                    DunsNo = obj[P_DunsNo].ToString();
//                if (obj.Table.Columns.Contains(P_VATRegNo))
//                    VATRegNo = obj[P_VATRegNo].ToString();
//                if (obj.Table.Columns.Contains(P_IndustryKey))
//                    IndustryKey = obj[P_IndustryKey].ToString();
//                if (obj.Table.Columns.Contains(P_TradingPartner))
//                    TradingPartner = obj[P_TradingPartner].ToString();
//                if (obj.Table.Columns.Contains(P_IBAN1))
//                    IBAN1 = obj[P_IBAN1].ToString();
//                if (obj.Table.Columns.Contains(P_IBAN2))
//                    IBAN2 = obj[P_IBAN2].ToString();
//                if (obj.Table.Columns.Contains(P_BNKCountryKey1))
//                    BNKCountryKey1 = obj[P_BNKCountryKey1].ToString();
//                if (obj.Table.Columns.Contains(P_BankName1))
//                    BankName1 = obj[P_BankName1].ToString();
//                if (obj.Table.Columns.Contains(P_BankCity1))
//                    BankCity1 = obj[P_BankCity1].ToString();
//                if (obj.Table.Columns.Contains(P_BankStreet1))
//                    BankStreet1 = obj[P_BankStreet1].ToString();
//                if (obj.Table.Columns.Contains(P_BankBranch1))
//                    BankBranch1 = obj[P_BankBranch1].ToString();
//                if (obj.Table.Columns.Contains(P_BankKey1))
//                    BankKey1 = obj[P_BankKey1].ToString();
//                if (obj.Table.Columns.Contains(P_BankAccNo1))
//                    BankAccNo1 = obj[P_BankAccNo1].ToString();
//                if (obj.Table.Columns.Contains(P_BankSwiftCode1))
//                    BankSwiftCode1 = obj[P_BankSwiftCode1].ToString();
//                if (obj.Table.Columns.Contains(P_AccHolderName1))
//                    AccHolderName1 = obj[P_AccHolderName1].ToString();
//                if (obj.Table.Columns.Contains(P_AdditionalBankInfo1))
//                    AdditionalBankInfo1 = obj[P_AdditionalBankInfo1].ToString();
//                if (obj.Table.Columns.Contains(P_CompanyCode))
//                    CompanyCode = obj[P_CompanyCode].ToString();
//                if (obj.Table.Columns.Contains(P_ReconcilliationAccount))
//                    ReconcilliationAccount = obj[P_ReconcilliationAccount].ToString();
//                if (obj.Table.Columns.Contains(P_TermsofPayment))
//                    TermsofPayment = obj[P_TermsofPayment].ToString();
//                if (obj.Table.Columns.Contains(P_BankName2))
//                    BankName2 = obj[P_BankName2].ToString();
//                if (obj.Table.Columns.Contains(P_BankCity2))
//                    BankCity2 = obj[P_BankCity2].ToString();
//                if (obj.Table.Columns.Contains(P_BankStreet2))
//                    BankStreet2 = obj[P_BankStreet2].ToString();
//                if (obj.Table.Columns.Contains(P_BankBranch2))
//                    BankBranch2 = obj[P_BankBranch2].ToString();
//                if (obj.Table.Columns.Contains(P_BankKey2))
//                    BankKey2 = obj[P_BankKey2].ToString();
//                if (obj.Table.Columns.Contains(P_BankAccNo2))
//                    BankAccNo2 = obj[P_BankAccNo2].ToString();
//                if (obj.Table.Columns.Contains(P_BankSwiftCode2))
//                    BankSwiftCode2 = obj[P_BankSwiftCode2].ToString();
//                if (obj.Table.Columns.Contains(P_AccHolderName2))
//                    AccHolderName2 = obj[P_AccHolderName2].ToString();
//                if (obj.Table.Columns.Contains(P_AdditionalBankInfo2))
//                    AdditionalBankInfo2 = obj[P_AdditionalBankInfo2].ToString();
//                if (obj.Table.Columns.Contains(P_MSORT2PK1))
//                    MSORT2PK1 = obj[P_MSORT2PK1].ToString();
//                if (obj.Table.Columns.Contains(P_MSORT2PK3))
//                    MSORT2PK3 = obj[P_MSORT2PK3].ToString();
//                if (obj.Table.Columns.Contains(P_LTU))
//                    LTU = obj[P_LTU].ToString();
//                if (obj.Table.Columns.Contains(P_WHoldingTaxCounty))
//                    WHoldingTaxCounty = obj[P_WHoldingTaxCounty].ToString();
//                if (obj.Table.Columns.Contains(P_WHoldingTaxType))
//                    WHoldingTaxType = obj[P_WHoldingTaxType].ToString();
//                if (obj.Table.Columns.Contains(P_WHoldingTaxCode))
//                    WHoldingTaxCode = obj[P_WHoldingTaxCode].ToString();
//                if (obj.Table.Columns.Contains(P_RecipientType))
//                    RecipientType = obj[P_RecipientType].ToString();
//                if (obj.Table.Columns.Contains(P_WithHoldingTaxID))
//                    WithHoldingTaxID = obj[P_WithHoldingTaxID].ToString();
//                if (obj.Table.Columns.Contains(P_IssuedOn) && obj[P_IssuedOn].ToString() != "" && obj[P_IssuedOn] is DateTime)
//                    IssuedOn = (DateTime)obj[P_IssuedOn];
//                if (obj.Table.Columns.Contains(P_IssuedBy))
//                    IssuedBy = obj[P_IssuedBy].ToString();
//                if (obj.Table.Columns.Contains(P_MMOrderCurrency))
//                    MMOrderCurrency = obj[P_MMOrderCurrency].ToString();
//                if (obj.Table.Columns.Contains(P_User_ID))
//                    User_ID = obj[P_User_ID].ToString();
//                if (obj.Table.Columns.Contains(P_Status))
//                    Status = obj[P_Status].ToString();
//                if (obj.Table.Columns.Contains(P_UpdateDate) && obj[P_UpdateDate].ToString() != "" && obj[P_UpdateDate] is DateTime)
//                    UpdateDate = (DateTime)obj[P_UpdateDate];
//                if (obj.Table.Columns.Contains(P_Email_Sent))
//                    Email_Sent = obj[P_Email_Sent].ToString();
//                if (obj.Table.Columns.Contains(P_Email_Sent_Date) && obj[P_Email_Sent_Date].ToString() != "" && obj[P_Email_Sent_Date] is DateTime)
//                    Email_Sent_Date = (DateTime)obj[P_Email_Sent_Date];
//                if (obj.Table.Columns.Contains(P_SAP_Vendor_ID))
//                    SAP_Vendor_ID = obj[P_SAP_Vendor_ID].ToString();
//                if (obj.Table.Columns.Contains(P_CompanyType))
//                    CompanyType = obj[P_CompanyType].ToString();
//                if (obj.Table.Columns.Contains(P_ComCate1))
//                    ComCate1 = obj[P_ComCate1].ToString();
//                if (obj.Table.Columns.Contains(P_ComCate2))
//                    ComCate2 = obj[P_ComCate2].ToString();
//                if (obj.Table.Columns.Contains(P_ComCate3))
//                    ComCate3 = obj[P_ComCate3].ToString();
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAP_Vendor
{
    public static class CATEGORY
    {
        public const string PAYMENT = "Payment";
        public const string CURRENCY = "Currency";
        public const string COUNTRY = "Country";
        public const string WITHOLDING_TAX_FIELD = "Withholding Tax Field";
        
        public static List<string> List
        {
            get
            {
                return new List<string> {
                    PAYMENT,
                    CURRENCY,
                     COUNTRY,
                     WITHOLDING_TAX_FIELD
                };
            }
        }
    }
}
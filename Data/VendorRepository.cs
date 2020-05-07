using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Telerik.Windows.Documents.Spreadsheet.Expressions.Functions;

namespace SAP_Vendor.Data
{
    public partial class VendorRepository : SAP_Vendor.Data.VendorEntities
    {
        public void BindListItems(ListControl list, string category)
        {
            try
            {
                list.Items.Clear();
                list.Items.Insert(0, new ListItem("", ""));
                var items = SAP_Vendor_Items.Where(d => d.Category == category && d.Enable == "1").Select(d=> new {d.Value,d.Description }).OrderBy(d => d).ToList();
                foreach (var item in items)
                {
                    list.Items.Add(new ListItem(item.Description, item.Value));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SAP_Vendor_Items> GetTQListItems(string category)
        {
            return SAP_Vendor_Items.Where(d => d.Category == category).OrderBy(d => d.Value).ToList();
        }

        public List<string> GetListItemTitles(string category)
        {
            return SAP_Vendor_Items.Where(d => d.Category == category && d.Enable == "1").Select(d => d.Value).OrderBy(d => d).ToList();
        }
        public List<ListItem> GetListItems(string category, string title)
        {
            try
            {
                var list = new List<ListItem>();               
                if (!string.IsNullOrEmpty(title))
                {
                   var items = SAP_Vendor_Items.Where(d => d.Category == category && d.Enable == "1" && d.Value.ToLower().Trim().Contains(title.ToLower().Trim())).Take(500).Select(d => new { d.Value, d.Description }).OrderBy(d => d).ToList();
                    foreach (var item in items)
                    {
                        list.Add(new ListItem(item.Description, item.Value));
                    }
                }
                else
                {

                   var items = SAP_Vendor_Items.Where(d => d.Category == category && d.Enable == "1").Take(500).Select(d => new { d.Value, d.Description }).OrderBy(d => d).ToList();

                    foreach (var item in items)
                    {
                        list.Add(new ListItem(item.Description, item.Value));
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SAP_Vendor.Data.SAP_VendorCreation AddVendorCreation(string initiatorId, string initiatorName)
        {
            try
            {
                SAP_VendorCreation objMain = SAP_VendorCreation.Where(d => d.InitiatorId == initiatorId && d.Status == 60).FirstOrDefault();
                if (objMain != null)
                {                             
                    return objMain;
                }
                else
                {
                    string requestId = Guid.NewGuid().ToString();
                    objMain = new SAP_VendorCreation();
                    objMain.InitiatorId = initiatorId;
                    objMain.InitiatorName = initiatorName;                   
                    objMain.Status = 60;
                    objMain.IncidentNo = 0;                    
                    objMain.RequestId = requestId;
                    this.Entry<SAP_VendorCreation>(objMain).State = EntityState.Added;
                   var count = this.SaveChanges();
                    return objMain;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public SAP_VendorCreation ClearVendorCreation(string requestId, string initiatorId, string initiatorName)
        {
            try
            {
                SAP_VendorCreation objMain = SAP_VendorCreation.Where(d => d.RequestId == requestId && d.Status == 60).FirstOrDefault();
                if (objMain != null)
                {
                    this.Entry(objMain).State = EntityState.Detached;
                    objMain = new SAP_VendorCreation();
                    objMain.RequestId = requestId;
                    objMain.InitiatorId = initiatorId;
                    objMain.InitiatorName = initiatorName;
                    objMain.Status = 60;
                    objMain.IncidentNo = 0;

                    this.SAP_VendorCreation.Attach(objMain);
                    this.Entry(objMain).State = EntityState.Modified;
                    this.SAP_VendorAttachment.Where(d => d.RequestId == requestId).ToList().RemoveAll(d => d.RequestId == requestId);
                    this.SaveChanges();
                    return objMain;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #region SAP_VendorCreation
        public SAP_VendorCreation GetVendorCreation(string requestId)
        {
            return SAP_VendorCreation.Where(d => d.RequestId == requestId).FirstOrDefault();
        }
        #endregion
        #region SAP_VendorCreationLog
        public SAP_VendorCreationLog GetVendorCreationLog(string requestId, string activity, string taskId)
        {
            return SAP_VendorCreationLog.Where(d => d.RequestId == requestId && d.Activity == activity && d.TaskId == taskId).FirstOrDefault();
        }
        public List<SAP_VendorCreationLog> GetVendorCreationLogs(string requestId)
        {
            //return SAP_VendorCreationLog.Where(d => d.RequestId == requestId && d.Activity != "Start" && d.Activity != "Return").OrderBy(d => d.Id).ToList();
            return SAP_VendorCreationLog.Where(d => d.RequestId == requestId).OrderBy(d => d.Id).ToList();
        }
        public SAP_VendorCreationLog GetVendorCreationLog(SAP_VendorCreation main, string activity, string taskId)
        {           
            var log = GetVendorCreationLog(requestId: main.RequestId, activity: activity, taskId: taskId);
            if (log == null)
                log = new SAP_VendorCreationLog { Id = 0 };
            log.CreatedDate = DateTime.Now;
            log.AccountNoIBAN = main.AccountNoIBAN;
            log.ActiveActivity = main.ActiveActivity;
            log.ActiveUserId = main.ActiveUserId;
            log.ActiveUserName = main.ActiveUserName;
            log.Activity = main.Activity;
            log.Address = main.Address;
            log.BankAddress = main.BankAddress;

            log.BenificaryName = main.BenificaryName;
            log.BusinessName = main.BusinessName;
            log.City = main.City;
            log.Classification = main.Classification;
            log.CompanyType = main.CompanyType;

            log.ContactPerson = main.ContactPerson;
            log.Country = main.Country;
            log.CreatedDate = main.CreatedDate;

            log.Email = main.Email;
            log.EmailSent = main.EmailSent;
            log.EmailSentDate = main.EmailSentDate;
            log.FaxNo = main.FaxNo;

            log.IncidentNo = main.IncidentNo;
            log.InitiatedDate = main.InitiatedDate;

            log.InitiatorId = main.InitiatorId;
            log.InitiatorName = main.InitiatorName;
            log.IssuedBy = main.IssuedBy;
            log.IssuedOn = main.IssuedOn;
            log.NatureOfWork = main.NatureOfWork;


            log.NTNNo = main.NTNNo;
            log.PaymentCurrency = main.PaymentCurrency;
            log.PaymentMethod = main.PaymentMethod;
            log.PaymentTerms = main.PaymentTerms;
            log.PeriodUpto = main.PeriodUpto;
            log.PhoneNo = main.PhoneNo;
            log.PostalCode = main.PostalCode;
            log.Qualification = main.Qualification;
            log.QuestionnaireCompleted = main.QuestionnaireCompleted;
            log.RegNA = main.RegNA;
            log.RequestId = main.RequestId;
            log.RequestType = main.RequestType;
            log.Reason = main.Reason;

            log.ReturnEmails = main.ReturnEmails;
            log.RoutingNo = main.RoutingNo;
            log.SAPVendorId = main.SAPVendorId;
            log.State = main.State;
            log.Status = main.Status;
            log.SwiftCode = main.SwiftCode;
            log.TaskId = main.TaskId;
            log.TaxRegNo = main.TaxRegNo;

            log.ToEmails = main.ToEmails;
            log.UpdatedDate = main.UpdatedDate;
            log.UserId = main.UserId;
            log.UserName = main.UserName;

            log.WithholdingTax = main.WithholdingTax;
            log.Remarks = main.Remarks;

            return log;
        }
        #endregion
    }
}
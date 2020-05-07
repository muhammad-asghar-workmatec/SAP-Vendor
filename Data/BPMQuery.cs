using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SAP_Vendor.Data
{
    public class TaskLog
    {
        public string TaskId { get; set; }
        public string Activity { get; set; }
        public string UserName { get; set; }

        public string JobTitle { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Remarks { get; set; }
        public string Action { get; set; }
    }
    public class BPMQuery : WPClient.Query
    {
        public BPMQuery(string connectionString) : base(connectionString) { }
        public List<TaskLog> GetTaskLogs(string processName, int incidentNo)
        {
            string query = @"SELECT T00001.T1F0001 AS TaskId,  T00001.T1F0022 AS Remarks, T00001.T1F0021 AS Action, ISNULL(T00009.T9F0007, T00001.T1F0005) AS UserName, T00009.T9F0002 AS JobTitle, 
                      T00001.T1F0008 AS CreatedDate, T00001.T1F0003 AS Activity
FROM         T00001 RIGHT OUTER JOIN
                      T00009 ON T00001.T1F0005 = T00009.T9F0003
WHERE(T00001.T1F0002 = @ProcessName) AND(T00001.T1F0004 = @IncidentNo) AND(T00001.T1F0009 IN(3, 4))AND(T00001.T1F0012 IN(2, 4))
ORDER BY CreatedDate";
            ClearParameters();
            AddParameter("@ProcessName", processName);
            AddParameter("@IncidentNo", incidentNo);
            DataTable dt = GetDataTable(query);
            List<TaskLog> taskLogs = new List<TaskLog>();
            foreach (DataRow row in dt.Rows)
            {
                var t = new TaskLog();
                t.TaskId = row["TaskId"].ToString();
                t.Activity = row["Activity"].ToString();
                t.UserName = row["UserName"].ToString();
                t.JobTitle = row["JobTitle"].ToString();
                t.Remarks = row["Remarks"].ToString();
                t.Action = row["Action"].ToString();
                t.CreatedDate = (DateTime)row["CreatedDate"];
                taskLogs.Add(t);
            }
            return taskLogs;
        }
    }
}
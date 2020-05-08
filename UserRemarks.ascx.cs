using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace SAP_Vendor
{
    public partial class UserRemarks : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void LoadRemarks(string ProcessName, int IncidentNo, string ConnectionString)
        {
            try
            {
                DSRemarks.ConnectionString = ConnectionString;
                DSRemarks.SelectParameters.Clear();
                DSRemarks.SelectParameters.Add("ProcessName", ProcessName);
                DSRemarks.SelectParameters.Add("IncidentNo", IncidentNo.ToString());
                dgProcess.Visible = true;
                dgProcess.DataBind();
            }
            catch (Exception ex)
            {
                lblErrorBottom.Text = ex.Message;
            }
        }
        public void LoadRemarks(WPClient.BPMExecution objBPMEx)
        {
            try
            {
                if (objBPMEx == null || objBPMEx.IncidentNo <= 0)
                {
                    dgProcess.Visible = false;
                    return;
                }
                LoadRemarks(objBPMEx.ProcessName, objBPMEx.IncidentNo, objBPMEx.ConnectionString);
            }
            catch (Exception ex)
            {
                lblErrorBottom.Text = ex.Message;
            }
        }
        protected void dgProcess_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row != null && e.Row.DataItem != null)
            {
                var radEditorRemarks = (RadEditor)e.Row.FindControl("radEditorRemarks");
                var row = ((System.Data.DataRowView)e.Row.DataItem).Row;
                if (radEditorRemarks != null && row != null)
                {
                    string Remarks = row["Remarks"] as string;
                    radEditorRemarks.Content = Remarks;
                }
            }
        }
    }
}
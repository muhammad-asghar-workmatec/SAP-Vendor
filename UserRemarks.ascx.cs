using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
    }
}
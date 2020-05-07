using SAP_Vendor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace SAP_Vendor
{
    public partial class Report : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.lblError.Text = "";
                
                if (!IsPostBack)
                {
                    ViewState["query"] = "";
                    LoadControls();

                }
                else DSGrid.SelectCommand = (string)ViewState["query"];
            }
            catch (Exception ex)
            {

                this.ErrorMessage = ex.Message;
            }

        }
        public void LoadControls()
        {
            try
            {
                var date1 = DateTime.Today.AddYears(-1);
                var date2 = DateTime.Today.AddDays(1);
                txtDateFrom.SelectedDate = date1;
                txtDateTo.SelectedDate = date2;               
                btnShow_Click(btnShow, null);
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {

            List<string> items = new List<string>();                       
            if (txtDateFrom.SelectedDate.HasValue)
            {
                var date1 = txtDateFrom.SelectedDate.Value;
                var dateFrom = new DateTime(date1.Year, date1.Month, date1.Day, 00, 00, 00);
                items.Add($"InitiatedDate>='{dateFrom.ToString()}'");
            }
            if (txtDateTo.SelectedDate.HasValue)
            {
                var date2 = txtDateTo.SelectedDate.Value;
                var dateTo = new DateTime(date2.Year, date2.Month, date2.Day, 23, 59, 59);
                items.Add($"InitiatedDate<='{dateTo.ToString()}'");
            }
            if (!string.IsNullOrWhiteSpace(txtBusinessName.Text))
            {
                items.Add($"BusinessName like'%{txtBusinessName.Text.Trim()}%'");
            }
            if (!string.IsNullOrWhiteSpace(txtVendorId.Text))
            {
                items.Add($"SAPVendorId like'%{txtVendorId.Text.Trim()}%'");
            }
            //var m = new TQMain();

            string query = "SELECT *, DATEDIFF(day, GETDATE(), InitiatedDate) as Aging, DATEDIFF(day, GETDATE(), UpdatedDate) as CurrentAging FROM SAP_VendorCreation ";
            if (items.Count > 0)
            {
                query += " where " + string.Join(" and ", items);
            }
            query += " ORDER BY [IncidentNo] DESC ";
            ViewState["query"] = query;
            DSGrid.SelectCommand = query;
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //
        }


        
        protected void ButtonExcel_Click(object sender, EventArgs e)
        {
            //Response.Clear();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment;filename=operations-eTQ.xls");
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-excel";
            //System.IO.StringWriter sw = new System.IO.StringWriter();
            //HtmlTextWriter hw = new HtmlTextWriter(sw);
            var GridviewExcel = radGrid;
            GridviewExcel.AllowPaging = false;
            int pageSize = GridviewExcel.PageSize;
            GridviewExcel.PageSize = 5000;
            GridviewExcel.ExportSettings.IgnorePaging = true;
            
            GridviewExcel.DataBind();
            //GridviewExcel.RenderControl(hw);
            radGrid.ExportToExcel();
            //GridviewExcel.PageSize = pageSize;
            //radGrid.AllowPaging = true;
            //GridviewExcel.DataBind();
            //string style = @"<style> .textmode { } </style>";
            //Response.Write(style);
            //Response.Output.Write(sw.ToString());
            //Response.Flush();
            //Response.End();
        }

        protected void radGrid_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item != null && e.Item.DataItem != null)
            {
                var row = ((System.Data.DataRowView)e.Item.DataItem).Row;
                if (row != null)
                {

                    var lblAging = (Label)e.Item.FindControl("lblAging");
                    var lblCurrentAging = (Label)e.Item.FindControl("lblCurrentAging");
                    if (lblAging != null && lblCurrentAging != null)
                    {
                        DateTime? InitiatedDate = (DateTime?)row["InitiatedDate"];

                        double aging = 0;
                        double currentAging = 0;
                        int Status = (int)row["Status"];
                       // string activeActivity = (string)row["ActiveActivity"];
                        DateTime? UpdatedDate = (DateTime?)row["UpdatedDate"];

                        if (Status == 3 || Status == -1)
                        {

                            aging = Math.Ceiling(UpdatedDate.Value.Subtract(InitiatedDate.Value).TotalDays);
                            currentAging = 0;

                        }
                        else//Activity Active
                        {
                            aging = Math.Ceiling(DateTime.Now.Subtract(InitiatedDate.Value).TotalDays);
                            currentAging = Math.Ceiling(DateTime.Now.Subtract(UpdatedDate.Value).TotalDays);
                        }
                        if (aging > 1)
                            lblAging.Text = aging.ToString() + " days";
                        else
                            lblAging.Text = aging.ToString() + " day";

                        if (currentAging > 1)
                            lblCurrentAging.Text = currentAging.ToString() + " days";
                        else if (currentAging > 0)
                            lblCurrentAging.Text = currentAging.ToString() + " day";
                    }
                    var link = (HyperLink)e.Item.FindControl("linkView");
                   // var radEditorRemarks = (RadEditor)e.Item.FindControl("radEditorRemarks");
                    if (link != null)
                    {

                        string TaskId = row["TaskId"] as string;                        
                            link.NavigateUrl = UrlHelpers.ToAbsolute("~/print.aspx?TaskID=" + TaskId);
                        //string Remarks = row["Remarks"] as string;
                        //radEditorRemarks.Content = Remarks;
                    }
                }

            }
        }
        //protected void gvListItems_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.DataItem != null)
        //    {
        //        var link = (HyperLink)e.Row.FindControl("linkView");
        //        var row = ((System.Data.DataRowView)e.Row.DataItem).Row;
        //        string TaskId = row["TaskId"] as string;
        //        string TQType = row["TQType"] as string;
        //        if (TQType == "Operations")
        //            link.NavigateUrl = "~/Operations/CompletedView.aspx?TaskID=" + TaskId;
        //        else
        //            link.NavigateUrl = "~/Construction/CompletedView.aspx?TaskID=" + TaskId;
        //    }
        //}
    }
}
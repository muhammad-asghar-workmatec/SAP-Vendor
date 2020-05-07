<%@ Page Title="eTQ" Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="SAP_Vendor.Report" StylesheetTheme="Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/Controls/Header.ascx" TagPrefix="uc1" TagName="Header" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title>Maximo Vendor Creation Form</title>
    <link href="stlLoan.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .style1
        {
            height: 40px;
        }
        </style>
    <script type="text/javascript" src="Scripts/jquery-3.3.1.min.js"></script>

</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
         <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        </telerik:RadAjaxManager>
        <telerik:RadScriptManager ID="ScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <div class="DivBody">
            <div class="DivHeader">
                <uc1:Header runat="server" ID="Header1" Title="" />
            </div>
            <div class="DivContent">
                <div class="RepFilterBG" style="text-align: left">
                    <div class="clearfix"></div>
                    <div>
                        <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                    </div>
                    <br />
                    <div class="clearfix"></div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="txtDateFrom" class="col-sm-3">Date From :  </label>
                                <div class="col-sm-9">
                                    <telerik:RadDatePicker ID="txtDateFrom" runat="server"></telerik:RadDatePicker>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="txtDateTo" class="col-sm-3">
                                    Date To :
                                </label>
                                <div class="col-sm-9">
                                    <telerik:RadDatePicker ID="txtDateTo" runat="server"></telerik:RadDatePicker>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="txtDateFrom" class="col-sm-3">Business Name :  </label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtBusinessName" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">   
                                 <label for="txtCRFNo" class="col-sm-3">SAP Vendor ID :  </label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtVendorId" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div style="text-align: right; padding-right: 5px; padding-top: 10px">
                        <asp:Button ID="btnShow" runat="server" CssClass="btn btn-primary"
                            Text="Show" OnClick="btnShow_Click" />
                          <asp:Button ID="btnExport" runat="server" CssClass="btn btn-primary"
                            Text="Export to Excel" OnClick="ButtonExcel_Click" />
                    </div>
                    <br />
                    <div class="clearfix"></div>
                    <div class="clearfix"></div>
                    <div class="form-group" align="left" style="overflow: scroll; width: 100%">
                           <telerik:RadGrid ID="radGrid" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="DSGrid" Skin="Bootstrap" OnItemDataBound="radGrid_ItemDataBound" RenderMode="Lightweight" CellSpacing="-1" GridLines="Both" >

<GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
                            <ExportSettings FileName="eTQ Data">
                            </ExportSettings>
                            <ClientSettings AllowColumnsReorder="True" AllowDragToGroup="True" ReorderColumnsOnClient="True">
                            </ClientSettings>
                               <MasterTableView DataKeyNames="RequestId" DataSourceID="DSGrid">
                                   <Columns>
                                               <telerik:GridTemplateColumn>
                                   <ItemTemplate>
                                       <asp:HyperLink ID="linkView" Target="_blank" Text="View" runat="server"></asp:HyperLink>
                                   </ItemTemplate>
                                </telerik:GridTemplateColumn>     
                                    <telerik:GridBoundColumn DataField="IncidentNo" HeaderText="Ref #" SortExpression="IncidentNo" />
                                     
                                        <telerik:GridTemplateColumn HeaderText="Aging" SortExpression="Aging">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAging" Text="" runat="server"></asp:Label>
                                        </ItemTemplate>
                                         <ItemStyle Width="100px"></ItemStyle>
                                    </telerik:GridTemplateColumn>
                                                                     <telerik:GridTemplateColumn HeaderText="Current Aging" SortExpression="CurrentAging">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCurrentAging" Text="" runat="server"></asp:Label>
                                        </ItemTemplate>
                                         <ItemStyle Width="100px"></ItemStyle>
                                    </telerik:GridTemplateColumn>
                                       <telerik:GridBoundColumn DataField="RequestType" FilterControlAltText="Filter RequestType column" HeaderText="Request Type" SortExpression="RequestType" UniqueName="RequestType">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="Reason" FilterControlAltText="Filter Reason column" HeaderText="Reason" SortExpression="Reason" UniqueName="Reason">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="BusinessName" FilterControlAltText="Filter BusinessName column" HeaderText="Business Name" SortExpression="BusinessName" UniqueName="BusinessName">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="Country" FilterControlAltText="Filter Country column" HeaderText="Country" SortExpression="Country" UniqueName="Country">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="PostalCode" FilterControlAltText="Filter PostalCode column" HeaderText="Postal Code" SortExpression="PostalCode" UniqueName="PostalCode">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="City" FilterControlAltText="Filter City column" HeaderText="City" SortExpression="City" UniqueName="City">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="CompanyType" FilterControlAltText="Filter CompanyType column" HeaderText="Company Type" SortExpression="CompanyType" UniqueName="CompanyType">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="NTNNo" FilterControlAltText="Filter NTNNo column" HeaderText="NTN#" SortExpression="NTNNo" UniqueName="NTNNo">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="TaxRegNo" FilterControlAltText="Filter TaxRegNo column" HeaderText="Tax Reg#" SortExpression="TaxRegNo" UniqueName="TaxRegNo">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="PaymentCurrency" FilterControlAltText="Filter PaymentCurrency column" HeaderText="Currency" SortExpression="PaymentCurrency" UniqueName="PaymentCurrency">
                                       </telerik:GridBoundColumn>
                                       
                                       <telerik:GridBoundColumn DataField="State" FilterControlAltText="Filter State column" HeaderText="State" SortExpression="State" UniqueName="State">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="Address" FilterControlAltText="Filter Address column" HeaderText="Address" SortExpression="Address" UniqueName="Address">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="PhoneNo" FilterControlAltText="Filter PhoneNo column" HeaderText="Phone" SortExpression="PhoneNo" UniqueName="PhoneNo">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="FaxNo" FilterControlAltText="Filter FaxNo column" HeaderText="Fax No" SortExpression="FaxNo" UniqueName="FaxNo">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="Email" FilterControlAltText="Filter Email column" HeaderText="Email" SortExpression="Email" UniqueName="Email">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="ContactPerson" FilterControlAltText="Filter ContactPerson column" HeaderText="Contact Person" SortExpression="ContactPerson" UniqueName="ContactPerson">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="PaymentMethod" FilterControlAltText="Filter PaymentMethod column" HeaderText="Payment Method" SortExpression="PaymentMethod" UniqueName="PaymentMethod">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="NatureOfWork" FilterControlAltText="Filter NatureOfWork column" HeaderText="Nature Of Work" SortExpression="NatureOfWork" UniqueName="NatureOfWork">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="WithholdingTax" FilterControlAltText="Filter WithholdingTax column" HeaderText="Withholding Tax" SortExpression="WithholdingTax" UniqueName="WithholdingTax">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="Classification" FilterControlAltText="Filter Classification column" HeaderText="Classification" SortExpression="Classification" UniqueName="Classification">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="Qualification" FilterControlAltText="Filter Qualification column" HeaderText="Qualification" SortExpression="Qualification" UniqueName="Qualification">
                                       </telerik:GridBoundColumn>
                                     
                                       <telerik:GridBoundColumn DataField="PeriodUpto" FilterControlAltText="Filter PeriodUpto column" HeaderText="Period Upto" SortExpression="PeriodUpto" UniqueName="PeriodUpto">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="BankAddress" FilterControlAltText="Filter BankAddress column" HeaderText="Bank Name & Address" SortExpression="BankAddress" UniqueName="BankAddress">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="AccountNoIBAN" FilterControlAltText="Filter AccountNoIBAN column" HeaderText="Account#/IBAN" SortExpression="AccountNoIBAN" UniqueName="AccountNoIBAN">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="RoutingNo" FilterControlAltText="Filter RoutingNo column" HeaderText="Routing#" SortExpression="RoutingNo" UniqueName="RoutingNo">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="SwiftCode" FilterControlAltText="Filter SwiftCode column" HeaderText="Swift Code" SortExpression="SwiftCode" UniqueName="SwiftCode">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="BenificaryName" FilterControlAltText="Filter BenificaryName column" HeaderText="BenificaryName" SortExpression="BenificaryName" UniqueName="BenificaryName">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="PaymentTerms" FilterControlAltText="Filter PaymentTerms column" HeaderText="PaymentTerms" SortExpression="PaymentTerms" UniqueName="PaymentTerms">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="Status" DataType="System.Int32" FilterControlAltText="Filter Status column" HeaderText="Status" SortExpression="Status" UniqueName="Status">
                                       </telerik:GridBoundColumn>
                                       
                                       <telerik:GridBoundColumn DataField="SAPVendorId" FilterControlAltText="Filter SAPVendorId column" HeaderText="SAPVendorId" SortExpression="SAPVendorId" UniqueName="SAPVendorId">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="IssuedBy" FilterControlAltText="Filter IssuedBy column" HeaderText="IssuedBy" SortExpression="IssuedBy" UniqueName="IssuedBy">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="IssuedOn" DataType="System.DateTime" FilterControlAltText="Filter IssuedOn column" HeaderText="IssuedOn" SortExpression="IssuedOn" UniqueName="IssuedOn">
                                       </telerik:GridBoundColumn>                                       
                                       <telerik:GridBoundColumn DataField="InitiatorName" FilterControlAltText="Filter InitiatorName column" HeaderText="InitiatorName" SortExpression="Initiator" UniqueName="InitiatorName">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="InitiatedDate" DataType="System.DateTime" FilterControlAltText="Filter InitiatedDate column" HeaderText="Initiated Date" SortExpression="InitiatedDate" UniqueName="InitiatedDate">
                                       </telerik:GridBoundColumn>
                                      
                                       <telerik:GridBoundColumn DataField="UpdatedDate" DataType="System.DateTime" FilterControlAltText="Filter UpdatedDate column" HeaderText="Updated Date" SortExpression="UpdatedDate" UniqueName="UpdatedDate">
                                       </telerik:GridBoundColumn>
                                       
                                   </Columns>
                               </MasterTableView>

<FilterMenu RenderMode="Lightweight"></FilterMenu>

<HeaderContextMenu RenderMode="Lightweight"></HeaderContextMenu>

                        </telerik:RadGrid>

                        <asp:SqlDataSource ID="DSGrid" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [SAP_VendorCreation] WHERE ([Status] &lt;&gt; @Status) ORDER BY [IncidentNo] DESC">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="60" Name="Status" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                </div>

            </div>

        </div>
    </form>
</body>
</html>

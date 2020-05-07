<%@ Page Title="eTQ" Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="SAP_Vendor.ListItemSettings" Theme="Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Src="Controls/Header.ascx" TagName="Header" TagPrefix="uc1" %>

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
    <script type="text/javascript" src="Scripts/telerik.js"></script>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
        <telerik:RadScriptManager ID="ScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <div class="DivBody" style="width:700px">
            <div class="DivHeader">
                <uc1:Header ID="Header1" runat="server" />
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
                        <div class="col-md-12">
                            <div class="form-group">
                                <label for="ddlField" class="col-sm-4">
                                    Category : <span class="required">*</span>
                                </label>
                                <div class="col-sm-8">
                                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="cbo" Width="100%" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" ValidateRequestMode="Enabled" ValidationGroup="A" AutoPostBack="True">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlCategory" ErrorMessage="Category is required." Text="" Display="None" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label for="txtTitle" class="col-sm-4">
                                    Title : <span class="required">*</span>
                                </label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTitle" ErrorMessage="Title is required." Text="" Display="None" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                                        <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label for="txtTitle" class="col-sm-4">
                                    Value : <span class="required">*</span>
                                </label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtValue" runat="server" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorValue" runat="server" ControlToValidate="txtValue" ErrorMessage="Value is required." Text="" Display="None" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                  
                    <div class="clearfix">
                    </div>
                    <div class="tdBorderLine">
                        &nbsp;&nbsp;
                    </div>
                    <div class="form-group" style="text-align: right; padding-right: 5px; padding-top: 10px">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" ValidationGroup="A"
                            OnClick="btnSave_Click" />
                        &nbsp;<asp:Button ID="btnReset" runat="server" CssClass="btn btn-default"
                            Text="Reset"
                            OnClick="btnReset_Click" />
                    </div>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="BulletList" ShowSummary="false" ValidationGroup="A" ShowValidationErrors="true" ShowMessageBox="true" />
                    <div class="clearfix"></div>
                    <div class="form-group" align="left" style="width: 100%">
                        <asp:GridView ID="gvListItems" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="DSListItems"
                            CellPadding="4" DataKeyNames="Id" PageSize="20" Style="position: relative"  CssClass="Grid"
                            OnRowCommand="gvListItems_RowCommand">
                            <RowStyle BackColor="White" />
                            <FooterStyle BackColor="Navy" Font-Bold="True" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" SelectText="Select"  ItemStyle-Width="80px"/>
                                <asp:BoundField DataField="Description" SortExpression="Description" HeaderText="Title" ItemStyle-Width="300px"></asp:BoundField>
                                <asp:BoundField DataField="Value" SortExpression="Value" HeaderText="Value" ItemStyle-Width="300px">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                              

                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/delete.png" ShowDeleteButton="True" ItemStyle-Width="80px"/>
                            </Columns>
                            <RowStyle BackColor="White" />
                            <FooterStyle BackColor="Navy" Font-Bold="True" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="Navy" ForeColor="White" HorizontalAlign="Right" />
                            <HeaderStyle BackColor="Navy" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>

                        <asp:SqlDataSource ID="DSListItems" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM SAP_Vendor_Items WHERE ([Category] = @Category) ORDER BY [Description]" DeleteCommand="delete FROM SAP_Vendor_Items WHERE ([Id] = @Id)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlCategory" Name="Category" PropertyName="SelectedValue" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                </div>
                <asp:HiddenField ID="hidRecordID" runat="server" />
                <asp:HiddenField ID="hidUserID" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
<%--eTQ Title: {obj.Title}
 <br />
You have received above rejected/return task in your inbox from "" {obj.CSEGroup} ""
<p>
    <span style='font-size: 8.5pt; font-family: Arial,sans-serif;'>Dear eTQ Initiator,</span>
</p>

<p style='background: white; line-height: normal; margin-bottom: 0pt;'>
    <span style='font-size: 8.5pt; font-family: Arial,sans-serif;'>Subject eTQ is return by "" {obj.CSEGroup} ""
        </span>
</p>
<br />

<p style='background: white; line-height: normal; margin-bottom: 0pt;'>
    <span style='font-size: 8.5pt; font-family: Arial,sans-serif;'>Please <a href='{AppSettings.BPM_URL+"/Default/Main.aspx"}'>Click here
    </a>to view the BPM task.
    </span>
</p>--%>

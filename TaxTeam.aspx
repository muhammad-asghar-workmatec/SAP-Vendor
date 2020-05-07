<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaxTeam.aspx.cs" Inherits="SAP_Vendor.TaxTeam" StylesheetTheme="Default" %>

<%@ Register Src="~/UserRemarks.ascx" TagPrefix="uc1" TagName="UserRemarks" %>
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
                <telerik:RadScriptManager ID="ScriptManager1" runat="server">
        </telerik:RadScriptManager>
                <div class="DivBody">
            <div class="DivHeader">
                <uc1:Header runat="server" ID="Header1" />
            </div>
  
            <div class="DivContent">
                <div class="RepFilterBG" style="text-align: left; ">
                    <div class="clearfix"></div>
                                <table style="width: 100%;">
                                                
                  <tr>
                                                    <td align="left" style="height: 40px; ">
                                                    </td>
                                                    <td class="style1" colspan="3">
                                                        <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></td>
                                                </tr>
                                                 <tr>
                                                    <td align="left" style="height: 40px; ">
                                                      </td>
                                                    <td class="style1" style="height: 40px; " colspan="3" align="left">
                                                        <asp:RadioButtonList ID="rblOptions" runat="server" RepeatLayout="Table" CellPadding="3" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="New" Value="New" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Change" Value="Change"></asp:ListItem>
                                                            <asp:ListItem Text="Active" Value="Active"></asp:ListItem>
                                                            <asp:ListItem Text="Inactive" Value="Inactive"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                          <asp:RequiredFieldValidator ID="RequiredFieldValidatorOptions" runat="server" ControlToValidate="rblOptions" ErrorMessage="Request type is required." Text="" Display="None" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="height: 40px; ">
                                                 Reason : <span class="required">*</span>
                                                    </td>
                                                    <td class="style1" style="height: 40px; " colspan="3">
                                                        <asp:TextBox ID="txtReason" runat="server" Width="100%" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidatorReason" runat="server" ControlToValidate="txtReason" ErrorMessage="Reason is required." Text="" Display="None" ValidationGroup="A"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="height: 40px; ">
                                                     Business Name : <span class="required">*</span></td>
                                                    <td class="style1" style="height: 40px; " colspan="3">
                                                        <asp:TextBox ID="txtBusinessName" runat="server" Width="100%" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorBusinessName" runat="server" ControlToValidate="txtBusinessName" ErrorMessage="Business Name is required." Text="" Display="None" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                        </td>
                                                </tr>
                                                 <tr>
                                                    <td align="left" style="height: 40px; ">
                                                        NTN# : </td>
                                                    <td class="style1" style="width: 186px; height: 24px">
                                                        <asp:TextBox ID="txtNTN" runat="server" Width="210px" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox>
                                                      
                                                    </td>
                                                    <td class="auto-style5">
                                                        Sale Tax Reg# :</td>
                                                    <td style="height: 40px; ">
                                                        <asp:TextBox ID="txtSaleTaxReg" runat="server" Width="210px" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox>
                                                    </td>
                                                   
                                                </tr>
                                                <tr><td colspan="4" style="text-align:right"><asp:CheckBox ID="txtNA" runat="server" Text="Not Applicable"></asp:CheckBox></td></tr>
                                                <tr>
                                                    <td align="left" style="height: 40px; ">
                                                        Type : <span class="required">*</span>
                                                      </td>
                                                    <td class="style1" style="height: 40px; " colspan="3" align="left">
                                                        <asp:RadioButtonList ID="rblType" runat="server" RepeatLayout="Table" CellPadding="3" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="Supplier" Value="Supplier" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Vendor Return" Value="Vendor Return"></asp:ListItem>                        
                                                        </asp:RadioButtonList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorType" runat="server" ControlToValidate="rblType" ErrorMessage="Vendor Type is required." Text="" Display="None" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td align="left" style="height: 40px; ">
                                                        Payment Currency : <span class="required">*</span>
                                                      </td>
                                                    <td class="style1" style="height: 40px; " colspan="3" align="left">
                                                         <asp:DropDownList ID="ddlCurrency" runat="server" CssClass="cbo" Width="100%">
                                                        </asp:DropDownList>   
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCurrency" runat="server" ControlToValidate="ddlCurrency" ErrorMessage="Payment Currency is required." Text="" Display="None" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td align="left" style="height: 40px; ">
                                                        Address : <span class="required">*</span></td>
                                                  <td class="style1" style="height: 40px; " colspan="3">
                                                        <asp:TextBox ID="txtAddress" runat="server" Width="100%" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox>
                                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAddress" ErrorMessage="Vendor Address is required." Text="" Display="None" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                  </td>                                                   
                                                </tr>
                                               
                                                <tr>
                                                    <td align="left" style="height: 40px; ">
                                                        City : <span class="required">*</span></td>
                                                    <td class="style1" style="width: 186px">
                                                        <asp:TextBox ID="txtCity" runat="server" Width="210px" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidatorCity" runat="server" ControlToValidate="txtCity" ErrorMessage="City is required." Text="" Display="None" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td class="auto-style2">
                                                        State : <span class="required">*</span></td>
                                                    <td style="height: 40px; ">
                                                        <asp:TextBox ID="txtState" runat="server" Width="210px" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidatorState" runat="server" ControlToValidate="txtState" ErrorMessage="State is required." Text="" Display="None" ValidationGroup="A"></asp:RequiredFieldValidator>

                                                    </td>
                                                        
                                                </tr>
                                                <tr><td style="height: 40px; ">
                                                        Postal Code : <span class="required">*</span>
                                                    </td>
                                                    <td style="height: 40px; ">
                                                        <asp:TextBox ID="txtPostalCode" runat="server" Width="210px" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidatorPostalCode" runat="server" ControlToValidate="txtPostalCode" ErrorMessage="Postal Code is required." Text="" Display="None" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td align="left" class="auto-style2">
                                                     Country : <span class="required">*</span></td>
                                                    <td class="style1" style="width: 186px">
                                                        <asp:DropDownList ID="ddlCountry" runat="server" CssClass="cbo" Width="210px">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCountry" runat="server" ControlToValidate="ddlCountry" ErrorMessage="Country is required." Text="" Display="None" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </td>
                                                    
                                                </tr>
                                                <tr>
                                                    <td align="left" style="height: 40px; ">
                                                        Contact No : <span class="required">*</span></td>
                                                    <td class="style1" style="width: 186px; height: 24px">
                                                        <asp:TextBox ID="txtContactNo" runat="server" Width="210px" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorContactNo" runat="server" ControlToValidate="txtContactNo" ErrorMessage="Contact No is required." Text="" Display="None" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td class="auto-style5">
                                                        Fax No : </td>
                                                    <td style="height: 40px; ">
                                                        <asp:TextBox ID="txtFaxNo" runat="server" Width="210px" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox>
                                                        
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="height: 40px; ">
                                                        Email : <span class="required">*</span></td>
                                                    <td class="style1" style="width: 186px; height: 24px" colspan="3">
                                                        <asp:TextBox ID="txtEmail" runat="server" Width="100%" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required." Text="" Display="None" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </td>
                                                    
                                                </tr>
                                                <tr>
                                                    <td align="left" style="height: 40px; ">
                                                        Contact Person : <span class="required">*</span></td>
                                                    <td class="style1" style="width: 186px; height: 24px" colspan="3">
                                                        <asp:TextBox ID="txtContactPerson" runat="server" Width="100%" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorContactPerson" runat="server" ControlToValidate="txtContactPerson" ErrorMessage="Contact Person is required." Text="" Display="None" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </td>                                                    
                                                </tr>
                                                <tr>
                                                    <td align="left" style="height: 40px; ">
                                                        Payment Terms : <span class="required">*</span></td>
                                                    <td class="style1" style="width: 186px; height: 24px" colspan="3">
                                                        <asp:DropDownList ID="ddlPaymentTerms" runat="server" CssClass="cbo" Width="100%">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPaymentTerms" runat="server" ControlToValidate="ddlPaymentTerms" ErrorMessage="Payment Terms is required." Text="" Display="None" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                        </td>                                                    
                                                </tr>
                                                 <tr>
                                                    <td align="left" style="height: 40px; ">
                                                        Payment Method : <span class="required">*</span>
                                                      </td>
                                                    <td class="style1" style="height: 40px; " colspan="3" align="left">
                                                        <asp:RadioButtonList ID="rblPaymentMethod" runat="server" RepeatLayout="Table" CellPadding="3" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="Cheque" Value="Cheque" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Wire transfer" Value="Wire transfer"></asp:ListItem>                        
                                                        </asp:RadioButtonList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPaymentMethod" runat="server" ControlToValidate="rblPaymentMethod" ErrorMessage="Payment Method is required." Text="" Display="None" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td align="left" style="height: 40px; ">
                                                        Nature of Work : <span class="required">*</span>
                                                      </td>
                                                    <td class="style1" style="height: 40px; " colspan="3" align="left">
                                                        <asp:RadioButtonList ID="rblNaturOfWork" runat="server" RepeatLayout="Table" CellPadding="3" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="Supplies" Value="Supplies" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Services/Contract" Value="Services/Contract"></asp:ListItem> 
                                                            <asp:ListItem Text="Other" Value="Other"></asp:ListItem> 
                                                        </asp:RadioButtonList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorNatureofWork" runat="server" ControlToValidate="rblNaturOfWork" ErrorMessage="Nature of Work is required." Text="" Display="None" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="height: 22px; ">
                                                     Withholding Tax Field : </td>
                                                    <td class="style1" style="width: 186px">
                                                        <asp:DropDownList ID="ddlWitholdingTaxField" runat="server" CssClass="cbo" Width="100%">
                                                        </asp:DropDownList>
                                                        
                                                    </td>
                                                    
                                                </tr>
                                                 <tr>
                                                    <td align="left" style="height: 40px; " colspan="2">
                                                        Pre-qualification Questionnaire Completed and Attached : <span class="required">*</span>
                                                      </td>
                                                    <td class="style1" style="height: 40px; " colspan="2" align="left">
                                                        <asp:RadioButtonList ID="rblAttached" runat="server" RepeatLayout="Table" CellPadding="3" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="Yes" Value="Yes" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="No" Value="No"></asp:ListItem>                        
                                                        </asp:RadioButtonList>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidatorAttached" runat="server" ControlToValidate="rblAttached" ErrorMessage="Pre-qualification Questionnaire Completed and Attached is required." Text="" Display="None" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td align="left" style="height: 40px; ">
                                                        Pre-qualification Classification : <span class="required">*</span>
                                                      </td>
                                                    <td class="style1" style="height: 40px; " colspan="3" align="left">
                                                        <asp:RadioButtonList ID="rblClassification" runat="server" RepeatLayout="Table" CellPadding="3" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="High(>$300K)" Value="High(>$300K)" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Medium(>$10K <=$300K)" Value="Medium(>$10K <=$300K)"></asp:ListItem> 
                                                            <asp:ListItem Text="Low(<=$10K)" Value="Low(<=$10K)"></asp:ListItem>  
                                                        </asp:RadioButtonList>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidatorClassification" runat="server" ControlToValidate="rblClassification" ErrorMessage="Pre-qualification Classification is required." Text="" Display="None" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="height: 40px; ">
                                                        Pre-qualification : <span class="required">*</span>
                                                      </td>
                                                    <td class="style1" style="height: 40px; " colspan="1" align="left">
                                                        <asp:RadioButtonList ID="rblQualification" runat="server" RepeatLayout="Table" CellPadding="3" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="Confirmed" Value="Confirmed" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Probation" Value="Probation"></asp:ListItem>                                                                 
                                                        </asp:RadioButtonList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorQualification" runat="server" ControlToValidate="rblQualification" ErrorMessage="Pre-qualification is required." Text="" Display="None" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </td>
                                                     <td class="auto-style5">
                                                        Probation Period Upto : </td>
                                                    <td style="height: 40px; ">
                                                        <asp:TextBox ID="txtPeriod" runat="server" Width="210px" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox>
                                                    </td>
                                                </tr>
                                               <tr><td colspan="4" style="font-size: medium;color:dodgerblue">Incase of foregion vendors only</td></tr>                                                                                              
                                                <tr>
                                                    <td align="left" style="height: 40px; ">
                                                        Bank Name & Address : </td>
                                                      <td class="style1" style="height: 40px; " colspan="3">
                                                        <asp:TextBox ID="txtBankAddress" runat="server" Width="100%" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox></td>
                                                    
                                                </tr>
                                                <tr>
                                                    <td align="left" style="height: 40px; ">
                                                        Account#/IBAN : </td>
                                                   <td class="style1" style="height: 40px; " colspan="3">
                                                       <asp:TextBox ID="txtIBAN" runat="server" Width="100%" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox></td>                                                    
                                                </tr>
                                                <tr>
                                                    <td align="left" style="height: 40px; ">
                                                        Routing# : </td>
                                                    <td class="style1" style="height: 40px; " colspan="3">
                                                        <asp:TextBox ID="txtRoutingNo" runat="server" Width="100%" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox></td>                                                   
                                                </tr>
                                                <tr>
                                                    <td align="left" style="height: 40px; ">
                                                        Swift Code :                                                      </td>
                                                   <td class="style1" style="height: 40px; " colspan="3">
                                                        <asp:TextBox ID="txtSwiftCode" runat="server" Width="100%" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox></td>                                                  
                                                </tr>
                                                <tr>
                                                    <td align="left" style="height: 40px; ">
                                                        Vendor/Benificary Name : </td>
                                                       <td class="style1" style="height: 40px; " colspan="3">
                                                        <asp:TextBox ID="txtBenificaryName" runat="server" Width="100%" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox></td>
                                                   
                                                </tr>
                                              
                                               <%-- <tr>
                                                    <td align="left" style="width: 145px; height: 24px">
                                                        SAP Vendor ID : <span class="required">*</span></td>
                                                    <td class="style1" style="width: 186px; height: 24px">
                                                        <asp:TextBox ID="txtVendorID" runat="server" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox></td>
                                                    <td style="height: 40px; ">
                                                        &nbsp;</td>
                                                    <td style="height: 40px; ">
                                                        &nbsp;</td>
                                                </tr>--%>
                                              
                                                <tr>
                                                    <td align="left" class="Line" colspan="4" style="height: 26px">
                                                        Attachment (If any) :</td>
                                                </tr>
                                                 
 <tr id="panelNewAttachment" runat="server" visible="false">
     <td>Attachment : <span class="required">*</span></td>
                                                    <td>
                                                      
                                        <div class="demo-container size-wide">
                                            <telerik:RadAsyncUpload RenderMode="Lightweight" runat="server" ID="fuFile" MultipleFileSelection="Automatic" DropZones=".DropZone1" HideFileInput="true" Width="100%" />
                                            <div class="DropZone1">
                                                <p>
                                                    <br />
                                                    Drop Files Here
                                                <br />
                                                </p>
                                            </div>
                                        </div>
                                                        </td>
                                    
                            <td>
                               
                                        File Description : <span class="required">*</span>
                                   </td>
                                                        <td>
                                        <asp:TextBox ID="txtFileDesc" runat="server" TextMode="MultiLine" Rows="2" CssClass="form-control" ValidationGroup="Upload" ValidateRequestMode="Enabled" ></asp:TextBox>                                        
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFileDesc" ErrorMessage="File Description is required." Text="" Display="None" ValidationGroup="Upload"></asp:RequiredFieldValidator>
                                        <div style="text-align: right; padding-top: 3px">
                                            <asp:Button ID="btnUpload" runat="server" OnClick="btUpload_Click" ValidationGroup="Upload" ValidateRequestMode="Enabled" Text="Upload" CssClass="btn btn-info" />
                                              <asp:ValidationSummary ID="ValidationSummary2" runat="server" DisplayMode="BulletList" ShowSummary="false" ValidationGroup="Upload"  ShowValidationErrors="true" ShowMessageBox="true"/>
                                       </div>
                            </td>
                                                                                       
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="4" style="height: 26px">
                                                       <asp:GridView ID="dgAttachment" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                           CellPadding="4" DataKeyNames="Id" PageSize="20" Style="position: relative" Width="100%" CssClass="Grid"
                                                           OnRowCommand="Attachments_RowCommand" OnRowDataBound="Attachments_RowDataBound">
    <RowStyle BackColor="White" />
    <FooterStyle BackColor="Navy" Font-Bold="True" />
    <Columns>
        <asp:TemplateField HeaderText="File Name">
            <ItemTemplate>
                <asp:HyperLink ID="lnkAttachment" runat="server" Target="_blank">HyperLink</asp:HyperLink>
            </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
            <ItemStyle HorizontalAlign="Left" Width="150px" />
            <HeaderStyle HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:BoundField DataField="Description" HeaderText="Description">
            <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField DataField="UserName" HeaderText="UserName" ItemStyle-Width="120px">
            <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField DataField="CreatedDate" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Width="80px">
            <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:ButtonField ButtonType="Image" CommandName="AEDelete" ImageUrl="~/Images/delete.png" Text="Delete" ItemStyle-Width="50px" />
    </Columns>
    <RowStyle BackColor="White" />
    <FooterStyle BackColor="Navy" Font-Bold="True" />
    <EditRowStyle BackColor="#2461BF" />
    <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="#333333" />
    <PagerStyle BackColor="Navy" ForeColor="White" HorizontalAlign="Right" />
    <HeaderStyle BackColor="Navy" Font-Bold="True" ForeColor="White" />
    <AlternatingRowStyle BackColor="White" />
</asp:GridView>
                                                        <asp:SqlDataSource ID="dsAttachment" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>">
                                                        </asp:SqlDataSource>
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" style="height: 26px">
                                                    </td>
                                                </tr>
                                                <tr><td>Remarks : <span class="required">*</span></td><td colspan="3">
                                                     <telerik:RadEditor RenderMode="Lightweight" EditModes="Design" EditType="Normal" runat="server" ID="txtRemarks" Width="99%" Height="150px" ToolsFile="~/tools.xml" CssClass="centered-editor" Font-Size="Small" ExternalDialogsPath="~/RadEditorDialogs/" BorderStyle="Solid" BorderColor="#cccccc" BorderWidth="1px">
                                        <ImageManager ViewPaths="~/Documents" UploadPaths="~/Documents" DeletePaths="~/Documents" />
                                        <TemplateManager ViewPaths="~/Documents" UploadPaths="~/Documents" DeletePaths="~/Documents" />
                                        <DocumentManager ViewPaths="~/Documents" UploadPaths="~/Documents" DeletePaths="~/Documents" />
                                        <ExportSettings FileName="export" OpenInNewWindow="true">
                                            <Docx PageHeader="" />
                                        </ExportSettings>
                                        <Content>
                                        </Content>

                                        <TrackChangesSettings CanAcceptTrackChanges="False"></TrackChangesSettings>
                                    </telerik:RadEditor>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRemarks" ErrorMessage="Remarks is required." Text="" Display="None" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                                                                      </td></tr>
                                                 <tr>
                                                <td  colspan="4" style="height:40px;text-align:right">
                                                    &nbsp;
                                                    <asp:RadioButton ID="optApprove" runat="server" Checked="True" Font-Bold="True" 
                                                        GroupName="A" Text="Process" />
                                                    &nbsp;
                                                    <asp:RadioButton ID="optReject" runat="server" Font-Bold="True" GroupName="A" 
                                                        Text="Reject" />
&nbsp;<asp:RadioButton ID="optReturn" runat="server" Font-Bold="True" GroupName="A" 
                                                        Text="Return" ValidationGroup="A" />
                                                </td>
                                            </tr>
                                              <tr>
                                                  <td align="left">
                                                    </td>
                                                    <td align="left">
                                                      <%--  <asp:Button ID="btUpdate" runat="server" CssClass="btn btn-primary"
                                                            Text="Update"  onclick="btUpdate_Click" />&nbsp;<asp:Button 
                                                            ID="btEmail" runat="server"  CssClass="btn btn-info"
                                                                Text="Send Email"  OnClick="btEmail_Click" 
                                                            ValidationGroup="A" />--%>
                                                    </td>
                                                  <td></td>
                                                  <td  colspan="1" style="height:40px;text-align:right">
                                                   <asp:Button ID="btnNew" runat="server" OnClick="btNewFile_Click" Text="Attach a file" CssClass="btn btn-info" />
                                <asp:Button ID="btSubmit" runat="server" CssClass="btn btn-primary"
                                    Text="Submit" ValidationGroup="A"
                                    OnClick="btSubmit_Click" />
                                                  </td></tr> 
                                       <tr><td colspan="4" style="text-align:right;height:40px">
     <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="BulletList" ShowSummary="false" ValidationGroup="A"  ShowValidationErrors="true" ShowMessageBox="true"/>
                                                         </td>
                                    </tr>
                                    <tr><td colspan="4" style="text-align:right;height:40px">
                                        <asp:Label ID="lblErrorBottom" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                                        </td>
                                        </tr>
                                     <tr><td colspan="4" style="">
                                                           <br />
                    <div class="clearfix"></div>
                    <div class="FlowBar" style="height: 30px">
                        <div style="width: 100%">
                            &nbsp;Process Flow
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <uc1:UserRemarks ID="UserRemarks1" runat="server" />
                                         </td>
                                         </tr>
                                </table>
                                <asp:HiddenField ID="hidRecordID" runat="server" />
                               
                                <asp:HiddenField ID="hidUserID" runat="server" />
                           
                                       
                        
                  
                    
                </div>
                    </div>
        </div>
    </form>
</body>
</html>


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HOF.aspx.cs" Inherits="SAP_Vendor.HOF" StylesheetTheme="Default" %>

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
                                                        <asp:RadioButtonList ID="rblOptions" Enabled="false" runat="server" RepeatLayout="Table" CellPadding="8" Width="400px" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="New" Value="New" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Change" Value="Change"></asp:ListItem>
                                                            <asp:ListItem Text="Active" Value="Active"></asp:ListItem>
                                                            <asp:ListItem Text="Inactive" Value="Inactive"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="height: 40px; ">
                                                        Reason :
                                                    </td>
                                                    <td class="style1" style="height: 40px;" colspan="3">
                                                        <asp:TextBox ID="txtReason" runat="server" Width="100%" ReadOnly="true" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="height: 40px;">
                                                     Business Name :</td>
                                                    <td class="style1" style="height: 40px;" colspan="3">
                                                        <asp:TextBox ID="txtBusinessName" runat="server" Width="100%" ReadOnly="true" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox>
                                                        </td>
                                                </tr>
                                                 <tr>
                                                    <td align="left" style=" height: 40px">
                                                        NTN# :</td>
                                                    <td class="style1" style="width: 186px; height: 40px">
                                                        <asp:TextBox ID="txtNTN" runat="server" Width="210px" ReadOnly="true" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox></td>
                                                    <td>
                                                        Sale Tax Reg# :</td>
                                                    <td style="height: 40px">
                                                        <asp:TextBox ID="txtSaleTaxReg" runat="server" Width="210px" ReadOnly="true" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox>
                                                    
                                                    </td>
                                                   
                                                </tr>
                                                 <tr><td colspan="4" style="text-align:right"><asp:CheckBox ID="txtNA" Enabled="false" runat="server" Text="Not Applicable"></asp:CheckBox></td></tr>
                                                <tr>
                                                    <td align="left" style="height: 40px; ">
                                                        Type :
                                                      </td>
                                                    <td class="style1" style="height: 40px;" colspan="3" align="left">
                                                        <asp:RadioButtonList Enabled="false"  ID="rblType" runat="server" RepeatLayout="Table" CellPadding="8" Width="250px" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="Supplier" Value="Supplier" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Vendor Return" Value="Vendor Return"></asp:ListItem>                        
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td align="left" style="height: 40px; ">
                                                        Payment Currency:
                                                      </td>
                                                    <td class="style1" style="height: 40px;" colspan="3" align="left">
                                                         <asp:TextBox ID="txtCurrency" runat="server" Width="100%" ReadOnly="true" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td align="left" style=" height: 40px">
                                                        Address :</td>
                                                  <td class="style1" style="height: 40px;" colspan="3">
                                                        <asp:TextBox ID="txtAddress" runat="server" Width="100%" ReadOnly="true" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox></td>                                                   
                                                </tr>
                                               
                                                <tr>
                                                    <td align="left" style=" height: 22px">
                                                        City :</td>
                                                    <td class="style1" style="width: 186px">
                                                        <asp:TextBox ID="txtCity" runat="server" Width="210px" ReadOnly="true" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox></td>
                                                    <td>
                                                        State :</td>
                                                    <td style="height: 22px">
                                                        <asp:TextBox ID="txtState" runat="server" Width="210px" ReadOnly="true" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox>

                                                    </td>
                                                        
                                                </tr>
                                                <tr><td style="height: 22px">
                                                        Postal Code :
                                                    </td>
                                                    <td style="height: 22px">
                                                        <asp:TextBox ID="txtPostalCode" runat="server" Width="210px" ReadOnly="true" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox></td>
                                                    <td align="left">
                                                                                                                Country :</td>
                                                    <td class="style1" style="width: 186px">
                                                      <asp:TextBox ID="txtCountry" runat="server" Width="210px" ReadOnly="true" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style=" height: 40px">
                                                        Contact No :</td>
                                                    <td class="style1" style="width: 186px; height: 40px">
                                                        <asp:TextBox ID="txtContactNo" runat="server" Width="210px" ReadOnly="true" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox></td>
                                                    <td>
                                                        Fax No :</td>
                                                    <td style="height: 40px">
                                                        <asp:TextBox ID="txtFaxNo" runat="server" Width="210px" ReadOnly="true" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style=" height: 40px">
                                                        Email :</td>
                                                    <td class="style1" style="width: 186px; height: 40px" colspan="3">
                                                        <asp:TextBox ID="txtEmail" runat="server" Width="100%" ReadOnly="true" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox></td>
                                                    <td class="auto-style1">
                                                        &nbsp;</td>
                                                    <td style="height: 40px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style=" height: 40px">
                                                        Contact Person :</td>
                                                    <td class="style1" style="width: 186px; height: 40px" colspan="3">
                                                        <asp:TextBox ID="txtContactPerson" runat="server" Width="100%" ReadOnly="true" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox></td>                                                    
                                                </tr>
                                                <tr>
                                                    <td align="left" style=" height: 40px">
                                                        Payment Terms :</td>
                                                    <td class="style1" style="width: 186px; height: 40px" colspan="3">
                                                        <asp:TextBox ID="txtPaymentTerms" runat="server" Width="100%" ReadOnly="true" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox></td>                                                    
                                                </tr>
                                                 <tr>
                                                    <td align="left" style="height: 40px; ">
                                                        Payment Method :
                                                      </td>
                                                    <td class="style1" style="height: 40px;" colspan="3" align="left">
                                                        <asp:RadioButtonList Enabled="false"  ID="rblPaymentMethod" runat="server" RepeatLayout="Table" CellPadding="8" Width="250px" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="Cheque" Value="Cheque" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Wire transfer" Value="Wire transfer"></asp:ListItem>                        
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td align="left" style="height: 40px; ">
                                                        Nature of Work :
                                                      </td>
                                                    <td class="style1" style="height: 40px;" colspan="3" align="left">
                                                        <asp:RadioButtonList Enabled="false"  ID="rblNaturOfWork" runat="server" RepeatLayout="Table" CellPadding="8" Width="350px" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="Supplies" Value="Supplies" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Services/Contract" Value="Services/Contract"></asp:ListItem> 
                                                            <asp:ListItem Text="Other" Value="Other"></asp:ListItem> 
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="height: 22px; ">
                                                     Withholding Tax Field :</td>
                                                    <td class="style1" style="width: 186px">                                                        
                                                        <asp:TextBox ID="txtWHoldingTax" runat="server" Width="210px" ReadOnly="true" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox>
                                                    </td>
                                                    
                                                </tr>
                                                 <tr>
                                                    <td align="left" style="height: 40px;" colspan="2">
                                                        Pre-qualification Questionnaire Completed and Attached :
                                                      </td>
                                                    <td class="style1" style="height: 40px;" colspan="2" align="left">
                                                        <asp:RadioButtonList Enabled="false"  ID="rblAttached" runat="server" RepeatLayout="Table" CellPadding="8" Width="150px" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="Yes" Value="Yes" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="No" Value="No"></asp:ListItem>                        
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td align="left" style="height: 40px;">
                                                        Pre-qualification Classification :
                                                      </td>
                                                    <td class="style1" style="height: 40px;" colspan="3" align="left">
                                                        <asp:RadioButtonList Enabled="false"  ID="rblClassification" runat="server" RepeatLayout="Table" CellPadding="8" Width="500px" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="High(>$300K)" Value="High(>$300K)" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Medium(>$10K <=$300K)" Value="Medium(>$10K <=$300K)"></asp:ListItem> 
                                                            <asp:ListItem Text="Low(<=$10K)" Value="Low(<=$10K)"></asp:ListItem>  
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="height: 40px; ">
                                                        Pre-qualification :
                                                      </td>
                                                    <td class="style1" style="height: 40px;" colspan="1" align="left">
                                                        <asp:RadioButtonList Enabled="false" ID="rblQualification" runat="server" RepeatLayout="Table" CellPadding="8" Width="250px" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="Confirmed" Value="Confirmed" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Probation" Value="Probation"></asp:ListItem>                                                                 
                                                        </asp:RadioButtonList>
                                                    </td>
                                                     <td>
                                                        Probation Period Upto :</td>
                                                    <td style="height: 40px">
                                                        <asp:TextBox ID="txtPeriod" runat="server" Width="210px" ReadOnly="true" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox>
                                                    </td>
                                                </tr>
                                               <tr><td colspan="4" style="font-size: medium;color:dodgerblue">Incase of foregion vendors only</td></tr>                                                                                              
                                                <tr>
                                                    <td align="left" style=" height: 40px">
                                                        Bank Name & Address :</td>
                                                      <td class="style1" style="height: 40px;" colspan="3">
                                                        <asp:TextBox ID="txtBankAddress" runat="server" Width="100%"  ReadOnly="true" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox></td>
                                                    
                                                </tr>
                                                <tr>
                                                    <td align="left" style=" height: 40px">
                                                        Account#/IBAN :</td>
                                                   <td class="style1" style="height: 40px;" colspan="3">
                                                       <asp:TextBox ID="txtIBAN" runat="server" Width="100%" ReadOnly="true" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox></td>                                                    
                                                </tr>
                                                <tr>
                                                    <td align="left" style=" height: 40px">
                                                        Routing# :</td>
                                                    <td class="style1" style="height: 40px;" colspan="3">
                                                        <asp:TextBox ID="txtRoutingNo" runat="server" Width="100%" ReadOnly="true" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox></td>                                                   
                                                </tr>
                                                <tr>
                                                    <td align="left" style=" height: 40px">
                                                        Swift Code :                                                     </td>
                                                   <td class="style1" style="height: 40px;" colspan="3">
                                                        <asp:TextBox ID="txtSwiftCode" runat="server" Width="100%" ReadOnly="true" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox></td>                                                  
                                                </tr>
                                                <tr>
                                                    <td align="left" style=" height: 40px">
                                                        Vendor/Benificary Name :</td>
                                                       <td class="style1" style="height: 40px;" colspan="3">
                                                        <asp:TextBox ID="txtBenificaryName" runat="server" Width="100%" ReadOnly="true" CssClass="form-control" ValidateRequestMode="Enabled" ValidationGroup="A" ></asp:TextBox></td>
                                                   
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="4" style="height: 40px">
                                                        Attachments (If any)</td>
                                                </tr>
                                              <tr>
                                                    <td align="left" colspan="4">
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
                                                       
                                                    </td>
                                                   
                                                </tr>
                                                <tr><td>Remarks : <span class="required">*</span></td><td colspan="3" style="padding-top:5px">
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
                                                
                                                <td colspan="4" style="text-align:right;height:40px" >
                                                    &nbsp;
                                                    <asp:RadioButton ID="optApprove" runat="server" Checked="True" Font-Bold="True" 
                                                        GroupName="A" Text="Approve" />
                                                    &nbsp;
                                                    <asp:RadioButton ID="optReject" runat="server" Font-Bold="True" GroupName="A" 
                                                        Text="Reject" />
&nbsp;<asp:RadioButton ID="optReturn" runat="server" Font-Bold="True" GroupName="A" 
                                                        Text="Return" ValidationGroup="A" />
                                                </td>
                                            </tr>
                                                <tr>
                                                   <td colspan="4" style="text-align:right;height:40px" >
                                                        &nbsp;<asp:Button ID="btSubmit" runat="server" CssClass="btn btn-primary"
                                                                Text="Submit" OnClick="btSubmit_Click" 
                                                            ValidationGroup="A" /></td>
                                                </tr>
                                                <tr><td colspan="4" style="text-align:right;height:20px">
     <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="BulletList" ShowSummary="false" ValidationGroup="A"  ShowValidationErrors="true" ShowMessageBox="true"/>                                    
                                        <asp:Label ID="lblErrorBottom" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                                        </td>
                                        </tr>
                                     <tr><td colspan="4" style="">                                                        
                  
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


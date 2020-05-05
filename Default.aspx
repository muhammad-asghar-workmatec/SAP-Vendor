<%@ Page Title="Vendor" Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SAP_Vendor._Default"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Maximo Vendor Creation Form</title>
    <link href="stlLoan.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="JavaScript" src="Script/lw_layers.js"></script>

    <script type="text/javascript" language="JavaScript" src="Script/lw_menu.js"></script>

    <script type="text/javascript" language="JavaScript" src="Script/popcalendar.js"></script>

    <script type="text/javascript" language="JavaScript" src="Script/Common.js"></script>

   

    <style type="text/css">
        .style1
        {
            height: 24px;
        }
        .auto-style1 {
            height: 24px;
            width: 185px;
        }
        .auto-style2 {
            height: 22px;
            width: 240px;
        }
        .auto-style3 {
            border-top: thin solid #C0C0C0;
            height: 14px;
            width: 240px;
        }
        .auto-style4 {
            border-top: thin solid #C0C0C0;
            height: 26px;
            width: 240px;
        }
        .auto-style5 {
            height: 24px;
            width: 240px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <table border="1" width="950px" cellspacing="0" cellpadding="0" id="table1" align="center">
            <tr>
                <td>
                    <table border="0" width="100%" cellspacing="0" cellpadding="0" id="table2">
                        <tr>
                            <td bordercolor="#33cc33" bordercolorlight="#009966">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/OMV.jpg" /></td>
                        </tr>
                        <tr class="TopBar" height="36px">
                            <td style="width: 956px">
                                &nbsp;New Vendor Creation Form</td>
                        </tr>
                        <tr class="Topbar1">
                            <td style="width: 956px">
                                &nbsp;</td>
                        </tr>
                        <tr class="RepFilterBG">
                            <td>
                                <table>
                                    <tr>
                                        <td style="width: 43px" valign="top">
                                            &nbsp;</td>
                                        <td style="width: 943px">
                                            <table cellpadding="0" cellspacing="0" style="width: 100%">
                                                <colgroup>
                                                    <col class="TableColumn" />
                                                    <col />
                                                    <col class="TableColumn" />
                                                </colgroup>
                                               <tbody>
                                                
                                                <tr>
                                                    <td align="left" style="height: 22px; width: 231px;">
                                                    </td>
                                                    <td class="style1" colspan="3">
                                                        <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></td>
                                                </tr>
                                                 <tr>
                                                    <td align="left" style="height: 24px; width: 231px;">
                                                      </td>
                                                    <td class="style1" style="height: 24px;" colspan="3" align="left">
                                                        <asp:RadioButtonList ID="rblOptions" runat="server" RepeatLayout="Table" CellPadding="3" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="New" Value="New" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Change" Value="Change"></asp:ListItem>
                                                            <asp:ListItem Text="Active" Value="Active"></asp:ListItem>
                                                            <asp:ListItem Text="Inactive" Value="Inactive"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="height: 24px; width: 231px;">
                                                 *Resion :
                                                    </td>
                                                    <td class="style1" style="height: 24px;" colspan="3">
                                                        <asp:TextBox ID="txtResion" runat="server" Width="620px"></asp:TextBox>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="height: 24px; width: 231px;">
                                                     Business Name :</td>
                                                    <td class="style1" style="height: 24px;" colspan="3">
                                                        <asp:TextBox ID="txtBusinessName" runat="server" Width="620px"></asp:TextBox>
                                                        </td>
                                                </tr>
                                                 <tr>
                                                    <td align="left" style="width: 231px; height: 24px">
                                                        NTN# :</td>
                                                    <td class="style1" style="width: 186px; height: 24px">
                                                        <asp:TextBox ID="txtNTN" runat="server" Width="210px"></asp:TextBox></td>
                                                    <td class="auto-style5">
                                                        Sale Tax Reg# :</td>
                                                    <td style="height: 24px">
                                                        <asp:TextBox ID="txtSaleTaxReg" runat="server" Width="210px"></asp:TextBox>
                                                    &nbsp;&nbsp;
                                                        <br />
                                                        <asp:CheckBox ID="txtNA" runat="server" Text="Not Applicable"></asp:CheckBox>
                                                    </td>
                                                   
                                                </tr>
                                                <tr>
                                                    <td align="left" style="height: 24px; width: 231px;">
                                                        Type :
                                                      </td>
                                                    <td class="style1" style="height: 24px;" colspan="3" align="left">
                                                        <asp:RadioButtonList ID="rblType" runat="server" RepeatLayout="Table" CellPadding="3" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="Supplier" Value="Supplier" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Vendor Return" Value="Vendor Return"></asp:ListItem>                        
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td align="left" style="height: 24px; width: 231px;">
                                                        Payment Currency:
                                                      </td>
                                                    <td class="style1" style="height: 24px;" colspan="3" align="left">
                                                        <asp:RadioButtonList ID="rblCurrency" runat="server" RepeatLayout="Table" CellPadding="3" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="PKR" Value="PKR" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="USD" Value="USD"></asp:ListItem>                        
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td align="left" style="width: 231px; height: 24px">
                                                        Address :</td>
                                                  <td class="style1" style="height: 24px;" colspan="3">
                                                        <asp:TextBox ID="txtAddress" runat="server" Width="620px"></asp:TextBox></td>                                                   
                                                </tr>
                                               
                                                <tr>
                                                    <td align="left" style="width: 231px; height: 22px">
                                                        City :</td>
                                                    <td class="style1" style="width: 186px">
                                                        <asp:TextBox ID="txtCity" runat="server" Width="210px"></asp:TextBox></td>
                                                    <td class="auto-style2">
                                                        State :</td>
                                                    <td style="height: 22px">
                                                        <asp:TextBox ID="txtState" runat="server" Width="210px"></asp:TextBox>

                                                    </td>
                                                        
                                                </tr>
                                                <tr><td style="height: 22px">
                                                        Postal Code :
                                                    </td>
                                                    <td style="height: 22px">
                                                        <asp:TextBox ID="txtPostalCode" runat="server" Width="210px"></asp:TextBox></td>
                                                    <td align="left" class="auto-style2">
                                                                                                                Country :</td>
                                                    <td class="style1" style="width: 186px">
                                                        <asp:DropDownList ID="ddlCountry" runat="server" CssClass="cbo" Width="210px">
                                                        </asp:DropDownList></td>
                                                    
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 231px; height: 24px">
                                                        Contact No :</td>
                                                    <td class="style1" style="width: 186px; height: 24px">
                                                        <asp:TextBox ID="txtContactNo" runat="server" Width="210px"></asp:TextBox></td>
                                                    <td class="auto-style5">
                                                        Fax No :</td>
                                                    <td style="height: 24px">
                                                        <asp:TextBox ID="txtFaxNo" runat="server" Width="210px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 231px; height: 24px">
                                                        Email :</td>
                                                    <td class="style1" style="width: 186px; height: 24px" colspan="3">
                                                        <asp:TextBox ID="txtEmail" runat="server" Width="620px"></asp:TextBox></td>
                                                    <td class="auto-style1">
                                                        &nbsp;</td>
                                                    <td style="height: 24px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 231px; height: 24px">
                                                        Contact Person :</td>
                                                    <td class="style1" style="width: 186px; height: 24px" colspan="3">
                                                        <asp:TextBox ID="txtContactPerson" runat="server" Width="620px"></asp:TextBox></td>                                                    
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 231px; height: 24px">
                                                        Payment Terms :</td>
                                                    <td class="style1" style="width: 186px; height: 24px" colspan="3">
                                                        <asp:TextBox ID="txtPaymentTerms" runat="server" Width="620px"></asp:TextBox></td>                                                    
                                                </tr>
                                                 <tr>
                                                    <td align="left" style="height: 24px; width: 231px;">
                                                        Payment Method :
                                                      </td>
                                                    <td class="style1" style="height: 24px;" colspan="3" align="left">
                                                        <asp:RadioButtonList ID="rblPaymentMethod" runat="server" RepeatLayout="Table" CellPadding="3" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="Cheque" Value="Cheque" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Wire transfer" Value="Wire transfer"></asp:ListItem>                        
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td align="left" style="height: 24px; width: 231px;">
                                                        Nature of Work :
                                                      </td>
                                                    <td class="style1" style="height: 24px;" colspan="3" align="left">
                                                        <asp:RadioButtonList ID="rblNaturOfWork" runat="server" RepeatLayout="Table" CellPadding="3" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="Supplies" Value="Supplies" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Services/Contract" Value="Services/Contract"></asp:ListItem> 
                                                            <asp:ListItem Text="Other" Value="Other"></asp:ListItem> 
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="height: 22px; width: 231px;">
                                                     Witholding Tax Field :</td>
                                                    <td class="style1" style="width: 186px">
                                                        <asp:DropDownList ID="ddlWitholdingTaxField" runat="server" CssClass="cbo" Width="190px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    
                                                </tr>
                                                 <tr>
                                                    <td align="left" style="height: 24px;" colspan="2">
                                                        Pre-qualification Questionnaire Completed and Attached :
                                                      </td>
                                                    <td class="style1" style="height: 24px;" colspan="2" align="left">
                                                        <asp:RadioButtonList ID="rblAttached" runat="server" RepeatLayout="Table" CellPadding="3" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="Yes" Value="Yes" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="No" Value="No"></asp:ListItem>                        
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td align="left" style="height: 24px;">
                                                        Pre-qualification Classification :
                                                      </td>
                                                    <td class="style1" style="height: 24px;" colspan="3" align="left">
                                                        <asp:RadioButtonList ID="rblClassification" runat="server" RepeatLayout="Table" CellPadding="3" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="High(>$300K)" Value="High(>$300K)" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Medium(>$10K <=$300K)" Value="Medium(>$10K <=$300K)"></asp:ListItem> 
                                                            <asp:ListItem Text="Low(<=$10K)" Value="Low(<=$10K)"></asp:ListItem>  
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="height: 24px; width: 231px;">
                                                        Pre-qualification :
                                                      </td>
                                                    <td class="style1" style="height: 24px;" colspan="1" align="left">
                                                        <asp:RadioButtonList ID="rblQualification" runat="server" RepeatLayout="Table" CellPadding="3" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="Confirmed" Value="Confirmed" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Probation" Value="Probation"></asp:ListItem>                                                                 
                                                        </asp:RadioButtonList>
                                                    </td>
                                                     <td class="auto-style5">
                                                        Probation Period Upto :</td>
                                                    <td style="height: 24px">
                                                        <asp:TextBox ID="txtPeriod" runat="server" Width="210px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                               <tr><td colspan="4" style="font-size: medium">Incase of foregion vendors only</td></tr>                                                                                              
                                                <tr>
                                                    <td align="left" style="width: 231px; height: 24px">
                                                        Bank Name & Address :</td>
                                                      <td class="style1" style="height: 24px;" colspan="3">
                                                        <asp:TextBox ID="txtBankAddress" runat="server" Width="620px"></asp:TextBox></td>
                                                    
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 231px; height: 24px">
                                                        Account#/IBAN# :</td>
                                                   <td class="style1" style="height: 24px;" colspan="3">
                                                       <asp:TextBox ID="txtIBAN" runat="server" Width="620px"></asp:TextBox></td>                                                    
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 231px; height: 24px">
                                                        Routing# :</td>
                                                    <td class="style1" style="height: 24px;" colspan="3">
                                                        <asp:TextBox ID="txtRoutingNo" runat="server" Width="620px"></asp:TextBox></td>                                                   
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 231px; height: 24px">
                                                        Swift Code :                                                     </td>
                                                   <td class="style1" style="height: 24px;" colspan="3">
                                                        <asp:TextBox ID="txtSwiftCode" runat="server" Width="620px"></asp:TextBox></td>                                                  
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 231px; height: 24px">
                                                        Vendor/Benificary Name :</td>
                                                       <td class="style1" style="height: 24px;" colspan="3">
                                                        <asp:TextBox ID="txtBenificaryName" runat="server" Width="620px"></asp:TextBox></td>
                                                   
                                                </tr>
                                              
                                                <tr>
                                                    <td align="left" style="width: 231px; height: 14px">
                                                        &nbsp;</td>
                                                    <td class="Line" style="width: 186px; height: 14px">
                                                    </td>
                                                    <td class="auto-style3">
                                                    </td>
                                                    <td class="Line" style="height: 14px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="4">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 231px; height: 26px">
                                                        &nbsp;Attachment :</td>
                                                    <td align="left" colspan="2">
                                                        <asp:FileUpload ID="fuFile" runat="server" Width="256px" />&nbsp;
                                                        <asp:Button ID="btUpload" runat="server" OnClick="btUpload_Click" Text="Upload" />
                                                    </td>
                                                    <td align="left" style="height: 26px">
                                                        <span id="Summary" runat="server">&nbsp;</span></td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="3" style="height: 26px">
                                                        <asp:GridView ID="dgAttachment" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                            CellPadding="4" DataKeyNames="ID" DataSourceID="dsAttachment" ForeColor="#333333"
                                                            GridLines="None" OnRowCommand="dgAttachment_RowCommand" OnRowDataBound="dgAttachment_RowDataBound"
                                                            PageSize="20" ShowFooter="True">
                                                            <RowStyle BackColor="White" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="File Name">
                                                                    <ItemTemplate>
                                                                        <asp:HyperLink ID="lnkAttachment" runat="server" Target="_blank">HyperLink</asp:HyperLink>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                    </FooterTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:ButtonField ButtonType="Button" CommandName="AEDelete" Text="Delete" />
                                                            </Columns>
                                                            <FooterStyle BackColor="Navy" Font-Bold="True" />
                                                            <PagerStyle BackColor="Navy" ForeColor="White" HorizontalAlign="Right" />
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="Navy" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#2461BF" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                        <asp:SqlDataSource ID="dsAttachment" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>">
                                                        </asp:SqlDataSource>
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" style="height: 26px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                <td align="left" class="style6" style="width: 231px">
                                                    &nbsp;
                                                    Remarks :</td>
                                                <td align="left" colspan="3">
                                                    <asp:TextBox ID="txtRemarks" runat="server" Rows="4" Width="620px" Height="60px"></asp:TextBox>
                                                </td>
                                            </tr>
                                                <tr>
                                                    <td align="left" class="Line" style="width: 231px; height: 26px">
                                                    </td>
                                                    <td align="left" class="Line" style="width: 186px">
                                                    </td>
                                                    <td class="auto-style4">
                                                        Submitted To :</td>
                                                    <td align="left" class="Line" style="height: 26px">
                                                            <select id="ddlTo" runat="server" class="cbo" style="width: 250px">
                                                                <option selected="selected"></option>
                                                            </select>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="Line" style="height: 26px; width: 231px;">
                                                    </td>
                                                    <td align="left" class="Line" style="width: 186px">
                                                    </td>
                                                    <td class="auto-style4">
                                                        &nbsp;</td>
                                                    <td align="right" class="Line" style="height: 26px">
                                                        &nbsp;<asp:Button ID="btSubmit" runat="server" CssClass="PageModalButtonCreate"
                                                                Text="Submit" Width="65px" OnClick="btSubmit_Click" 
                                                            ValidationGroup="A" /></td>
                                                </tr>
                                                   </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <asp:HiddenField ID="hidRecordID" runat="server" />
                                                        <asp:HiddenField ID="hidUserID" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <div id="_Script" runat="server">
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Finance.aspx.cs" Inherits="SAP_Vendor.Finance" %>

<%@ Register Src="~/UserRemarks.ascx" TagPrefix="uc1" TagName="UserRemarks" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Maximo Vendor Creation Form</title>
    <link href="stlLoan.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="JavaScript" src="Script/lw_layers.js"></script>

    <script type="text/javascript" language="JavaScript" src="Script/lw_menu.js"></script>

    <script type="text/javascript" language="JavaScript" src="Script/popcalendar.js"></script>

    <script type="text/javascript" language="JavaScript" src="Script/Common.js"></script>

   <script type="text/javascript" language="javascript">
       function ValidateForm() {
           var notes
           if (!document.form1.optApprove.checked && !document.form1.optReject.checked && !document.form1.optReturn.checked) {
               alert('Please select approve,reject or return');
               return false;
           }
           if (document.form1.optApprove.checked) {
               window.parent.frames(0).document.FormObj.SetVarValue('AppStatus', '1');
               //alert('Please enter vendor id to intimate originator.');
               //window.parent.frames(0).document.FormObj.DoNotes();
               notes = window.parent.frames(0).document.FormObj.GetCurrentNotes
             //  if (notes == "") {
            //       alert('Please enter vendor id to intimate originator.');
            //       return false;
            //   }
               document.form1.hidRemarks.value = notes;
               window.parent.frames(0).document.FormObj.SetVarValue('Subject', 'Vendor Approved');
               window.parent.frames(0).document.FormObj.SetVarValue('Message', 'Your vendor ' + document.form1.txtName1.value + ' request has been approved and vendor id is ' + document.form1.txtVendorID.value);
           }
           else if (document.form1.optReject.checked) {
               window.parent.frames(0).document.FormObj.DoNotes();
               notes = window.parent.frames(0).document.FormObj.GetCurrentNotes
               if (notes == "") {
                   alert('Please enter remarks.');
                   return false;
               }
               document.form1.hidRemarks.value = notes;
               window.parent.frames(0).document.FormObj.SetVarValue('Message', 'Your vendor ' + document.form1.txtName1.value + ' request has been disapproved due to  ' + notes);
               window.parent.frames(0).document.FormObj.SetVarValue('Subject', 'Vendor Disapproved');
               window.parent.frames(0).document.FormObj.SetVarValue('AppStatus', '2'); ;
           }
           else if (document.form1.optReturn.checked) {
               window.parent.frames(0).document.FormObj.DoNotes();
               notes = window.parent.frames(0).document.FormObj.GetCurrentNotes
               if (notes == "") {
                   alert('Please enter remarks.');
                   return false;
               }
               document.form1.hidRemarks.value = notes;
               window.parent.frames(0).document.FormObj.SetVarValue('AppStatus', '3');
           }
           notes = window.parent.frames(0).document.FormObj.GetCurrentNotes
           document.form1.hidRemarks.value = notes;
           return true;
       }
       
   </script>

    <style type="text/css">
        .style1
        {
            height: 24px;
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
                                                <tr>
                                                    <td align="left" style="height: 22px; width: 145px;">
                                                    </td>
                                                    <td class="style1" colspan="3">
                                                        <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></td>
                                                </tr>
                                                 <tr>
                                                    <td align="left" style="height: 24px; width: 145px;">
                                                        Account Group :</td>
                                                    <td class="style1" style="height: 24px;" colspan="3">
                                                        <asp:Label ID="lblAG" runat="server" Text="VEND"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="height: 24px; width: 145px;">
                                                                                                                Name 1:
                                                    </td>
                                                    <td class="style1" style="height: 24px;" colspan="3">
                                                        <asp:TextBox ID="txtName1" runat="server" Width="620px"></asp:TextBox>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="height: 24px; width: 145px;">
                                                                                                                Name 2:</td>
                                                    <td class="style1" style="height: 24px;" colspan="3">
                                                        <asp:TextBox ID="txtName2" runat="server" Width="620px"></asp:TextBox>
                                                        </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="height: 22px; width: 145px;">
                                                                                                                Country :</td>
                                                    <td class="style1" style="width: 186px">
                                                        <asp:DropDownList ID="ddlCountry" runat="server" CssClass="cbo" Width="190px">
                                                        </asp:DropDownList></td>
                                                    <td style="height: 22px">
                                                        Postal Code :
                                                    </td>
                                                    <td style="height: 22px">
                                                        <asp:TextBox ID="txtPostalCode" runat="server"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 145px; height: 22px">
                                                        City :    <td class="style1" style="width: 186px">
                                                        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox></td>
                                                    <td style="height: 22px">
                                                        &nbsp;</td>
                                                    <td style="height: 22px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 145px; height: 24px">
                                                        Street &amp; House # :</td>
                                                    <td class="style1" style="width: 186px; height: 24px">
                                                        <asp:TextBox ID="txtHNo" runat="server" Width="210px"></asp:TextBox></td>
                                                    <td style="height: 24px">
                                                        Street&nbsp; :</td>
                                                    <td style="height: 24px">
                                                        <asp:TextBox ID="txtStreet" runat="server" Width="250px"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 145px; height: 24px">
                                                        District :</td>
                                                    <td class="style1" style="width: 186px; height: 24px">
                                                        <asp:TextBox ID="txtDistrict" runat="server" Width="210px"></asp:TextBox></td>
                                                    <td style="height: 24px">
                                                        Region :</td>
                                                    <td style="height: 24px">
                                                        <asp:TextBox ID="txtRegion" runat="server" Width="210px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 145px; height: 24px">
                                                        PO Box :</td>
                                                    <td class="style1" style="width: 186px; height: 24px">
                                                        <asp:TextBox ID="txtPOBox" runat="server"></asp:TextBox></td>
                                                    <td style="height: 24px">
                                                        &nbsp;</td>
                                                    <td style="height: 24px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 145px; height: 24px">
                                                        Search Term 1 :</td>
                                                    <td class="style1" style="width: 186px; height: 24px">
                                                        <asp:TextBox ID="txtSterm1" runat="server" Width="210px"></asp:TextBox></td>
                                                    <td style="height: 24px">
                                                        Search Term 2 :</td>
                                                    <td style="height: 24px">
                                                        <asp:TextBox ID="txtSterm2" runat="server" Width="210px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 145px; height: 24px">
                                                        Language Key :</td>
                                                    <td class="style1" style="width: 186px; height: 24px">
                                                        <asp:TextBox ID="txtLanguage" runat="server"></asp:TextBox></td>
                                                    <td style="height: 24px">
                                                        Phone :
                                                    </td>
                                                    <td style="height: 24px">
                                                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 145px; height: 24px">
                                                        Fax : </td>
                                                    <td class="style1" style="width: 186px; height: 24px">
                                                        <asp:TextBox ID="txtFax" runat="server"></asp:TextBox></td>
                                                    <td style="height: 24px">
                                                        Email :</td>
                                                    <td style="height: 24px">
                                                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 145px; height: 24px">
                                                        Tax Code 1 (CNIC):</td>
                                                    <td class="style1" style="width: 186px; height: 24px">
                                                        <asp:TextBox ID="txtTaxcode1" runat="server"></asp:TextBox></td>
                                                    <td style="height: 24px">
                                                        Tax Code 2 (NTN):</td>
                                                    <td style="height: 24px">
                                                        <asp:TextBox ID="txtTaxCode2" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 145px; height: 24px">
                                                        DUNS Number :</td>
                                                    <td class="style1" style="width: 186px; height: 24px">
                                                        <asp:TextBox ID="txtDunsNumber" runat="server"></asp:TextBox></td>
                                                    <td style="height: 24px">
                                                        VAT reg no :</td>
                                                    <td style="height: 24px">
                                                        <asp:TextBox ID="txtVAT" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 145px; height: 24px">
                                                        Industry Key :</td>
                                                    <td class="style1" style="width: 186px; height: 24px">
                                                        <asp:TextBox ID="txtIndustryKey" runat="server"></asp:TextBox></td>
                                                    <td style="height: 24px">
                                                        &nbsp;</td>
                                                    <td style="height: 24px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 145px; height: 24px">
                                                        &nbsp;</td>
                                                    <td class="style1" style="width: 186px; height: 24px">
                                                        &nbsp;</td>
                                                    <td style="height: 24px">
                                                        &nbsp;</td>
                                                    <td style="height: 24px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 145px; height: 24px">
                                                        IBAN :</td>
                                                    <td class="style1" style="width: 186px; height: 24px">
                                                        <asp:TextBox ID="txtIBAN1" runat="server"></asp:TextBox></td>
                                                    <td style="height: 24px">
                                                        IBAN :</td>
                                                    <td style="height: 24px">
                                                        <asp:TextBox ID="txtIBAN2" runat="server"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 145px; height: 24px">
                                                        Bank Country Key :</td>
                                                    <td class="style1" style="width: 186px; height: 24px">
                                                        <asp:DropDownList ID="ddlBankCountry1" runat="server" CssClass="cbo" 
                                                            Width="190px">
                                                        </asp:DropDownList></td>
                                                    <td style="height: 24px">
                                                        Bank Country Key :</td>
                                                    <td style="height: 24px">
                                                        <asp:DropDownList ID="ddlBankCountry2" runat="server" CssClass="cbo" 
                                                            Width="190px">
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 145px; height: 24px">
                                                        Bank Name :</td>
                                                    <td class="style1" style="width: 186px; height: 24px">
                                                        <asp:TextBox ID="txtBNKName1" runat="server" Width="210px"></asp:TextBox></td>
                                                    <td style="height: 24px">
                                                        Bank Name :</td>
                                                    <td style="height: 24px">
                                                        <asp:TextBox ID="txtBNKName2" runat="server" Width="210px"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 145px; height: 24px">
                                                        City :
                                                    </td>
                                                    <td class="style1" style="width: 186px; height: 24px">
                                                        <asp:TextBox ID="txtBCity1" runat="server"></asp:TextBox></td>
                                                    <td style="height: 24px">
                                                        City : </td>
                                                    <td style="height: 24px">
                                                        <asp:TextBox ID="txtBCity2" runat="server"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 145px; height: 24px">
                                                        H No St # :</td>
                                                    <td class="style1" style="width: 186px; height: 24px">
                                                        <asp:TextBox ID="txtBHNo1" runat="server" Width="210px"></asp:TextBox></td>
                                                    <td style="height: 24px">
                                                        H No St # :</td>
                                                    <td style="height: 24px">
                                                        <asp:TextBox ID="txtBHNo2" runat="server" Width="210px"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 145px; height: 24px">
                                                        Branch :</td>
                                                    <td class="style1" style="width: 186px; height: 24px">
                                                        <asp:TextBox ID="txtBBranch1" runat="server"></asp:TextBox></td>
                                                    <td style="height: 24px">
                                                        Branch :</td>
                                                    <td style="height: 24px">
                                                        <asp:TextBox ID="txtBBranch2" runat="server"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 145px; height: 24px">
                                                        Bank Key :</td>
                                                    <td class="style1" style="width: 186px; height: 24px">
                                                        <asp:TextBox ID="txtBankKey1" runat="server"></asp:TextBox></td>
                                                    <td style="height: 24px">
                                                        Bank Key :</td>
                                                    <td style="height: 24px">
                                                        <asp:TextBox ID="txtBankKey2" runat="server"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 145px; height: 24px">
                                                        Account # :</td>
                                                    <td class="style1" style="width: 186px; height: 24px">
                                                        <asp:TextBox ID="txtAccount1" runat="server"></asp:TextBox></td>
                                                    <td style="height: 24px">
                                                        Account # :</td>
                                                    <td style="height: 24px">
                                                        <asp:TextBox ID="txtAccount2" runat="server"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 145px; height: 24px">
                                                        Swift Code :</td>
                                                    <td class="style1" style="width: 186px; height: 24px">
                                                        <asp:TextBox ID="txtSwitCode1" runat="server"></asp:TextBox></td>
                                                    <td style="height: 24px">
                                                        Swift Code :</td>
                                                    <td style="height: 24px">
                                                        <asp:TextBox ID="txtSwitCode2" runat="server"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 145px; height: 24px">
                                                        Account Holder Name :</td>
                                                    <td class="style1" style="width: 186px; height: 24px">
                                                        <asp:TextBox ID="txtAHName1" runat="server"></asp:TextBox></td>
                                                    <td style="height: 24px">
                                                        Account Holder Name :</td>
                                                    <td style="height: 24px">
                                                        <asp:TextBox ID="txtAHName2" runat="server"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 145px; height: 24px">
                                                        Additional Bank Info :</td>
                                                    <td class="style1" style="width: 186px; height: 24px">
                                                        <asp:TextBox ID="txtABInfo1" runat="server"></asp:TextBox></td>
                                                    <td style="height: 24px">
                                                        Additional Bank Info :</td>
                                                    <td style="height: 24px">
                                                        <asp:TextBox ID="txtABInfo2" runat="server" 
                                                            ></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 145px; height: 24px">
                                                        Company Code :</td>
                                                    <td class="style1" style="width: 186px; height: 24px">
                                                        <asp:TextBox ID="txtCCode1" runat="server"></asp:TextBox></td>
                                                    <td style="height: 24px">
                                                        Reconciliation Account :</td>
                                                    <td style="height: 24px">
                                                        <asp:TextBox ID="txtRecon" runat="server"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 145px; height: 24px">
                                                        Terms of Payment :</td>
                                                    <td class="style1" style="width: 186px; height: 24px">
                                                        <asp:DropDownList ID="ddlPaymentTerms" runat="server" CssClass="cbo" 
                                                            Width="190px">
                                                        </asp:DropDownList></td>
                                                    <td style="height: 24px">
                                                        &nbsp;</td>
                                                    <td style="height: 24px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 145px; height: 24px">
                                                        LTU :</td>
                                                    <td class="style1" style="width: 186px; height: 24px">
                                                        <asp:TextBox ID="txtLTU" runat="server" Visible="False"></asp:TextBox></td>
                                                    <td style="height: 24px">
                                                        Recipient Type : </td>
                                                    <td style="height: 24px">
                                                        <asp:DropDownList ID="ddlRecepientType" runat="server" CssClass="cbo" 
                                                            Width="190px">
                                                        </asp:DropDownList></td>
                                                </tr>

                                                <tr>
                                                    <td align="left" style="width: 145px; height: 24px">
                                                        MM Order Currency :</td>
                                                    <td class="style1" style="width: 186px; height: 24px">
                                                        <asp:DropDownList ID="ddlCurrency" runat="server" CssClass="cbo" Width="190px">
                                                        </asp:DropDownList></td>
                                                    <td style="height: 24px">
                                                        Email Sent :</td>
                                                    <td style="height: 24px">
                                                        <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                     <tr>
                                                    <td align="left" style="width: 231px; height: 24px">
                                                        Company Type :</td>
                                                    <td class="style1" style="width: 186px; height: 24px">
                                                        <asp:TextBox ID="txtCType" runat="server" Width="210px" ReadOnly="True"></asp:TextBox></td>
                                                    <td style="height: 24px">
                                                        &nbsp;</td>
                                                    <td style="height: 24px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 231px; height: 33px">
                                                        Company Category 1 (Main Product / Service Type)</td>
                                                    <td class="style1" style="height: 33px" colspan="3">
                                                    <asp:TextBox ID="txtCCate1" runat="server" Width="594px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 231px; height: 33px">
                                                        Company Category 2 (Additional Product / Services)</td>
                                                    <td class="style1" style="height: 33px" colspan="3">
                                                    <asp:TextBox ID="txtCCate2" runat="server" Width="594px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 231px; height: 33px">
                                                        Company Category 3 (Additoinal Product / Services)</td>
                                                    <td class="style1" style="height: 33px" colspan="3">
                                                    <asp:TextBox ID="txtCCate3" runat="server" Width="594px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 145px; height: 24px">
                                                        SAP Vendor ID :</td>
                                                    <td class="style1" style="width: 186px; height: 24px">
                                                        <asp:TextBox ID="txtVendorID" runat="server"></asp:TextBox></td>
                                                    <td style="height: 24px">
                                                        &nbsp;</td>
                                                    <td style="height: 24px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 145px; height: 14px">
                                                        &nbsp;</td>
                                                    <td class="Line" style="width: 186px; height: 14px">
                                                    </td>
                                                    <td class="Line" style="height: 14px">
                                                    </td>
                                                    <td class="Line" style="height: 14px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="4">
                                                        </td>
                                                </tr>
                                                 
                                                <tr>
                                                    <td align="left" colspan="4" style="height: 26px">
                                                        Attachment (if any)</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="4" style="height: 26px">
                                                        <asp:GridView ID="dgAttachment" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                            CellPadding="4" DataKeyNames="ID" DataSourceID="dsAttachment" ForeColor="#333333"
                                                            GridLines="None" OnRowDataBound="dgAttachment_RowDataBound" PageSize="20" ShowFooter="True"
                                                            Width="100%">
                                                            <RowStyle BackColor="White" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="File Name">
                                                                    <FooterTemplate>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:HyperLink ID="lnkAttachment" runat="server" Target="_blank">HyperLink</asp:HyperLink>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <FooterStyle BackColor="Navy" Font-Bold="True" />
                                                            <PagerStyle BackColor="Navy" ForeColor="White" HorizontalAlign="Right" />
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="Navy" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#2461BF" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                        <asp:SqlDataSource ID="dsAttachment" runat="server" ConnectionString="<%$ appSettings:ConnectionString %>">
                                                        </asp:SqlDataSource>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                <td align="left" class="style6">
                                                    &nbsp;
                                                    Remarks :</td>
                                                <td align="left" colspan="3">
                                                    <asp:TextBox ID="txtRemarks" runat="server" Width="594px"></asp:TextBox>
                                                </td>
                                            </tr>
                                                 <tr>
                                                <td align="left" class="style6">
                                                    &nbsp;
                                                </td>
                                                <td align="left" style="width: 227px">
                                                    &nbsp;
                                                </td>
                                                <td style="height: 26px">
                                                    &nbsp;
                                                </td>
                                                <td align="right" style="height: 26px">
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
                                                    <td align="left" class="Line" style="height: 26px; width: 145px;">
                                                    </td>
                                                    <td align="left" class="Line" style="width: 186px">
                                                        <asp:Button ID="btUpdate" runat="server" CssClass="PageModalButtonCreate"
                                                            Text="Update" Width="65px" onclick="btUpdate_Click" />&nbsp;<asp:Button 
                                                            ID="btEmail" runat="server" CssClass="PageModalButtonCreate"
                                                                Text="Send Email" Width="89px" OnClick="btEmail_Click" 
                                                            ValidationGroup="A" />
                                                    </td>
                                                    <td class="Line" style="height: 26px">
                                                        &nbsp;</td>
                                                    <td align="right" class="Line" style="height: 26px">
                                                        &nbsp;<asp:Button ID="btSubmit" 
                                                            runat="server" CssClass="PageModalButtonCreate"
                                                                Text="Submit" Width="65px" OnClick="btSubmit_Click" 
                                                            ValidationGroup="A" /></td>
                                                </tr>
                                                      <tr class="RepFilterHD">
                                                <td align="left" class="style7">
                                                    Process Flow</td>
                                                <td align="left" class="Line" style="width: 185px">
                                                    &nbsp;</td>
                                                <td class="Line" style="height: 26px">
                                                    &nbsp;</td>
                                                <td align="right" class="Line" style="height: 26px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left"  colspan="4">
                                                    <uc1:UserRemarks ID="UserRemarks1" runat="server" />
                                                </td>
                                            </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <asp:HiddenField ID="hidRecordID" runat="server" />
                                                        <asp:TextBox ID="txtTaxcode3" runat="server" 
                                    Visible="False"></asp:TextBox>
                                                        <asp:TextBox ID="txtTradingPart" runat="server" 
                                    Visible="False"></asp:TextBox>
                                <asp:HiddenField ID="hidIsAdd" runat="server" />
                                <asp:SqlDataSource ID="dsFlow" runat="server" 
                                    ConnectionString="<%$ appSettings:ConnectionString %>" 
                                    ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                <asp:HiddenField ID="hidRemarks" runat="server" />
                                                        <asp:TextBox ID="txtMSOrt2PK1" runat="server" 
                                    Visible="False"></asp:TextBox>
                                                        <asp:TextBox ID="txtMSOrt2PK3" runat="server" 
                                    Visible="False"></asp:TextBox>
                                                        <asp:TextBox ID="txtWHTType" runat="server" 
                                    Visible="False"></asp:TextBox>
                                                        <asp:TextBox ID="txtWHTC" runat="server" 
                                    Visible="False"></asp:TextBox>
                                                        <asp:TextBox ID="txtWHTCode" runat="server" 
                                    Visible="False"></asp:TextBox>
                                                        <asp:TextBox ID="txtWHTTID" runat="server" 
                                    Visible="False"></asp:TextBox><asp:HiddenField ID="hidUserID" runat="server" />
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


<%@ Page Title="eTQ" Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="Message.aspx.cs" Inherits="SAP_Vendor.Message" StylesheetTheme="Default" %>

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
        <div class="DivBody">
            <div class="DivHeader">
                <uc1:Header runat="server" ID="Header1" />
            </div>
            <div class="DivContent">
                <div class="RepFilterBG" style="text-align: left">
                    <div class="clearfix"></div>
                    <div>
                        <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                    </div>
                    <br />
                    <div class="clearfix"></div>
                </div>

            </div>

        </div>
    </form>
</body>
</html>

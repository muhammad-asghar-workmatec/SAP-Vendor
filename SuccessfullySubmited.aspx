<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuccessfullySubmited.aspx.cs" Inherits="SAP_Vendor.SuccessfullySubmited" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Successfully Submitted</title>
     <script language="javascript" type="text/javascript" >
         var win = window.open("", "_top", "", "true");
         win.opener = true;
         win.close();
    </script>
     <script language="javascript" type="text/javascript" >
         close();
     </script>
</head>
<body>
    <form id="form1" runat="server">
       <div style="color:Green; font-size:larger; text-align:center">
    Successfully Submitted!
    <asp:Button ID="Button1" runat="server" Text="Close" UseSubmitBehavior=false  OnClientClick="window.close();return false;" Width=100px CssClass="btn"/>
    </div>
    </form>
</body>
</html>
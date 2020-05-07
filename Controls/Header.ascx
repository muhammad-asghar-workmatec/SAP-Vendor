<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="SAP_Vendor.Controls.Header" %>
<div> <div style="              text-align: right;
              padding: 10px;
      " class="pull-right no-print">
                <asp:HyperLink ID="btnPrint" Visible="false" runat="server" Text="Print" CssClass="btn btn-default btn-sm" Target="_blank" NavigateUrl="~/Print.aspx"></asp:HyperLink>
            </div>
    <div class="TopBar">
        <div style="width: 100%; padding: 3px 3px;">

            <asp:Image ID="Image1" runat="server" Height="50px" ImageUrl="~/Images/logo.png" />
            &nbsp;<asp:Label runat="server" ID="lblTitle" ForeColor="White" Text="New Vendor Creation Form"></asp:Label>
        </div>
    </div>
    <div class="Topbar1">
        <div style="width: 100%">
            &nbsp;
        </div>
    </div>
</div>

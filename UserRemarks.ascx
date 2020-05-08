<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserRemarks.ascx.cs" Inherits="SAP_Vendor.UserRemarks" %>
<div style="text-align:left">
 <asp:GridView ID="dgProcess" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    CellPadding="4" DataSourceID="DSRemarks"
                                    Height="15px" PageSize="20" 
            Style="position: relative" Width="100%" CssClass="Grid" 
        Visible="False" OnRowDataBound="dgProcess_RowDataBound">
                                    <FooterStyle BackColor="Navy" Font-Bold="True" />
                                    <Columns>
                                        <asp:BoundField DataField="UserName" HeaderText="Name" 
                                            SortExpression="UserName">
                                            <ItemStyle Width="150px" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Action" HeaderText="Action" SortExpression="Action" >
                                            <ItemStyle Width="150px" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                                    <asp:TemplateField>
                <ItemTemplate>
 <telerik:RadEditor RenderMode="Lightweight" runat="server" ID="radEditorRemarks" Width="99%" CssClass="" AutoResizeHeight="true" BackColor="White" EditType="Inline" Enabled="false"  ExternalDialogsPath="~/RadEditorDialogs/" EditModes="Preview">       
        <ExportSettings FileName="export" OpenInNewWindow="true">
            <Docx PageHeader="" />
        </ExportSettings>
        <Content>
           
        </Content>

        <TrackChangesSettings CanAcceptTrackChanges="False"></TrackChangesSettings>
    </telerik:RadEditor>
                </ItemTemplate>
            </asp:TemplateField>
                                      
                                        <asp:BoundField DataField="CreatedDate" HeaderText="Time" 
                                            SortExpression="CreatedDate" DataFormatString="{0:dd/MM/yyyy hh:mm tt}">
                                             <ItemStyle Width="180px" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                    </Columns>
                                    <RowStyle BackColor="White" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="#333333" />
                                    <PagerStyle BackColor="Navy" ForeColor="White" HorizontalAlign="Right" />
                                    <HeaderStyle BackColor="Navy" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
         <asp:Label ID="lblErrorBottom" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
    
    <asp:SqlDataSource ID="DSRemarks" runat="server" 
         ConnectionString="<%$ ConnectionStrings:BPMConnectionString %>" ProviderName="<%$ ConnectionStrings:BPMConnectionString.ProviderName %>"                 
        SelectCommand="SELECT     T00001.T1F0022 AS Remarks, T00001.T1F0021 AS Action, ISNULL(T00009.T9F0007, T00001.T1F0005) AS UserName, T00009.T9F0002 AS JobTitle, 
                      T00001.T1F0008 AS CreatedDate, T00001.T1F0003 AS ActivityName
FROM         T00001 RIGHT OUTER JOIN
                      T00009 ON T00001.T1F0005 = T00009.T9F0003
WHERE     (T00001.T1F0002 = @ProcessName) AND (T00001.T1F0004 = @IncidentNo) AND (T00001.T1F0009 IN (3, 4))AND (T00001.T1F0012 IN (2, 4))
ORDER BY CreatedDate">
        <SelectParameters>
            <asp:Parameter Name="ProcessName" />
            <asp:Parameter Name="IncidentNo" />
        </SelectParameters>
    </asp:SqlDataSource>
    </div>
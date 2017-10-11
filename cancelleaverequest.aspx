<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="cancelleaverequest.aspx.cs" Inherits="cancelleaverequest" Title="取消請假" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>註銷請假</h2>
 <asp:GridView ID="GridView1" runat="server"
   DataSourceID="obsLeaveRequests"
        EmptyDataText ="No Leave Requests Are Available!" 
        DataKeyNames = "requestid"
        AutoGenerateColumns="False" >
     <Columns>
         <asp:BoundField DataField="startdate" HeaderText="起始日" />
         <asp:BoundField DataField="enddate" HeaderText="結束日" />
         <asp:BoundField DataField="leavetype" HeaderText="請假類型" />
         <asp:BoundField DataField="reason" HeaderText="原因" />
         <asp:BoundField DataField="requestid" Visible="False" />
         <asp:TemplateField>
            <ItemTemplate>
             <asp:Button runat="server" Text="註銷"
               CommandName="delete" OnClientClick="return confirm('Do you want to delete leave')"  />
            </ItemTemplate>
         </asp:TemplateField>
     </Columns>
   </asp:GridView>
    <asp:ObjectDataSource ID="obsLeaveRequests" runat="server" 
        SelectMethod="GetNewLeaveRequests" TypeName="RequestsDAL" 
        DeleteMethod="CancelLeaveRequest">
        <DeleteParameters>
            <asp:Parameter Name="requestid" Type="Int32" />
        </DeleteParameters>
        <SelectParameters>
            <asp:SessionParameter Name="employeeid" SessionField="employeeid" 
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>


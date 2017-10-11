<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="responseleaverequest.aspx.cs" Inherits="responseleaverequest" Trace = "true"  Title="簽核" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="AjaxControlToolkit"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h2>請假簽核</h2>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="obsLeaveRequests"
        EmptyDataText ="No Leave Requests Are Available!"
        DataKeyNames = "requestid" 
        AutoGenerateColumns="False">
        <Columns>
		 <asp:BoundField DataField="FullName" HeaderText="員工" />
         <asp:BoundField DataField="startdate" HeaderText="起始日" />
         <asp:BoundField DataField="enddate" HeaderText="結束日" />
         <asp:BoundField DataField="leavetype" HeaderText="請假類型" />
         <asp:BoundField DataField="reason" HeaderText="原因" />
         <asp:BoundField DataField="status" HeaderText="狀態" />
         <asp:BoundField DataField="requestedon" HeaderText="申請日" />
         <asp:BoundField DataField="requestid" Visible="False" />
         <asp:TemplateField>
            <ItemTemplate>
             <asp:Button runat="server" Text="簽核"
               CommandName="update" OnClientClick="return confirm('Do you want to update leave')" />
             <asp:Button runat="server" Text="退回"
               CommandName="delete" OnClientClick="return confirm('Do you want to update leave')" />
            </ItemTemplate>
         </asp:TemplateField>
		</Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="obsLeaveRequests" runat="server" 
        SelectMethod="GetLeaveRequestsByLeader" TypeName="RequestsDAL"
        UpdateMethod="UpdateLeaveRequest"
        DeleteMethod="RejectLeaveRequest">
        <UpdateParameters>
            <asp:Parameter Name="requestid" Type="Int32" />
        </UpdateParameters>
        <DeleteParameters>
            <asp:Parameter Name="requestid" Type="Int32" />
        </DeleteParameters>
        <SelectParameters>
            <asp:SessionParameter Name="employeeid" SessionField="employeeid" 
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:Label ID="lblMsg" runat="server" Text="" EnableViewState="false"></asp:Label>
</asp:Content>


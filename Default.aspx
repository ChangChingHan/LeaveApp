<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="首頁" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>請假紀錄</h2>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="obsLeaveRequests"
        EmptyDataText ="No Leave Requests Are Available!" AutoGenerateColumns="False">
        <Columns>
         <asp:BoundField DataField="startdate" HeaderText="起始日" />
         <asp:BoundField DataField="enddate" HeaderText="結束日" />
         <asp:BoundField DataField="leavetype" HeaderText="請假類型" />
         <asp:BoundField DataField="reason" HeaderText="原因" />
         <asp:BoundField DataField="status" HeaderText="狀態" />
         <asp:BoundField DataField="requestedon" HeaderText="申請日" />
		</Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="obsLeaveRequests" runat="server" 
        SelectMethod="GetLeaveRequests" TypeName="RequestsDAL">
        <SelectParameters>
            <asp:SessionParameter Name="employeeid" SessionField="employeeid" 
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
    
</asp:Content>



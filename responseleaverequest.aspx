<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="responseleaverequest.aspx.cs" Inherits="responseleaverequest" Trace = "true"  Title="ñ��" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="AjaxControlToolkit"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h2>�а�ñ��</h2>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="obsLeaveRequests"
        EmptyDataText ="No Leave Requests Are Available!"
        DataKeyNames = "requestid" 
        AutoGenerateColumns="False">
        <Columns>
		 <asp:BoundField DataField="FullName" HeaderText="���u" />
         <asp:BoundField DataField="startdate" HeaderText="�_�l��" />
         <asp:BoundField DataField="enddate" HeaderText="������" />
         <asp:BoundField DataField="leavetype" HeaderText="�а�����" />
         <asp:BoundField DataField="reason" HeaderText="��]" />
         <asp:BoundField DataField="status" HeaderText="���A" />
         <asp:BoundField DataField="requestedon" HeaderText="�ӽФ�" />
         <asp:BoundField DataField="requestid" Visible="False" />
         <asp:TemplateField>
            <ItemTemplate>
             <asp:Button runat="server" Text="ñ��"
               CommandName="update" OnClientClick="return confirm('Do you want to update leave')" />
             <asp:Button runat="server" Text="�h�^"
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


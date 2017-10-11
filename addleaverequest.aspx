<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="addleaverequest.aspx.cs" Inherits="addleaverequest" Title="請假" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="AjaxControlToolkit"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <h2>請假申請</h2>
<table>
 <tr>
 <td> 起始日 [mm/dd/yyyy] :  </td>
 <td>
   <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
   
     <AjaxControlToolkit:CalendarExtender ID="txtStartDate_CalendarExtender" runat="server" 
         format="MM/dd/yyyy" Enabled="True" TargetControlID="txtStartDate">
     </AjaxControlToolkit:CalendarExtender>
   
   <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
    runat="server" ControlToValidate ="txtStartDate" 
    Display = "dynamic"
    ErrorMessage="Required"></asp:RequiredFieldValidator>
 </td>
 </tr>
 <tr>
 <td>結束日 [mm/dd/yyyy] : </td>
 <td>
    <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
     <AjaxControlToolkit:CalendarExtender ID="txtEndDate_CalendarExtender" runat="server" 
        format="MM/dd/yyyy"  Enabled="True" TargetControlID="txtEndDate">
     </AjaxControlToolkit:CalendarExtender>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
        runat="server" ControlToValidate ="txtEndDate" 
         Display = "dynamic"
        ErrorMessage="Required"></asp:RequiredFieldValidator>
    </td>
 </tr>
  <tr>
 <td>請假類型</td>
  <td>
      <asp:DropDownList ID="ddlLeaveType" runat="server">
        <asp:ListItem Value = "c" Text = "特休" />
        <asp:ListItem Value = "s" Text = "病假" />
        <asp:ListItem Value = "p" Text = "事假" />
      </asp:DropDownList>
 </td>
 </tr>
 <tr>
 <td>請假原因 : </td>
 <td>
    <asp:TextBox ID="txtReason"  runat="server"></asp:TextBox>
 </td>
 </tr>
</table>
<p />
    <asp:Button ID="btnAdd" runat="server" Text="送出" 
        onclick="btnAdd_Click" />
        <p />
    <asp:Label ID="lblMsg" runat="server" Text="" EnableViewState="false"></asp:Label>
</asp:Content>


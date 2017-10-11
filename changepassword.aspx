<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="changepassword.aspx.cs" Inherits="changepassword" Title="更改密碼" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>更改密碼</h2>
<table>
 <tr>
 <td>舊密碼 : </td>
 <td>
   <asp:TextBox ID="txtOldPassword"  TextMode="Password" runat="server"></asp:TextBox>
   <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
    runat="server" ControlToValidate ="txtOldPassword" 
     Display = "dynamic"
    ErrorMessage="Required"></asp:RequiredFieldValidator>
 </td>
 </tr>
  <tr>
 <td>新密碼 : </td>
 <td>
    <asp:TextBox ID="txtNewPassword"  TextMode="Password" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
        runat="server" ControlToValidate ="txtNewPassword" 
         Display = "dynamic"
        ErrorMessage="Required"></asp:RequiredFieldValidator>
    </td>
 </tr>
  <tr>
 <td>再次輸入新密碼 : </td>
 <td><asp:TextBox ID="txtConfirmPassword"
     TextMode="Password" runat="server"></asp:TextBox>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
        runat="server"  Display = "dynamic" ControlToValidate ="txtConfirmPassword" 
        ErrorMessage="Required"></asp:RequiredFieldValidator>
     <asp:CompareValidator ID="CompareValidator1" runat="server" 
      ControlToValidate ="txtNewPassword" ControlToCompare ="txtConfirmPassword"
      Operator="Equal" Type="String"    Display = "dynamic"
      ErrorMessage="Passwords Mismatch!"></asp:CompareValidator>        
 </td>
 </tr>
</table>
<p />
    <asp:Button ID="btnChange" runat="server" Text="更新密碼" 
        onclick="btnChange_Click" />
        <p />
    <asp:Label ID="lblMsg" runat="server" Text="" EnableViewState="false"></asp:Label>
</asp:Content>


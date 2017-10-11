<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" Trace="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>登入</title>
</head>
<body>
    <form id="form1" runat="server">
    <center>
     <table class="maintable">
       <tr style="height:50px"  valign ="top">
        <td>
         <div class="header">出缺勤系統</div>
        </td>
       </tr>
       <tr>
       <td align="center" valign="top">
       <h2>進入系統</h2>
       <table>
         <tr>
         <td>
         員工號碼 : 
         </td>
         <td>
             <asp:TextBox ID="txtEmployeeId"  Width="150px" runat="server"></asp:TextBox>
         </td>
         </tr>
         
         <tr>
         <td>
         密碼 : 
         </td>
         <td>
             <asp:TextBox ID="txtPassword"  Width="150px"  TextMode ="password" runat="server"></asp:TextBox>
         </td>
         </tr>

       </table>
       
       <p/>
           <asp:Button ID="btnLogin" runat="server" Text="登入" 
               onclick="btnLogin_Click" />
           <p />
           <asp:Label ID="lblMsg" runat="server" Text="" EnableViewState="false"></asp:Label>
       
       
       </td>
       </tr>
       <tr height="50px" valign= "bottom">
       <td>
          <div  class="footer">All Rights reserved.&copy; Srikanth Technologies</div>
       </td>
       </tr>
       
     </table>
    </center>
    </form>
</body>
</html>

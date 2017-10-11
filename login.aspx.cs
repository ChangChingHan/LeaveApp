using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string fullname = EmployeeDAL.Login
            (txtEmployeeId.Text, txtPassword.Text);
        if (fullname == null)
        {
            lblMsg.Text = "Sorry! Invalid Login. Try Again!";
            txtEmployeeId.Focus();
        }
        else
        {
            // put required data in session 
            Session.Add("employeeid", txtEmployeeId.Text);
            Session.Add("fullname", fullname);
            FormsAuthentication.RedirectFromLoginPage(txtEmployeeId.Text, false);
        }

    }
}

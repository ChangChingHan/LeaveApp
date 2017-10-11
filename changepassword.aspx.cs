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

public partial class changepassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnChange_Click(object sender, EventArgs e)
    {
        bool done = EmployeeDAL.ChangePassword(
            Session["employeeid"].ToString(),
            txtOldPassword.Text,
            txtNewPassword.Text);
        if (done)
            lblMsg.Text = "Password Changed Successfully!";
        else
            lblMsg.Text = "Sorry! Could not change password! ";
    }
}

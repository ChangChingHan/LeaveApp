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

public partial class addleaverequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
		int EmployeeId = Int32.Parse(Session["employeeid"].ToString());

		Employee employee = EmployeeDAL.GetEmployee(EmployeeId);
        LeaveRequest request = new LeaveRequest();
        request.EmployeeId = EmployeeId;

		request.StartDate = Convert.ToDateTime(txtStartDate.Text);
        request.StartDate = DateTime.Parse (txtStartDate.Text);
        request.EndDate = DateTime.Parse(txtEndDate.Text);
        request.LeaveType = ddlLeaveType.SelectedItem.Value;
        request.Reason = txtReason.Text;
        request.RequestedOn = DateTime.Now;
        request.Status = "n"; // new 
		request.Approve_Person = employee.Leader1.ToString();

        bool done = RequestsDAL.AddLeaveRequest(request);
        if (done)
            lblMsg.Text = "Your request for leave has been stored";
        else
            lblMsg.Text = "Sorry! Could not store your request. Try again!";
    }
}

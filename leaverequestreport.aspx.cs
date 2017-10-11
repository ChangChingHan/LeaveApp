// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Web;
// using System.Web.UI;
// using System.Web.UI.WebControls;
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


public partial class leaverequestreport : System.Web.UI.Page
{
	DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
		if (RequestsDAL.IsReport(Int32.Parse(Session["employeeid"].ToString())) == false)
		{
			lblMsg.Text = "您無此權限";
			GridView1.Visible = false;
		}
		else
		{
			dt = new DataTable();
			dt.Columns.Add("Employee");
			dt.Columns.Add("startdate");
			dt.Columns.Add("enddate");
			dt.Columns.Add("leavetype");
			dt.Columns.Add("reason");
			dt.Columns.Add("status");
		}
    }

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		RequestsDAL.SearchLeaveRequest(ref dt, DateTime.Parse(txtStartDate.Text), 
			DateTime.Parse(txtEndDate.Text), ddlLeaveType.SelectedItem.Value, txtName.Text);

		GridView1.DataSource = dt;
		GridView1.DataBind();


// 		LeaveRequest request = new LeaveRequest();
// 		request.EmployeeId = Int32.Parse(Session["employeeid"].ToString());
// 
// 		request.StartDate = Convert.ToDateTime(txtStartDate.Text);
// 		request.StartDate = DateTime.Parse(txtStartDate.Text);
// 		request.EndDate = DateTime.Parse(txtEndDate.Text);
// 		request.LeaveType = ddlLeaveType.SelectedItem.Value;
// 		request.Reason = txtReason.Text;
// 		request.RequestedOn = DateTime.Now;
// 		request.Status = "n"; // new 
// 
// 		bool done = RequestsDAL.AddLeaveRequest(request);
// 		if (done)
// 			lblMsg.Text = "Your request for leave has been stored";
// 		else
// 			lblMsg.Text = "Sorry! Could not store your request. Try again!";
	}
}

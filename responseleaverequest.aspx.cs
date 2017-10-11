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

public partial class responseleaverequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (RequestsDAL.IsLeader(Int32.Parse(Session["employeeid"].ToString())) == false)
		{
			lblMsg.Text = "您無此權限";
			GridView1.Visible = false;
		}
		else
		{
// 			foreach (GridViewRow v in GridView1.Rows)
// 			{
// 				int n = 0;
// 				if (Int32.TryParse(v.Cells[0].Text,out n) == true)
// 				{
// 					string s = EmployeeDAL.GetEmployeeNmae(n);
// 					v.Cells[0].Text = s;
// 				}
// 			}
 		}
    }
    protected void btnPermit_Click(object sender, EventArgs e)
    {
		RequestsDAL.UpdateLeaveRequest(Int32.Parse(Session["employeeid"].ToString()));
//         CabRequest cr = new CabRequest();
//         cr.EmployeeId = Int32.Parse(Session["employeeid"].ToString());
//         cr.FromPlace = Int32.Parse(ddlFromPlace.SelectedItem.Value);
//         cr.ToPlace = Int32.Parse(ddlToPlace.SelectedItem.Value);
//         cr.RequiredDate = DateTime.Parse(txtRequiredDate.Text);
//         cr.RequiredTime = txtRequiredTime.Text;
//         cr.RequestedOn = DateTime.Now;
//         cr.Remarks = txtRemarks.Text;
//         cr.Status = "n";
// 		bool done = RequestsDAL.ResponseLeaveRequest(cr);
//         if (done)
//             lblMsg.Text = "Added Cab Request Successfully!";
//         else
//             lblMsg.Text = "Sorry! Could not add cab request!";
    }
}

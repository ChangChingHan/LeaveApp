using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.Linq.Mapping;
using System.Data.Linq;

[Table(Name = "employees")]
public class Employee
{
    [Column(Name = "empid", IsPrimaryKey = true)]
    public int EmployeeId { get; set; }

	private EntitySet<LeaveRequest> _LeaveRequests;
	[Association(Storage = "_LeaveRequests", OtherKey = "EmployeeId")]
	public EntitySet<LeaveRequest> LeaveRequests
	{
		get { return this._LeaveRequests; }
		set { this._LeaveRequests.Assign(value); }
	}


    [Column(Name = "password")]
    public string Password { get; set; }

    [Column(Name = "fullname")]
    public string FullName { get; set; }


    [Column(Name = "email")]
    public string Email { get; set; }

    [Column(Name = "mobile")]
    public string MobileNumber { get; set; }

	[Column(Name = "leader_1")]
	public int Leader1 { get; set; }

	[Column(Name = "leader_2")]
	public int Leader2 { get; set; }
}

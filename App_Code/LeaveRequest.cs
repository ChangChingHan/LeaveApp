// using System;
// using System.Data.Linq.Mapping;
// using System.Data.Linq;

using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.Linq;
using System.Data.Linq.Mapping;

[Table (Name="LeaveRequests")]
public class LeaveRequest
{
    [Column(Name = "requestid", IsPrimaryKey = true, IsDbGenerated = true)]
    public int RequestId { get; set; }

    [Column(Name = "empid")]
    public int EmployeeId { get; set; }

    [Column(Name = "requestedon")]
    public DateTime RequestedOn { get; set; }

    [Column(Name = "startdate")]
    public DateTime StartDate { get; set; }

	[Column(Name = "enddate")]
    public DateTime EndDate { get; set; }

    [Column(Name = "leavetype")]
    public string LeaveType { get; set; }

    [Column(Name = "reason")]
    public string Reason { get; set; }

    [Column(Name = "remarks")]
    public string Remarks { get; set; }

    [Column(Name = "status")]
    public string Status { get; set; }

	[Column(Name = "approve_person")]
	public string Approve_Person { get; set; }

	private EntityRef<Employee> _Employee;
	[Association(Storage = "_Employee", ThisKey = "EmployeeId")]
	public Employee Employees
	{
		get { return this._Employee.Entity; }
		set { this._Employee.Entity = value; }
	}

}

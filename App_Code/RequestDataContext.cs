using System;
using System.Data;
//using System.Linq;
using System.Data.Linq;

public class RequestDataContext : DataContext 
{
	public RequestDataContext() : 
        base( Database.ConnectionString )
	{
	}
    public Table<Employee> Employees
    {
        get
        {
            return GetTable<Employee>();
        }
    }

    public Table<LeaveRequest> LeaveRequests
    {
        get
        {
            return GetTable<LeaveRequest>();
        }
    }

	public Table<Leaders> Leaders
    {
        get
        {
			return GetTable<Leaders>();
        }
    }

    public Table<Place> Places
    {
        get
        {
            return GetTable<Place>();
        }
    }
}

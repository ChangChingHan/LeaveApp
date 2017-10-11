using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Collections;
using System.Data;

public class RequestsDAL
{
	public static void SearchLeaveRequest(ref DataTable dt, DateTime StartDate, DateTime EndDate, string LeaveType, string EmployeeName)
	{
		try
		{
			int EmployeeId = EmployeeDAL.GetEmployeeID(EmployeeName);
			RequestDataContext ctx = new RequestDataContext();
			IEnumerable request;

			if (EmployeeId == 0)
			{
				request = from req in ctx.LeaveRequests
						  where req.StartDate >= StartDate && req.EndDate <= EndDate && req.LeaveType == LeaveType
						  select req;
			} 
			else
			{
				request = from req in ctx.LeaveRequests
						  where req.StartDate >= StartDate && req.EndDate <= EndDate && req.LeaveType == LeaveType && req.EmployeeId == EmployeeId
						  select req;
			}
			

			foreach (LeaveRequest v in request)
			{
				string name = EmployeeDAL.GetEmployeeNmae(v.EmployeeId);
				DataRow dr = dt.NewRow();
				dr["Employee"] = name;
				dr["startdate"] = v.StartDate.ToShortDateString();
				dr["enddate"] = v.EndDate.ToShortDateString();
				dr["leavetype"] = GetLeaveName(v.LeaveType);
				dr["reason"] = v.Reason;
				dr["status"] = GetStatusName(v.Status);
				dt.Rows.Add(dr);
			}
		}
		catch (Exception ex)
		{
			Utilities.WriteToTrace("RequestDAL.SearchLeaveRequest()", ex);
		}
	}

	public static Leaders.Authorize LeaderType(int employeeid)
	{
		try
		{
			RequestDataContext ctx = new RequestDataContext();
			Leaders request = (from req in ctx.Leaders
							   where req.LeaderId == employeeid
							   select req).SingleOrDefault();
			if (request != null)
			{
				return request.Author;
			}
			return Leaders.Authorize.Authorize_NON;
		}
		catch (Exception ex)
		{
			Utilities.WriteToTrace("RequestDAL.LeaderType()", ex);
			return Leaders.Authorize.Authorize_NON;
		}
	}
	public static bool IsLeader(int employeeid)
	{
		Leaders.Authorize a = LeaderType(employeeid);
		if (a == Leaders.Authorize.Authorize_APPR)
		{
			return true;
		} 
		else
		{
			return false;
		}
	}
	public static bool IsReport(int employeeid)
	{
		Leaders.Authorize a = LeaderType(employeeid);
		if (a == Leaders.Authorize.Authorize_REPORT)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
    public static bool CancelLeaveRequest(int requestid)
    {
        try
        {
            RequestDataContext ctx = new RequestDataContext();
            var request = (from req in ctx.LeaveRequests
                           where req.RequestId == requestid
                           select req).SingleOrDefault();
            if (request != null)
            {
                ctx.LeaveRequests.DeleteOnSubmit(request);
                ctx.SubmitChanges();
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            Utilities.WriteToTrace("RequestDAL.CancelLeaveRequest()", ex);
            return false;
        }
    }
    public static bool AddLeaveRequest(LeaveRequest request)
    {
        try
        {
            RequestDataContext ctx = new RequestDataContext();
            ctx.LeaveRequests.InsertOnSubmit (request);
            ctx.SubmitChanges();
            return true;
        }
        catch (Exception ex)
        {
            Utilities.WriteToTrace("RequestDAL.AddLeaveRequest()", ex);
            return false; 
        }
   }
    public static string GetLeaveName(string ltype) 
	{
        return ltype == "s" ? "病假" :
               ltype == "p" ? "事假" : "特休";
    }
    public static string GetStatusName(string status)
    {
        return	status == "n" ? "新假單" :
				status == "t" ? "簽核中" :
				status == "a" ? "已簽核" : "退回";
    }
    public static IEnumerable GetLeaveRequests(int employeeid)
    {
        try
        {
            RequestDataContext ctx = new RequestDataContext();
            var lrs = from req in ctx.LeaveRequests
                      where req.EmployeeId == employeeid
                      orderby req.StartDate
                      select new
                      {
						  EmployeeId = req.EmployeeId,
                          StartDate = req.StartDate.ToShortDateString(),
                          EndDate = req.EndDate.ToShortDateString(),
                          LeaveType = GetLeaveName(req.LeaveType),
                          Reason = req.Reason,
                          Status = GetStatusName(req.Status),
                          RequestedOn = req.RequestedOn.ToShortDateString()
                      };

            return lrs;
        }
        catch (Exception ex)
        {
            Utilities.WriteToTrace("RequestDAL.GetLeaveRequests()", ex);
            return null;
        }
    }
	public static IEnumerable GetLeaveRequestsByLeader(int employeeid)
	{
		try
		{
			RequestDataContext ctx = new RequestDataContext();
// 			var elist = from req in ctx.Employees
// 						where req.Leader1 == employeeid || req.Leader2 == employeeid
// 						select req.EmployeeId;

// 			var lrs = from req in ctx.LeaveRequests
// 					  where elist.Contains(req.EmployeeId)
// 					  orderby req.StartDate
			var lrs = from req in ctx.LeaveRequests
					  where req.Approve_Person == employeeid.ToString()
					  orderby req.StartDate
					  select new
					  {
						  RequestId = req.RequestId,
						  FullName = req.Employees.FullName,
						  StartDate = req.StartDate.ToShortDateString(),
						  EndDate = req.EndDate.ToShortDateString(),
						  LeaveType = GetLeaveName(req.LeaveType),
						  Reason = req.Reason,
						  Status = GetStatusName(req.Status),
						  RequestedOn = req.RequestedOn.ToShortDateString(),
					  };

			return lrs;
		}
		catch (Exception ex)
		{
			Utilities.WriteToTrace("RequestDAL.GetLeaveRequestsByLeader()", ex);
			return null;
		}
	}
	public static bool RejectLeaveRequest(int requestid)
	{
		try
		{
			RequestDataContext ctx = new RequestDataContext();
			var lrs = (from req in ctx.LeaveRequests
					  where req.RequestId == requestid
					   select req).SingleOrDefault();

			if (lrs != null)
			{
				Employee employee = EmployeeDAL.GetEmployee(lrs.EmployeeId);
				lrs.Status = "r";
				lrs.Approve_Person = employee.Leader1.ToString();
				ctx.SubmitChanges();
				return true;
			}


			return true;
		}
		catch (Exception ex)
		{
			Utilities.WriteToTrace("RequestDAL.RejectLeaveRequest()", ex);
			return false;
		}
	}
	public static bool UpdateLeaveRequest(int requestid)
	{
		try
		{
			RequestDataContext ctx = new RequestDataContext();
			var lrs =	(from req in ctx.LeaveRequests
						where req.RequestId == requestid
						 select req).SingleOrDefault();

			if (lrs != null)
			{
				Employee employee = EmployeeDAL.GetEmployee(lrs.EmployeeId);
				if (lrs.Status == "n" || lrs.Status == "r")
				{
					lrs.Status = "t";
					lrs.Approve_Person = employee.Leader2.ToString();
				}
				else if (lrs.Status == "t")
				{
					lrs.Status = "a";
					lrs.Approve_Person = "done";
				}
				else
				{
					return true;
				}
				ctx.SubmitChanges();
				return true;
			}
			
			
			return true;
		}
		catch (Exception ex)
		{
			Utilities.WriteToTrace("RequestDAL.UpdateLeaveRequest()", ex);
			return false;
		}
	}
    public static IEnumerable GetNewLeaveRequests(int employeeid)
    {
        try
        {
            RequestDataContext ctx = new RequestDataContext();
            var lrs = from req in ctx.LeaveRequests
                      where req.EmployeeId == employeeid &&
                            req.Status != "a" 
                      orderby req.StartDate
                      select new
                      {
                          RequestId  = req.RequestId,
                          StartDate = req.StartDate.ToShortDateString(),
                          EndDate = req.EndDate.ToShortDateString(),
                          LeaveType = GetLeaveName(req.LeaveType),
                          Reason = req.Reason
                      };

            return lrs;
            
        }
        catch (Exception ex)
        {
			Utilities.WriteToTrace("RequestDAL.GetNewLeaveRequests()", ex);
            return null;
        }
    }

}

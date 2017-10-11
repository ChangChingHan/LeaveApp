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

public class EmployeeDAL
{
	public static int GetEmployeeID(string name)
	{
		try
		{
			RequestDataContext ctx = new RequestDataContext();
			var request = (from req in ctx.Employees
						   where req.FullName == name
						   select req).SingleOrDefault();
			if (request != null)
			{
				return request.EmployeeId;
			}
			return 0;
		}
		catch (Exception ex)
		{
			Utilities.WriteToTrace("EmployeeDAL.GetEmployeeID()", ex);
			return 0;
		}
	}
	public static string GetEmployeeNmae(int emid)
	{
		try
		{
			RequestDataContext ctx = new RequestDataContext();
			var request = (from req in ctx.Employees
						   where req.EmployeeId == emid
						   select req).SingleOrDefault();
			if (request != null)
			{
				return request.FullName;
			}
			return null;
		}
		catch (Exception ex)
		{
			Utilities.WriteToTrace("EmployeeDAL.GetEmployeeNmae()", ex);
			return null;
		}
	}
	public static Employee GetEmployee(int emid)
	{
		try
		{
			RequestDataContext ctx = new RequestDataContext();
			var request = (from req in ctx.Employees
						   where req.EmployeeId == emid
						   select req).SingleOrDefault();
			if (request != null)
			{
				return request;
			}
			return null;
		}
		catch (Exception ex)
		{
			Utilities.WriteToTrace("EmployeeDAL.GetEmployeeNmae()", ex);
			return null;
		}
	}
    /* returns fullname on success or null on failure */
    public static string Login(string empid, string password)
    {
        try
        {
            RequestDataContext ctx = new RequestDataContext();
            var emp = (from e in ctx.Employees
                       where e.EmployeeId == Int32.Parse(empid) &&
                              e.Password == password
                       select e).SingleOrDefault();
            if (emp == null)
                return null;
            else
                return emp.FullName;
        }
        catch (Exception ex)
        {
            Utilities.WriteToTrace("EmployeeDAL.Login()", ex);
            return null;
        }
    }

   


    /* returns true on success and false on failure */
    public static bool ChangePassword(string empid, string oldpassword, string newpassword)
    {
        try
        {
            RequestDataContext ctx = new RequestDataContext();
            var emp = (from e in ctx.Employees
                       where e.EmployeeId == Int32.Parse(empid)
                       && e.Password ==  oldpassword
                       select e).SingleOrDefault();
            if (emp == null)
                return false;
            else
            {
                emp.Password = newpassword;
                ctx.SubmitChanges();
                return true;
            }
        }
        catch (Exception ex)
        {
            Utilities.WriteToTrace("EmployeeDAL.ChangePassword()",ex);
            return false; 
        }
    }
}

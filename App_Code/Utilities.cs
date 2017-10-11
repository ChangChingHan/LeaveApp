using System;
using System.Web;
public class Utilities
{
    public static void WriteToTrace(string functionname,
           Exception ex)
    {
        HttpContext.Current.Trace.Write
           ("Error message from " + functionname + " : " +
           ex.Message);
        HttpContext.Current.Trace.Write
          ("Error message from " + functionname + " : " +
          ex.StackTrace);

    }
}

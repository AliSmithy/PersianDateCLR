using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Globalization;

public static class PersianDateCLR
{
  [Microsoft.SqlServer.Server.SqlFunction]
	public static SqlString GregorianToPersian(SqlDateTime GregorianDate, SqlString Separator)
	{
		try
		{
			PersianCalendar pc = new PersianCalendar();
			int y = pc.GetYear(GregorianDate.Value);
			int m = pc.GetMonth(GregorianDate.Value);
			int d = pc.GetDayOfMonth(GregorianDate.Value);
			if (Separator.IsNull)
				return string.Format("{0:d4}/{1:d2}/{2:d2}", y, m, d);
			else
				return string.Format("{0:d4}{3}{1:d2}{3}{2:d2}", y, m, d, Separator);
		}
		catch
		{
			return SqlString.Null;
		}
	}

	[Microsoft.SqlServer.Server.SqlFunction]
	public static SqlDateTime PersianToGregorian(SqlString date)
	{
		try
		{
			PersianCalendar pc = new PersianCalendar();
			int y = Convert.ToInt32(date.Value.Substring(0, 4));
			int m = Convert.ToInt32(date.Value.Substring(5, 2));
			int d = Convert.ToInt32(date.Value.Substring(8, 2));
			pc.ToDateTime(y, m, d, 0, 0, 0, 0);
			return pc.ToDateTime(y, m, d, 0, 0, 0, 0);
		}
		catch
		{
			return SqlDateTime.Null;
		}
	}

	[Microsoft.SqlServer.Server.SqlFunction]
	public static SqlInt32 PersianYear(SqlDateTime GregorianDate)
	{
		PersianCalendar pc = new PersianCalendar();
		try
		{
			int y = pc.GetYear(GregorianDate.Value);
			return y;
		}
		catch
		{
			return SqlInt32.Null;
		}
	}
  
	[Microsoft.SqlServer.Server.SqlFunction]
	public static SqlInt32 PersianMonth(SqlDateTime GregorianDate)
	{
		PersianCalendar pc = new PersianCalendar();
		try
		{
			int m = pc.GetMonth(GregorianDate.Value);
			return m;
		}
		catch
		{
			return SqlInt32.Null;
		}
	}

  [Microsoft.SqlServer.Server.SqlFunction]
	public static SqlInt32 PersianDay(SqlDateTime GregorianDate)
	{
		PersianCalendar pc = new PersianCalendar();
		try
		{
			int m = pc.GetDayOfMonth(GregorianDate.Value);
			return m;
		}
		catch
		{
			return SqlInt32.Null;
		}
	}
}
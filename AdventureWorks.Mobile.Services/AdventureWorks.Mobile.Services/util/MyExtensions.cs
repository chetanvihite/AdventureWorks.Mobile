using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AdventureWorks.Mobile.Services.util
{
    public static class MyExtensions
    {
        public static string AsString(this DataRow row, string columnName)
        {
            return row[columnName] != null ? row[columnName].ToString() : string.Empty;
        }
        public static decimal AsDecimal(this DataRow row, string columnName)
        {
            return row[columnName] != null ? Convert.ToDecimal(row[columnName].ToString()) : decimal.Zero;
        }
        public static DateTime? AsDate(this DataRow row, string columnName)
        {
            if (row[columnName] != null)
            {
                DateTime value;
                var data = row[columnName].ToString();
                var success = DateTime.TryParse(data, out value);
                if (success) return value;
            }
            return null;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Extensions
{
    public static class EFExtensions
    {
        public static string ToSqlParamsString(this IDictionary<string, string> dict)
        {
            string result = string.Empty;
            foreach (var kvp in dict)
            {
                result += $"@{kvp.Key}='{kvp.Value}',";
            }
            return result.Trim(',', ' ');
        }

    }
}

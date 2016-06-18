using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyllan.Common.Utility
{
    public static class DbDataReaderHelper
    {
        public static int ReadInteger(this DbDataReader reader, int index)
        {
            return !reader.IsDBNull(index) ? reader.GetInt32(index) : 0;
        }

        public static float ReadFloat(this DbDataReader reader, int index)
        {
            return !reader.IsDBNull(index) ? (float)reader.GetDouble(index) : 0f;
        }

        public static string ReadString(this DbDataReader reader, int index, string defaultValue = "", bool trim = true)
        {
            string value = !reader.IsDBNull(index) ? reader.GetString(index) : defaultValue;
            return trim ? value.Trim() : value;
        }

        public static Guid ReadGuid(this DbDataReader reader, int index)
        {
            return !reader.IsDBNull(index) ? reader.GetGuid(index) : Guid.Empty;
        }

        public static DateTime ReadDate(this DbDataReader reader, int index)
        {
            return !reader.IsDBNull(index) ? reader.GetDateTime(index) : DateTime.MinValue;
        }

        public static T ReadEnum<T>(this DbDataReader reader, int index, T defaultValue) where T : struct
        {
            T result = defaultValue;
            T tempValue = default(T);
            string value = !reader.IsDBNull(index) ? reader.ReadString(index) : "";
            if (Enum.TryParse<T>(value, out tempValue))
            {
                result = tempValue;
            }
            return result;
        }

        public static TimeSpan ReadTimeSpan(this SqlDataReader reader, int index)
        {
            return !reader.IsDBNull(index) ? reader.GetTimeSpan(index) : TimeSpan.Zero;
        }
    }
}

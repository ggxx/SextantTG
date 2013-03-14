using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SextantTG.Util
{
    public class TypeConverter
    {
        private static System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.InvariantCulture;

        public static String ToString(object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return string.Empty;
            else
                return obj.ToString();
        }

        public static string ToString(decimal? value, string strType)
        {
            return value.HasValue ? value.Value.ToString(strType) : string.Empty;
        }

        public static string ToString(int? value, string strType)
        {
            return value.HasValue ? value.Value.ToString(strType) : string.Empty;
        }

        public static string ToString(DateTime? value, string strType)
        {
            return value.HasValue ? value.Value.ToString(strType) : string.Empty;
        }

        public static ulong? ToULongNull(object obj)
        {
            return ToULongNull(obj, false);
        }

        public static ulong? ToULongNull(object obj, bool tag)
        {
            if (obj == null || obj == DBNull.Value)
                return tag ? 0 : new ulong?();
            ulong p;
            if (ulong.TryParse(obj.ToString(), out p))
                return p;
            else
                return tag ? 0 : new ulong?();
        }

        public static long? ToLongNull(object obj)
        {
            return ToLongNull(obj, false);
        }

        public static long? ToLongNull(object obj, bool tag)
        {
            if (obj == null || obj == DBNull.Value)
                return tag ? 0 : new long?();
            long p;
            if (long.TryParse(obj.ToString(), out p))
                return p;
            else
                return tag ? 0 : new long?();
        }

        public static float? ToFloatNull(object obj)
        {
            return ToFloatNull(obj, false);
        }

        public static float? ToFloatNull(object obj, bool tag)
        {
            if (obj == null || obj == DBNull.Value)
                return tag ? 0 : new float?();
            float p;
            if (float.TryParse(obj.ToString(), out p))
                return p;
            else
                return tag ? 0 : new float?();
        }

        public static int? ToInt32Null(object obj)
        {
            return ToInt32Null(obj, false);
        }

        public static int? ToInt32Null(object obj, bool tag)
        {
            if (obj == null || obj == DBNull.Value)
                return tag ? 0 : new int?();
            int p;
            if (int.TryParse(obj.ToString(), out p))
                return p;
            else
                return tag ? 0 : new int?();
        }

        public static decimal? ToDecimalNull(object obj)
        {
            return ToDecimalNull(obj, false);
        }

        public static decimal? ToDecimalNull(object obj, bool tag)
        {
            if (obj == null || obj == DBNull.Value)
                return tag ? 0 : new decimal?();
            decimal p;
            if (decimal.TryParse(obj.ToString(), out p))
                return p;
            else
                return tag ? 0 : new decimal?();
        }

        public static decimal? Add(decimal? d1, decimal? d2)
        {
            if (!d1.HasValue && !d2.HasValue)
            {
                return null;
            }
            else
            {
                return (d1.HasValue ? d1.Value : 0) + (d2.HasValue ? d2.Value : 0);
            }
        }

        public static object ToDBValue(object obj)
        {
            if (obj == null)
            {
                return DBNull.Value;
            }
            else
            {
                return obj;
            }
        }

        public static DateTime? ToDateTimeNull(object obj)
        {
            return ToDateTimeNull(obj, false);
        }

        public static DateTime? ToDateTimeNull(object obj, bool tag)
        {
            if (obj == null || obj == DBNull.Value)
                return tag ? DateTime.MinValue : new DateTime?();

            DateTime d;
            if (DateTime.TryParse(obj.ToString(), out d))
                return d;
            else
                return tag ? DateTime.MinValue : new DateTime?();
        }

        public static DateTime? ToDateTimeNull(object obj, string format)
        {
            return ToDateTimeNull(obj, format, false);
        }

        public static DateTime? ToDateTimeNull(object obj, string format, bool tag)
        {
            if (obj == null || obj == DBNull.Value)
                return tag ? DateTime.MinValue : new DateTime?();

            DateTime d;

            if (DateTime.TryParseExact(obj.ToString(), format, provider, System.Globalization.DateTimeStyles.None, out d))
                return d;
            else
                return tag ? DateTime.MinValue : new DateTime?();
        }
    }
}

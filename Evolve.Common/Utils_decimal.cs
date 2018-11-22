using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolve.Common
{
    public static class Utils_decimal
    {
        public static string ToFormatStr(this decimal val, string format = "{0:F2}")
        {
            return string.Format(format, val);
        }

        public static string ToFormatStr(this decimal val, int decimallPlace)
        {
            var fmt = "{" + "0:F" + decimallPlace.ToString() + "}";
            return string.Format(fmt, val);
        }
    }
}

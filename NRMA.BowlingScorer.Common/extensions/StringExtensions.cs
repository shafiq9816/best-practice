using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRMA.BowlingScorer.Common
{
    public static class StringExtensions
    {
        public static string NullIfEmpty(this string value)
        {
            if (value == String.Empty) return null;
            return value;
        }

        public static bool IsNotNullOrEmpty(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;
            return true;
        }

        public static bool IsNullOrEmpty(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return true;
            return false;
        }

    }
    
}

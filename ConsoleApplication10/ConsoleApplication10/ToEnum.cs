using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10
{
    public static class StringHelper
    {
        public static T ToEnum<T>(this string value)
        {

            return (T) Enum.Parse(typeof(T), value, true);

        }

    }
}

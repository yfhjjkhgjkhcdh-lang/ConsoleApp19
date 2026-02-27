using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    internal static class int_Extensions
    {
        public static bool IsEven(this int number)
        {
            return number % 2 == 0;
        }

    }
}

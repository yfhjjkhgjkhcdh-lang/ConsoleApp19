using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    internal class CHeaterFailedExceptioncs:Exception
    {
        public CHeaterFailedExceptioncs(string message):base(message) { }
    }
}

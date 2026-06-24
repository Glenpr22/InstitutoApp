using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academico.Common.Exceptions
{
    public class InvalidExceptionData : System.Exception
    {
        public InvalidExceptionData(string message) : base(message)
        {
        }

        public InvalidExceptionData()
        {
        }
    }
}

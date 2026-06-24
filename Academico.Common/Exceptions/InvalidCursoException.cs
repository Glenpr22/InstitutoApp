using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academico.Common.Exceptions
{
    public class InvalidCursoException : System.Exception
    {
        public InvalidCursoException(string message) : base(message)
        {
        }

        public InvalidCursoException()
        {
        }
    }
}

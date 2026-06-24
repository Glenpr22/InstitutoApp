using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academico.Common.Exceptions
{
    public class InvalidEstudianteException : System.Exception
    {
        public InvalidEstudianteException(string message) : base(message)
        {
        }

        public InvalidEstudianteException()
        {
        }
    }
}

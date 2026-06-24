using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academico.Common.Exceptions
{
    public class DuplicateEstudianteException : System.Exception
    {
        public DuplicateEstudianteException(string message) : base(message)
        {
        }

        public DuplicateEstudianteException()
        {
        }
    }
}

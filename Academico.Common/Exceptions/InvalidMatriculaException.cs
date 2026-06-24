using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academico.Common.Exceptions
{
    public class InvalidMatriculaException: System.Exception
    {
        public InvalidMatriculaException (string message) : base(message)
        {
        }

        public InvalidMatriculaException()
        {
        }

    }
}

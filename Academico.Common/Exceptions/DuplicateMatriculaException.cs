using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academico.Common.Exceptions
{

    public class DuplicateMatriculaException : System.Exception
    {
        public DuplicateMatriculaException(string message) : base(message)
        {
        }

        public DuplicateMatriculaException()
        {
        }
    }
}

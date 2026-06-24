using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academico.Common.Exceptions
{
    public class DuplicateCursoException : System.Exception
    {
        public DuplicateCursoException(string message) : base(message)
        {
        }

        public DuplicateCursoException()
        {
        }
    }
}

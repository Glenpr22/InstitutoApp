using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academico.DTOs.Curso
{
    public class CursoResponseDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public int CupoMaximo { get; set; }

        public bool Estado { get; set; }

        public DateTime FechaCreacion { get; set; }

    }//end class
}

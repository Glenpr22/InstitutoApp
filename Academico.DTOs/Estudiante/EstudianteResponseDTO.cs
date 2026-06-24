using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academico.DTOs.Estudiante
{
    public class EstudianteResponseDTO
    {
        public int Id { get; set; }

        public string Cedula { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;

        public string PrimerApellido { get; set; } = string.Empty;

        public string SegundoApellido { get; set; } = string.Empty;

        public string CorreoElectronico { get; set; } = string.Empty;

        public string? Telefono { get; set; }

        public bool Estado { get; set; }

        public DateTime FechaCreacion { get; set; }

    }//end class
}

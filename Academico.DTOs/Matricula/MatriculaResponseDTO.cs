using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academico.DTOs.Matricula
{
    public class MatriculaResponseDTO
    {
        public int Id { get; set; }

        public int EstudianteId { get; set; }

        public string EstudianteNombre { get; set; } = string.Empty;

        public int CursoId { get; set; }

        public string CursoNombre { get; set; } = string.Empty;

        public DateTime FechaMatricula { get; set; }

        public bool Estado { get; set; }

    }//end class
}

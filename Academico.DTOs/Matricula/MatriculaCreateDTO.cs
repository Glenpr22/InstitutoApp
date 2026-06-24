using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academico.DTOs.Matricula
{
    public class MatriculaCreateDTO
    {
        [Required(ErrorMessage = "El estudiante es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un estudiante valido.")]
        public int EstudianteId { get; set; }

        [Required(ErrorMessage = "El curso es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un curso valido.")]
        public int CursoId { get; set; }

    }//end class
}

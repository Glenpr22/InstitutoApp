using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academico.DTOs.Curso
{
    public class CursoCreateDTO
    { 

        [Required(ErrorMessage = "El nombre del curso es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripcion del curso es obligatoria.")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El cupo maximo es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El cupo maximo debe ser mayor que cero.")]
        public int CupoMaximo { get; set; }

        public bool Estado { get; set; } = true;

    }//end class
}

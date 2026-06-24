using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academico.DTOs.Estudiante
{
    public class EstudianteUpdateDTO
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "La cedula es obligatoria.")]
        public string Cedula { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre del estudiante es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El primer apellido del estudiante es obligatorio.")]
        public string PrimerApellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "El segundo apellido del estudiante es obligatorio.")]
        public string SegundoApellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo electronico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electronico no tiene un formato valido.")]
        public string CorreoElectronico { get; set; } = string.Empty;

        [Phone(ErrorMessage = "El telefono no tiene un formato valido.")]
        public string? Telefono { get; set; }

  
    }
}

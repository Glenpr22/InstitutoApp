using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academico.Entities
{
    // estudent of atributes of tipe Unique
    [Index(nameof(Cedula), IsUnique = true)]
    [Index(nameof(CorreoElectronico), IsUnique = true)]
    public class Estudiante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "La cedula es obligatoria.")]
        [MaxLength(20, ErrorMessage = "La cedula no puede superar los 20 caracteres.")]
        public string Cedula { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre del estudiante es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El primer apellido del estudiante es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El primer apellido no puede superar los 50 caracteres.")]
        public string PrimerApellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "El segundo apellido del estudiante es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El segundo apellido no puede superar los 50 caracteres.")]
        public string SegundoApellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo electronico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electronico no tiene un formato valido.")]
        [MaxLength(150, ErrorMessage = "El correo electronico no puede superar los 150 caracteres.")]
        public string CorreoElectronico { get; set; } = string.Empty;

        [Phone(ErrorMessage = "El telefono no tiene un formato valido.")]
        [MaxLength(20, ErrorMessage = "El telefono no puede superar los 20 caracteres.")]
        public string? Telefono { get; set; }

        public bool Estado { get; set; } = true;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();

    }//end class student entities

}//end namespace
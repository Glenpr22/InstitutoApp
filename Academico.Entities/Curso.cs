using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academico.Entities
{
    // entidad curso
    [Index(nameof(Nombre), IsUnique = true)]
    public class Curso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del curso es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripcion del curso es obligatoria.")]
        [MaxLength(250, ErrorMessage = "La descripcion no puede superar los 250 caracteres.")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El cupo maximo es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El cupo maximo debe ser mayor que cero.")]
        public int CupoMaximo { get; set; }

        public bool Estado { get; set; } = true;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();

    }//end class Course entities

}//end namespace
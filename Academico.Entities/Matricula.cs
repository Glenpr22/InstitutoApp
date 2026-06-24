using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academico.Entities
{
    
   // [Index(nameof(EstudianteId), nameof(CursoId), IsUnique = true)]
    public class Matricula
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El estudiante es obligatorio.")]
        public int EstudianteId { get; set; }

        [Required(ErrorMessage = "El curso es obligatorio.")]
        public int CursoId { get; set; }

        public DateTime FechaMatricula { get; set; } = DateTime.Now;

        public bool Estado { get; set; } = true;

        public Estudiante Estudiante { get; set; } = null!;

        public Curso Curso { get; set; } = null!;

    }//end class

}//end namespace
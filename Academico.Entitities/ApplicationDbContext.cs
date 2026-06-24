using Academico.Entities;
using Microsoft.EntityFrameworkCore;


namespace Academico.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }//end constructor


        //tablas de la base de datos
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }

        //fluid API para configurar el modelo de datos student,course,
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //NO se puede definir con data annotations
            //eje prelaciones, indices y llaves foraneas

            //relacion estudiante 1 => N matriculas
            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Estudiante)
                .WithMany(e => e.Matriculas)
                .HasForeignKey(m => m.EstudianteId);

            //relacion curso 1 => N matriculas
            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Curso)
                .WithMany(c => c.Matriculas)
                .HasForeignKey(m => m.CursoId);

            //evita matricular dos veces el mismo estudiante en el mismo curso
            modelBuilder.Entity<Matricula>()
                .HasIndex(m => new { m.EstudianteId, m.CursoId })
                .IsUnique();

            base.OnModelCreating(modelBuilder);

        }//end method



    }//end ApplicationDbContex
}

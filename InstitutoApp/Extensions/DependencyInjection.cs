using Academico.Common.Interfaces;
using Academico.Data;
using Academico.Entities;
using Academico.Repository;
using Academico.Services;
using Academico.Services.Mapper;
using Academico.DTOs.Estudiante;
using Academico.DTOs.Curso;
using Academico.DTOs.Matricula;
using Microsoft.EntityFrameworkCore;

namespace Academico.API.Extensions
{
    public static class DependencyInjection
    {
        //lleva coleccion de todas las inyecciones del programa
        public static IServiceCollection AddAplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            //base de datos - db context
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            //profile auto mapper
            services.AddAutoMapper(cfg => { }, typeof(MappingProfile));

            //inyeccion de dependencia de servicios
            services.AddScoped<IGenericService<EstudianteResponseDTO, EstudianteCreateDTO, EstudianteUpdateDTO>, EstudianteService>();
            services.AddScoped<IGenericService<CursoResponseDTO, CursoCreateDTO, CursoUpdateDTO>, CursoService>();

            //matricula no requiere update dto, se reutiliza create dto para cumplir la interfaz generica
            services.AddScoped<IGenericService<MatriculaResponseDTO, MatriculaCreateDTO, MatriculaCreateDTO>, MatriculaService>();

            //inyeccion de dependencia de repositorios
            services.AddScoped<IGenericRepository<Estudiante>, EstudianteRepository>();
            services.AddScoped<IGenericRepository<Curso>, CursoRepository>();
            services.AddScoped<IGenericRepository<Matricula>, MatriculaRepository>();

            return services;
        }
    }
}
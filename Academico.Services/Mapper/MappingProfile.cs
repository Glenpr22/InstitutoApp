using AutoMapper;
using Academico.Entities;
using Academico.DTOs.Estudiante;
using Academico.DTOs.Curso;
using Academico.DTOs.Matricula;

namespace Academico.Services.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // dto create => entity
            CreateMap<EstudianteCreateDTO, Estudiante>();
            CreateMap<CursoCreateDTO, Curso>();
            CreateMap<MatriculaCreateDTO, Matricula>();

            // dto update => entity
            CreateMap<EstudianteUpdateDTO, Estudiante>();
            CreateMap<CursoUpdateDTO, Curso>();

            // entity => dto response
            CreateMap<Estudiante, EstudianteResponseDTO>();
            CreateMap<Curso, CursoResponseDTO>();

            // entity => dto response con datos relacionados
            CreateMap<Matricula, MatriculaResponseDTO>()
                .ForMember(dest => dest.EstudianteNombre,
                    opt => opt.MapFrom(src => src.Estudiante.Nombre))
                .ForMember(dest => dest.CursoNombre,
                    opt => opt.MapFrom(src => src.Curso.Nombre));
        }
    }
}

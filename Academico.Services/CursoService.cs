using Academico.Common.Interfaces;
using Academico.Common.Exceptions;
using Academico.Common.Response;
using Academico.DTOs.Curso;
using Academico.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academico.Services
{
    public class CursoService : IGenericService<CursoResponseDTO, CursoCreateDTO, CursoUpdateDTO>
    {
        //inyeccion para el repository
        public readonly IGenericRepository<Curso> _cursoRepository;

        //inyeccion mapper
        private readonly IMapper _mapper;

        //now we can access the repository through the interface
        public CursoService(IGenericRepository<Curso> cursoRepository, IMapper mapper)
        {
            _cursoRepository = cursoRepository;
            _mapper = mapper;

        }//end method constructor

        //we contact the repository and check if there is data in the database
        public async Task<Response<List<CursoResponseDTO>>> ObtenerTodosAsync()
        {
            var cursoList = await _cursoRepository.ObtenerTodosAsync();

            if (cursoList == null || !cursoList.Any())
                throw new NotFoundException("No se encontraron cursos.");

            return new Response<List<CursoResponseDTO>>
            {
                Data = _mapper.Map<List<CursoResponseDTO>>(cursoList),
                Message = "Cursos obtenidos exitosamente",
                Success = true
            };

        }//end method getAll

        public async Task<Response<CursoResponseDTO>> ObtenerPorIdAsync(int id)
        {
            if (id <= 0)
                throw new InvalidCursoException("El ID del curso debe ser un numero positivo.");

            var curso = await _cursoRepository.ObtenerPorIdAsync(id);

            if (curso is null)
                throw new NotFoundException($"No se encontro el curso con ID {id}.");

            return new Response<CursoResponseDTO>
            {
                Data = _mapper.Map<CursoResponseDTO>(curso),
                Message = "Curso obtenido correctamente",
                Success = true
            };

        }//end method getById

        public async Task<Response<CursoResponseDTO>> CrearAsync(CursoCreateDTO curso)
        {
            if (string.IsNullOrWhiteSpace(curso.Nombre))
                throw new InvalidCursoException("El nombre del curso es obligatorio.");

            if (string.IsNullOrWhiteSpace(curso.Descripcion))
                throw new InvalidCursoException("La descripcion del curso es obligatoria.");

            if (curso.CupoMaximo <= 0)
                throw new InvalidCursoException("El cupo maximo debe ser mayor que cero.");

            var cursos = await _cursoRepository.ObtenerTodosAsync();

            if (cursos.Any(c => c.Nombre.ToLower() == curso.Nombre.ToLower()))
                throw new DuplicateCursoException("Ya existe un curso con el mismo nombre.");

            Curso cursoEntity = _mapper.Map<Curso>(curso);

            cursoEntity = await _cursoRepository.CrearAsync(cursoEntity);

            return new Response<CursoResponseDTO>
            {
                Data = _mapper.Map<CursoResponseDTO>(cursoEntity),
                Message = "Curso creado correctamente",
                Success = true
            };

        }//end method create

        public async Task<Response<CursoResponseDTO>> ActualizarAsync(CursoUpdateDTO curso)
        {
            if (curso.Id <= 0)
                throw new InvalidCursoException("El ID del curso debe ser un numero positivo.");

            if (string.IsNullOrWhiteSpace(curso.Nombre))
                throw new InvalidCursoException("El nombre del curso es obligatorio.");

            if (string.IsNullOrWhiteSpace(curso.Descripcion))
                throw new InvalidCursoException("La descripcion del curso es obligatoria.");

            if (curso.CupoMaximo <= 0)
                throw new InvalidCursoException("El cupo maximo debe ser mayor que cero.");

            var cursoExistente = await _cursoRepository.ObtenerPorIdAsync(curso.Id);

            if (cursoExistente is null)
                throw new NotFoundException($"No se encontro el curso con ID {curso.Id}.");

            var cursos = await _cursoRepository.ObtenerTodosAsync();

            if (cursos.Any(c => c.Nombre.ToLower() == curso.Nombre.ToLower() && c.Id != curso.Id))
                throw new DuplicateCursoException("Ya existe otro curso con el mismo nombre.");

            _mapper.Map(curso, cursoExistente);

            var cursoActualizado = await _cursoRepository.ActualizarAsync(cursoExistente);

            return new Response<CursoResponseDTO>
            {
                Data = _mapper.Map<CursoResponseDTO>(cursoActualizado),
                Message = "Curso actualizado correctamente",
                Success = true
            };

        }//end method update

        public async Task<Response<bool>> EliminarAsync(int id)
        {
            if (id <= 0)
                throw new InvalidCursoException("El ID del curso debe ser un numero positivo.");

            var curso = await _cursoRepository.ObtenerPorIdAsync(id);

            if (curso is null)
                throw new NotFoundException($"No se encontro el curso con ID {id}.");

            bool result = await _cursoRepository.EliminarAsync(id);

            return new Response<bool>
            {
                Data = result,
                Message = "Curso eliminado correctamente",
                Success = true
            };

        }//end method delete

    }//end class
}

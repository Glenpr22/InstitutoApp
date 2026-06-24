using Academico.Common.Interfaces;
using Academico.Common.Exceptions;
using Academico.Common.Response;
using Academico.DTOs.Matricula;
using Academico.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academico.Services
{
    public class MatriculaService : IGenericService<MatriculaResponseDTO, MatriculaCreateDTO, MatriculaCreateDTO>
    {
        //inyeccion para el repository de matricula
        public readonly IGenericRepository<Matricula> _matriculaRepository;

        //inyeccion para validar estudiante
        public readonly IGenericRepository<Estudiante> _estudianteRepository;

        //inyeccion para validar curso
        public readonly IGenericRepository<Curso> _cursoRepository;

        //inyeccion mapper
        private readonly IMapper _mapper;

        //now we can access the repositories through the interfaces
        public MatriculaService(
            IGenericRepository<Matricula> matriculaRepository,
            IGenericRepository<Estudiante> estudianteRepository,
            IGenericRepository<Curso> cursoRepository,
            IMapper mapper)
        {
            _matriculaRepository = matriculaRepository;
            _estudianteRepository = estudianteRepository;
            _cursoRepository = cursoRepository;
            _mapper = mapper;

        }//end method constructor

        //we contact the repository and check if there is data in the database
        public async Task<Response<List<MatriculaResponseDTO>>> ObtenerTodosAsync()
        {
            var matriculaList = await _matriculaRepository.ObtenerTodosAsync();

            if (matriculaList == null || !matriculaList.Any())
                throw new NotFoundException("No se encontraron matriculas.");

            return new Response<List<MatriculaResponseDTO>>
            {
                Data = _mapper.Map<List<MatriculaResponseDTO>>(matriculaList),
                Message = "Matriculas obtenidas exitosamente",
                Success = true
            };

        }//end method getAll

        public async Task<Response<MatriculaResponseDTO>> ObtenerPorIdAsync(int id)
        {
            if (id <= 0)
                throw new InvalidMatriculaException("El ID de la matricula debe ser un numero positivo.");

            var matricula = await _matriculaRepository.ObtenerPorIdAsync(id);

            if (matricula is null)
                throw new NotFoundException($"No se encontro la matricula con ID {id}.");

            return new Response<MatriculaResponseDTO>
            {
                Data = _mapper.Map<MatriculaResponseDTO>(matricula),
                Message = "Matricula obtenida correctamente",
                Success = true
            };

        }//end method getById

        public async Task<Response<MatriculaResponseDTO>> CrearAsync(MatriculaCreateDTO matricula)
        {
            if (matricula.EstudianteId <= 0)
                throw new InvalidMatriculaException("Debe seleccionar un estudiante valido.");

            if (matricula.CursoId <= 0)
                throw new InvalidMatriculaException("Debe seleccionar un curso valido.");

            var estudiante = await _estudianteRepository.ObtenerPorIdAsync(matricula.EstudianteId);

            if (estudiante is null)
                throw new NotFoundException($"No se encontro el estudiante con ID {matricula.EstudianteId}.");

            var curso = await _cursoRepository.ObtenerPorIdAsync(matricula.CursoId);

            if (curso is null)
                throw new NotFoundException($"No se encontro el curso con ID {matricula.CursoId}.");

            var matriculas = await _matriculaRepository.ObtenerTodosAsync();

            if (matriculas.Any(m => m.EstudianteId == matricula.EstudianteId && m.CursoId == matricula.CursoId))
                throw new DuplicateMatriculaException("El estudiante ya se encuentra matriculado en este curso.");

            int cantidadMatriculados = matriculas.Count(m => m.CursoId == matricula.CursoId);

            if (cantidadMatriculados >= curso.CupoMaximo)
                throw new InvalidMatriculaException("El curso ya alcanzo el cupo maximo permitido.");

            Matricula matriculaEntity = _mapper.Map<Matricula>(matricula);

            matriculaEntity = await _matriculaRepository.CrearAsync(matriculaEntity);

            var matriculaConDatos = await _matriculaRepository.ObtenerPorIdAsync(matriculaEntity.Id);

            return new Response<MatriculaResponseDTO>
            {
                Data = _mapper.Map<MatriculaResponseDTO>(matriculaConDatos),
                Message = "Matricula creada correctamente",
                Success = true
            };

        }//end method create

        public async Task<Response<MatriculaResponseDTO>> ActualizarAsync(MatriculaCreateDTO matricula)
        {
            throw new InvalidMatriculaException("La matricula no permite actualizacion");

        }//end method update

        public async Task<Response<bool>> EliminarAsync(int id)
        {
            throw new InvalidMatriculaException("La matricula no permite eliminacion");

        }//end method delete

    }//end class
}
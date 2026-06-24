using Academico.Common.Interfaces;
using Academico.Common.Exceptions;
using Academico.Common.Response;
using Academico.DTOs.Estudiante;
using Academico.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academico.Services
{
    public class EstudianteService : IGenericService<EstudianteResponseDTO, EstudianteCreateDTO, EstudianteUpdateDTO>
    {
        //inyeccion para el repository
        public readonly IGenericRepository<Estudiante> _estudianteRepository;

        //inyeccion mapper
        private readonly IMapper _mapper;

        //now we can access the repository through the interface
        public EstudianteService(IGenericRepository<Estudiante> estudianteRepository, IMapper mapper)
        {
            _estudianteRepository = estudianteRepository;
            _mapper = mapper;

        }//end method constructor

        //we contact the repository and check if there is data in the database
        public async Task<Response<List<EstudianteResponseDTO>>> ObtenerTodosAsync()
        {
            var estudianteList = await _estudianteRepository.ObtenerTodosAsync();

            if (estudianteList == null || !estudianteList.Any())
                throw new NotFoundException("No se encontraron estudiantes.");

            return new Response<List<EstudianteResponseDTO>>
            {
                Data = _mapper.Map<List<EstudianteResponseDTO>>(estudianteList),
                Message = "Estudiantes obtenidos exitosamente",
                Success = true
            };

        }//end method getAll

        public async Task<Response<EstudianteResponseDTO>> ObtenerPorIdAsync(int id)
        {
            if (id <= 0)
                throw new InvalidEstudianteException("El ID del estudiante debe ser un numero positivo.");

            var estudiante = await _estudianteRepository.ObtenerPorIdAsync(id);

            if (estudiante is null)
                throw new NotFoundException($"No se encontro el estudiante con ID {id}.");

            return new Response<EstudianteResponseDTO>
            {
                Data = _mapper.Map<EstudianteResponseDTO>(estudiante),
                Message = "Estudiante obtenido correctamente",
                Success = true
            };

        }//end method getById

        public async Task<Response<EstudianteResponseDTO>> CrearAsync(EstudianteCreateDTO estudiante)
        {
            if (string.IsNullOrWhiteSpace(estudiante.Cedula))
                throw new InvalidEstudianteException("La cedula es obligatoria.");

            if (!estudiante.Cedula.All(char.IsDigit))
                throw new InvalidEstudianteException("La cedula debe contener unicamente numeros.");

            if (string.IsNullOrWhiteSpace(estudiante.Nombre))
                throw new InvalidEstudianteException("El nombre del estudiante es obligatorio.");

            if (string.IsNullOrWhiteSpace(estudiante.PrimerApellido))
                throw new InvalidEstudianteException("El primer apellido del estudiante es obligatorio.");

            if (string.IsNullOrWhiteSpace(estudiante.SegundoApellido))
                throw new InvalidEstudianteException("El segundo apellido del estudiante es obligatorio.");

            if (string.IsNullOrWhiteSpace(estudiante.CorreoElectronico))
                throw new InvalidEstudianteException("El correo electronico es obligatorio.");

            var estudiantes = await _estudianteRepository.ObtenerTodosAsync();

            if (estudiantes.Any(e => e.Cedula == estudiante.Cedula))
                throw new DuplicateEstudianteException("Ya existe un estudiante con la misma cedula.");

            if (estudiantes.Any(e => e.CorreoElectronico == estudiante.CorreoElectronico))
                throw new DuplicateEstudianteException("Ya existe un estudiante con el mismo correo electronico.");

            Estudiante estudianteEntity = _mapper.Map<Estudiante>(estudiante);

            estudianteEntity = await _estudianteRepository.CrearAsync(estudianteEntity);

            return new Response<EstudianteResponseDTO>
            {
                Data = _mapper.Map<EstudianteResponseDTO>(estudianteEntity),
                Message = "Estudiante creado correctamente",
                Success = true
            };

        }//end method create

        public async Task<Response<EstudianteResponseDTO>> ActualizarAsync(EstudianteUpdateDTO estudiante)
        {
            if (estudiante.Id <= 0)
                throw new InvalidEstudianteException("El ID del estudiante debe ser un numero positivo.");

            if (string.IsNullOrWhiteSpace(estudiante.Cedula))
                throw new InvalidEstudianteException("La cedula es obligatoria.");

            if (!estudiante.Cedula.All(char.IsDigit))
                throw new InvalidEstudianteException("La cedula debe contener unicamente numeros.");

            if (string.IsNullOrWhiteSpace(estudiante.Nombre))
                throw new InvalidEstudianteException("El nombre del estudiante es obligatorio.");

            if (string.IsNullOrWhiteSpace(estudiante.PrimerApellido))
                throw new InvalidEstudianteException("El primer apellido del estudiante es obligatorio.");

            if (string.IsNullOrWhiteSpace(estudiante.SegundoApellido))
                throw new InvalidEstudianteException("El segundo apellido del estudiante es obligatorio.");

            if (string.IsNullOrWhiteSpace(estudiante.CorreoElectronico))
                throw new InvalidEstudianteException("El correo electronico es obligatorio.");

            var estudianteExistente = await _estudianteRepository.ObtenerPorIdAsync(estudiante.Id);

            if (estudianteExistente is null)
                throw new NotFoundException($"No se encontro el estudiante con ID {estudiante.Id}.");

            var estudiantes = await _estudianteRepository.ObtenerTodosAsync();

            if (estudiantes.Any(e => e.Cedula == estudiante.Cedula && e.Id != estudiante.Id))
                throw new DuplicateEstudianteException("Ya existe otro estudiante con la misma cedula.");

            if (estudiantes.Any(e => e.CorreoElectronico == estudiante.CorreoElectronico && e.Id != estudiante.Id))
                throw new DuplicateEstudianteException("Ya existe otro estudiante con el mismo correo electronico.");

            _mapper.Map(estudiante, estudianteExistente);

            var estudianteActualizado = await _estudianteRepository.ActualizarAsync(estudianteExistente);

            return new Response<EstudianteResponseDTO>
            {
                Data = _mapper.Map<EstudianteResponseDTO>(estudianteActualizado),
                Message = "Estudiante actualizado correctamente",
                Success = true
            };

        }//end method update

        public async Task<Response<bool>> EliminarAsync(int id)
        {
            if (id <= 0)
                throw new InvalidEstudianteException("El ID del estudiante debe ser un numero positivo.");

            var estudiante = await _estudianteRepository.ObtenerPorIdAsync(id);

            if (estudiante is null)
                throw new NotFoundException($"No se encontro el estudiante con ID {id}.");

            bool result = await _estudianteRepository.EliminarAsync(id);

            return new Response<bool>
            {
                Data = result,
                Message = "Estudiante eliminado correctamente",
                Success = true
            };

        }//end method delete

    }//end class
}

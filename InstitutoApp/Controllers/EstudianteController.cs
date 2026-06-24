using Academico.Common.Exceptions;
using Academico.Common.Interfaces;
using Academico.DTOs.Estudiante;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academico.API.Controllers
{
    //access
    [ApiController]
    [Route("api/estudiante")]
    public class EstudianteController : Controller
    {
        //inject of dependency the interface of service
        public readonly IGenericService<EstudianteResponseDTO, EstudianteCreateDTO, EstudianteUpdateDTO> _estudianteService;

        // parameter the interface of service
        public EstudianteController(IGenericService<EstudianteResponseDTO, EstudianteCreateDTO, EstudianteUpdateDTO> estudianteService)
        {
            _estudianteService = estudianteService;

        }//end method constructor

        //Get All
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                var list = await _estudianteService.ObtenerTodosAsync();
                return Ok(list);

            }
            catch (NotFoundException ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = $"Error al obtener los estudiantes: {ex.Message}" });
            }

        }//end method getAll

        //Get by Id
        [HttpGet("{id}")]
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var estudiante = await _estudianteService.ObtenerPorIdAsync(id);
                return Ok(estudiante);

            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidEstudianteException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener el estudiante: {ex.Message}");
            }

        }//end method getById

        //Create
        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] EstudianteCreateDTO estudiante)
        {
            try
            {
                var student = await _estudianteService.CrearAsync(estudiante);
                return Ok(student);

            }
            catch (InvalidEstudianteException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DuplicateEstudianteException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear el estudiante: {ex.Message}");
            }

        }//end method create

        //Update
        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] EstudianteUpdateDTO estudiante)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Id incorrecto");

                if (estudiante == null)
                    return BadRequest("Datos incorrectos,s");

                estudiante.Id = id;

                var student = await _estudianteService.ActualizarAsync(estudiante);
                return Ok(student);

            }
            catch (InvalidEstudianteException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DuplicateEstudianteException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar el estudiante: {ex.Message}");
            }

        }//end method edit

        //Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var student = await _estudianteService.EliminarAsync(id);
                return Ok(student);

            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidEstudianteException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al eliminar el estudiante: {ex.Message}");
            }

        }//end method delete

    }//end class
}

using Academico.Common.Exceptions;
using Academico.Common.Interfaces;
using Academico.DTOs.Curso;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academico.API.Controllers
{
    //access
    [ApiController]
    [Route("api/curso")]
    public class CursoController : Controller
    {
        //inject of dependency the interface of service
        public readonly IGenericService<CursoResponseDTO, CursoCreateDTO, CursoUpdateDTO> _cursoService;

        //Constructor
        public CursoController(IGenericService<CursoResponseDTO, CursoCreateDTO, CursoUpdateDTO> cursoService)
        {
            _cursoService = cursoService;

        }//end method constructor

        //Get All
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                var list = await _cursoService.ObtenerTodosAsync();
                return Ok(list);

            }
            catch (NotFoundException ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = $"Error al obtener los cursos: {ex.Message}" });
            }

        }//end method getAll

        //Get by Id
        [HttpGet("{id}")]
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var curso = await _cursoService.ObtenerPorIdAsync(id);
                return Ok(curso);

            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidCursoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener el curso: {ex.Message}");
            }

        }//end method getById

        //create
        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] CursoCreateDTO curso)
        {
            try
            {
                var course = await _cursoService.CrearAsync(curso);
                return Ok(course);

            }
            catch (InvalidCursoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DuplicateCursoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear el curso: {ex.Message}");
            }

        }//end method create

        //Update
        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] CursoUpdateDTO curso)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Id incorrecto");

                if (curso == null)
                    return BadRequest("Datos incorrectos");

                curso.Id = id;

                var course = await _cursoService.ActualizarAsync(curso);
                return Ok(course);

            }
            catch (InvalidCursoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DuplicateCursoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar el curso: {ex.Message}");
            }

        }//end method edit

        //Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var course = await _cursoService.EliminarAsync(id);
                return Ok(course);

            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidCursoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al eliminar el curso: {ex.Message}");
            }

        }//end method delete

    }//end class
}

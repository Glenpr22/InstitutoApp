using Academico.Common.Exceptions;
using Academico.Common.Interfaces;
using Academico.DTOs.Matricula;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academico.API.Controllers
{
    //access
    [ApiController]
    [Route("api/matricula")]
    public class MatriculaController : Controller
    {
        //inject of dependency the interface of service
        public readonly IGenericService<MatriculaResponseDTO, MatriculaCreateDTO, MatriculaCreateDTO> _matriculaService;

        //parameter the interface of service
        public MatriculaController(IGenericService<MatriculaResponseDTO, MatriculaCreateDTO, MatriculaCreateDTO> matriculaService)
        {
            _matriculaService = matriculaService;

        }//end method constructor

        // Gell All
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                var list = await _matriculaService.ObtenerTodosAsync();
                return Ok(list);

            }
            catch (NotFoundException ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = $"Error al obtener las matriculas: {ex.Message}" });
            }

        }//end method getAll
        
        //Get by id
        [HttpGet("{id}")]
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var matricula = await _matriculaService.ObtenerPorIdAsync(id);
                return Ok(matricula);

            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidMatriculaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener la matricula: {ex.Message}");
            }

        }//end method getById

        //Create
        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] MatriculaCreateDTO matricula)
        {
            try
            {
                var enrollment = await _matriculaService.CrearAsync(matricula);
                return Ok(enrollment);

            }
            catch (InvalidMatriculaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DuplicateMatriculaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear la matricula: {ex.Message}");
            }

        }//end method create

    }//end class
}

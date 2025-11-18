using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Implementations;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEvoEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Indica que todos los métodos en este controlador requieren autorización
    public class ResourceController : ControllerBase
    {
        private readonly IResourceRepository _ResourceRepository; //Inyección de dependencia

        public ResourceController(IResourceRepository ResourceRepository)
        {
            _ResourceRepository = ResourceRepository;
        }

        [HttpGet("GetResources")] //Indica que este método responde a solicitudes HTTP GET(Lectura)
        [ProducesResponseType(StatusCodes.Status200OK)] //Indica que este método puede devolver un estado 200 OK
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Indica que este método puede devolver un estado 404 Not Found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] //Indica que este método puede devolver un estado 500 Internal Server Error
        public async Task<IActionResult> GetResources() // IActionResult es un tipo de retorno genérico para una acción de controlador
        {
            try
            {
                var Resources = await _ResourceRepository.GetResources(); //Llama al método GetRoles del repositorio
                if (Resources == null || !Resources.Any()) //Verifica si la lista de roles está vacía o es nula
                {
                    return NotFound("No se encontraron Resources."); //Devuelve un estado 404 Not Found con un mensaje
                }

                return Ok(Resources);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los Services: " + ex.Message);
            }
        }

        [HttpGet("GetResource")] //Indica que este método responde a solicitudes HTTP GET(Lectura)
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetResource(Guid Id) // IActionResult es un tipo de retorno genérico para una acción de controlador
        {
            try
            {
                var Resources = await _ResourceRepository.GetResource(Id); //Llama al método GetRoles del repositorio
                if (Resources == null) //Verifica si la lista de roles está vacía o es nula
                {
                    return NotFound("No se encontró el Resource."); //Devuelve un estado 404 Not Found con un mensaje
                }

                return Ok(Resources);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el Resource: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpPost("InsertResource")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateResource([FromBody] Resource Resource) // FromBody indica que el parámetro se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                var Result = await _ResourceRepository.CreateResource(Resource);
                if (!Result)
                {
                    return NotFound("No se pudo insertar el Resource.");
                }

                return Ok("Resource Insertado correctamemnte");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el Resource: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")] // Indica que este método requiere autorización con la política "RequireAdmin"
        [HttpPut("UpdateResource")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]


        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> UpdateResource(Guid Id, [FromBody] Resource UpdatedResource)
        {
            try
            {
                var Result = await _ResourceRepository.UpdateResource(Id, UpdatedResource);
                if (!Result)
                {
                    return NotFound("No se pudo actualizar el Resource.");
                }
                return Ok("Resource actualizado correctamemnte");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el Resource: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpDelete("DeleteResource")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> DeleteResource(Guid Id)  // FromBody indica que el parámetro se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                var Result = await _ResourceRepository.DeleteResource(Id);
                if (!Result) // Verifica si la lista de roles está vacía o es nula
                {
                    return BadRequest("No se pudo eliminar el Resource.");  //BadRequest hace referencia a un estado 400
                }

                return Ok("Resource eliminado Correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al Eliminar el Resource: " + ex.Message);
            }
        }
    }
}

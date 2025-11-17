using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEvoEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Indica que todos los métodos en este controlador requieren autorización
    public class ServiceResourceController : ControllerBase
    {
        private readonly IServiceResourceRepository _ServiceResourceRepository; //Inyección de dependencia

        public ServiceResourceController(IServiceResourceRepository ServiceResourceRepository)
        {
            _ServiceResourceRepository = ServiceResourceRepository;
        }

        [HttpGet("GetServiceResources")] //Indica que este método responde a solicitudes HTTP GET(Lectura)
        [ProducesResponseType(StatusCodes.Status200OK)] //Indica que este método puede devolver un estado 200 OK
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Indica que este método puede devolver un estado 404 Not Found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] //Indica que este método puede devolver un estado 500 Internal Server Error
        public async Task<IActionResult> GetResources() // IActionResult es un tipo de retorno genérico para una acción de controlador
        {
            try
            {
                var ServiceResources = await _ServiceResourceRepository.GetServiceResources(); //Llama al método GetRoles del repositorio
                if (ServiceResources == null || !ServiceResources.Any()) //Verifica si la lista de roles está vacía o es nula
                {
                    return NotFound("No se encontraron ServiceResources."); //Devuelve un estado 404 Not Found con un mensaje
                }

                return Ok(ServiceResources);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los Services: " + ex.Message);
            }
        }

        [HttpGet("GetServiceResource")] //Indica que este método responde a solicitudes HTTP GET(Lectura)
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetServiceResource(Guid Id) // IActionResult es un tipo de retorno genérico para una acción de controlador
        {
            try
            {
                var ServiceResources = await _ServiceResourceRepository.GetServiceResource(Id); //Llama al método GetRoles del repositorio
                if (ServiceResources == null) //Verifica si la lista de roles está vacía o es nula
                {
                    return NotFound("No se encontró el ServiceResource."); //Devuelve un estado 404 Not Found con un mensaje
                }

                return Ok(ServiceResources);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el ServiceResource: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpPost("InsertServiceResource")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateServiceResource([FromBody] ServiceResource ServiceResource) // FromBody indica que el parámetro se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                var Result = await _ServiceResourceRepository.CreateServiceResource(ServiceResource);
                if (!Result)
                {
                    return NotFound("No se pudo insertar el ServiceResource.");
                }

                return Ok("ServiceResource Insertado correctamemnte");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el ServiceResource: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpPut("UpdateServiceResource")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]


        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> UpdateServiceResource(Guid Id, [FromBody] ServiceResource UpdatedServiceResource)
        {
            try
            {
                var Result = await _ServiceResourceRepository.UpdateServiceResource(Id, UpdatedServiceResource);
                if (!Result)
                {
                    return NotFound("No se pudo actualizar el ServiceResource.");
                }
                return Ok("ServiceResource actualizado correctamemnte");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el ServiceResource: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")] // Indica que este método requiere autorización y el usuario debe tener el rol "Admin"
        [HttpDelete("DeleteServiceResource")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> DeleteServiceResource(Guid Id)  // FromBody indica que el parámetro se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                var Result = await _ServiceResourceRepository.DeleteServiceResource(Id);
                if (!Result) // Verifica si la lista de roles está vacía o es nula
                {
                    return BadRequest("No se pudo eliminar el ServiceResource.");  //BadRequest hace referencia a un estado 400
                }

                return Ok("ServiceResource eliminado Correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al Eliminar el ServiceResource: " + ex.Message);
            }
        }
    }
}

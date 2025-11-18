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
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _ServiceRepository; //Inyección de dependencia

        public ServiceController(IServiceRepository ServiceRepository)
        {
            _ServiceRepository = ServiceRepository;
        }

        [HttpGet("GetServices")] //Indica que este método responde a solicitudes HTTP GET(Lectura)
        [ProducesResponseType(StatusCodes.Status200OK)] //Indica que este método puede devolver un estado 200 OK
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Indica que este método puede devolver un estado 404 Not Found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] //Indica que este método puede devolver un estado 500 Internal Server Error
        public async Task<IActionResult> GetServices() // IActionResult es un tipo de retorno genérico para una acción de controlador
        {
            try
            {
                var Services = await _ServiceRepository.GetServices(); //Llama al método GetRoles del repositorio
                if (Services == null || !Services.Any()) //Verifica si la lista de roles está vacía o es nula
                {
                    return NotFound("No se encontraron Services."); //Devuelve un estado 404 Not Found con un mensaje
                }

                return Ok(Services);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los Services: " + ex.Message);
            }
        }

        [HttpGet("GetService")] //Indica que este método responde a solicitudes HTTP GET(Lectura)
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetService(Guid Id) // IActionResult es un tipo de retorno genérico para una acción de controlador
        {
            try
            {
                var Services = await _ServiceRepository.GetService(Id); //Llama al método GetRoles del repositorio
                if (Services == null) //Verifica si la lista de roles está vacía o es nula
                {
                    return NotFound("No se encontró el Service."); //Devuelve un estado 404 Not Found con un mensaje
                }

                return Ok(Services);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el Service: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpPost("InsertService")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateService([FromBody] Service Service) // FromBody indica que el parámetro se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                var Result = await _ServiceRepository.CreateService(Service);
                if (!Result)
                {
                    return NotFound("No se pudo insertar el Service.");
                }

                return Ok("Service Insertado correctamemnte");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el Service: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpPut("UpdateService")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]


        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> UpdateService(Guid Id, [FromBody] Service UpdatedService)
        {
            try
            {
                var Result = await _ServiceRepository.UpdateService(Id, UpdatedService);
                if (!Result)
                {
                    return NotFound("No se pudo actualizar el Service.");
                }
                return Ok("Service actualizado correctamemnte");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el Service: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpDelete("DeleteService")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> DeleteService(Guid Id)  // FromBody indica que el parámetro se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                var Result = await _ServiceRepository.DeleteService(Id);
                if (!Result) // Verifica si la lista de roles está vacía o es nula
                {
                    return BadRequest("No se pudo eliminar el Service.");  //BadRequest hace referencia a un estado 400
                }

                return Ok("Service eliminado Correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al Eliminar el Service: " + ex.Message);
            }
        }
    }
}

using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEvoEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] //Requiere que el usuario esté autenticado para acceder a los métodos del controlador
    public class StatusResourceController : ControllerBase
    {
        private readonly IStatusResourceRepository _StatusResourceRepository; //Inyección de dependencia

        public StatusResourceController(IStatusResourceRepository StatusResourceRepository)
        {
            _StatusResourceRepository = StatusResourceRepository;
        }

        [HttpGet("GetStatusResources")] //Indica que este método responde a solicitudes HTTP GET(Lectura)
        [ProducesResponseType(StatusCodes.Status200OK)] //Indica que este método puede devolver un estado 200 OK
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Indica que este método puede devolver un estado 404 Not Found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] //Indica que este método puede devolver un estado 500 Internal Server Error
        public async Task<IActionResult> GetCategoryServices() // IActionResult es un tipo de retorno genérico para una acción de controlador
        {
            try
            {
                var StatusResources = await _StatusResourceRepository.GetStatusResources(); //Llama al método GetRoles del repositorio
                if (StatusResources == null || !StatusResources.Any()) //Verifica si la lista de roles está vacía o es nula
                {
                    return NotFound("No se encontraron StatusResources."); //Devuelve un estado 404 Not Found con un mensaje
                }

                return Ok(StatusResources);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los StatusResources: " + ex.Message);
            }
        }

        [HttpGet("GetStatusResource")] //Indica que este método responde a solicitudes HTTP GET(Lectura)
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStatusResource(Guid Id) // IActionResult es un tipo de retorno genérico para una acción de controlador
        {
            try
            {
                var StatusResource = await _StatusResourceRepository.GetStatusResource(Id); //Llama al método GetRoles del repositorio
                if (StatusResource == null) //Verifica si la lista de roles está vacía o es nula
                {
                    return NotFound("No se encontró el StatusResource."); //Devuelve un estado 404 Not Found con un mensaje
                }

                return Ok(StatusResource);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el StatusResource: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpPost("InsertStatusResource")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateStatusResource([FromBody] StatusResource StatusResource) // FromBody indica que el parámetro se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                var Result = await _StatusResourceRepository.CreateStatusResource(StatusResource);
                if (!Result)
                {
                    return NotFound("No se pudo crear el StatusResource.");
                }

                return Ok("StatusResource creado correctamemnte");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el StatusResource: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpPut("UpdateStatusResource")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]


        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> UpdateStatusResource(Guid Id, [FromBody] StatusResource UpdatedStatusResource)
        {
            try
            {
                var Result = await _StatusResourceRepository.UpdateStatusResource(Id, UpdatedStatusResource);
                if (!Result)
                {
                    return NotFound("No se pudo actualizar el StatusResource.");
                }
                return Ok("StatusResource actualizado correctamemnte");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el StatusResource: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpDelete("DeleteStatusResource")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> DeleteStatusResource(Guid Id)  // FromBody indica que el parámetro se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                var Result = await _StatusResourceRepository.DeleteStatusResource(Id);
                if (!Result) // Verifica si la lista de CategoryService está vacía o es nula
                {
                    return BadRequest("No se pudo eliminar el StatusResource.");  //BadRequest hace referencia a un estado 400
                }

                return Ok("StatusResource eliminado Correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al Eliminar el StatusResource: " + ex.Message);
            }
        }
    }
}

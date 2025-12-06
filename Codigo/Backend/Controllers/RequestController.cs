using BackEvoEventos.Dtos;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Implementations;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackEvoEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RequestController : ControllerBase
    {
        private readonly IRequestRepository _requestRepository; //variable de solo lectura para el repositorio de Customers de tipo global(se accede desde cualquier método del código)
        public RequestController(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpGet("GetAllRequest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<Request>>> GetAllRequests()
        {
            try
            {
                var requests = await _requestRepository.GetAllRequests();
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener las solicitudes: {ex.Message}");
            }
        }
        [HttpGet("GetRequestById{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Request>> GetRequestById(Guid id)
        {
            try
            {
                var request = await _requestRepository.GetRequestById(id);

                if (request == null)
                {
                    return NotFound($"No se encontró la solicitud con ID {id}");
                }

                return Ok(request);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener la solicitud: {ex.Message}");
            }
        }
        [HttpPost("CreateRequest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateRequest([FromBody] CreateRequestDto RequestDto)
        {
            try
            {
                
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                
                if (string.IsNullOrWhiteSpace(RequestDto.FullName)) // Validación manual de campos requeridos para que llenen todos los campos
                    return BadRequest(new { message = "El nombre completo es requerido" });

                if (string.IsNullOrWhiteSpace(RequestDto.Email))
                    return BadRequest(new { message = "El email es requerido" });

                if (RequestDto.HandledBy == Guid.Empty)
                    return BadRequest(new { message = "El usuario es requerido" });

                var createdRequest = await _requestRepository.CreateRequest(RequestDto);

                var success = await _requestRepository.CreateRequest(RequestDto);

                if (!success)
                    return BadRequest(new { message = "No se pudo crear la solicitud" });

               
                return Ok(new
                {
                    message = "Solicitud creada exitosamente",
                    
                });
            
            }
            catch (Exception ex)
            {
                
                if (ex.Message.Contains("no existe") || ex.Message.Contains("no encontrado"))
                    return BadRequest(new { message = ex.Message });

                return StatusCode(500, new
                {
                    message = "Error al crear la solicitud",
                    error = ex.Message
                });
            }
        }

        [HttpPut("UpdateRequest{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateRequest(Guid id, [FromBody] Request request)
        {
            try
            {
                if (id != request.Id)
                {
                    return BadRequest("El ID de la URL no coincide con el ID de la solicitud");
                }

                var updatedRequest = await _requestRepository.UpdateRequest(request);
                return Ok(updatedRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar la solicitud: {ex.Message}");
            }
        }
        [HttpDelete("DeleteRequest{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteRequest(Guid id)
        {
            try
            {
                var success = await _requestRepository.DeleteRequest(id);

                if (!success)
                {
                    return NotFound($"No se encontró la solicitud con ID {id}");
                }

                return Ok(new { message = "Solicitud eliminada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar la solicitud: {ex.Message}");
            }
        }
    }
}

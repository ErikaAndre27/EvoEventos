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
        [HttpGet("GetRequestById")]
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
        public async Task<ActionResult> CreateRequest([FromBody] Request RequestDto)
        {
            try
            {
                var UserEmailExisting = await _UserRepository.GetUserByEmail(UserDto.Email);
                var UserDocumentExisting = await _UserRepository.GetUserByDocumentNumber(UserDto.DocumentNumber);
                if (UserEmailExisting == null && UserDocumentExisting == null)
                {
                    var Result = await _UserRepository.CreateUser(UserDto);
                    if (!Result)
                    {
                        return BadRequest("No se pudo crear el usuario.");
                    }

                    return Ok("Usuario creado correctamemnte");
                }
                else if (UserDocumentExisting != null)
                {
                    return BadRequest("El número de documento ya se encuentra registrado");
                }
                else if (UserEmailExisting != null)
                {
                    return BadRequest("El correo ya se encuentra registrado");
                }
                return BadRequest("No se pudo procesar la solicitud.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el usuario: " + ex.Message);
            }
        }
        [HttpPut("UpdateRequest")]
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

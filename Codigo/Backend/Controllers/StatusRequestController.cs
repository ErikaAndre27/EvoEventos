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
    [Authorize]
    public class StatusRequestController : ControllerBase
    {
        private readonly IStatusRequestRepository _statusRequestRepository;
        public StatusRequestController(IStatusRequestRepository statusRequestRepository) 
        {
            _statusRequestRepository = statusRequestRepository;
        }

        [HttpGet("GetAllStatusRequest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllStatusRequest()
        {
            try
            {
                var statusRequests = await _statusRequestRepository.GetAllStatusRequest();

                if (statusRequests == null || !statusRequests.Any())
                {
                    return NotFound("No se encontraron estados de solicitud.");
                }

                return Ok(statusRequests);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Error al obtener los estados de solicitud: " + ex.Message
                );
            }
        }

        [HttpGet("GetStatusRequestById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStatusRequestById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("El ID proporcionado no es válido.");
                }

                var statusRequest = await _statusRequestRepository.GetStatusRequestById(id);

                if (statusRequest == null)
                {
                    return NotFound($"No se encontró el estado de solicitud con ID: {id}");
                }

                return Ok(statusRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Error al obtener el estado de solicitud con ID {id}: " + ex.Message
                );
            }
        }
        [HttpPut("UpdateStatusRequest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateStatusRequest(Guid id, [FromBody] StatusRequest statusRequest)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("El ID proporcionado no es válido.");
                }

                if (statusRequest == null)
                {
                    return BadRequest("Los datos del estado de solicitud son requeridos.");
                }

                if (statusRequest.Id != id)
                {
                    return BadRequest("El ID de la URL no coincide con el ID del estado de solicitud.");
                }

                if (string.IsNullOrWhiteSpace(statusRequest.Name))
                {
                    return BadRequest("El nombre del estado de solicitud es requerido.");
                }

                var updatedStatusRequest = await _statusRequestRepository.UpdateStatusRequest(statusRequest);

                return Ok(updatedStatusRequest);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("Ya existe"))
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Error al actualizar el estado de solicitud con ID {id}: " + ex.Message
                );
            }
        }
    }
}

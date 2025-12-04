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
    public class StatusQuotationController : ControllerBase
    {
        private readonly IStatusQuotationRepository _statusQuotationRepository;
        public StatusQuotationController(IStatusQuotationRepository statusQuotationRepository)
        {
            _statusQuotationRepository = statusQuotationRepository;
        }
        [HttpGet("GetAllStatusQuotation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllStatusQuotation()
        {
            try
            {
                var statusQuotations = await _statusQuotationRepository.GetAllStatusQuotation();

                if (statusQuotations == null || !statusQuotations.Any())
                {
                    return NotFound("No se encontraron estados de cotización.");
                }

                return Ok(statusQuotations);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Error al obtener los estados de cotización: " + ex.Message
                );
            }
        }
        [HttpGet("GetStatusQuotationById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStatusQuotationById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("El ID proporcionado no es válido.");
                }

                var statusQuotation = await _statusQuotationRepository.GetStatusQuotationById(id);

                if (statusQuotation == null)
                {
                    return NotFound($"No se encontró el estado de cotización con ID: {id}");
                }

                return Ok(statusQuotation);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Error al obtener el estado de cotización con ID {id}: " + ex.Message
                );
            }
        }
        [HttpPut("UpdateStatusQuotation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateStatusQuotation(Guid id, [FromBody] StatusQuotation statusQuotation)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("El ID proporcionado no es válido.");
                }

                if (statusQuotation == null)
                {
                    return BadRequest("Los datos del estado de cotización son requeridos.");
                }

                if (statusQuotation.Id != id)
                {
                    return BadRequest("El ID de la URL no coincide con el ID del estado de cotización.");
                }

                if (string.IsNullOrWhiteSpace(statusQuotation.Name))
                {
                    return BadRequest("El nombre del estado de cotización es requerido.");
                }

                var updatedStatusQuotation = await _statusQuotationRepository.UpdateStatusQuotation(statusQuotation);

                return Ok(updatedStatusQuotation);
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
                    $"Error al actualizar el estado de cotización con ID {id}: " + ex.Message
                );
            }
        }
    }
}

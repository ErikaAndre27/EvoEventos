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
    public class EventTypeController : ControllerBase
    {
        private readonly IEventTypeRepository _eventTypeRepository;
        public EventTypeController(IEventTypeRepository eventTypeRepository)
        {
            _eventTypeRepository = eventTypeRepository;
        }

        [HttpGet("GetAllEventTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<EventType>>> GetAllEventTypes()
        {
            {
                try
                {
                    var eventTypes = await _eventTypeRepository.GetAllEventTypes();

                    if (eventTypes == null || !eventTypes.Any())
                    {
                        return NotFound("No se encontraron tipos de evento.");
                    }

                    return Ok(eventTypes);
                }
                catch (Exception ex)
                {
                    return StatusCode
                       (StatusCodes.Status500InternalServerError,
                        "Error al obtener los tipos de evento: " + ex.Message);
                }
            }
        }
        [HttpGet("GetEventTypeById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEventTypeById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("El ID proporcionado no es válido.");
                }

                var eventType = await _eventTypeRepository.GetEventTypeById(id);

                if (eventType == null)
                {
                    return NotFound($"No se encontró el tipo de evento con ID: {id}");
                }

                return Ok(eventType);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Error al obtener el tipo de evento con ID {id}: " + ex.Message
                );
            }
        }

        [HttpPost("CreateEventType")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateEventType([FromBody] EventType eventType)
        {
            try
            {
                if (eventType == null)
                {
                    return BadRequest("Los datos del tipo de evento son requeridos.");
                }

                if (string.IsNullOrWhiteSpace(eventType.Name))
                {
                    return BadRequest("El nombre del tipo de evento es requerido.");
                }

                var createdEventType = await _eventTypeRepository.CreateEventType(eventType);

                return CreatedAtAction(
                    nameof(GetEventTypeById),
                    new { id = createdEventType.Id },
                    createdEventType
                );
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("Ya existe"))
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Error al crear el tipo de evento: " + ex.Message
                );
            }
        }

        [HttpPut("UpdateEventType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateEventType(Guid id, [FromBody] EventType eventType)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("El ID proporcionado no es válido.");
                }

                if (eventType == null)
                {
                    return BadRequest("Los datos del tipo de evento son requeridos.");
                }

                if (eventType.Id != id)
                {
                    return BadRequest("El ID de la URL no coincide con el ID del tipo de evento.");
                }

                if (string.IsNullOrWhiteSpace(eventType.Name))
                {
                    return BadRequest("El nombre del tipo de evento es requerido.");
                }

                var updatedEventType = await _eventTypeRepository.UpdateEventType(eventType);

                return Ok(updatedEventType);
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
                    $"Error al actualizar el tipo de evento con ID {id}: " + ex.Message
                );
            }
        }

        [HttpDelete("DeleteEventType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteEventType(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("El ID proporcionado no es válido.");
                }

                var result = await _eventTypeRepository.DeleteEventType(id);

                if (!result)
                {
                    return NotFound($"No se pudo eliminar el tipo de evento con ID {id}. Puede que no exista o esté en uso.");
                }

                return Ok(new { message = $"Tipo de evento con ID {id} eliminado exitosamente.", success = true });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Error al eliminar el tipo de evento con ID {id}: " + ex.Message
                );
            }
        }

    }
}

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
    public class ReservationServiceController : ControllerBase
    {
        private readonly IReservationServiceRepository _reservationServiceRepository;

        public ReservationServiceController(IReservationServiceRepository ReservationServiceRepository)
        {
            _reservationServiceRepository = ReservationServiceRepository;
        }
        [HttpGet("GetReservationServices")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetAllReservationServices()
        {
            try
            {
                var reservationServices = await _reservationServiceRepository.GetAllReservationServices();
                if (reservationServices == null || !reservationServices.Any())
                {
                    return NotFound("No se encontraron Servicios de Reserva.");
                }
                return Ok(reservationServices);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los Servicios de Reserva: " + ex.Message);
            }
        }

        [HttpGet("GetReservationServiceById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetReservationServiceById(Guid Id)
        {
            try
            {
                var reservationService = await _reservationServiceRepository.GetReservationServiceById(Id);
                if (reservationService == null)
                {
                    return NotFound("No se encontró el Servicio de Reserva.");
                }
                return Ok(reservationService);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el Servicio de Reserva: " + ex.Message);
            }
        }

        [HttpGet("GetReservationServicesByReservationId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetReservationServicesByReservationId(Guid ReservationId)
        {
            try
            {
                var reservationServices = await _reservationServiceRepository.GetReservationServicesByReservationId(ReservationId);
                if (reservationServices == null || !reservationServices.Any())
                {
                    return NotFound("No se encontraron Servicios de Reserva para la Reserva especificada.");
                }
                return Ok(reservationServices);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los Servicios de Reserva: " + ex.Message);
            }
        }
        [HttpPost("CreateReservationService")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateReservationService([FromBody] ReservationService reservationService)
        {
            try
            {
                var created = await _reservationServiceRepository.CreateReservationService(reservationService);

                if (created == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "No se pudo crear el Servicio de Reserva." );
                }
                return Ok(created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el Servicio de Reserva: " + ex.Message);
            }
        }

       
        [HttpPut("UpdateReservationService")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateReservationService([FromBody] ReservationService updatedReservationService)
        {
            try
            {
                var updated = await _reservationServiceRepository.UpdateReservationService(updatedReservationService);

                if (updated == null)
                {
                    return NotFound("No se pudo actualizar. El Servicio de Reserva no existe.");
                }
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el Servicio de Reserva: " + ex.Message);
            }
        }

        [HttpDelete("DeleteReservationService")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteReservationService(Guid id)
        {
            try
            {
                var deleted = await _reservationServiceRepository.DeleteReservationService(id);

                if (!deleted)
                    
                    return NotFound("No se pudo eliminar. El Servicio de Reserva no existe.");

                return Ok("Servicio de Reserva eliminado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar el Servicio de Reserva: " + ex.Message);
            }
        }
    }
}

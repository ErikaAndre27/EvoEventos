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
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepository _reservationRepository;
        public ReservationController(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        [HttpGet("GetAllReservations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> GetAllReservations()
        {
            try
            {
                var reservations = await _reservationRepository.GetAllReservations();
                if (reservations == null || !reservations.Any())
                {
                    return NotFound("No se encontraron reservas.");
                }
                return Ok(reservations);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener las reservas: " + ex.Message);
            }
        }

        [HttpGet("GetReservationById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> GetReservationById(Guid Id)
        {
            try
            {
                var Reservation = await _reservationRepository.GetReservationById(Id);

                if (Reservation == null)
                    return NotFound($"No se encontró la reserva con ID: {Id}");

                return Ok(Reservation);
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error al obtener la reserva: " + Ex.Message);
            }
        }

      
        [HttpGet("GetReservationsByCustomerId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetReservationsByCustomerId(Guid CustomerId)
        {
            try
            {
                var Reservations = await _reservationRepository.GetReservationsByCustomerId(CustomerId);

                if (Reservations == null || !Reservations.Any())
                    return NotFound($"No se encontraron reservas para el cliente con ID: {CustomerId}");

                return Ok(Reservations);
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error al obtener las reservas: " + Ex.Message);
            }
        }
        [HttpPost("CreateReservation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateReservation([FromBody] Reservation Reservation)
        {
            try
            {
                if (Reservation == null)
                    return BadRequest("La reserva enviada es inválida.");

                var CreatedReservation = await _reservationRepository.CreateReservation(Reservation);

                return CreatedAtAction(nameof(GetReservationById),
                    new { Id = CreatedReservation.Id },
                    CreatedReservation);
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error al crear la reserva: " + Ex.Message);
            }
        }

        
        [HttpPut("UpdateReservation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateReservation(Guid Id, [FromBody] Reservation UpdatedReservation)
        {
            try
            {
                if (UpdatedReservation == null || UpdatedReservation.Id != Id)
                    return BadRequest("Los datos de la reserva no son válidos.");

                var ExistingReservation = await _reservationRepository.GetReservationById(Id);

                if (ExistingReservation == null)
                    return NotFound($"No se encontró la reserva con ID: {Id}");

                var ReservationResult = await _reservationRepository.UpdateReservation(UpdatedReservation);

                return Ok(ReservationResult);
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error al actualizar la reserva: " + Ex.Message);
            }
        }

        
        [HttpDelete("DeleteReservation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteReservation(Guid Id)
        {
            try
            {
                var Deleted = await _reservationRepository.DeleteReservation(Id);

                if (!Deleted)
                    return NotFound($"No se encontró la reserva con ID: {Id}");

                return Ok($"Reserva con ID {Id} eliminada correctamente.");
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error al eliminar la reserva: " + Ex.Message);
            }
        }
    }
}



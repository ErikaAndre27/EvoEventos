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
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        [HttpGet ("GetAllPayments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllPayments()
        {
            try
            {
                var payments = await _paymentRepository.GetAllPayments();
                if (payments == null || !payments.Any())
                {
                    return NotFound("No se encontraron pagos.");
                }
                return Ok(payments);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los pagos: " + ex.Message);
            }

        }
        [HttpGet("GetPaymentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPaymentById(Guid paymentId)
        {
            try
            {
                var payment = await _paymentRepository.GetPaymentById(paymentId);
                if (payment == null)
                {
                    return NotFound("No se encontró el pago.");
                }
                return Ok(payment);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el pago: " + ex.Message);
            }
        }
        [HttpGet("GetPaymentsByReservationId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetPaymentsByReservationId(Guid ReservationId)
        {
            try
            {
                var payments = await _paymentRepository.GetPaymentsByReservationId(ReservationId);

                if (payments == null || !payments.Any())
                {
                    return NotFound("No se encontraron pagos para la reserva especificada.");
                }

                return Ok(payments);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los pagos: " + ex.Message);
            }
        }
        [HttpPost("CreatePayment")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreatePayment([FromBody] Payment Payment)
        {
            try
            {
                if (Payment == null)
                {
                    return BadRequest("Los datos enviados son inválidos.");
                }

                var created = await _paymentRepository.CreatePayment(Payment);

                return StatusCode(StatusCodes.Status201Created, created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error al crear el estado de pago: " + ex.Message);
            }
        }

        [HttpPut("UpdatePayment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> UpdatePayment([FromBody] Payment Payment)
        {
            try
            {
                var updated = await _paymentRepository.UpdatePayment(Payment);
                if (updated == null)
                {
                    return NotFound("No se pudo actualizar el pago.");
                }
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error al actualizar el pago: " + ex.Message);
            }
        }

        [HttpDelete("DeletePayment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> DeletePayment(Guid Id)
        {
            try
            {
                var result = await _paymentRepository.DeletePayment(Id);

                if (!result)
                {
                    return BadRequest("No se pudo eliminar el pago.");
                }

                return Ok("Pago eliminado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error al eliminar el pago: " + ex.Message);
            }
        }
    }
}


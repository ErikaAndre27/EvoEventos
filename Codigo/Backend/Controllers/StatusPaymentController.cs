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
    public class StatusPaymentController : ControllerBase
    {
        private readonly IStatusPaymentRepository _statusPaymentRepository;
        public StatusPaymentController(IStatusPaymentRepository statusPaymentRepository)
        {
            _statusPaymentRepository = statusPaymentRepository; 
        }
        [HttpGet("GetAllStatusPayments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllStatusPayments()
        {
            try
            {
                var statusPayments = await _statusPaymentRepository.GetAllStatusPayments();
                if (statusPayments == null || !statusPayments.Any())
                {
                    return NotFound("No se encontraron Estados de Pago.");
                }
                return Ok(statusPayments);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los Estados de Pago: " + ex.Message);
            }
        }
        [HttpGet("GetStatusPaymentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetStatusPaymentById(Guid Id)
        {
            try
            {
                var statusPayment = await _statusPaymentRepository.GetStatusPaymentById(Id);
                if (statusPayment == null)
                {
                    return NotFound("No se encontró el Estado de Pago.");
                }
                return Ok(statusPayment);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el Estado de Pago: " + ex.Message);
            }
        }

        [HttpPost("CreateStatusPayment")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateStatusPayment([FromBody] StatusPayment statusPayment)
        {
            try
            {
                if (statusPayment == null)
                {
                    return BadRequest("El Estado de Pago no puede ser nulo.");
                }
                var createdStatusPayment = await _statusPaymentRepository.CreateStatusPayment(statusPayment);
                return CreatedAtAction(nameof(GetStatusPaymentById), new { Id = createdStatusPayment.Id }, createdStatusPayment);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el Estado de Pago: " + ex.Message);
            }
        }

        [HttpPut("UpdateStatusPayment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> UpdateStatusPayment([FromBody] StatusPayment statusPayment)
        {
            try
            {
                var existingStatusPayment = await _statusPaymentRepository.GetStatusPaymentById(statusPayment.Id);
                if (existingStatusPayment == null)
                {
                    return NotFound("No se encontró el Estado de Pago.");
                }
                var updatedStatusPayment = await _statusPaymentRepository.UpdateStatusPayment(statusPayment);
                return Ok(updatedStatusPayment);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el Estado de Pago: " + ex.Message);
            }
        }

        [HttpDelete("DeleteStatusPayment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> DeleteStatusPayment(Guid Id)
        {
            try
            {
                var existingStatusPayment = await _statusPaymentRepository.GetStatusPaymentById(Id);
                if (existingStatusPayment == null)
                {
                    return NotFound("No se encontró el Estado de Pago.");
                }
                var result = await _statusPaymentRepository.DeleteStatusPayment(Id);
                if (!result)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "No se pudo eliminar el Estado de Pago.");
                }
                return Ok("Estado de Pago eliminado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar el Estado de Pago: " + ex.Message);
            }
        }
    }
}

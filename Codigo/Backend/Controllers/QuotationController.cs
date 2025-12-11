using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEvoEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotationController : ControllerBase
    {
        private readonly IQuotationRepository _QuotationRepository;

        public QuotationController(IQuotationRepository quotationRepository)
        {
            _QuotationRepository = quotationRepository;
        }
        [HttpPost("CreateQuotation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateQuotation([FromBody] Quotation quotation)
        {
            try
            {
                var success = await _QuotationRepository.CreateQuotation(quotation);

                if (!success)
                {
                    return BadRequest("No se pudo crear la cotización");
                }

                return CreatedAtAction(nameof(GetQuotationById), new { id = quotation.Id }, quotation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la cotización: {ex.Message}");
            }
        }
        [HttpPut("UpdateQuotation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> UpdateQuotation([FromBody] Quotation quotation)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var updatedQuotation = await _QuotationRepository.UpdateQuotation(quotation);
                if (updatedQuotation == null)
                    return NotFound("Quotation not found");

                return Ok(updatedQuotation);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpDelete("DeleteQuotation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteQuotation(Guid id)
        {
            try
            {
                var result = await _QuotationRepository.DeleteQuotation(id);
                if (!result)
                    return NotFound($"La Cotización con el Id {id} no fué encontrada");

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("GetQuotationByEventType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetQuotationByEventType(string eventType)
        {
            try
            {
                var quotation = await _QuotationRepository.GetQuotationByEventType(eventType);
                if (quotation == null)
                    return NotFound($"Quotation with event type '{eventType}' not found");

                return Ok(quotation);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("GetQuotationByEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetQuotationByEmail(string email)
        {
            try
            {
                var quotation = await _QuotationRepository.GetQuotationByEmail(email);
                if (quotation == null)
                    return NotFound($"La Cotización con el email '{email}' no se encontró");

                return Ok(quotation);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("GetQuotationByCustomerName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetQuotationByCustomerName(string customerName)
        {
            try
            {
                var quotation = await _QuotationRepository.GetQuotationByCustomerName(customerName);
                if (quotation == null)
                    return NotFound($"La cotización para el cliente '{customerName}' no se encontró");

                return Ok(quotation);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("GetQuotationById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetQuotationById(Guid id)
        {
            try
            {
                var quotation = await _QuotationRepository.GetQuotationById(id);
                if (quotation == null)
                    return NotFound($"La Cotización con Id {id} no se encontró");

                return Ok(quotation);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }

}


using Azure.Core;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Implementations;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEvoEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotationDetailController : ControllerBase
    {
        private readonly IQuotationDetailRepository _QuotationDetailRepository;
        public QuotationDetailController(IQuotationDetailRepository _quotationDetailRepository)
        {
            _QuotationDetailRepository = _quotationDetailRepository;
        }
        [HttpPut("GetRequestDetailById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<QuotationDetail>> UpdateQuotationDetail(QuotationDetail quotationDetail)
        {
            try
            {
                if (quotationDetail == null)
                {
                    return BadRequest("El Detalle de la Cotización está vacío");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var updatedQuotationDetail = await _QuotationDetailRepository.UpdateQuotationDetail(quotationDetail);

                if (updatedQuotationDetail == null)
                {
                    return NotFound($"QuotationDetail with ID {quotationDetail.Id} not found");
                }

                return Ok(updatedQuotationDetail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

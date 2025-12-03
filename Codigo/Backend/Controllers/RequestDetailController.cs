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
    public class RequestDetailController : ControllerBase
    {
        private readonly IRequestDetailRepository _RequestDetailRepository;
        public RequestDetailController(IRequestDetailRepository requestDetailRepository)
        {
            _RequestDetailRepository = requestDetailRepository;
        }

        [HttpGet("GetRequestDetailById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<RequestDetail>> GetRequestDetailById(Guid Id)
        {
            try
            {
                var request = await _RequestDetailRepository.GetRequestDetailById(Id);

                if (request == null)
                {
                    return NotFound($"No se encontró la solicitud con ID {Id}");
                }

                return Ok(request);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener la solicitud: {ex.Message}");
            }
        }
        [HttpGet("GetAllRequestDetail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<List<RequestDetail>> GetAllRequestDetail()
        {
            try
            {
                var requestDetail = await _RequestDetailRepository.GetAllRequestDetail();
                return requestDetail;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener las solicitudes: {ex.Message}");
            }

        }

    }
}

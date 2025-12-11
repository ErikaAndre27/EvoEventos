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
    public class ReportTypeController : ControllerBase
    {
        private readonly IReportTypeRepository _ReportTypeRepository;

        public ReportTypeController(IReportTypeRepository ReportTypeRepository)
        {
            _ReportTypeRepository = ReportTypeRepository;
        }

        [HttpGet("GetAllDocumentTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllReportTypes() // IActionResult es un tipo de retorno genérico para una acción de controlador
        {
            try
            {
                var ReportTypes = await _ReportTypeRepository.GetAllReportTypes();
                if (ReportTypes == null || !ReportTypes.Any())
                {
                    return NotFound("No se encontraron tipos de reportes.");
                }

                return Ok(ReportTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los tipos de reportes: " + ex.Message);
            }
        }

        [HttpGet("GetReportTypeById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetReportTypeById(Guid Id)
        {
            try
            {
                var ReportType = await _ReportTypeRepository.GetReportType(Id);
                if (ReportType == null)
                {
                    return NotFound("No se encontró el tipo reporte.");
                }

                return Ok(ReportType);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el tipo de reporte: " + ex.Message);
            }
        }
    }
}

using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Implementations;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BackEvoEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _ReportRepository;

        public ReportController(IReportRepository ReportRepository)
        {
            _ReportRepository = ReportRepository;
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpPost("CreateReport")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateReport([FromBody] Report Report)
        {
            try
            {
                var ReportExists = (await _ReportRepository.ReportExists(Report.IdReportType, Report.RangeStartDate, Report.RangeEndDate));
                if (ReportExists != null) // Validar si el cliente ya existe
                {
                    return Conflict($"Ya existe un reporte de este tipo y con el rango de fechas solicitadas {ReportExists}");
                }

                var CreatedReport = await _ReportRepository.CreateReport(Report);
                return StatusCode(StatusCodes.Status201Created, CreatedReport);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error al crear el nuevo cliente: {ex.Message}");
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpGet("GetAllReports")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetAllReports()
        {
            try
            {
                var Reports = await _ReportRepository.GetAllReports();
                if (Reports == null || !Reports.Any()) 
                {
                    return NotFound("No se encontraron reportes");
                }
                return Ok(Reports);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los reportes: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpGet("GetReportsByUserId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetReportsByUserId(Guid UserId)
        {
            try
            {
                var Reports = await _ReportRepository.GetReportsByUserId(UserId);
                if (Reports == null)
                {
                    return NotFound("No se encontraron reportes generados por el usuario");
                }
                return Ok(Reports);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los reportes: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpGet("GetReportsId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetReportsId(Guid Id)
        {
            try
            {
                var Report = await _ReportRepository.GetReportId(Id);
                if (Report == null)
                {
                    return NotFound("No se encontró el reporte");
                }
                return Ok(Report);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el reporte: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpGet("GetReportsByTypeId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetReportsByTypeId(Guid Id)
        {
            try
            {
                var Reports = await _ReportRepository.GetReportsByTypeId(Id);
                if (Reports == null)
                {
                    return NotFound("No se encontraron reportes del tipo solicitado");
                }
                return Ok(Reports);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los reportes: " + ex.Message);
            }
        }


    }
}

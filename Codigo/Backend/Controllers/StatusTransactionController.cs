using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEvoEventos.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StatusTransactionController : ControllerBase
    {
        private readonly IStatusTransactionRepository _StatusTransactionRepository; //Inyección de dependencia

        public StatusTransactionController(IStatusTransactionRepository StatusTransactionRepository)
        {
            _StatusTransactionRepository = StatusTransactionRepository;
        }

        [HttpGet("GetStatusTransactions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStatusTransactions()
        {
            try
            {
                var StatusTransactions = await _StatusTransactionRepository.GetStatusTransactions();
                if (StatusTransactions == null || !StatusTransactions.Any())
                {
                    return NotFound("No se encontraron StatusTransactions.");
                }

                return Ok(StatusTransactions);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los StatusTransactions: " + ex.Message);
            }
        }

        [HttpGet("GetStatusTransaction")] //Indica que este método responde a solicitudes HTTP GET(Lectura)
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStatusReservation(Guid Id) // IActionResult es un tipo de retorno genérico para una acción de controlador
        {
            try
            {
                var StatusTransactions = await _StatusTransactionRepository.GetStatusTransaction(Id); //Llama al método GetRoles del repositorio
                if (StatusTransactions == null) //Verifica si la lista de roles está vacía o es nula
                {
                    return NotFound("No se encontró el StatusTransaction."); //Devuelve un estado 404 Not Found con un mensaje
                }

                return Ok(StatusTransactions);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el StatusTransaction: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpPost("InsertStatusTransaction")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateStatusTransaction([FromBody] StatusTransaction StatusTransaction) // FromBody indica que el parámetro se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                var Result = await _StatusTransactionRepository.CreateStatusTransaction(StatusTransaction);
                if (!Result)
                {
                    return NotFound("No se pudo insertar el StatusTransaction.");
                }

                return Ok("StatusTransaction Insertado correctamemnte");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al intsertar el StatusTransaction: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpPut("UpdateStatusTransaction")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> UpdateStatusTransaction(Guid Id, [FromBody] StatusTransaction UpdatedStatusTransaction)
        {
            try
            {
                var Result = await _StatusTransactionRepository.UpdateStatusTransaction(Id, UpdatedStatusTransaction);
                if (!Result)
                {
                    return NotFound("No se pudo actualizar el StatusTransaction.");
                }
                return Ok("StatusTransaction actualizado correctamemnte");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el StatusTransaction: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpDelete("DeleteStatusTransaction")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> DeleteStatusTransaction(Guid Id)  // FromBody indica que el parámetro se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                var Result = await _StatusTransactionRepository.DeleteStatusTransaction(Id);
                if (!Result) // Verifica si la lista de roles está vacía o es nula
                {
                    return BadRequest("No se pudo eliminar el StatusTransaction.");  //BadRequest hace referencia a un estado 400
                }

                return Ok("StatusTransaction eliminado Correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al Eliminar el StatusTransaction: " + ex.Message);
            }

        }
    }
}

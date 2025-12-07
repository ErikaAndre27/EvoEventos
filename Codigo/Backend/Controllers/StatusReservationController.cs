using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEvoEventos.Controllers
{
    [Route("api/[controller]")] //http://localhost:5000/api/Role
    [ApiController]
    public class StatusReservationController : ControllerBase
    {
        private readonly IStatusReservationRepository _StatusReservationRepository; //Inyección de dependencia

        public StatusReservationController(IStatusReservationRepository StatusReservationRepository)
        {
            _StatusReservationRepository = StatusReservationRepository;
        }

        [HttpGet("GetStatusReservations")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] 
        public async Task<IActionResult> GetStatusReservations() 
        {
            try
            {
                var StatusReservations = await _StatusReservationRepository.GetStatusReservations(); 
                if (StatusReservations == null || !StatusReservations.Any()) 
                {
                    return NotFound("No se encontraron StatusReservations."); 
                }

                return Ok(StatusReservations);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los StatusReservations: " + ex.Message);
            }
        }

        [HttpGet("GetStatusReservation")] //Indica que este método responde a solicitudes HTTP GET(Lectura)
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStatusReservation(Guid Id) // IActionResult es un tipo de retorno genérico para una acción de controlador
        {
            try
            {
                var StatusReservations = await _StatusReservationRepository.GetStatusReservation(Id); //Llama al método GetRoles del repositorio
                if (StatusReservations == null) //Verifica si la lista de roles está vacía o es nula
                {
                    return NotFound("No se encontró el StatusReservation."); //Devuelve un estado 404 Not Found con un mensaje
                }

                return Ok(StatusReservations);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el StatusReservation: " + ex.Message);
            }
        }

        [HttpPost("InsertStatusReservation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateStatusReservation([FromBody] StatusReservation StatusReservation) // FromBody indica que el parámetro se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                var Result = await _StatusReservationRepository.CreateStatusReservation(StatusReservation);
                if (!Result)
                {
                    return NotFound("No se pudo insertar el StatusReservation.");
                }

                return Ok("StatusReservation Insertado correctamemnte");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al intsertar el StatusReservation: " + ex.Message);
            }
        }

        [HttpPut("UpdateStatusReservation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> UpdateStatusReservation(Guid Id, [FromBody] StatusReservation UpdatedStatusReservation)
        {
            try
            {
                var Result = await _StatusReservationRepository.UpdateStatusReservation(Id, UpdatedStatusReservation);
                if (!Result)
                {
                    return NotFound("No se pudo actualizar el StatusReservation.");
                }
                return Ok("StatusReservation actualizado correctamemnte");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el StatusReservation: " + ex.Message);
            }
        }

        [HttpDelete("DeleteStatusReservation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> DeleteStatusReservation(Guid Id)  // FromBody indica que el parámetro se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                var Result = await _StatusReservationRepository.DeleteStatusReservation(Id);
                if (!Result) // Verifica si la lista de roles está vacía o es nula
                {
                    return BadRequest("No se pudo eliminar el StatusReservation.");  //BadRequest hace referencia a un estado 400
                }

                return Ok("StatusReservation eliminado Correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al Eliminar el StatusReservation: " + ex.Message);
            }
        }
    }
}

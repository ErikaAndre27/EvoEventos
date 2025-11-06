using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Implementations;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEvoEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggingTypeController : ControllerBase
    {
        private readonly ILoggingTypeRepository _loggingTypeRepository; //Inyección de dependencia

        public LoggingTypeController(ILoggingTypeRepository LoggingTypeRepository)
        {
            _loggingTypeRepository = LoggingTypeRepository;
        }

        [HttpGet("GetLogginTypes")] //Indica que este método responde a solicitudes HTTP GET(Lectura)
        [ProducesResponseType(StatusCodes.Status200OK)] //Indica que este método puede devolver un estado 200 OK
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Indica que este método puede devolver un estado 404 Not Found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] //Indica que este método puede devolver un estado 500 Internal Server Error
        public async Task<IActionResult> GetLoggingTypes() // IActionResult es un tipo de retorno genérico para una acción de controlador
        {
            try
            {
                var LogginTypes = await _loggingTypeRepository.GetLoggingTypes(); //Llama al método GetRoles del repositorio
                if (LogginTypes == null || !LogginTypes.Any()) //Verifica si la lista de roles está vacía o es nula
                {
                    return NotFound("No se encontraron Loggin Types."); //Devuelve un estado 404 Not Found con un mensaje
                }

                return Ok(LogginTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los Logging Types: " + ex.Message);
            }
        }

        [HttpGet("GetLogginType")] //Indica que este método responde a solicitudes HTTP GET(Lectura)
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLoggingType(Guid Id) // IActionResult es un tipo de retorno genérico para una acción de controlador
        {
            try
            {
                var LoggingType = await _loggingTypeRepository.GetLoggingType(Id); //Llama al método GetRoles del repositorio
                if (LoggingType == null) //Verifica si la lista de roles está vacía o es nula
                {
                    return NotFound("No se encontró el Loggin Type."); //Devuelve un estado 404 Not Found con un mensaje
                }

                return Ok(LoggingType);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el Loggin Type: " + ex.Message);
            }
        }

        [HttpPost("InsertLogginType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateLoggingType([FromBody] LoggingType LoggingType) // FromBody indica que el parámetro se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                var Result = await _loggingTypeRepository.CreateLoggingType(LoggingType);
                if (!Result)
                {
                    return NotFound("No se pudo insertar el Loggin Type.");
                }

                return Ok("Loggin Type Insertado correctamemnte");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al insertar el Loggin Type: " + ex.Message);
            }
        }

        [HttpPut("UpdateLogginType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> UpdateLoggingType(Guid Id, [FromBody] LoggingType UpdatedLoggingType)
        {
            try
            {
                var Result = await _loggingTypeRepository.UpdateLoggingType(Id, UpdatedLoggingType);
                if (!Result)
                {
                    return NotFound("No se pudo actualizar el Loggin Type.");
                }
                return Ok("Loggin Type actualizado correctamemnte");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el Loggin Type: " + ex.Message);
            }
        }

        [HttpDelete("DeleteLogginType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> DeleteLoggingType(Guid Id)  // FromBody indica que el parámetro se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                var Result = await _loggingTypeRepository.DeleteLoggingType(Id);
                var LoggingType = await _loggingTypeRepository.DeleteLoggingType(Id);
                if (!Result) // Verifica si la lista de roles está vacía o es nula
                {
                    return BadRequest("No se pudo Eliminar el Loggin Type.");  //BadRequest hace referencia a un estado 400
                }

                return Ok("Loggin Type Eliminado Correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al Eliminar el Loggin Type: " + ex.Message);
            }
        }
    }
}

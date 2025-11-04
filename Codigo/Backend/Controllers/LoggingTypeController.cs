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

        public LoggingTypeController(ILoggingTypeRepository loggingTypeRepository)
        {
            _loggingTypeRepository = loggingTypeRepository;
        }

        [HttpGet("Get Loggin Types")] //Indica que este método responde a solicitudes HTTP GET(Lectura)
        [ProducesResponseType(StatusCodes.Status200OK)] //Indica que este método puede devolver un estado 200 OK
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Indica que este método puede devolver un estado 404 Not Found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] //Indica que este método puede devolver un estado 500 Internal Server Error
        public async Task<IActionResult> GetLoggingTypes() // IActionResult es un tipo de retorno genérico para una acción de controlador
        {
            try
            {
                var logginTypes = await _loggingTypeRepository.GetLoggingTypes(); //Llama al método GetRoles del repositorio
                if (logginTypes == null || !logginTypes.Any()) //Verifica si la lista de roles está vacía o es nula
                {
                    return NotFound("No se encontraron Loggin Types."); //Devuelve un estado 404 Not Found con un mensaje
                }

                return Ok(logginTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los Logging Types: " + ex.Message);
            }
        }

        [HttpGet("Get Loggin Type")] //Indica que este método responde a solicitudes HTTP GET(Lectura)
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLoggingType(Guid id) // IActionResult es un tipo de retorno genérico para una acción de controlador
        {
            try
            {
                var loggingType = await _loggingTypeRepository.GetLoggingType(id); //Llama al método GetRoles del repositorio
                if (loggingType == null) //Verifica si la lista de roles está vacía o es nula
                {
                    return NotFound("No se encontró el Loggin Type."); //Devuelve un estado 404 Not Found con un mensaje
                }

                return Ok(loggingType);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el Loggin Type: " + ex.Message);
            }
        }

        [HttpPost("Insert Loggin Type")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateLoggingType([FromBody] LoggingType loggingType) // FromBody indica que el parámetro se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                var resultado = await _loggingTypeRepository.CreateLoggingType(loggingType);
                if (!resultado)
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

        [HttpPut("Update Loggin Type")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> UpdateLoggingType(Guid id, [FromBody] LoggingType updatedLoggingType)
        {
            try
            {
                var resultado = await _loggingTypeRepository.UpdateLoggingType(id, updatedLoggingType);
                if (!resultado)
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

        [HttpDelete("Delete Loggin Type")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> DeleteLoggingType(Guid id)  // FromBody indica que el parámetro se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                var resultado = await _loggingTypeRepository.DeleteLoggingType(id);
                var loggingType = await _loggingTypeRepository.DeleteLoggingType(id);
                if (!resultado) // Verifica si la lista de roles está vacía o es nula
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

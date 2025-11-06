using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Implementations;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEvoEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerTypeController : ControllerBase
    {
        private readonly ICustomerTypeRepository _customerTypeRepository; //Inyección de dependencia

        public CustomerTypeController(ICustomerTypeRepository CustomerTypeRepository)
        {
            _customerTypeRepository = CustomerTypeRepository;
        }

        [HttpGet("GetCustomerTypes")] //Indica que este método responde a solicitudes HTTP GET(Lectura)
        [ProducesResponseType(StatusCodes.Status200OK)] //Indica que este método puede devolver un estado 200 OK
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Indica que este método puede devolver un estado 404 Not Found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] //Indica que este método puede devolver un estado 500 Internal Server Error
        public async Task<IActionResult> GetCustomerTypes() // IActionResult es un tipo de retorno genérico para una acción de controlador
        {
            try
            {
                var CustomerTypes = await _customerTypeRepository.GetCustomerTypes(); //Llama al método GetRoles del repositorio
                if (CustomerTypes == null || !CustomerTypes.Any()) //Verifica si la lista de roles está vacía o es nula
                {
                    return NotFound("No se encontraron Customer Types."); //Devuelve un estado 404 Not Found con un mensaje
                }

                return Ok(CustomerTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los Customer Types: " + ex.Message);
            }
        }

        [HttpGet("GetCustomerType")] //Indica que este método responde a solicitudes HTTP GET(Lectura)
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLoggingType(Guid id) // IActionResult es un tipo de retorno genérico para una acción de controlador
        {
            try
            {
                var CustomerType = await _customerTypeRepository.GetCustomerType(id); //Llama al método GetRoles del repositorio
                if (CustomerType == null) //Verifica si la lista de roles está vacía o es nula
                {
                    return NotFound("No se encontró el Customer Type."); //Devuelve un estado 404 Not Found con un mensaje
                }

                return Ok(CustomerType);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el Customer Type: " + ex.Message);
            }
        }

        [HttpPost("InsertCustomerType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateLoggingType([FromBody] CustomerType CustomerType) // FromBody indica que el parámetro se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                var Result = await _customerTypeRepository.CreateCustomerType(CustomerType);
                if (!Result)
                {
                    return NotFound("No se pudo insertar el Customer Type.");
                }

                return Ok("Customer Type Insertado correctamemnte");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al insertar el Customer Type: " + ex.Message);
            }
        }

        [HttpPut("UpdateCustomerType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> UpdateLoggingType(Guid id, [FromBody] CustomerType UpdatedCustomerType)
        {
            try
            {
                var Result = await _customerTypeRepository.UpdateCustomerType(id, UpdatedCustomerType);
                if (!Result)
                {
                    return NotFound("No se pudo actualizar el Customer Type.");
                }
                return Ok("Customer Type actualizado correctamemnte");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el Customer Type: " + ex.Message);
            }
        }

        [HttpDelete("DeleteCustomerType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> DeleteCustomerType(Guid Id)  // FromBody indica que el parámetro se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                var Result = await _customerTypeRepository.DeleteCustomerType(Id);
                var LoggingType = await _customerTypeRepository.DeleteCustomerType(Id);
                if (!Result) // Verifica si la lista de roles está vacía o es nula
                {
                    return BadRequest("No se pudo Eliminar el Customer Type.");  //BadRequest hace referencia a un estado 400
                }

                return Ok("Customer Type Eliminado Correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al Eliminar el Customer Type: " + ex.Message);
            }
        }
    }
}

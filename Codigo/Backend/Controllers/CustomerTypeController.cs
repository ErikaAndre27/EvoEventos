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

        public CustomerTypeController(ICustomerTypeRepository customerTypeRepository)
        {
            _customerTypeRepository = customerTypeRepository;
        }

        [HttpGet("Get Customer Types")] //Indica que este método responde a solicitudes HTTP GET(Lectura)
        [ProducesResponseType(StatusCodes.Status200OK)] //Indica que este método puede devolver un estado 200 OK
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Indica que este método puede devolver un estado 404 Not Found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] //Indica que este método puede devolver un estado 500 Internal Server Error
        public async Task<IActionResult> GetCustomerTypes() // IActionResult es un tipo de retorno genérico para una acción de controlador
        {
            try
            {
                var customerTypes = await _customerTypeRepository.GetCustomerTypes(); //Llama al método GetRoles del repositorio
                if (customerTypes == null || !customerTypes.Any()) //Verifica si la lista de roles está vacía o es nula
                {
                    return NotFound("No se encontraron Customer Types."); //Devuelve un estado 404 Not Found con un mensaje
                }

                return Ok(customerTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los Customer Types: " + ex.Message);
            }
        }

        [HttpGet("Get Customer Type")] //Indica que este método responde a solicitudes HTTP GET(Lectura)
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLoggingType(Guid id) // IActionResult es un tipo de retorno genérico para una acción de controlador
        {
            try
            {
                var customerType = await _customerTypeRepository.GetCustomerType(id); //Llama al método GetRoles del repositorio
                if (customerType == null) //Verifica si la lista de roles está vacía o es nula
                {
                    return NotFound("No se encontró el Customer Type."); //Devuelve un estado 404 Not Found con un mensaje
                }

                return Ok(customerType);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el Customer Type: " + ex.Message);
            }
        }

        [HttpPost("Insert Customer Type")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateLoggingType([FromBody] CustomerType customerType) // FromBody indica que el parámetro se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                var resultado = await _customerTypeRepository.CreateCustomerType(customerType);
                if (!resultado)
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

        [HttpPut("Update Customer Type")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> UpdateLoggingType(Guid id, [FromBody] CustomerType updatedCustomerType)
        {
            try
            {
                var resultado = await _customerTypeRepository.UpdateCustomerType(id, updatedCustomerType);
                if (!resultado)
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

        [HttpDelete("Delete Customer Type")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> DeleteCustomerType(Guid id)  // FromBody indica que el parámetro se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                var resultado = await _customerTypeRepository.DeleteCustomerType(id);
                var loggingType = await _customerTypeRepository.DeleteCustomerType(id);
                if (!resultado) // Verifica si la lista de roles está vacía o es nula
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

using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Implementations;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEvoEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository; //variable de solo lectura para el repositorio de Customers de tipo global(se accede desde cualquier método del código)
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        [HttpGet("GetAllCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                var Customers = await _customerRepository.GetAllCustomers();
                if (Customers == null || !Customers.Any()) //verifica si la lista de personas está vacía o es nula
                {
                    return NotFound("No se Encontró Cliente");
                }
                return Ok(Customers);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los Clientes: " + ex.Message);
            }
        }

        [HttpGet("GetCustomerById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCustomerById(Guid Id)
        {
            try
            {
                var customer = await _customerRepository.GetCustomerById(Id);
                if (customer == null)
                {
                    return NotFound("No se encontró el Cliente");
                }
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el Id del Cliente: " + ex.Message);
            }
        }

        [HttpGet("GetCustomerByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCustomerByName(string Name)
        {
            try
            {
                var customer = await _customerRepository.GetCustomersByName(Name);
                if (customer == null)
                {
                    return NotFound("No se encontró el nombre del Cliente");
                }
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el nombre del Cliente: " + ex.Message);
            }
        }

        [HttpGet("GetCustomerDocumentNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCustomerByDocumentNumber(string DocumentNumber)
        {
            try
            {
                var customer = await _customerRepository.GetCustomerByDocumentNumber(DocumentNumber);
                if (customer == null)
                {
                    return NotFound("No se encontró el número de Documento del Cliente");
                }
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el número de Documento del Cliente: " + ex.Message);
            }
        }

        [HttpPost("CreateCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)// FromBody indica que el parámetro persona se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                
                if (await _customerRepository.CustomerExists(customer.DocumentNumber)) // Validar si el cliente ya existe
                {
                    return Conflict($"Ya existe un cliente con el número de documento {customer.DocumentNumber}");
                }

                
                customer.Id = Guid.NewGuid();
                customer.IsActive = true;

                
                var createdCustomer = await _customerRepository.CreateCustomer(customer); 

                return CreatedAtAction(
                    nameof(GetCustomerById),
                    new { id = createdCustomer.Id },
                    createdCustomer
                );
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error al crear el nuevo cliente: {ex.Message}");
            }
        }

        [HttpPut("UpdateCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Customer>> UpdateCustomer([FromBody] Customer UpdatedCustomer) //ActionResult permite devolver el objeto o las respuestas de Http
        {
            try
            {
                var result = await _customerRepository.UpdateCustomer(UpdatedCustomer);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Error al actualizar el cliente:{ ex.Message}");

            }
        }

        [HttpDelete("DeleteCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteCustomer(Guid Id)
        {
            try
            {
                var Result = await _customerRepository.DeleteCustomer(Id);
                if (!Result)
                {
                    return BadRequest("No se Puede Eliminar El Cliente");
                }
                return Ok("El CLiente ha sido Eliminado Correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar el Cliente: " + ex.Message);
            }
        }

    }
}
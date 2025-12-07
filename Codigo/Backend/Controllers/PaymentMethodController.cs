using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEvoEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        private readonly IPaymentMethodRepository _PaymentMethodRepository; //Inyección de dependencia

        public PaymentMethodController(IPaymentMethodRepository PaymentMethodRepository)
        {
            _PaymentMethodRepository = PaymentMethodRepository;
        }

        [HttpGet("GetPaymentMethods")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStatusTransactions()
        {
            try
            {
                var PaymentMethods = await _PaymentMethodRepository.GetPaymentMethods();
                if (PaymentMethods == null || !PaymentMethods.Any())
                {
                    return NotFound("No se encontraron PaymentMethods.");
                }

                return Ok(PaymentMethods);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los PaymentMethods: " + ex.Message);
            }
        }

        [HttpGet("GetPaymentMethod")] //Indica que este método responde a solicitudes HTTP GET(Lectura)
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPaymentMethod(Guid Id) // IActionResult es un tipo de retorno genérico para una acción de controlador
        {
            try
            {
                var PaymentMethods = await _PaymentMethodRepository.GetPaymentMethod(Id); //Llama al método GetRoles del repositorio
                if (PaymentMethods == null) //Verifica si la lista de roles está vacía o es nula
                {
                    return NotFound("No se encontró el PaymentMethod."); //Devuelve un estado 404 Not Found con un mensaje
                }

                return Ok(PaymentMethods);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el PaymentMethod: " + ex.Message);
            }
        }

        [HttpPost("InsertPaymentMethod")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreatePaymentMethod([FromBody] PaymentMethod PaymentMethod) // FromBody indica que el parámetro se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                var Result = await _PaymentMethodRepository.CreatePaymentMethod(PaymentMethod);
                if (!Result)
                {
                    return NotFound("No se pudo insertar el PaymentMethod.");
                }

                return Ok("PaymentMethod Insertado correctamemnte");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al intsertar el PaymentMethod: " + ex.Message);
            }
        }

        [HttpPut("UpdatePaymentMethod")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> UpdatePaymentMethod(Guid Id, [FromBody] PaymentMethod UpdatedPaymentMethod)
        {
            try
            {
                var Result = await _PaymentMethodRepository.UpdatePaymentMethod(Id, UpdatedPaymentMethod);
                if (!Result)
                {
                    return NotFound("No se pudo actualizar el PaymentMethod.");
                }
                return Ok("PaymentMethod actualizado correctamemnte");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el PaymentMethod: " + ex.Message);
            }
        }

        [HttpDelete("DeletePaymentMethod")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> DeletePaymentMethod(Guid Id)  // FromBody indica que el parámetro se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                var Result = await _PaymentMethodRepository.DeletePaymentMethod(Id);
                if (!Result) // Verifica si la lista de roles está vacía o es nula
                {
                    return BadRequest("No se pudo eliminar el PaymentMethod.");  //BadRequest hace referencia a un estado 400
                }

                return Ok("PaymentMethod eliminado Correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al Eliminar el PaymentMethod: " + ex.Message);
            }

        }
    }
}

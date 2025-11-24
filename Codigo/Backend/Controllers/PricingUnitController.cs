using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEvoEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PricingUnitController : ControllerBase
    {
        private readonly IPricingUnitRepository _PricingUnitRepository; //Inyección de dependencia

        public PricingUnitController(IPricingUnitRepository PricingUnitRepository)
        {
            _PricingUnitRepository = PricingUnitRepository;
        }

        [HttpGet("GetPricingUnits")] //Indica que este método responde a solicitudes HTTP GET(Lectura)
        [ProducesResponseType(StatusCodes.Status200OK)] //Indica que este método puede devolver un estado 200 OK
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Indica que este método puede devolver un estado 404 Not Found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] //Indica que este método puede devolver un estado 500 Internal Server Error
        public async Task<IActionResult> GetPricingUnits() // IActionResult es un tipo de retorno genérico para una acción de controlador
        {
            try
            {
                var PricingUnits = await _PricingUnitRepository.GetPricingUnits(); //Llama al método GetRoles del repositorio
                if (PricingUnits == null || !PricingUnits.Any()) //Verifica si la lista de roles está vacía o es nula
                {
                    return NotFound("No se encontraron PricingUnits."); //Devuelve un estado 404 Not Found con un mensaje
                }

                return Ok(PricingUnits);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los PricingUnits: " + ex.Message);
            }
        }

        [HttpGet("GetPricingUnit")] //Indica que este método responde a solicitudes HTTP GET(Lectura)
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRole(Guid Id) // IActionResult es un tipo de retorno genérico para una acción de controlador
        {
            try
            {
                var PricingUnit = await _PricingUnitRepository.GetPricingUnit(Id); //Llama al método GetRoles del repositorio
                if (PricingUnit == null) //Verifica si la lista de roles está vacía o es nula
                {
                    return NotFound("No se encontró el PricingUnit."); //Devuelve un estado 404 Not Found con un mensaje
                }

                return Ok(PricingUnit);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el PricingUnit: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpPost("InsertPricingUnit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreatePricingUnit([FromBody] PricingUnit PricingUnit) // FromBody indica que el parámetro se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                var Result = await _PricingUnitRepository.CreatePricingUnit(PricingUnit);
                if (!Result)
                {
                    return NotFound("No se pudo insertar el PricingUnit.");
                }

                return Ok("PricingUnit Insertado correctamemnte");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el PricingUnit: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpPut("UpdatePricingUnit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]


        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> UpdatePricingUnit(Guid Id, [FromBody] PricingUnit UpdatedPricingUnit)
        {
            try
            {
                var Result = await _PricingUnitRepository.UpdatePricingUnit(Id, UpdatedPricingUnit);
                if (!Result)
                {
                    return NotFound("No se pudo actualizar el PricingUnit.");
                }
                return Ok("Rol actualizado correctamemnte");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el PricingUnit: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpDelete("DeletePricingUnit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> DeletePricingUnit(Guid Id)  // FromBody indica que el parámetro se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                var Result = await _PricingUnitRepository.DeletePricingUnit(Id);
                if (!Result) // Verifica si la lista de roles está vacía o es nula
                {
                    return BadRequest("No se pudo eliminar el PricingUnit.");  //BadRequest hace referencia a un estado 400
                }

                return Ok("PricingUnit eliminado Correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al Eliminar el PricingUnit: " + ex.Message);
            }
        }
    }
}

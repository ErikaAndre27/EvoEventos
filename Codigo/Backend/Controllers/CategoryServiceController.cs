using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEvoEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] //Requiere que el usuario esté autenticado para acceder a los métodos del controlador
    public class CategoryServiceController : ControllerBase
    {
        private readonly ICategoryServiceRepository _CategoryServiceRepository; //Inyección de dependencia

        public CategoryServiceController(ICategoryServiceRepository CategoryServiceRepository)
        {
            _CategoryServiceRepository = CategoryServiceRepository;
        }

        [HttpGet("GetCategoryServices")] //Indica que este método responde a solicitudes HTTP GET(Lectura)
        [ProducesResponseType(StatusCodes.Status200OK)] //Indica que este método puede devolver un estado 200 OK
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Indica que este método puede devolver un estado 404 Not Found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] //Indica que este método puede devolver un estado 500 Internal Server Error
        public async Task<IActionResult> GetCategoryServices() // IActionResult es un tipo de retorno genérico para una acción de controlador
        {
            try
            {
                var CategoryServices = await _CategoryServiceRepository.GetCategoryServices(); //Llama al método GetRoles del repositorio
                if (CategoryServices == null || !CategoryServices.Any()) //Verifica si la lista de roles está vacía o es nula
                {
                    return NotFound("No se encontraron CategoryServices."); //Devuelve un estado 404 Not Found con un mensaje
                }

                return Ok(CategoryServices);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los CategoryServices: " + ex.Message);
            }
        }

        [HttpGet("GetCategoryService")] //Indica que este método responde a solicitudes HTTP GET(Lectura)
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCategoryService(Guid Id) // IActionResult es un tipo de retorno genérico para una acción de controlador
        {
            try
            {
                var CategoryService = await _CategoryServiceRepository.GetCategoryService(Id); //Llama al método GetRoles del repositorio
                if (CategoryService == null) //Verifica si la lista de roles está vacía o es nula
                {
                    return NotFound("No se encontró el CategoryService."); //Devuelve un estado 404 Not Found con un mensaje
                }

                return Ok(CategoryService);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el CategoryService: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpPost("InsertCategoryService")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateCategoryService([FromBody] CategoryService CategoryService) // FromBody indica que el parámetro se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                var Result = await _CategoryServiceRepository.CreateCategoryService(CategoryService);
                if (!Result)
                {
                    return NotFound("No se pudo crear el CategoryService.");
                }

                return Ok("CategoryService creado correctamemnte");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el CategoryService: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpPut("UpdateCategoryService")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]


        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> UpdateCategoryService(Guid Id, [FromBody] CategoryService UpdatedCategoryService)
        {
            try
            {
                var Result = await _CategoryServiceRepository.UpdateCategoryService(Id, UpdatedCategoryService);
                if (!Result)
                {
                    return NotFound("No se pudo actualizar el CategoryService.");
                }
                return Ok("CategoryService actualizado correctamemnte");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el CategoryService: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpDelete("DeleteCategoryService")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> DeleteCategoryService(Guid Id)  // FromBody indica que el parámetro se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                var Result = await _CategoryServiceRepository.DeleteCategoryService(Id);
                if (!Result) // Verifica si la lista de CategoryService está vacía o es nula
                {
                    return BadRequest("No se pudo eliminar el CategoryService.");  //BadRequest hace referencia a un estado 400
                }

                return Ok("CategoryService eliminado Correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al Eliminar el CategoryService: " + ex.Message);
            }
        }
    }
}

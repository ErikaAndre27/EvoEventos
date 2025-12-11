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
    public class CategoryResourceController : ControllerBase
    {
        private readonly ICategoryResourceRepository _CategoryResourceRepository; //Inyección de dependencia

        public CategoryResourceController(ICategoryResourceRepository CategoryResourceRepository)
        {
            _CategoryResourceRepository = CategoryResourceRepository;
        }

        [HttpGet("GetCategoryResources")] //Indica que este método responde a solicitudes HTTP GET(Lectura)
        [ProducesResponseType(StatusCodes.Status200OK)] //Indica que este método puede devolver un estado 200 OK
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Indica que este método puede devolver un estado 404 Not Found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] //Indica que este método puede devolver un estado 500 Internal Server Error
        public async Task<IActionResult> GetCategoryResources() // IActionResult es un tipo de retorno genérico para una acción de controlador
        {
            try
            {
                var CategoryResources = await _CategoryResourceRepository.GetCategoryResources(); //Llama al método GetRoles del repositorio
                if (CategoryResources == null || !CategoryResources.Any()) //Verifica si la lista de roles está vacía o es nula
                {
                    return NotFound("No se encontraron CategoryResources."); //Devuelve un estado 404 Not Found con un mensaje
                }

                return Ok(CategoryResources);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los CategoryResources: " + ex.Message);
            }
        }

        [HttpGet("GetCategoryResource")] //Indica que este método responde a solicitudes HTTP GET(Lectura)
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCategoryResource(Guid Id) // IActionResult es un tipo de retorno genérico para una acción de controlador
        {
            try
            {
                var CategoryResource = await _CategoryResourceRepository.GetCategoryResource(Id); //Llama al método GetRoles del repositorio
                if (CategoryResource == null) //Verifica si la lista de roles está vacía o es nula
                {
                    return NotFound("No se encontró el CategoryResource."); //Devuelve un estado 404 Not Found con un mensaje
                }

                return Ok(CategoryResource);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el CategoryResource: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpPost("InsertCategoryResource")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateCategoryResource([FromBody] CategoryResource CategoryResource) // FromBody indica que el parámetro se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                var Result = await _CategoryResourceRepository.CreateCategoryResource(CategoryResource);
                if (!Result)
                {
                    return NotFound("No se pudo crear el CategoryResource.");
                }

                return Ok("CategoryResource creado correctamemnte");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el CategoryResource: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpPut("UpdateCategoryResource")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]


        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> UpdateCategoryResource(Guid Id, [FromBody] CategoryResource UpdatedCategoryResource)
        {
            try
            {
                var Result = await _CategoryResourceRepository.UpdateCategoryResource(Id, UpdatedCategoryResource);
                if (!Result)
                {
                    return NotFound("No se pudo actualizar el CategoryResource.");
                }
                return Ok("CategoryResource actualizado correctamemnte");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el CategoryResource: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpDelete("DeleteCategoryResource")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> DeleteCategoryResource(Guid Id)  // FromBody indica que el parámetro se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                var Result = await _CategoryResourceRepository.DeleteCategoryResource(Id);
                if (!Result) // Verifica si la lista de CategoryService está vacía o es nula
                {
                    return BadRequest("No se pudo eliminar el CategoryResource.");  //BadRequest hace referencia a un estado 400
                }

                return Ok("CategoryResource eliminado Correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al Eliminar el CategoryResource: " + ex.Message);
            }
        }
    }
}

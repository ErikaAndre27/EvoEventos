using BackEvoEventos.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackEvoEventos.Models;
using Microsoft.AspNetCore.Authorization;


namespace BackEvoEventos.Controllers
{
    [Route("api/[controller]")] //http://localhost:5000/api/Role
    [ApiController] //
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository; //Inyección de dependencia

        public RoleController(IRoleRepository RoleRepository)
        {
            _roleRepository = RoleRepository;
        }

        [HttpGet("GetRoles")] //Indica que este método responde a solicitudes HTTP GET(Lectura)
        [ProducesResponseType(StatusCodes.Status200OK)] //Indica que este método puede devolver un estado 200 OK
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Indica que este método puede devolver un estado 404 Not Found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] //Indica que este método puede devolver un estado 500 Internal Server Error
        public async Task<IActionResult> GetRoles() // IActionResult es un tipo de retorno genérico para una acción de controlador
        {
            try
            {
                var Roles = await _roleRepository.GetRoles(); //Llama al método GetRoles del repositorio
                if (Roles == null || !Roles.Any()) //Verifica si la lista de roles está vacía o es nula
                {
                    return NotFound("No se encontraron Roles."); //Devuelve un estado 404 Not Found con un mensaje
                }

                return Ok(Roles);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los Roles: " + ex.Message);
            }
        }

        [HttpGet("GetRole")] //Indica que este método responde a solicitudes HTTP GET(Lectura)
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRole(Guid Id) // IActionResult es un tipo de retorno genérico para una acción de controlador
        {
            try
            {
                var Roles = await _roleRepository.GetRole(Id); //Llama al método GetRoles del repositorio
                if (Roles == null) //Verifica si la lista de roles está vacía o es nula
                {
                    return NotFound("No se encontró el Rol."); //Devuelve un estado 404 Not Found con un mensaje
                }

                return Ok(Roles);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los Roles: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpPost("InsertRole")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateRole([FromBody] Role Role) // FromBody indica que el parámetro se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                var Result = await _roleRepository.CreateRole(Role);
                if (!Result)
                {
                    return NotFound("No se pudo insertar el Rol.");
                }

                return Ok("Rol Insertado correctamemnte");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los roles: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpPut("UpdateRole")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]


        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> UpdateRole(Guid Id, [FromBody] Role UpdatedRole)
        {
            try
            {
                var Result = await _roleRepository.UpdateRole(Id, UpdatedRole);
                if (!Result)
                {
                    return NotFound("No se pudo actualizar el rol.");
                }
                return Ok("Rol actualizado correctamemnte");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los roles: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpDelete("DeleteRole")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> DeleteRole(Guid Id)  // FromBody indica que el parámetro se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                var Result = await _roleRepository.DeleteRole(Id);
                if (!Result) // Verifica si la lista de roles está vacía o es nula
                {
                    return BadRequest("No se pudo eliminar el rol.");  //BadRequest hace referencia a un estado 400
                }

                return Ok("Rol eliminado Correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al Eliminar el Rol: " + ex.Message);
            }
        }

    }
}

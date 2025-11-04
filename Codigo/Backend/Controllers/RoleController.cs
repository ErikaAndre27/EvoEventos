using BackEvoEventos.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackEvoEventos.Models;


namespace BackEvoEventos.Controllers
{
    [Route("api/[controller]")] //http://localhost:5000/api/Role
    [ApiController] //
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository; //Inyección de dependencia

        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet("Get Roles")] //Indica que este método responde a solicitudes HTTP GET(Lectura)
        [ProducesResponseType(StatusCodes.Status200OK)] //Indica que este método puede devolver un estado 200 OK
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Indica que este método puede devolver un estado 404 Not Found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] //Indica que este método puede devolver un estado 500 Internal Server Error
        public async Task<IActionResult> GetRoles() // IActionResult es un tipo de retorno genérico para una acción de controlador
        {
            try
            {
                var roles = await _roleRepository.GetRoles(); //Llama al método GetRoles del repositorio
                if (roles == null || !roles.Any()) //Verifica si la lista de roles está vacía o es nula
                {
                    return NotFound("No se encontraron Roles."); //Devuelve un estado 404 Not Found con un mensaje
                }

                return Ok(roles);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los Roles: " + ex.Message);
            }
        }

        [HttpGet("Get Role")] //Indica que este método responde a solicitudes HTTP GET(Lectura)
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRole(Guid id) // IActionResult es un tipo de retorno genérico para una acción de controlador
        {
            try
            {
                var roles = await _roleRepository.GetRole(id); //Llama al método GetRoles del repositorio
                if (roles == null) //Verifica si la lista de roles está vacía o es nula
                {
                    return NotFound("No se encontró el Rol."); //Devuelve un estado 404 Not Found con un mensaje
                }

                return Ok(roles);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los Roles: " + ex.Message);
            }
        }

        [HttpPost("Insert Role")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateRole([FromBody] Role role) // FromBody indica que el parámetro se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                var resultado = await _roleRepository.CreateRole(role);
                if (!resultado)
                {
                    return NotFound("No se pudo insertar el Rol.");
                }

                return Ok("Rol Insertado correctamemnte");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los Roles: " + ex.Message);
            }
        }

        [HttpPut("Update Role")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> UpdateRole(Guid id, [FromBody] Role updatedRole)
        {
            try
            {
                var resultado = await _roleRepository.UpdateRole(id, updatedRole);
                if (!resultado)
                {
                    return NotFound("No se pudo actualizar el Rol.");
                }
                return Ok("Rol actualizado correctamemnte");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los Roles: " + ex.Message);
            }
        }

        [HttpDelete("Delete Role")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> DeleteRole(Guid id)  // FromBody indica que el parámetro se obtiene del cuerpo de la solicitud HTTP
        {
            try
            {
                var resultado = await _roleRepository.DeleteRole(id);
                var roles = await _roleRepository.DeleteRole(id);
                if (!resultado) // Verifica si la lista de roles está vacía o es nula
                {
                    return BadRequest("No se pudo Eliminar el Rol.");  //BadRequest hace referencia a un estado 400
                }

                return Ok("Rol Eliminado Correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al Eliminar el Rol: " + ex.Message);
            }
        }

    }
}

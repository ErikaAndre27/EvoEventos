using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEvoEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _UserRepository;

        public UserController(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        [HttpGet("GetUsers")] 
        [ProducesResponseType(StatusCodes.Status200OK)] 
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] 
        public async Task<IActionResult> GetAllUsers() // IActionResult es un tipo de retorno genérico para una acción de controlador
        {
            try
            {
                var Users = await _UserRepository.GetAllUsers(); 
                if (Users == null || !Users.Any()) 
                {
                    return NotFound("No se encontraron usuarios."); 
                }

                return Ok(Users);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los usuarios: " + ex.Message);
            }
        }

        [HttpGet("GetUserById")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserById(Guid Id) 
        {
            try
            {
                var User = await _UserRepository.GetUserById(Id); 
                if (User == null) 
                {
                    return NotFound("No se encontró el usuario."); 
                }

                return Ok(User);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el usuario: " + ex.Message);
            }
        }

        [HttpPost("CreateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateUser([FromBody] User User) 
        {
            try
            {
                var Result = await _UserRepository.CreateUser(User);
                if (!Result)
                {
                    return BadRequest("No se pudo crear el usuario.");
                }

                return Ok("Usuario creado correctamemnte");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el usuario: " + ex.Message);
            }
        }

        [HttpPut("UpdateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> UpdateUser(Guid Id, [FromBody] User UpdateUser)
        {
            try
            {
                var Result = await _UserRepository.UpdateUser(Id, UpdateUser);
                if (!Result)
                {
                    return BadRequest("No se pudo actualizar el usuario.");
                }
                return Ok("Usuario actualizado correctamemnte");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el usuario: " + ex.Message);
            }
        }

        [HttpDelete("DeleteUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> DeleteUser(Guid Id)  
        {
            try
            {
                var Result = await _UserRepository.DeleteUser(Id);
                if (!Result) 
                {
                    return BadRequest("No se pudo eliminar el usuario.");
                }

                return Ok("Usuario eliminado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar el usuario: " + ex.Message);
            }
        }
    }
}

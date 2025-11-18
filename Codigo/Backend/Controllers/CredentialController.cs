using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Implementations;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEvoEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CredentialController : ControllerBase
    {
        private readonly ICredentialRepository _credentialRepository;
        public CredentialController(ICredentialRepository credentialRepository)
        {
            _credentialRepository = credentialRepository;
        }
               
        [Authorize(Policy = "RequireAdmin")]
        [HttpGet("GetCredentialByUserId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult>GetCredentialByUserId(Guid IdUser)
        {
            try
            {
                var Credential = await _credentialRepository.GetCredentialByUserId(IdUser);
                if (Credential == null)
                {
                    return NotFound("No se encontró el Cliente");
                }
                return Ok(Credential);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el Id del Cliente: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpPut("UpdatePassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdatePassword([FromQuery]Guid CredentialId,  [FromQuery]string NewPassword)
        {
            try
            {
                var success = await _credentialRepository.UpdatePassword(CredentialId, NewPassword);
                if (!success)
                {
                    return NotFound("Credencial no encontrada");
                }
                return Ok("Contraseña actualizada correctamente");
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar contraseña: " + ex.Message);
            }
        }
        [Authorize(Policy = "RequireAdmin")]
        [HttpDelete("DeleteCredential")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteCredential(Guid Id)
        {
            try
            {
                var Result = await _credentialRepository.DeleteCredential(Id);
                if (!Result)
                {
                    return BadRequest("No se pudo eliminar la credencial.");
                }

                return Ok("Credencial eliminada correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar la credencial: " + ex.Message);
            }
        }
    }
}

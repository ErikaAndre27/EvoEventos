using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Implementations;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEvoEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CredentialController : ControllerBase
    {
        private readonly ICredentialRepository _credentialRepository;
        public CredentialController(ICredentialRepository credentialRepository)
        {
            _credentialRepository = credentialRepository;
        }

        [HttpGet("GetCredentialByIdentifierAndType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetCredentialByIdentifierAndType([FromQuery] string Identifier, [FromQuery] Guid Id)
        {
            try
            {
                var Credential = await _credentialRepository.GetCredentialByIdentifierAndType(Identifier, Id);

                if (Credential == null)
                {
                    return NotFound("Credencial no Encontrada");
                }
                return Ok(Credential);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener la búsqueda: " + ex.Message);
            }
        }

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

        [HttpPost("CreateCredential")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCredential([FromBody] Credential Credential)
        {
            try
            {
                
                if (await _credentialRepository.IdentifierExists(Credential.Identifier, Credential.IdLoggingType))
                {
                    return Conflict($"Ya existe una credencial con el identificador {Credential.Identifier}");
                }

              
                Credential.Id = Guid.NewGuid();

                // Crear la nueva credencial
                var createdCredential = await _credentialRepository.CreateCredential(Credential);

                return CreatedAtAction(
                    nameof(GetCredentialByUserId),
                    new { idUser = createdCredential.IdUser },
                    createdCredential
                );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,$"Error al crear la nueva credencial: {ex.Message}");
            }
        }

        [HttpPut("UpdateLastLogin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult>UpdateLastLogin(Guid CredentialId)
        {
            try
            {
                var success = await _credentialRepository.UpdateLastLogin(CredentialId);
                if (!success)
                {
                    return NotFound("Credencial no Encontrada");
                }
                return Ok("Último login actualizado correctamente");
            }   
            catch(Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error actualizando último login: " + ex.Message);
            }
        }

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

                return Ok("Tipo de documento eliminado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar la credencial: " + ex.Message);
            }
        }
    }
}

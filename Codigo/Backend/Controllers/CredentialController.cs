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

        
    }
}

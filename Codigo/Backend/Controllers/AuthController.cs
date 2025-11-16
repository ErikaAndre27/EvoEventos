using BackEvoEventos.Context;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Validations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackEvoEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ICredentialRepository _CredentialRepository;
        private readonly IConfiguration _Configuration;

        public AuthController(ICredentialRepository CredentialRepository, IConfiguration Configuration)
        {
            _CredentialRepository = CredentialRepository;
            _Configuration = Configuration;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(Login Login)
        {
            if (Login == null || string.IsNullOrEmpty(Login.Identifier) || string.IsNullOrEmpty(Login.Password))
            {
                return BadRequest("Requerimiento inválido");
            }

            var Credential = await _CredentialRepository.GetCredentialByIdentifier(Login.Identifier);
            if (Credential == null)
            {
                return Unauthorized();
            }

            if (Login.Password == Credential.Password)
            {
                var SecretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["Jwt:Key"]));
                var SigningCredentials = new SigningCredentials(SecretKey, SecurityAlgorithms.HmacSha256);

                var TokenOptions = new JwtSecurityToken(
                    issuer: _Configuration["Jwt:Issuer"],
                    audience: _Configuration["Jwt:Audience"],
                    claims: new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, Login.Identifier),
                        new Claim(ClaimTypes.Role, "Admin")
                    },
                    expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: SigningCredentials
                    ); 

                var TokenString = new JwtSecurityTokenHandler().WriteToken(TokenOptions);
                return Ok(new { Token = TokenString });
            }
            else
            {
                return Unauthorized();
            }


        }
    }

}

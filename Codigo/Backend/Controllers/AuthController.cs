using BackEvoEventos.Context;
using BackEvoEventos.Dtos;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Implementations;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IUserRepository _UserRepository;
        private readonly IRoleRepository _RolRepository;



        public AuthController(
            ICredentialRepository CredentialRepository,
            IConfiguration Configuration,
            IUserRepository UserRepository,
            IRoleRepository RolRepository)
        {
            _CredentialRepository = CredentialRepository;
            _Configuration = Configuration;
            _UserRepository = UserRepository;
            _RolRepository = RolRepository;
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
            bool IsValid = BCrypt.Net.BCrypt.Verify(Login.Password, Credential.Password);
            if (IsValid)
            {
                var User = await _UserRepository.GetUserById(Credential.IdUser);
                var Rol = await _RolRepository.GetRole(User.IdRole);

                await _CredentialRepository.UpdateLastLogin(Credential.Id);


                var SecretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["Jwt:Key"]));

                var SigningCredentials = new SigningCredentials(SecretKey, SecurityAlgorithms.HmacSha256);

                var TokenOptions = new JwtSecurityToken(
                    issuer: _Configuration["Jwt:Issuer"],
                    audience: _Configuration["Jwt:Audience"],
                    claims: new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, Login.Identifier),
                        new Claim(ClaimTypes.Role, Rol.Name)
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

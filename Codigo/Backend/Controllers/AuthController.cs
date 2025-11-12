using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BackEvoEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthController(IUserRepository UserRepository, IConfiguration Configuration ) // Solo se necesita User y Password
        {
            _userRepository = UserRepository;
            _configuration = Configuration;
        }

        public async Task<IActionResult> Login(Login Login)
        {

        }
    }
}

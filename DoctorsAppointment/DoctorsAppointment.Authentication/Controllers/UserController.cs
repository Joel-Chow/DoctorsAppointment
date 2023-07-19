using DoctorsAppointment.DoctorsAppointment.Authentication.Dtos;
using DoctorsAppointment.DoctorsAppointment.Authentication.Security;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsAppointment.DoctorsAppointment.Authentication.Controllers
{
    [Route("/authenticate")]
    public class UserController : ControllerBase
    {
        private readonly JwtCreator _jwtCreator;
        private readonly ILogger<UserController> _logger;
        public UserController(JwtCreator jwtCreator, ILogger<UserController> logger)
        {
            _jwtCreator = jwtCreator;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("GET Authentication called.");
            return Ok("Authentication Module");
        }

        [HttpPost("/login")]
        public Task<IActionResult> Post([FromBody] LoginRequest request)
        {
            if (request.UserName == "admin")
            {
                var token = _jwtCreator.GenerateJsonWebToken("admin");
                var loginResponse = new LoginResponse { token = token };
                return Task.FromResult<IActionResult>(Ok(loginResponse));
            }

            return Task.FromResult<IActionResult>(Unauthorized());
        }
    }
}

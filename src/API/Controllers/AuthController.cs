using System.Threading.Tasks;
using Business.IServices;
using Business.Models.Authenticate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequestModel loginRequest)
        {
            return Ok(await _authService.LoginAsync(loginRequest));
        }

        [Route("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] LoginRequestModel loginRequest)
        {
            await _authService.RegisterUserAsync(loginRequest);

            return Ok();
        }

        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] string refreshRequestModel)
        {
            return Ok(await _authService.RefreshTokenAsync(refreshRequestModel));
        }

        [Authorize(Policy = "Vova")]
        [Route("test")]
        public string TetsAsync()
        {
            return "test";
        }
    }
}
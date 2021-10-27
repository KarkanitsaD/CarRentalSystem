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
        public async Task<IActionResult> LoginAsync(LoginRequestModel request)
        {
            return Ok(await _authService.LoginAsync(request));
        }

        [Authorize(Policy = "Vova")]
        [Route("test")]
        public string TetsAsync()
        {
            return "test";
        }
    }
}
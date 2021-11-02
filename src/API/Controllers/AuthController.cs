using System.Threading.Tasks;
using Business.IServices;
using Business.Models.Authenticate;
using Business.Policies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Authorizes user.
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns>LoginResponseModel</returns>
        /// <response code="200">Returns LoginResponseModel</response>
        /// <response code="404">If user not found</response>   
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequestModel loginRequest)
        {
            return Ok(await _authService.LoginAsync(loginRequest));
        }

        /// <summary>
        /// Register user.
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns>LoginResponseModel</returns>
        /// <response code="200">Returns LoginResponseModel</response>
        /// <response code="404">If user not found</response>
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RegisterAsync([FromBody] LoginRequestModel loginRequest)
        {
            await _authService.RegisterUserAsync(loginRequest);

            return Ok();
        }

        [HttpGet]
        [Authorize(Policy = Policy.ForUserOnly)]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] string refreshRequestModel)
        {
            return Ok(await _authService.RefreshTokenAsync(refreshRequestModel));
        }

        [HttpGet]
        [Authorize(Policy = "Vova")]
        [Route("test")]
        public string TetsAsync()
        {
            return "test";
        }
    }
}
using System.Threading.Tasks;
using API.Models.Request.Auth;
using API.Models.Response.Auth;
using AutoMapper;
using Business.IServices;
using Business.Models;
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
        private readonly IMapper _mapper;
        
        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
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
            var loginModel = _mapper.Map<LoginRequestModel, LoginModel>(loginRequest);
            var loginSuccessModel = await _authService.LoginAsync(loginModel);
            return Ok(_mapper.Map<LoginSuccessModel, LoginResponseModel>(loginSuccessModel));
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
            var loginModel = _mapper.Map<LoginRequestModel, LoginModel>(loginRequest);
            await _authService.RegisterUserAsync(loginModel);

            return Ok();
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] string refreshRequestModel)
        {
            var successRefresh = await _authService.RefreshTokenAsync(refreshRequestModel);
            return Ok(_mapper.Map<RefreshTokenSuccessModel, RefreshTokenResponseModel>(successRefresh));
        }

        [HttpGet]
        [Authorize(Policy = Policy.ForUserOnly)]
        [Route("test")]
        public string TestAsync()
        {
            return "test";
        }
    }
}
using System.Threading.Tasks;
using API.Contracts;
using Business.IServices;
using Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequestModel requestModel)
        {
            return Ok(await _authenticationService.Authenticate(requestModel));
        }

        [HttpGet]
        [Route("word")]
        [Authorize(AuthenticationSchemes = SchemesNamesConst.TokenAuthenticationDefaultScheme, Roles = "User")]
        public string GetWord()
        {
            return "word";
        }
    }
}

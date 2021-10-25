using System.Threading.Tasks;
using Business.IServices;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public LoginController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequestModel requestModel)
        {
            return Ok(await _tokenService.GenerateToken(requestModel));
        }

        [HttpGet]
        [Route("word")]
        public string GetWord()
        {
            return "word";
        }
    }
}

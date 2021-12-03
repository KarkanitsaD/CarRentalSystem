using System;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController: ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] DateTime date)
        {
            return Ok(date);
        }
    }
}
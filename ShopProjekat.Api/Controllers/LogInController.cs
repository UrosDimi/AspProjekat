using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopProjekat.Api.Core;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopProjekat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {

        private readonly JwtManager _manager;

        public LogInController(JwtManager manager)
        {
            _manager = manager;
        }
        [HttpPost]
        public IActionResult Post([FromBody] TokenRequest request)
        {
            try
            {
                var token = _manager.MakeToken(request.Username, request.Password);

                return Ok(new { token });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
    }

    public class TokenRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

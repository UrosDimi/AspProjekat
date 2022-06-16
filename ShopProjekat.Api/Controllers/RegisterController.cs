using Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjekatAsp.Application.UseCases.Commands;
using ProjekatAsp.Application.UseCases.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopProjekat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : OwnController
    {
        public RegisterController(UseCaseHandler handler) : base(handler)
        {
        }


        // POST api/<RegisterController>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] RegisterDto dto,[FromServices] IRegisterUserCommand command)
        {
            _handler.HandleCommand(command, dto);

            return StatusCode(StatusCodes.Status201Created);
        }

    }
}

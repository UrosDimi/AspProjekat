using Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjekatAsp.Application.UseCases.Commands;
using ProjekatAsp.Application.UseCases.DTO;
using ShopProjekat.Api.Core.DTO;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopProjekat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthorizedController : ControllerBase
    {
        private UseCaseHandler _handler;

        public AuthorizedController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        [HttpPost]
        public IActionResult Post([FromBody] AuthorizedDto dto, [FromServices] IAddAuthorizedCommand command)
        {
            try
            {
                _handler.HandleCommand(command, dto);

                return StatusCode(201);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] UpdateUserUseCaseDto request,[FromServices] IUpdateUserUseCaseCommand command)
        {

                _handler.HandleCommand(command, request);

                return NoContent();

        }
    }
}

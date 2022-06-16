using Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjekatAsp.Application.UseCases.Commands;
using ProjekatAsp.Application.UseCases.DTO;
using ProjekatAsp.Application.UseCases.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopProjekat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentController : OwnController
    {
        public CommentController(UseCaseHandler handler) : base(handler)
        {
        }

        // GET: api/<CommentController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices]IGetCommentWithProductQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/<CommentController>
        [HttpPost]
        public IActionResult Post([FromBody] CommentDto dto,[FromServices] IAddCommentWithProductsCommand command)
        {
            _handler.HandleCommand(command, dto);

            return StatusCode(201);
        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

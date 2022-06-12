using Implementation;
using Microsoft.AspNetCore.Mvc;
using ProjekatAsp.Application.UseCases.DTO.Searches;
using ProjekatAsp.Application.UseCases.Queries;

namespace ShopProjekat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecificationController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public SpecificationController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        // GET: api/<SpecificationController>


        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search,[FromServices] IGetSpecificationsQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query, search));
        }

        // GET api/<SpecificationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SpecificationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SpecificationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SpecificationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

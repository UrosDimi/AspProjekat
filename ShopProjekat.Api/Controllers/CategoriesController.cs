using Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjekatAsp.Application.UseCases.Commands;
using ProjekatAsp.Application.UseCases.DTO;
using ProjekatAsp.Application.UseCases.DTO.Searches;
using ProjekatAsp.Application.UseCases.Queries;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopProjekat.Api.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private UseCaseHandler _handler;

        public CategoriesController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public IActionResult Get([FromQuery] BasePagedSearch search, [FromServices] IGetCategoriesQuery query)
        {
            return Ok(_handler.HandleQuery(query,search));
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateCategoryDto dto,[FromServices] ICreateCategoryCommand command)
        {

                _handler.HandleCommand(command, dto);

                return StatusCode(201);

        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

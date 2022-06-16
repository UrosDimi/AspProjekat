using Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjekatAsp.Application.UseCases.Commands;
using ProjekatAsp.Application.UseCases.DTO;
using ProjekatAsp.Application.UseCases.Queries;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopProjekat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : OwnController
    {
        public CartController(UseCaseHandler handler) : base(handler)
        {
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id,[FromServices] IGetCartWithProductsQuery query)
        {
            try
            {
                return Ok(_handler.HandleQuery(query, id));
            }
            catch(Exception ex)
            {
                return StatusCode(500, new {error= ex.Message});
            }
        }

        /// <summary>
        /// Creates new category.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Categories
        ///     {
        ///        "product_id": "3",
        ///        "cart_id": "2",
        ///        "user_id": "2",
        ///        ProductAmount:"1" ili vise
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Successfull creation.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPost]
        public IActionResult Post([FromBody] ProductCartDto dto,[FromServices]IAddProductToCartCommand command)
        {

            _handler.HandleCommand(command, dto);

            return StatusCode(201);

        }

    }
}

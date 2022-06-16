using Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjekatAsp.Application.UseCases.Commands;
using ProjekatAsp.Application.UseCases.DTO;
using ProjekatAsp.Application.UseCases.DTO.Searches;
using ProjekatAsp.Application.UseCases.Queries;
using ShopProjekat.Api.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopProjekat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : OwnController
    {
        public ProductController(UseCaseHandler handler) : base(handler)
        {
        }


        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult Get([FromQuery]BasePagedSearch dto,[FromServices] IGetProductsQuery query)
        {
            var obj=_handler.HandleQuery(query, dto);
            return Ok(obj);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromForm] ProductDtoWithImage dto,[FromServices] ICreateProductCommand command)
        {

            var extensions = dto.Images.Select(x => x.FileName);

            var newFileNames=extensions.Select(x => Guid.NewGuid()+x).ToList();

            var paths=new List<string>();

            newFileNames.ForEach(x =>
            {
                paths.Add(Path.Combine("wwwroot", "images", x));
            });

                paths.ForEach(x =>
                {
                    using var fileStream = new FileStream(x, FileMode.Create);
                    foreach (var image in dto.Images)
                    {
                        if (fileStream.Name.Contains(image.FileName))
                        {
                                image.CopyTo(fileStream);
                        }
                    }
                });

            dto.ImagesFileName = newFileNames;

            _handler.HandleCommand(command, dto);

            return StatusCode(201);
        
        }

        private IEnumerable<string> SupportedExtensions =>
            new List<string> { ".png", ".jpeg", ".jpg" };

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }


}

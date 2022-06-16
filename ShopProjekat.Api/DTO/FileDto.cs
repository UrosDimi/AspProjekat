using Microsoft.AspNetCore.Http;
using ProjekatAsp.Application.UseCases.DTO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ShopProjekat.Api.DTO
{
    public class ProductDtoWithImage : ProductDto
    {

        public IEnumerable<IFormFile>? Images { get; set; }

    }
}

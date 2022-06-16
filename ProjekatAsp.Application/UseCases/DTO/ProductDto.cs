using ProjekatAsp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAsp.Application.UseCases.DTO
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }
        public string Desc { get; set; }

        public decimal Price { get; set; }
        public IEnumerable<string> ImagesFileName { get; set; } = new List<string>();
    }


    public class ProductWithCategories : ProductDto
    {
        public IEnumerable<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
    }
}

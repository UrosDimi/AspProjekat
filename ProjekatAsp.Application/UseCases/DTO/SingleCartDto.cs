using ProjekatAsp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAsp.Application.UseCases.DTO
{
    public class SingleCartDto : BaseDto
    {
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<ProductDto> Products { get; set; } = new List<ProductDto>();
        public IApplicationUser User { get; set; }

    }
}

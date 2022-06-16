using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAsp.Application.UseCases.DTO
{
    public class ProductCartDto : BaseDto
    {
        public int product_id { get; set; }
        public int cart_id { get; set; }

        public int user_id { get; set; }
        //public string ProductName { get; set; }
        //public decimal ProductPrice { get; set; }
        public int ProductAmount { get; set; }

    }
}

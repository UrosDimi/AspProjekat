using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAsp.Domain
{
    public class ProductsCart : Entity
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductAmount { get; set; }
        public int Product_id { get; set; }
        public int Cart_id { get; set; }
        public Product Product { get; set; }
        public Cart Cart { get; set; }



    }
}

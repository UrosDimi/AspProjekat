using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAsp.Domain
{
    public class Product : Entity
    {

        public string Name { get; set; }
        public string Desc { get; set; }


        public ICollection<Category> Categories { get; set; } = new List<Category>();
        public ICollection<Image> Images { get; set; } = new List<Image>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<ProductSpecification> ProductSpecifications { get; set; } = new List<ProductSpecification>();
        public ICollection<ProductsCart> ProductsCarts { get; set; } = new List<ProductsCart>();
        public ICollection<Price> ProductsPrice { get; set; } = new List<Price>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAsp.Domain
{
    public class Category : Entity
    {

        public string Name { get; set; }
        public string Desc { get; set; }
        public int? image_id { get; set; }
        public int? parent_id { get; set; }

        public Image Image { get; set; }
        public Category Parent_category { get; set; }
        public ICollection<Category> Child_categories { get; set; } = new List<Category>();
        public ICollection<Specification> Specifications { get; set; } = new List<Specification>();
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}

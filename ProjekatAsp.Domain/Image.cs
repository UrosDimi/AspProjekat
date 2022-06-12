using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAsp.Domain
{
    public class Image : Entity
    {
        public string Path { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAsp.Domain
{
    public class AvailableData : Entity
    {

        public string Name { get; set; }
        public int Specification_id { get; set; }
        public Specification Specification { get; set; }

        public ICollection<ProductSpecification> ProductSpecification { get; set; } = new List<ProductSpecification>();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAsp.Domain
{
    public class Specification : Entity
    {

        public string Name { get; set; }

        public ICollection<Category> Categories { get; set; } = new List<Category>();
        public ICollection<AvailableData> AvailableDatas { get; set; } = new List<AvailableData>();
        public ICollection<ProductSpecification> ProductSpecifications { get; set; } = new List<ProductSpecification>();

    }
}

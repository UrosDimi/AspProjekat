using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAsp.Domain
{
    public class ProductSpecification : Entity
    {
        public string value { get; set; }
        public int Specification_id { get; set; }
        public int AvailableData_id { get; set; }
        public int Product_id { get; set; }
        public Product Product { get; set; }
        public Specification Specification { get; set; } //1 ram
        public AvailableData AvailableData { get; set; } //(3,4,5,6,7,8,9,10) ram (5,6,7)
    }
}

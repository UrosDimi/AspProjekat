using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAsp.Domain
{
    public class Price : Entity
    {

        public decimal price { get; set; }
        public int Product_id{ get; set; }
        public Product Product{ get; set; }

        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

    }
}

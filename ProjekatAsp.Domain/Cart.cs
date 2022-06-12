using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAsp.Domain
{
    public class Cart : Entity
    {


        public decimal TotalPrice { get; set; }

        public int User_id { get; set; }

        public User User { get; set; }

        public ICollection<ProductsCart> ProductsCarts { get; set; }=new List<ProductsCart>();

        public DateTime DateAndTime { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAsp.Domain
{
    public class User : Entity
    {

        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsSuperUser { get; set; }
        public string Email { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Cart> Carts { get; set; } = new List<Cart>();
        public ICollection<UserUseCase> UserUseCases { get; set; } = new List<UserUseCase>();
    }
}

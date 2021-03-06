using ProjekatAsp.Domain;
using System.Collections.Generic;

namespace ShopProjekat.Api.Core
{
    public class JwtUser : IApplicationUser
    {
        public string Identity { get; set; }
        public int Id { get; set; }
        public IEnumerable<int> UseCaseIds { get; set; } = new List<int>();
        public string Email { get; set; }
    }


    public class AnonimousUser : IApplicationUser
    {
        public string Identity => "Anonymous";
        public int Id => 0;
        public IEnumerable<int> UseCaseIds => new List<int> { 1,2,3,4,5,6,7,8,10,11,12, 13 };
        public string Email => "anonimous@asp-api.com";
    }
}

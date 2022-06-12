using Microsoft.EntityFrameworkCore;
using ProjekatAsp.DataAccess;

namespace ShopProjekat.Api.Core
{
    public class JwtManager
    {
        private readonly ShopDbContext _context;
        private readonly JwtSettings _settings;


        public JwtManager(ShopDbContext context, JwtSettings settings)
        {
            _settings = settings;
            _context = context;
        }


        public string MakeToken(string email, string password)
        {
            //var user = _context.Users.Include(x => x.UserCase)

            return "";
        }
    }
}

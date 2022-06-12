using ProjekatAsp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases
{
    public abstract class EfUseCase
    {
        protected EfUseCase(ShopDbContext context)
        {
            Context = context;
        }

        protected ShopDbContext Context { get; }
    }
}

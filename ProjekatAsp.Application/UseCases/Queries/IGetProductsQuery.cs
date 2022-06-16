using ProjekatAsp.Application.UseCases.DTO;
using ProjekatAsp.Application.UseCases.DTO.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAsp.Application.UseCases.Queries
{
    public interface IGetProductsQuery : IQuery<BasePagedSearch, PagedResponse<ProductWithCategories>>
    {
    }
}

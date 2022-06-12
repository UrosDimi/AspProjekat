using ProjekatAsp.Application.UseCases.DTO;
using ProjekatAsp.Application.UseCases.DTO.Searches;
using ProjekatAsp.Application.UseCases.Queries;
using ProjekatAsp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Ef
{
    public class EfGetCategoriesQuery: EfUseCase ,IGetCategoriesQuery
    {
        public int Id => 1;

        public string Name => "Search Categories";

        public string Description => "Search Categories using Entitiy Framework";

        public EfGetCategoriesQuery(ShopDbContext context) 
            : base(context)
        {

        }

        public PagedResponse<CategoryDto> Execute(BasePagedSearch search)
        {
            var query = Context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.Contains(search.Keyword));
            }

            if (search.PerPage == null || search.PerPage < 1)
            {
                search.PerPage = 15;
            }

            if (search.Page == null || search.Page < 1)
            {
                search.PerPage = 1;
            }

            var toSkip = (search.Page.Value - 1) * search.PerPage.Value;


            var response = new PagedResponse<CategoryDto>();
            response.TotalCount = query.Count();
            response.Data = query.Skip(toSkip).Take(search.PerPage.Value).Select(x => new CategoryDto
            {
                Name = x.Name,
                Id = x.Id
            }).ToList();
            response.CurrentPage = search.Page.Value;
            response.ItemsPerPage = search.PerPage.Value;
            //return query.Select(

            return response;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using ProjekatAsp.Application.UseCases.DTO;
using ProjekatAsp.Application.UseCases.DTO.Searches;
using ProjekatAsp.Application.UseCases.Queries;
using ProjekatAsp.DataAccess;
using ProjekatAsp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Ef
{
    public class EfGetProdcutsQuery :EfUseCase, IGetProductsQuery
    {
        public EfGetProdcutsQuery(ShopDbContext context) : base(context)
        {
        }

        public int Id => 10;

        public string Name => "Get Products";

        public string Description => "Search all products and filters with pagination and more";

        public PagedResponse<ProductWithCategories> Execute(BasePagedSearch search)
        {
            var allProducts = Context.Products.Include(x=>x.Categories).AsQueryable();

            var response = new PagedResponse<ProductWithCategories>();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                allProducts = allProducts.Where(x => x.Name.Contains(search.Keyword));
            }


            if (search.PerPage == null || search.PerPage < 1)
            {
                search.PerPage = 10;
            }

            if (search.Page == null || search.Page < 1)
            {
                search.PerPage = 1;
            }

            var toSkip = (search.Page.Value - 1) * search.PerPage.Value;

            response.Data = allProducts.Skip(toSkip).Take(search.PerPage.Value).Select(x => new ProductWithCategories
            {
                Id = x.Id,
                Name = x.Name,
                Desc = x.Desc,
                ImagesFileName = x.Images.Select(x => x.Path).ToArray(),
                Categories = x.Categories.Select(y => new CategoryDto
                {
                    Name = y.Name,
                    Id=y.Id
                }),
            }).ToList();

            response.TotalCount = allProducts.Count();
            response.CurrentPage = search.Page.Value;
            response.ItemsPerPage = search.PerPage.Value;


            return response;
        }
    }
}

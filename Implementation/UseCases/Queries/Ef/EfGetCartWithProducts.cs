using Microsoft.EntityFrameworkCore;
using ProjekatAsp.Application.UseCases.DTO;
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
    public class EfGetCartWithProducts : EfUseCase, IGetCartWithProductsQuery
    {
        private IApplicationUser _user;
        public EfGetCartWithProducts(ShopDbContext context, IApplicationUser user) : base(context)
        {
            _user= user;
        }

        public int Id => 12;

        public string Name => "Get Cart with all Products";

        public string Description => "Get Cart with all Products using Entityframework";

        public SingleCartDto Execute(int search)
        {
            if(search <= 0)
            {
                throw new Exception("Cart with forwarded Id is cannot have a value less than 0");
            }

            var cart = Context.Carts.Where(x => x.Id == search)
                                    .Include(x => x.ProductsCarts)
                                    .ThenInclude(x => x.Product)
                                    .ThenInclude(x => x.ProductsPrice)
                                    .FirstOrDefault();

            if(cart == null)
            {
                throw new Exception("Cart with forwarded Id is not found!");
            }

            var singleCart = new SingleCartDto
            {
                Id = cart.Id,
                Date= DateTime.Now,
                Products = cart.ProductsCarts.Select(x=>new ProductDto
                {
                    Id=x.Product.Id,
                    Desc=x.Product.Desc,
                    ImagesFileName=x.Product.Images.Select(x=>x.Path),
                    Name=x.Product.Name,
                    Price=x.Product
                            .ProductsPrice
                            .Where(x=>x.DateTo==null)
                            .FirstOrDefault()
                            .price
                }),
                TotalPrice=cart.TotalPrice,
                User= _user
            };


            return singleCart;

        }
    }
}

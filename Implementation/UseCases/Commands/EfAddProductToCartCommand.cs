using Microsoft.EntityFrameworkCore;
using ProjekatAsp.Application.UseCases.Commands;
using ProjekatAsp.Application.UseCases.DTO;
using ProjekatAsp.DataAccess;
using ProjekatAsp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands
{
    public class EfAddProductToCartCommand :EfUseCase , IAddProductToCartCommand
    {
        public EfAddProductToCartCommand(ShopDbContext context) : base(context)
        {
        }

        public int Id => 11;

        public string Name => "App products to cart";

        public string Description => "";

        public void Execute(ProductCartDto request)
        {

            var all = Context.Products
                            .Include(x=>x.ProductsCarts)
                            .ThenInclude(x => x.Cart)
                            .Include(x=>x.ProductsPrice)
                            .ToList();

            var getProducts=all.Find(x=>x.Id == request.product_id);



            if (getProducts == null)
            {
                throw new Exception("Products with this Id is not found!");
            }

            if (all.Any(x => x.ProductsCarts.Any(x => x.Cart.User_id == request.user_id)))
            {
              
                var productA = Context.ProductsCarts
                    .Where(x => (x.Product_id == request.product_id)
                                                                && (x.Cart_id == request.cart_id))
                    .FirstOrDefault();

                if (productA != null)
                {
                    productA.ProductAmount += request.ProductAmount;
                }
                else
                {
                    var cart = Context.Carts.Where(x => x.User_id == request.user_id).FirstOrDefault();


                    var neww = CreateProductCart(request, getProducts, cart);

                    cart.TotalPrice = cart.ProductsCarts.Sum(x => x.ProductPrice * x.ProductAmount);
                }

            }
            else
            {
                var cart = new Cart
                {
                    User_id = request.user_id,
                };

                var neww = CreateProductCart(request, getProducts, cart);


                cart.TotalPrice = neww.ProductPrice;

            }

            Context.SaveChanges();

        }

        public ProductsCart CreateProductCart(ProductCartDto request,Product getProducts,Cart cart)
        {
            var neww = new ProductsCart
            {
                Product_id = request.product_id,
                ProductName = getProducts.Name,
                Cart = cart,
                ProductPrice = getProducts
                                        .ProductsPrice
                                        .Where(x => x.DateTo == null)
                                        .FirstOrDefault()
                                        .price,
                ProductAmount = request.ProductAmount
            };

            Context.ProductsCarts.Add(neww);

            return neww;
        }

    }
}

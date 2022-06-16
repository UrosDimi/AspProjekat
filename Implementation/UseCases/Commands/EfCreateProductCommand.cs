using FluentValidation;
using Implementation.Validators;
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
    public class EfCreateProductCommand:EfUseCase,ICreateProductCommand
    {
        private CreateProductValidator _validator;
        public EfCreateProductCommand(ShopDbContext context, CreateProductValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 5;

        public string Name => "Create new Product";

        public string Description => "Create new Product";

        public void Execute(ProductDto request)
        {
            _validator.ValidateAndThrow(request);


            var price = new Price
            {
                price = request.Price,
                DateFrom = DateTime.UtcNow
            };

            var product = new Product
            {
                Name = request.Name,
                Desc = request.Desc
            };

            product.ProductsPrice.Add(price);



            if (request.ImagesFileName.Any())
            {
                var images=request.ImagesFileName.Select(x=> new Image
                {
                    Path=x
                });

                product.Images = images.ToList();
            }


            Context.Products.Add(product);

            Context.SaveChanges();
        }
    }
}

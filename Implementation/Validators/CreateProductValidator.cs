using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatAsp.Application.UseCases.DTO;
using ProjekatAsp.DataAccess;

namespace Implementation.Validators
{
    public class CreateProductValidator : AbstractValidator<ProductDto>
    {
        private ShopDbContext _context;
        public CreateProductValidator(ShopDbContext context)
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name is required property.")
                .MinimumLength(3).WithMessage("Minimal number of charcter is 3.")
                .Must(ProductNotInUse).WithMessage("Name {PropertyValue} is already used.");
            _context = context;

            RuleFor(x => x.Desc)
                .NotEmpty().WithMessage("Description is required property.")
                .MinimumLength(15);

        }
        private bool ProductNotInUse(string name)
        {
            var exists = _context.Products.Any(x => x.Name == name);

            return !exists;
        }
    }

}

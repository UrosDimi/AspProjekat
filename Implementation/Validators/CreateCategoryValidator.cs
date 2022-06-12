using FluentValidation;
using ProjekatAsp.Application.UseCases.DTO;
using ProjekatAsp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
    {
        private ShopDbContext _context;


        public CreateCategoryValidator(ShopDbContext context)
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Naziv je obavezan podatak.")
                .MinimumLength(3).WithMessage("Minimalan broj karaktera je 3.")
                .Must(CategoryNotInUse).WithMessage("Naziv {PropertyValue} je već u upotrebi.");
            _context = context;
  
            RuleFor(x => x.ParentCategoryId)
                .Must(x => context.Categories.Any(c => c.Id == x && c.IsActive))
                .When(dto => dto.ParentCategoryId.HasValue).WithMessage("Prosleđena roditeljska kategorija ne postoji u sistemu.");

        }

        private bool CategoryNotInUse(string name)
        {
            var exists = _context.Categories.Any(x => x.Name == name);

            return !exists;
        }
    }
}

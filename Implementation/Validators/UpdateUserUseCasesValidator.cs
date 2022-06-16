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
    public class UpdateUserUseCasesValidator : AbstractValidator<UpdateUserUseCaseDto>
    {
        public UpdateUserUseCasesValidator(ShopDbContext context)
        {

            RuleFor(x => x.UserId)
                .Must(x => context.Users.Any(r => r.Id == x && r.IsActive))
                .WithMessage("User with provided ID doenst exists.");

            RuleFor(x => x.UseCaseIds).NotEmpty()
               .WithMessage("Use cases are required.")
               .Must(x => x.Distinct()
               .Count() == x.Count())
               .WithMessage("Duplicates are not allowed.");

        }
    }
}

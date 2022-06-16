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
    public class EfUpdateUserUseCasesCommand : EfUseCase, IUpdateUserUseCaseCommand
    {

        private readonly UpdateUserUseCasesValidator _validator;
        public EfUpdateUserUseCasesCommand(ShopDbContext context, UpdateUserUseCasesValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 10;

        public string Name => "Update user user-cases.";

        public string Description => throw new NotImplementedException();

        public void Execute(UpdateUserUseCaseDto request)
        {
            _validator.ValidateAndThrow(request);

            var useCases = Context.UserUseCase.Where(x => x.UserId == request.UserId);

            Context.RemoveRange(useCases);

            var newUseCases=request.UseCaseIds.Select(x=> new UserUseCase
            {
                UserCaseId=x,
                UserId=request.UserId
            });

            Context.UserUseCase.AddRange(newUseCases);
            Context.SaveChanges();
        }
    }
}

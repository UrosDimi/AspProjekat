using Microsoft.EntityFrameworkCore;
using ProjekatAsp.Application.UseCases.Commands;
using ProjekatAsp.Application.UseCases.DTO;
using ProjekatAsp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatAsp.Domain;
namespace Implementation.UseCases.Commands
{
    public class EfAddAuthorizedCommand :EfUseCase, IAddAuthorizedCommand
    {
        public EfAddAuthorizedCommand(ShopDbContext context) : base(context)
        {
        }

        public int Id => 4;

        public string Name => "Add new role for UseCase";

        public string Description => "Authorized an new UseCase";

        public void Execute(AuthorizedDto request)
        {

            if(request.UserCaseId <1 || request.UserId < 1)
            {
                throw new Exception("UserId or UserCaseId must be greater than 1");
            }

            var dbContext = Context.Users.Include(x=>x.UserUseCases).ToList();

            var user = dbContext.Where(x => x.Id == request.UserId).FirstOrDefault();

            if (user != null)
            {
                var isAlreadyAdd = user.UserUseCases.Where(x => x.UserCaseId == request.UserCaseId).FirstOrDefault();

                if (isAlreadyAdd != null)
                {
                    throw new Exception("Role authorized already exists");
                }

                Context.UserUseCase.Add(new UserUseCase
                {
                    UserCaseId = request.UserCaseId,
                    UserId = request.UserId
                });

                Context.SaveChanges();
            }
            else
            {
                throw new Exception("User does not exists");
            }

        }
    }
}

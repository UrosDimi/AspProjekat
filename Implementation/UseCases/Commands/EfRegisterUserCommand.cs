using ProjekatAsp.Application.UseCases.Commands;
using ProjekatAsp.Application.UseCases.DTO;
using ProjekatAsp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatAsp.Domain;
using ProjekatAsp.Application.Emails;
using Implementation.Validators;
using FluentValidation;
using ProjekatAsp.Application.Emails.Dto;

namespace Implementation.UseCases.Commands
{
    public class EfRegisterUserCommand : EfUseCase, IRegisterUserCommand
    {
        private readonly RegisterUserValidator _validator;
        private readonly IEmailSender _sender;

        public EfRegisterUserCommand(ShopDbContext context, RegisterUserValidator validator, IEmailSender sender) : base(context)
        {
            _validator = validator;
            _sender = sender;
        }

        public int Id => 6;

        public string Name => "Add new User in system (Using EF)";

        public string Description => "";

        public void Execute(RegisterDto request)
        {

            _validator.ValidateAndThrow(request);

            //var hash = BCrypt.Net.BCrypt.HashPassword(request.Password);

                Context.Users.Add(new User
                {
                    UserName = request.Username,
                    Email = request.Email,
                    Password = request.Password,
                    Name = request.FirstName,
                    LastName = request.LastName,
                    IsSuperUser = request.IsSuperUser,
                });

                Context.SaveChanges();


            _sender.Send(new MessageDto
            {
                To = request.Email,
                Title = "Successfull registration",
                Body = $"Dear {request.Username} \n Please activate your account.."
            });
        }
    }
}

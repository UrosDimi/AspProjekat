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
    public class EfCreateCategoryCommand : EfUseCase, ICreateCategoryCommand
    {

        private CreateCategoryValidator _validator;

        public EfCreateCategoryCommand(ShopDbContext context, CreateCategoryValidator validator) : base(context)
        {

            _validator= validator;
        }

        public int Id => 3;

        public string Name => "Create Category (EF)";

        public string Description => "Create category using entity framework.";

        public void Execute(CreateCategoryDto request)
        {
            _validator.ValidateAndThrow(request);

            var category = new Category
            {
                Name = request.Name,
                parent_id = request.ParentCategoryId,
                Desc=request.Desc
            };

            Context.Categories.Add(category);

            Context.SaveChanges();
        }
    }
}

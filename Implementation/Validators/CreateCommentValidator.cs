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
    public class CreateCommentValidator : AbstractValidator<CommentDto>
    {

        private ShopDbContext _context;


        public CreateCommentValidator(ShopDbContext context)
        {
            RuleFor(x => x.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Title is required data.")
                .MinimumLength(10).WithMessage("The minimum number of characters is 10.");

            RuleFor(x => x.Comments)
                .NotEmpty().WithMessage("Comment is required data.")
                .MinimumLength(20);


            RuleFor(x => x.product_id).Must(ProductNotExist).WithMessage("Name {PropertyValue} is not found."); ;

            _context = context;
        }

        private bool ProductNotExist(int id)
        {
            var exists = _context.Products.Any(x => x.Id== id);

            return exists;
        }
    }
}

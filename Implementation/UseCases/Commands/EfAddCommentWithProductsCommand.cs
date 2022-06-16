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
    public class EfAddCommentWithProductsCommand :EfUseCase, IAddCommentWithProductsCommand
    {

        private CreateCommentValidator _validate;
        public EfAddCommentWithProductsCommand(ShopDbContext context, CreateCommentValidator validate) : base(context)
        {
            _validate=validate;
        }

        public int Id => 13;

        public string Name => "Add Comment";

        public string Description => "add a comment to the product with entityframework";

        public void Execute(CommentDto request)
        {
            _validate.ValidateAndThrow(request);


            var comments = Context.Comments.ToList();
            var user = Context.Users.Find(request.user_id);
            var product = Context.Products.Find(request.product_id);
            var comment = new Comment();
            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (request.parent_comment_id != null)
            {
                if (!comments.Any(x => x.Id == request.parent_comment_id))
                {
                    throw new Exception("Comment not found");
                }
                else
                {
                    comment = new Comment
                    {
                        Comments = request.Comments,
                        Title = request.Title,
                        User = user,
                        Product = product,
                        Parent_comment= comments.Find(x=>x.Id==request.parent_comment_id),
                    };
                }
            }
            else
            {
                comment = new Comment
                {
                    Comments = request.Comments,
                    Title = request.Title,
                    User = user,
                    Product = product
                };
            }

            Context.Comments.Add(comment);
            Context.SaveChanges();

        }
    }
}

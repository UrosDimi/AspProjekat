using Microsoft.EntityFrameworkCore;
using ProjekatAsp.Application.UseCases;
using ProjekatAsp.Application.UseCases.DTO;
using ProjekatAsp.Application.UseCases.Queries;
using ProjekatAsp.DataAccess;
using ProjekatAsp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Ef
{
    public class EfIGetCommentWithProductQuery :EfUseCase, IGetCommentWithProductQuery
    {
        public EfIGetCommentWithProductQuery(ShopDbContext context) : base(context)
        {
        }

        public int Id => 14;

        public string Name => "Get Comments for this product";

        public string Description => "Get Comments for this product using Entityframework";

        public ProductWithComments Execute(int search)
        {
            var commentsProduct=Context.Products
                                        .Where(x=>x.Id==search)
                                        .Include(x=>x.Comments.Where(x=>x.Parent_comment==null))
                                        .ThenInclude(x=>x.Child_comments)
                                        .FirstOrDefault();

            if (commentsProduct == null)
            {
                throw new Exception("Product not found");
            }

            commentsProduct.Comments = commentsProduct.Comments.Where(x => x.Parent_comment == null).ToList();

            var productWithCommnets = new CommentStyle
            {
                Id = commentsProduct.Id,
                Desc = commentsProduct.Desc,
                Name = commentsProduct.Name,
                Comment=commentsProduct.Comments.Select(x=> new ProductWithComments
                {
                    Id = x.Id,
                    Name = x.Title,
                    Desc =x.Comments
                })
            };


            //ovde ima problem

            return productWithCommnets;
        }
    }
}

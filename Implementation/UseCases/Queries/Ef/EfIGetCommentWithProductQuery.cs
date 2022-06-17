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

        public ProductComm Execute(int search)
        {
            var commentsProduct=Context.Products
                                        .Where(x=>x.Id==search)
                                        .Include(x=>x.Comments)
                                        .ThenInclude(x=>x.Child_comments)
                                        .Include(x=>x.ProductsPrice)
                                        .FirstOrDefault();

            if (commentsProduct == null)
            {
                throw new Exception("Product not found");
            }

            commentsProduct.Comments = commentsProduct.Comments.Where(x => x.Parent_comment == null).ToList();

            //var productWithCommnets = new ProductComm
            //{
            //    Id = commentsProduct.Id,
            //    Description = commentsProduct.Desc,
            //    name = commentsProduct.Name,
            //    Comment = commentsProduct.Comments.Select(x => new ProductWithComments
            //    {
            //        Id = x.Id,
            //        Name = x.Title,
            //        Desc = x.Comments,
            //        Comment = x.Child_comments.Select(y => new ProductWithComments
            //        {
            //            Id=y.Id,
            //            Desc=y.Comments,
            //            Name=y.Title,

            //        })
            //    })
            //};



            var productWithCommnets = new ProductComm
            {
                Id = commentsProduct.Id,
                Description = commentsProduct.Desc,
                name = commentsProduct.Name,
                Comment = commentsProduct.Comments.Select(x => new ProductWithComments
                {
                    Id = x.Id,
                    Name = x.Title,
                    Desc = x.Comments,
                    Comment = getComments(x.Child_comments)
                })
            };


            return productWithCommnets;
        }

        public IEnumerable<ProductWithComments> getComments(IEnumerable<Comment> comments)
        {

            List<Comment> commentsList = comments.ToList();
            List<ProductWithComments> commentss= new List<ProductWithComments>();
            if (comments.Any())
            {

                foreach (var comment in commentsList)
                {
                    var com= new ProductWithComments
                    {
                        Id = comment.Id,
                        Desc = comment.Comments,
                        Name = comment.Title
                    };


                    if (comment.Child_comments.Any())
                    {
                        com.Comment = getComments(comment.Child_comments);
                    }
                    commentss.Add(com);
                }

            }
                return commentss;
        }
    }
}

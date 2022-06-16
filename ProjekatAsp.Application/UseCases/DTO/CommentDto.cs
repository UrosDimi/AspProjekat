using ProjekatAsp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAsp.Application.UseCases.DTO
{
    public class CommentDto : BaseDto
    {
        public string Title { get; set; }
        public string Comments { get; set; }
        public int? parent_comment_id { get; set; }
        public int product_id { get; set; }
        public int user_id { get; set; }
    }


    public class CommentDtoProducs : BaseDto
    {
        public string Title { get; set; }
        public string Comment { get; set; }

        public IEnumerable<CommentStyle> child_comments { get; set; } = new List<CommentStyle>();
    }

    public class ProductWithComments : BaseDto
    {
        public string Name { get; set; }
        public string Desc { get; set; }

    }
    public class CommentStyle : ProductWithComments
    {
        public IEnumerable<ProductWithComments> Comment { get; set; } = new List<ProductWithComments>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAsp.Application.UseCases.DTO
{
    public class CategoryDto : BaseDto
    {
        public string Name { get; set; }
    }


    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public string Desc { get; set; }
    }
}

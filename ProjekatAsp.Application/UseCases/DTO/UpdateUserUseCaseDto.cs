using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAsp.Application.UseCases.DTO
{
    public class UpdateUserUseCaseDto
    {
        public int UserId { get; set; }
        public IEnumerable<int> UseCaseIds { get; set; } = new List<int>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAsp.Domain
{
    public class UserUseCase
    {

        public int UserId { get; set; }
        public int UserCaseId { get; set; }
        public User User { get; set; }

    }
}

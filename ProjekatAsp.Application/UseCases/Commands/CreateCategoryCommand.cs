using ProjekatAsp.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAsp.Application.UseCases.Commands
{

    //U Icommand msm CategoryDto ocekujemo da klijent posalje
    public interface ICreateCategoryCommand : ICommand<CreateCategoryDto>
    {



    }
}

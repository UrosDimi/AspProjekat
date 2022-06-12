using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAsp.Application.UseCases
{
    //sve sto se izvodi iz IUseCase ce imati ove podatke
    //Ovde stavljamo sta svaki slucaj koriscenja treba da podrazumeva
    public interface IUseCase
    {
        public int Id { get; }
        string Name { get; }
        string Description { get; }

    }
}

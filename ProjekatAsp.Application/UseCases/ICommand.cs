using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAsp.Application.UseCases
{
    //Komande menjaju sistem ali nista ne vracaju
    //TRequest zato sto je to ulaz u sami sistem, zahtev ka promeni sistema,  pa iz tog razloga takvo i ime
    public interface ICommand<TRequest> : IUseCase
    {

        void Execute(TRequest request);

    }
}

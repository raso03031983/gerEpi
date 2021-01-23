using Back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Services.Interface
{
    public interface IClassificacaoServices
    {
        Task<List<Classificacao>> GetAll(Classificacao model);
        Task<string> Post(Classificacao model);
        Task<string> Put(Classificacao model);
        Task<string> Delete(int id);
    }
}

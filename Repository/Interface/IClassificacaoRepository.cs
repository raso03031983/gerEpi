using Back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Repository.Interface
{
    public interface IClassificacaoRepository
    {
        Task<List<Classificacao>> GetAll(Classificacao model);
        Task<string> Post(Classificacao model);
        Task<string> Put(Classificacao model);
        Task<string> Delete(int id);
    }
}

using Back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Repository.Interface
{
    public interface IIntegranteRepository
    {
        Task<List<Integrante>> GetAll(Integrante model);
        Task<string> Post(Integrante model);
        Task<string> Put(Integrante model);
        Task<string> Delete(Integrante model);
        Task<string> PostSenha(string newSenha, string senhaAtual, int idUser);
    }
}

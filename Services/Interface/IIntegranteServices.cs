using Back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Services.Interface
{
    public interface IIntegranteServices

    {
        Task<List<Integrante>> GetAll(Integrante model);
        Task<string> Post(Integrante model);
        Task<string> Put(Integrante model);
        Task<string> Delete(Integrante model);
        Task<string> PostSenha(string newSenha, string senhaAtual, int idUser);
    }
}

using Back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Services.Interface
{
    public interface IEntrega_MobileServices
    {
        Task<List<Entrega_Mobile>> GetAll(int id_cliente);
        Task<string> Post(Entrega_Mobile model);
        Task<string> Put(Entrega_Mobile model);
        Task<string> Delete(Entrega_Mobile model);
    }
}

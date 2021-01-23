using Back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Repository.Interface
{
    public interface IEntrega_MobileRepository
    {
        Task<List<Entrega_Mobile>> GetAll(int id_cliente);
        Task<string> Post(Entrega_Mobile model);
        Task<string> Put(Entrega_Mobile model);
        Task<string> Delete(Entrega_Mobile model);
    }
}

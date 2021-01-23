using Back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Repository.Interface
{
    public interface IEntradaRepository
    {
        Task<List<Entrada>> GetAll(string desc, int idItem, int id_cliente);
        Task<string> Post(Entrada model);
        Task<string> Put(Entrada model);
        Task<string> Delete(Entrada model);
    }
}

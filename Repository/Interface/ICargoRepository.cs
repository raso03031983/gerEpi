using Back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Repository.Interface
{
    public interface ICargoRepository
    {
        Task<List<Cargo>> GetAll(string Codigo_Cargo, string Descricao_Cargo, int id_cliente);
        Task<string> Post(Cargo cargo);
        Task<string> Put(Cargo cargo);
        Task<string> Delete(Cargo cargo);
    }
}

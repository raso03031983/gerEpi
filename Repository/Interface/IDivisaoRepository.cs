using Back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Repository.Interface
{
    public interface IDivisaoRepository
    {
        Task<List<Divisao>> GetAll(int id, string desc, int id_cliente);
        Task<string> Post(Divisao model);
        Task<string> Put(Divisao model);
        Task<string> Delete(int id);
    }
}

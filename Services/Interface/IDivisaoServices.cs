using Back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Services.Interface
{
    public interface IDivisaoServices
    {
        Task<List<Divisao>> GetAll(int id, string desc, int id_cliente);
        Task<string> Post(Divisao model);
        Task<string> Put(Divisao model);
        Task<string> Delete(int id);
    }
}

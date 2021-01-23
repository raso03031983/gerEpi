using Back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Repository.Interface
{
    public interface IFamiliaRepository
    {
        Task<List<Familia>> GetAll(string desc, int id_cliente);
        Task<string> Post(Familia model);
        Task<string> Put(Familia model);
        Task<string> Delete(int id);
    }
}

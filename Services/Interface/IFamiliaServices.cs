using Back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Services.Interface
{
    public interface IFamiliaServices
    {
        Task<List<Familia>> GetAll(string desc, int id_cliente);
        Task<string> Post(Familia model);
        Task<string> Put(Familia model);
        Task<string> Delete(int id);
    }
}

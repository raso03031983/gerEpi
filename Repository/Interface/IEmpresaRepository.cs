using Back.Models;
using System.Threading.Tasks;

namespace Back.Repository.Interface
{
    public interface IEmpresaRepository
    {
        Task<Empresa> GetAll(int id_cliente);
        Task<string> Post(Empresa model);
        Task<string> Put(Empresa model);
        Task<string> Delete(Empresa model);
    }
}

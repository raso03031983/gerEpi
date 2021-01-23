using Back.Models;
using System.Threading.Tasks;

namespace Back.Services.Interface
{
    public interface IEmpresaServices
    {
        Task<Empresa> GetAll(int id_cliente);
        Task<string> Post(Empresa model);
        Task<string> Put(Empresa model);
        Task<string> Delete(Empresa model);
    }
}

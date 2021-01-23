using Back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Repository.Interface
{
    public interface IFornecedorRepository
    {
        Task<List<Fornecedor>> GetAll(string desc, int id_cliente);
        Task<string> Post(Fornecedor model);
        Task<string> Put(Fornecedor model);
        Task<string> Delete(Fornecedor model);
    }
}

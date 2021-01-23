using Back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Repository.Interface
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> GetAll(Categoria model);
        Task<string> Post(Categoria model);
        Task<string> Put(Categoria model);
        Task<string> Delete(int id);
    }
}

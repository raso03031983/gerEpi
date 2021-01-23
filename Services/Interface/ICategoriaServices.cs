using Back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Services.Interface
{
    public interface ICategoriaServices
    {
        Task<List<Categoria>> GetAll(Categoria model);
        Task<string> Post(Categoria model);
        Task<string> Put(Categoria model);
        Task<string> Delete(int del);
    }
}

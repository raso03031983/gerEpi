using Back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Repository.Interface
{
    public interface IGSERepository
    {
        Task<List<GSE>> GetAll(string desc, int id_cliente);
        Task<string> Post(GSE model);
        Task<string> Put(GSE model);
        Task<string> Delete(GSE model);
    }
}

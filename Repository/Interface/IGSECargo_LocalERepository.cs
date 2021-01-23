using Back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Repository.Interface
{
    public interface IGSE_CargoLocalRepository
    {
        Task<List<GSE_CargoLocal>> GetAll(string desc, int id_cliente);
        Task<string> Post(GSE_CargoLocal model);
        Task<string> Put(GSE_CargoLocal model);
        Task<string> Delete(GSE_CargoLocal model);
    }
}

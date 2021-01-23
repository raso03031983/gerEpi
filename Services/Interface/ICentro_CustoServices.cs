using Back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Services.Interface
{
    public interface ICentro_CustoServices
    {
        Task<List<Centro_Custo>> GetAll(Centro_Custo model);
        Task<string> Post(Centro_Custo model);
        Task<string> Put(Centro_Custo model);
        Task<string> Delete(Centro_Custo model);
    }
}

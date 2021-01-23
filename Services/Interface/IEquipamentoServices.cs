using Back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Services.Interface
{
    public interface IEquipamentoServices
    {
        Task<List<Equipamento>> GetAll(Equipamento model);
        Task<string> Post(Equipamento model);
        Task<string> Put(Equipamento model);
        Task<string> Delete(int id);
    }
}

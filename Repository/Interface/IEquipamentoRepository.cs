using Back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Repository.Interface
{
    public interface IEquipamentoRepository
    {
        Task<List<Equipamento>> GetAll(Equipamento model);
        Task<string> Post(Equipamento model);
        Task<string> Put(Equipamento model);
        Task<string> Delete(int id);
    }
}

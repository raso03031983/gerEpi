using Back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Repository.Interface
{
    public interface IEPI_EntregueRepository
    {
        Task<List<EPI_Entregue>> GetAll(int id_entrega, int id_cargo, int id_integrante, int id_cliente);
        Task<string> Post(EPI_Entregue model);
        Task<string> Put(EPI_Entregue model);
        Task<string> Delete(EPI_Entregue model);
    }
}

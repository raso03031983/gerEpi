using Back.Models;
using Back.Repository.Interface;
using Back.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Services
{
    public class EPI_EntregueServices : IEPI_EntregueServices
    {

        private readonly IEPI_EntregueRepository _repository;

        public EPI_EntregueServices(IEPI_EntregueRepository repository)
        {
            _repository = repository;
        }

        public Task<string> Delete(EPI_Entregue model)
        {
           return _repository.Delete(model);
        }

        public Task<List<EPI_Entregue>> GetAll(int id_entrega, int id_cargo, int id_integrante, int id_cliente)
        {
            return _repository.GetAll(id_entrega, id_cargo, id_integrante, id_cliente);
        }

        public Task<string> Post(EPI_Entregue model)
        {
            return  _repository.Post(model);
        }

        public Task<string> Put(EPI_Entregue model)
        {
            return _repository.Put(model);
        }
    }
}

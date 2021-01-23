using Back.Models;
using Back.Repository.Interface;
using Back.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Services
{
    public class EquipamentoServices : IEquipamentoServices
    {

        private readonly IEquipamentoRepository _repository;

        public EquipamentoServices(IEquipamentoRepository repository)
        {
            _repository = repository;
        }

        public Task<string> Delete(int id)
        {
           return _repository.Delete(id);
        }

        public Task<List<Equipamento>> GetAll(Equipamento model)
        {
            return _repository.GetAll(model);
        }

        public Task<string> Post(Equipamento model)
        {
            return  _repository.Post(model);
        }

        public Task<string> Put(Equipamento model)
        {
            return _repository.Put(model);
        }
    }
}

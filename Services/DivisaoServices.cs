using Back.Models;
using Back.Repository.Interface;
using Back.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Services
{
    public class DivisaoServices : IDivisaoServices
    {

        private readonly IDivisaoRepository _repository;

        public DivisaoServices(IDivisaoRepository repository)
        {
            _repository = repository;
        }

        public Task<string> Delete(int id)
        {
           return _repository.Delete(id);
        }

        public Task<List<Divisao>> GetAll(int id, string desc, int id_cliente)
        {
            return _repository.GetAll(id, desc, id_cliente);
        }

        public Task<string> Post(Divisao model)
        {
            return  _repository.Post(model);
        }

        public Task<string> Put(Divisao model)
        {
            return _repository.Put(model);
        }
    }
}

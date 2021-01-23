using Back.Models;
using Back.Repository.Interface;
using Back.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Services
{
    public class EntradaServices : IEntradaServices
    {

        private readonly IEntradaRepository _repository;

        public EntradaServices(IEntradaRepository repository)
        {
            _repository = repository;
        }

        public Task<string> Delete(Entrada model)
        {
           return _repository.Delete(model);
        }

        public Task<List<Entrada>> GetAll(string desc, int idItem, int id_cliente)
        {
            return _repository.GetAll(desc, idItem, id_cliente);
        }

        public Task<string> Post(Entrada model)
        {
            return  _repository.Post(model);
        }

        public Task<string> Put(Entrada model)
        {
            return _repository.Put(model);
        }
    }
}

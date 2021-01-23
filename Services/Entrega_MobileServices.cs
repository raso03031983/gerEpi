using Back.Models;
using Back.Repository.Interface;
using Back.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Services
{
    public class Entrega_MobileServices : IEntrega_MobileServices
    {

        private readonly IEntrega_MobileRepository _repository;

        public Entrega_MobileServices(IEntrega_MobileRepository repository)
        {
            _repository = repository;
        }

        public Task<string> Delete(Entrega_Mobile model)
        {
           return _repository.Delete(model);
        }

        public Task<List<Entrega_Mobile>> GetAll(int id_cliente)
        {
            return _repository.GetAll(id_cliente);
        }

        public Task<string> Post(Entrega_Mobile model)
        {
            return  _repository.Post(model);
        }

        public Task<string> Put(Entrega_Mobile model)
        {
            return _repository.Put(model);
        }
    }
}

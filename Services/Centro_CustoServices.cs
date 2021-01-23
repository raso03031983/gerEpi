using Back.Models;
using Back.Repository.Interface;
using Back.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Services
{
    public class Centro_CustoServices : ICentro_CustoServices
    {

        private readonly ICentro_CustoRepository _repository;

        public Centro_CustoServices(ICentro_CustoRepository repository)
        {
            _repository = repository;
        }

        public Task<string> Delete(Centro_Custo model)
        {
           return _repository.Delete(model);
        }

        public Task<List<Centro_Custo>> GetAll(Centro_Custo model)
        {
            return _repository.GetAll(model);
        }

        public Task<string> Post(Centro_Custo model)
        {
            return  _repository.Post(model);
        }

        public Task<string> Put(Centro_Custo model)
        {
            return _repository.Put(model);
        }
    }
}

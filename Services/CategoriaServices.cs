using Back.Models;
using Back.Repository.Interface;
using Back.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Services
{
    public class CategoriaServices : ICategoriaServices
    {

        private readonly ICategoriaRepository _repository;

        public CategoriaServices(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public Task<string> Delete(int id)
        {
           return _repository.Delete(id);
        }

        public Task<List<Categoria>> GetAll(Categoria model)
        {
            return _repository.GetAll(model);
        }

        public Task<string> Post(Categoria model)
        {
            return  _repository.Post(model);
        }

        public Task<string> Put(Categoria model)
        {
            return _repository.Put(model);
        }
    }
}

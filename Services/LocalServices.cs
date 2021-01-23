using Back.Models;
using Back.Repository.Interface;
using Back.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Services
{
    public class LocalServices : ILocalServices
    {

        private readonly ILocalRepository _repository;

        public LocalServices(ILocalRepository repository)
        {
            _repository = repository;
        }

        public Task<string> Delete(int id)
        {
           return _repository.Delete(id);
        }

        public Task<List<Local>> GetAll(Local model)
        {
            return _repository.GetAll(model);
        }

        public Task<string> Post(Local model)
        {
            return  _repository.Post(model);
        }

        public Task<string> Put(Local model)
        {
            return _repository.Put(model);
        }
    }
}

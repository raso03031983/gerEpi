using Back.Models;
using Back.Repository.Interface;
using Back.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Services
{
    public class FamiliaServices : IFamiliaServices
    {

        private readonly IFamiliaRepository _repository;

        public FamiliaServices(IFamiliaRepository repository)
        {
            _repository = repository;
        }

        public Task<string> Delete(int id)
        {
           return _repository.Delete(id);
        }

        public Task<List<Familia>> GetAll(string desc, int id_cliente)
        {
            return _repository.GetAll(desc, id_cliente);
        }

        public Task<string> Post(Familia model)
        {
            return  _repository.Post(model);
        }

        public Task<string> Put(Familia model)
        {
            return _repository.Put(model);
        }
    }
}

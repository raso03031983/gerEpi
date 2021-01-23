using Back.Models;
using Back.Repository.Interface;
using Back.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Services
{
    public class GSEServices : IGSEServices
    {

        private readonly IGSERepository _repository;

        public GSEServices(IGSERepository repository)
        {
            _repository = repository;
        }

        public Task<string> Delete(GSE model)
        {
           return _repository.Delete(model);
        }

        public Task<List<GSE>> GetAll(string desc, int id_cliente)
        {
            return _repository.GetAll(desc, id_cliente);
        }

        public Task<string> Post(GSE model)
        {
            return  _repository.Post(model);
        }

        public Task<string> Put(GSE model)
        {
            return _repository.Put(model);
        }
    }
}

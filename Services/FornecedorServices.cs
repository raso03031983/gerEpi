using Back.Models;
using Back.Repository.Interface;
using Back.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Services
{
    public class FornecedorServices : IFornecedorServices
    {

        private readonly IFornecedorRepository _repository;

        public FornecedorServices(IFornecedorRepository repository)
        {
            _repository = repository;
        }

        public Task<string> Delete(Fornecedor model)
        {
           return _repository.Delete(model);
        }

        public Task<List<Fornecedor>> GetAll(string desc, int id_cliente)
        {
            return _repository.GetAll(desc, id_cliente);
        }

        public Task<string> Post(Fornecedor model)
        {
            return  _repository.Post(model);
        }

        public Task<string> Put(Fornecedor model)
        {
            return _repository.Put(model);
        }
    }
}

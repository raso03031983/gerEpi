using Back.Models;
using Back.Repository.Interface;
using Back.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Services
{
    public class ClassificacaoServices : IClassificacaoServices
    {

        private readonly IClassificacaoRepository _repository;

        public ClassificacaoServices(IClassificacaoRepository repository)
        {
            _repository = repository;
        }

        public Task<string> Delete(int id)
        {
           return _repository.Delete(id);
        }

        public Task<List<Classificacao>> GetAll(Classificacao model)
        {
            return _repository.GetAll(model);
        }

        public Task<string> Post(Classificacao model)
        {
            return  _repository.Post(model);
        }

        public Task<string> Put(Classificacao model)
        {
            return _repository.Put(model);
        }
    }
}

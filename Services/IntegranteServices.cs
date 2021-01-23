using Back.Models;
using Back.Repository.Interface;
using Back.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Services
{
    public class IntegranteServices : IIntegranteServices
    {

        private readonly IIntegranteRepository _repository;

        public IntegranteServices(IIntegranteRepository repository)
        {
            _repository = repository;
        }

        public Task<string> Delete(Integrante model)
        {
           return _repository.Delete(model);
        }

        public Task<List<Integrante>> GetAll(Integrante model)
        {
            return _repository.GetAll(model);
        }

        public Task<string> Post(Integrante model)
        {
            return  _repository.Post(model);
        }

        public Task<string> PostSenha(string newSenha, string senhaAtual, int idUser)
        {
            return _repository.PostSenha(newSenha, senhaAtual, idUser);
        }

        public Task<string> Put(Integrante model)
        {
            return _repository.Put(model);
        }
    }
}

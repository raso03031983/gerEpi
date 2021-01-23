using Back.Models;
using Back.Repository.Interface;
using Back.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Services
{
    public class Grade_TamanhoServices : IGrade_TamanhoServices
    {

        private readonly IGrade_TamanhoRepository _repository;

        public Grade_TamanhoServices(IGrade_TamanhoRepository repository)
        {
            _repository = repository;
        }

        public Task<string> Delete(Grade_Tamanho model)
        {
           return _repository.Delete(model);
        }

        public Task<List<Grade_Tamanho>> GetAll(int id_divisao, int id_cliente)
        {
            return _repository.GetAll(id_divisao, id_cliente);
        }

        public Task<string> Post(Grade_Tamanho model)
        {
            return  _repository.Post(model);
        }

        public Task<string> Put(Grade_Tamanho model)
        {
            return _repository.Put(model);
        }
    }
}

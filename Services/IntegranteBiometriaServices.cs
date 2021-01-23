using Back.Models;
using Back.Repository.Interface;
using Back.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Services
{
    public class IntegranteBiometriaServices : IIntegranteBiometriaServices
    {

        private readonly IIntegranteBiometriaRepository _repository;

        public IntegranteBiometriaServices(IIntegranteBiometriaRepository repository)
        {
            _repository = repository;
        }

        public Task<string> Delete(Integrante_Biometria model)
        {
           return _repository.Delete(model);
        }

        public Task<List<Integrante_Biometria>> GetAll(string desc, int id_cliente)
        {
            return _repository.GetAll(desc, id_cliente);
        }

        public Task<string> Post(Integrante_Biometria model)
        {
            return  _repository.Post(model);
        }

        public Task<string> Put(Integrante_Biometria model)
        {
            return _repository.Put(model);
        }
    }
}

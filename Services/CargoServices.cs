using Back.Models;
using Back.Repository.Interface;
using Back.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Services
{
   

    public class CargoServices : ICargoServices
    {

        private readonly ICargoRepository _repository;

        public CargoServices(ICargoRepository repository)
        {
            _repository = repository;
        }

        public Task<string> Delete(Cargo cargo)
        {
           return _repository.Delete(cargo);
        }

        public Task<List<Cargo>> GetAll(string Codigo_Cargo, string Descricao_Cargo, int id_cliente)
        {
            return _repository.GetAll(Codigo_Cargo, Descricao_Cargo, id_cliente);
        }

        public Task<string> Post(Cargo cargo)
        {
            return  _repository.Post(cargo);
        }

        public Task<string> Put(Cargo cargo)
        {
            return _repository.Put(cargo);
        }
    }
}

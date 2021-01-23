using Back.Models;
using Back.Repository.Interface;
using Back.Services.Interface;
using System.Threading.Tasks;

namespace Back.Services
{
    public class EmpresaServices : IEmpresaServices
    {

        private readonly IEmpresaRepository _repository;

        public EmpresaServices(IEmpresaRepository repository)
        {
            _repository = repository;
        }

        public Task<string> Delete(Empresa model)
        {
           return _repository.Delete(model);
        }

        public Task<Empresa> GetAll(int id_cliente)
        {
            return _repository.GetAll(id_cliente);
        }

        public Task<string> Post(Empresa model)
        {
            return  _repository.Post(model);
        }

        public Task<string> Put(Empresa model)
        {
            return _repository.Put(model);
        }
    }
}

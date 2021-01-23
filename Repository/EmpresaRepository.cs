using Back.Models;
using Back.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;

namespace Back.Repository
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly DataContext _dataContext;

        public EmpresaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<string> Delete(Empresa model)
        {
            try {

                var item = _dataContext.Empresas.Find(model.id);
                 
                if (item == null)
                {
                    return "Não encontrado";
                }

                _dataContext.Empresas.Remove(item);
                await _dataContext.SaveChangesAsync();
                return "Realizado";

            }
            catch (Exception error)
            {
                return error.ToString();
            }
        }

        public async Task<Empresa> GetAll(int id_cliente)
        {
            var resp = _dataContext.Empresas.Where(x => x.id_cliente == id_cliente).FirstOrDefault();
            return resp;
        }

        public async Task<string> Post(Empresa model)
        {
            try {

                _dataContext.Empresas.Add(model);
                await _dataContext.SaveChangesAsync();
                return "Realizado";
            }
            catch (Exception error)
            {
                return error.ToString();
            }
           
        }

        public async Task<string> Put(Empresa model)
        {
            try
            {
                _dataContext.Empresas.Update(model);
                await _dataContext.SaveChangesAsync();
                return "Realizado";
            }
            catch (DbUpdateConcurrencyException)
            {
                return "Item esta sendo atualizado neste momento, tente mais tarde";
            }
            catch (Exception error)
            {
                return error.ToString();
            }
        }
    }
}

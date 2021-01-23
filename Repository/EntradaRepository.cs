using Back.Models;
using Back.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;

namespace Back.Repository
{
    public class EntradaRepository : IEntradaRepository
    {
        private readonly DataContext _dataContext;

        public EntradaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<string> Delete(Entrada model)
        {
            try {

                //pendente de execução

                var item = _dataContext.Entradas.Find(1);
                 
                if (item == null)
                {
                    return "Não encontrado";
                }

                _dataContext.Entradas.Remove(item);
                await _dataContext.SaveChangesAsync();
                return "Realizado";

            }
            catch (Exception error)
            {
                return error.ToString();
            }
        }

        public Task<List<Entrada>> GetAll(string desc, int idItem, int id_cliente)
        {
            //pendente de execução

            throw new NotImplementedException();
        }

        public async Task<string> Post(Entrada model)
        {
            try {

                _dataContext.Entradas.Add(model);
                await _dataContext.SaveChangesAsync();
                return "Realizado";
            }
            catch (Exception error)
            {
                return error.ToString();
            }
           
        }

        public async Task<string> Put(Entrada model)
        {
            try
            {
                _dataContext.Entradas.Update(model);
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

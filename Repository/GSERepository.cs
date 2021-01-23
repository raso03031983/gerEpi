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
    public class GSERepository : IGSERepository
    {
        private readonly DataContext _dataContext;

        public GSERepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<string> Delete(GSE model)
        {
            try {

                var item = _dataContext.GSEs.Find(model.id);
                 
                if (item == null)
                {
                    return "Não encontrado";
                }

                _dataContext.GSEs.Remove(item);
                await _dataContext.SaveChangesAsync();
                return "Realizado";

            }
            catch (Exception error)
            {
                return error.ToString();
            }
        }

        public async Task<List<GSE>> GetAll(string desc, int id_cliente)
        {

                var resp = _dataContext.GSEs.FromSqlRaw("EXEC dbo.uspGSEConsultar @p_parametro={0}, @id_cliente={1}",
                                                         desc, id_cliente).ToList();
                return resp;
        }

        public async Task<string> Post(GSE model)
        {
            try {

                _dataContext.GSEs.Add(model);
                await _dataContext.SaveChangesAsync();
                return "Realizado";
          
            }
            catch (Exception error)
            {
                return error.ToString();
            }
           
        }

        public async Task<string> Put(GSE model)
        {
            try
            {
                _dataContext.GSEs.Update(model);
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

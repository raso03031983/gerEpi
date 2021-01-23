using Back.Models;
using Back.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data;

namespace Back.Repository
{
    public class LocalRepository : ILocalRepository
    {
        private readonly DataContext _dataContext;

        public LocalRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<string> Delete(int id)
        {
            try {

                var item = _dataContext.Locais.Find(id);
                 
                if (item == null)
                {
                    return "Não encontrado";
                }

                _dataContext.Locais.Remove(item);
                await _dataContext.SaveChangesAsync();
                return "Realizado";

            }
            catch (Exception error)
            {
                return error.ToString();
            }
        }

        public async Task<List<Local>> GetAll(Local model)
        {

            var query = new StringBuilder();

            query.Append("SELECT ID_Local, Descricao_Local, id_cliente FROM Local ");
            query.Append("where id_cliente = '" + model.id_cliente + "'  ");

            if (!string.IsNullOrEmpty(model.Descricao_Local))
                query.Append("and Descricao_Local LIKE '%" + model.Descricao_Local + "%'   ");

            var resp = _dataContext.Locais.FromSqlRaw(query.ToString()).ToList();

            return resp;
        }

        public async Task<string> Post(Local model)
        {
            try {

                var resp = await _dataContext.Database.ExecuteSqlRawAsync("EXEC dbo.uspLocalInserir @Descricao_Local={0}, @id_cliente={1}",
                                                         model.Descricao_Local, model.id_cliente);
                return "Realizado";
            }
            catch (Exception error)
            {
                return error.ToString();
            }
           
        }

        public async Task<string> Put(Local model)
        {
            try
            {
                _dataContext.Locais.Update(model);
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

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
    public class GSE_CargoLocalRepository : IGSE_CargoLocalRepository
    {
        private readonly DataContext _dataContext;

        public GSE_CargoLocalRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<string> Delete(GSE_CargoLocal model)
        {
            try {

                var item = _dataContext.GSE_CargoLocais.Find(model.id);
                 
                if (item == null)
                {
                    return "Não encontrado";
                }

                _dataContext.GSE_CargoLocais.Remove(item);
                await _dataContext.SaveChangesAsync();
                return "Realizado";

            }
            catch (Exception error)
            {
                return error.ToString();
            }
        }

        public async Task<List<GSE_CargoLocal>> GetAll(string desc, int id_cliente)
        {

                var resp = _dataContext.GSE_CargoLocais.FromSqlRaw("EXEC dbo.uspGSE_CargoLocalConsultar @p_parametro={0}, @id_cliente={1}",
                                                         desc, id_cliente).ToList();
                return resp;
        }

        public async Task<string> Post(GSE_CargoLocal model)
        {
            try {

                _dataContext.GSE_CargoLocais.Add(model);
                await _dataContext.SaveChangesAsync();
                return "Realizado";
          
            }
            catch (Exception error)
            {
                return error.ToString();
            }
           
        }

        public async Task<string> Put(GSE_CargoLocal model)
        {
            try
            {
                _dataContext.GSE_CargoLocais.Update(model);
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

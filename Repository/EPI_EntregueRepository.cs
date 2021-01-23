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
    public class EPI_EntregueRepository : IEPI_EntregueRepository
    {
        private readonly DataContext _dataContext;

        public EPI_EntregueRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<string> Delete(EPI_Entregue model)
        {
            try {

                var item = _dataContext.EPI_Entregues.Find(model.id);
                 
                if (item == null)
                {
                    return "Não encontrado";
                }

                _dataContext.EPI_Entregues.Remove(item);
                await _dataContext.SaveChangesAsync();
                return "Realizado";

            }
            catch (Exception error)
            {
                return error.ToString();
            }
        }

        public async Task<List<EPI_Entregue>> GetAll(int id_entrega, int id_cargo, int id_integrante, int id_cliente)
        {

            var resp = _dataContext.EPI_Entregues.Where(x => x.id_cliente == id_cliente).ToList();
                return resp;
        }

        public async Task<string> Post(EPI_Entregue model)
        {
            try {

                _dataContext.EPI_Entregues.Add(model);
                await _dataContext.SaveChangesAsync();
                return "Realizado";
          
            }
            catch (Exception error)
            {
                return error.ToString();
            }
           
        }

        public async Task<string> Put(EPI_Entregue model)
        {
            try
            {
                _dataContext.EPI_Entregues.Update(model);
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

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
    public class Entrega_MobileRepository : IEntrega_MobileRepository
    {
        private readonly DataContext _dataContext;

        public Entrega_MobileRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<string> Delete(Entrega_Mobile model)
        {
            try {

                var item = _dataContext.Entregas_Mobile.Find(model.id);
                 
                if (item == null)
                {
                    return "Não encontrado";
                }

                _dataContext.Entregas_Mobile.Remove(item);
                await _dataContext.SaveChangesAsync();
                return "Realizado";

            }
            catch (Exception error)
            {
                return error.ToString();
            }
        }

        public async Task<List<Entrega_Mobile>> GetAll(int id_cliente)
        {
            var resp = _dataContext.Entregas_Mobile.Where(x => x.id_cliente == id_cliente).ToList();
            return resp;
        }

        public async Task<string> Post(Entrega_Mobile model)
        {
            try {

                _dataContext.Entregas_Mobile.Add(model);
                await _dataContext.SaveChangesAsync();
                return "Realizado";
          
            }
            catch (Exception error)
            {
                return error.ToString();
            }
           
        }

        public async Task<string> Put(Entrega_Mobile model)
        {
            try
            {
                _dataContext.Entregas_Mobile.Update(model);
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

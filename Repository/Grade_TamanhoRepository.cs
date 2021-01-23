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
    public class Grade_TamanhoRepository : IGrade_TamanhoRepository
    {
        private readonly DataContext _dataContext;

        public Grade_TamanhoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<string> Delete(Grade_Tamanho model)
        {
            try {

                var item = _dataContext.Grade_Tamanhos.Find(model.id);
                 
                if (item == null)
                {
                    return "Não encontrado";
                }

                _dataContext.Grade_Tamanhos.Remove(item);
                await _dataContext.SaveChangesAsync();
                return "Realizado";

            }
            catch (Exception error)
            {
                return error.ToString();
            }
        }

        public async Task<List<Grade_Tamanho>> GetAll(int id_divisao, int id_cliente)
        {

                var resp = _dataContext.Grade_Tamanhos.FromSqlRaw("EXEC dbo.uspGradeTamanhoConsultar @ID_Divisao={0}, @id_cliente={1}",
                                                                   id_divisao, id_cliente).ToList();
                return resp;
        }

        public async Task<string> Post(Grade_Tamanho model)
        {
            try {

                _dataContext.Grade_Tamanhos.Add(model);
                await _dataContext.SaveChangesAsync();
                return "Realizado";
          
            }
            catch (Exception error)
            {
                return error.ToString();
            }
           
        }

        public async Task<string> Put(Grade_Tamanho model)
        {
            try
            {
                _dataContext.Grade_Tamanhos.Update(model);
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

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
    public class DivisaoRepository : IDivisaoRepository
    {
        private readonly DataContext _dataContext;

        public DivisaoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<string> Delete(int id)
        {
            try {

                var item = _dataContext.Divisoes.Find(id);
                 
                if (item == null)
                {
                    return "Não encontrado";
                }

                _dataContext.Divisoes.Remove(item);
                await _dataContext.SaveChangesAsync();
                return "Realizado";

            }
            catch (Exception error)
            {
                return error.ToString();
            }
        }

        public async Task<List<Divisao>> GetAll(int id, string desc, int id_cliente)
        {

            if (id > 0) {
                var resp = _dataContext.Divisoes.FromSqlRaw("EXEC dbo.uspDivisaoConsultarPorID @ID_Divisao={0}, @id_cliente={1}",
                                                       id, id_cliente).ToList();
                return resp;
            }
            else {
                var resp = _dataContext.Divisoes.FromSqlRaw("EXEC dbo.uspDivisaoConsultarPorDescricao @p_parametro={0}, @id_cliente={1}",
                                                             desc, id_cliente).ToList();
                return resp;
            }
           
               

        }

        public async Task<string> Post(Divisao model)
        {
            try {

                var resp = await _dataContext.Database.ExecuteSqlRawAsync("EXEC dbo.uspDivisaoInserir @Descricao_Divisao={0}, @Img_Divisao={1}, @id_cliente={2}",
                                                         model.Descricao_Divisao, model.Img_Divisao, model.id_cliente);
                return "Realizado";
            }
            catch (Exception error)
            {
                return error.ToString();
            }
           
        }

        public async Task<string> Put(Divisao model)
        {
            try
            {
                _dataContext.Divisoes.Update(model);
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

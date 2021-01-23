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
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly DataContext _dataContext;

        public CategoriaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<string> Delete(int id)
        {
            try {

                var item = _dataContext.Categorias.Find(id);
                 
                if (item == null)
                {
                    return "Não encontrado";
                }

                _dataContext.Categorias.Remove(item);
                await _dataContext.SaveChangesAsync();
                return "Realizado";

            }
            catch (Exception error)
            {
                return error.ToString();
            }
        }

        public async Task<List<Categoria>> GetAll(Categoria model)
        {
            if (model.id > 0) {
                var resp = _dataContext.Categorias.FromSqlRaw("EXEC dbo.uspCategoriaConsultarPorID @ID_Categoria={0}, @id_cliente={1}",
                                                         model.id, model.id_cliente).ToList();
                return resp;
            }
            else {
          
                var resp = _dataContext.Categorias.FromSqlRaw("EXEC dbo.uspCategoriaConsultarPorDescricao @p_parametro={0}, @id_cliente={1}",
                                                               model.Descricao_Categoria, model.id_cliente).ToList();
                return resp;
            }
        }

        public async Task<string> Post(Categoria model)
        {
            try {
                var resp = await _dataContext.Database.ExecuteSqlRawAsync("EXEC dbo.uspCategoriaInserir @Descricao_Categoria={0}, @Img_Categoria={1}, @id_cliente={2}",
                                                         model.Descricao_Categoria, model.Img_Categoria,  model.id_cliente);
                return "Realizado";
            }
            catch (Exception error)
            {
                return error.ToString();
            }
           
        }

        public async Task<string> Put(Categoria model)
        {
            try
            {
                _dataContext.Categorias.Update(model);
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

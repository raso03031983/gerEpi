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
    public class FamiliaRepository : IFamiliaRepository
    {
        private readonly DataContext _dataContext;

        public FamiliaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<string> Delete(int id)
        {
            try {

                var item = _dataContext.Familias.Find(id);
                 
                if (item == null)
                {
                    return "Não encontrado";
                }

                _dataContext.Familias.Remove(item);
                await _dataContext.SaveChangesAsync();
                return "Realizado";

            }
            catch (Exception error)
            {
                return error.ToString();
            }
        }

        public async Task<List<Familia>> GetAll(string desc, int id_cliente)
        {
            var query = new StringBuilder();

            query.Append(" SELECT ID_Familia, Descricao_Familia, Img_Familia, id_cliente FROM Familia WHERE id_cliente = '" + id_cliente + "' ");

            if (!string.IsNullOrEmpty(desc))
                query.Append("  and  Descricao_Familia LIKE '%" + desc + "%' ");

            var resp = _dataContext.Familias.FromSqlRaw(query.ToString()).ToList();
                return resp;
        }

        public async Task<string> Post(Familia model)
        {
            try {

                var resp = await _dataContext.Database.ExecuteSqlRawAsync("EXEC dbo.uspFamiliaInserir @Descricao_Familia={0}, @Img_Familia={1}, @id_cliente={2}",
                                                         model.Descricao_Familia, model.Img_Familia, model.id_cliente);
                return "Realizado";
          
            }
            catch (Exception error)
            {
                return "erroInterno " +  error.ToString();
            }
           
        }

        public async Task<string> Put(Familia model)
        {
            try
            {
                _dataContext.Familias.Update(model);
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

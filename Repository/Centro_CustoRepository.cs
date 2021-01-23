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
    public class Centro_CustoRepository : ICentro_CustoRepository
    {
        private readonly DataContext _dataContext;

        public Centro_CustoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<string> Delete(Centro_Custo model)
        {
            try {

                var item = _dataContext.Centro_Custos.Find(model.id);
                 
                if (item == null)
                {
                    return "Não encontrado";
                }

                _dataContext.Centro_Custos.Remove(item);
                await _dataContext.SaveChangesAsync();
                return "Realizado";

            }
            catch (Exception error)
            {
                return error.ToString();
            }
        }

        public async Task<List<Centro_Custo>> GetAll(Centro_Custo model)
        {
            var query = new StringBuilder();

            query.Append("select ID_CentroCusto, Codigo_CentroCusto, Descricao_CentroCusto, id_cliente ");
            query.Append("from Centro_Custo  ");
            query.Append("where id_cliente = '" + model.id_cliente + "'  ");

            if (model.id > 0)
                query.Append("and ID_CentroCusto = '" + model.id + "'  ");

            if (!string.IsNullOrEmpty(model.Codigo_CentroCusto))
                query.Append("and Codigo_CentroCusto = '" + model.Codigo_CentroCusto + "'  ");

            var resp = _dataContext.Centro_Custos.FromSqlRaw(query.ToString()).ToList();

            return resp;
        }

        public async Task<string> Post(Centro_Custo model)
        {
            try {

                _dataContext.Centro_Custos.Add(model);
                await _dataContext.SaveChangesAsync();
                return "Realizado";
            }
            catch (Exception error)
            {
                return error.ToString();
            }
           
        }

        public async Task<string> Put(Centro_Custo model)
        {
            try
            {
                _dataContext.Centro_Custos.Update(model);
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

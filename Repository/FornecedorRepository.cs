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
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly DataContext _dataContext;

        public FornecedorRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<string> Delete(Fornecedor model)
        {
            try {

                var item = _dataContext.Fornecedores.Find(model.id);
                 
                if (item == null)
                {
                    return "Não encontrado";
                }

                _dataContext.Fornecedores.Remove(item);
                await _dataContext.SaveChangesAsync();
                return "Realizado";

            }
            catch (Exception error)
            {
                return error.ToString();
            }
        }

        public async Task<List<Fornecedor>> GetAll(string desc, int id_cliente)
        {

            var query = new StringBuilder();

            query.Append("SELECT ID_Fornecedor , Nome_Fornecedor , Nome_Fantasia , CNPJ , id_cliente FROM Fornecedor ");
            query.Append("where id_cliente = '" + id_cliente + "'  ");

            if (!string.IsNullOrEmpty(desc))
                query.Append("and Nome_Fornecedor LIKE '%" + desc + "%'  ");


            var resp = _dataContext.Fornecedores.FromSqlRaw(query.ToString()).ToList();
            return resp;
        }

        public async Task<string> Post(Fornecedor model)
        {
            try {

                _dataContext.Fornecedores.Add(model);
                await _dataContext.SaveChangesAsync();
                return "Realizado";
          
            }
            catch (Exception error)
            {
                return error.ToString();
            }
           
        }

        public async Task<string> Put(Fornecedor model)
        {
            try
            {
                _dataContext.Fornecedores.Update(model);
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

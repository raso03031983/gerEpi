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
    public class ClassificacaoRepository : IClassificacaoRepository
    {
        private readonly DataContext _dataContext;

        public ClassificacaoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<string> Delete(int id)
        {
            try {

                var item = _dataContext.Classificacoes.Find(id);
                 
                if (item == null)
                {
                    return "Não encontrado";
                }

                _dataContext.Classificacoes.Remove(item);
                await _dataContext.SaveChangesAsync();
                return "Realizado";

            }
            catch (Exception error)
            {
                return error.ToString();
            }
        }

        public async Task<List<Classificacao>> GetAll(Classificacao model)
        {

           var query =  new StringBuilder();

            query.Append("SELECT cl.ID_Classificacao, cl.ID_Familia, cl.ID_Divisao, cl.ID_Categoria, cl.id_cliente, fa.Descricao_Familia, di.Descricao_Divisao, ca.Descricao_Categoria ");
            query.Append("FROM Classificacao cl  ");
            query.Append("inner join Familia fa on fa.ID_Familia = cl.ID_Familia  ");
            query.Append("inner join Divisao di on di.ID_Divisao = cl.ID_Divisao  ");
            query.Append("inner join Categoria ca on ca.ID_Categoria = cl.ID_Categoria ");
            query.Append("where cl.id_cliente = '" +model.id_cliente+ "'  ");

            if (model.ID_Familia > 0)
                query.Append("and cl.ID_Familia = '" + model.ID_Familia + "'  ");

            if (model.ID_Divisao > 0)
                query.Append("and cl.ID_Divisao = '" + model.ID_Divisao + "'  ");

            if (model.ID_Categoria > 0)
                query.Append("and ca.ID_Categoria = '" + model.ID_Categoria + "'  ");


            var resp = _dataContext.Classificacoes.FromSqlRaw(query.ToString()).ToList();

            return resp;

        }

        public async Task<string> Post(Classificacao model)
        {
            try
            {
                var query = new StringBuilder();

                query.Append("INSERT INTO Classificacao (ID_Familia, ID_Divisao, ID_Categoria) ");
                query.Append("VALUES ('" + model.ID_Familia + "', '" + model.ID_Divisao + "', '" + model.ID_Categoria + "')");

                _dataContext.Database.ExecuteSqlCommand(query.ToString());

                return "Realizado";
            }
            catch (Exception error)
            {
                return error.ToString();
            }

        }

        public async Task<string> Put(Classificacao model)
        {
            try
            {
                var query = new StringBuilder();
                 
                query.Append("update Classificacao set ID_Familia =  '" + model.ID_Familia + "', ID_Divisao = '" + model.ID_Divisao + "', ID_Categoria =  '" + model.ID_Categoria + "' where ID_Classificacao = '"+ model.id +"'  ");
                
                _dataContext.Database.ExecuteSqlCommand(query.ToString());

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

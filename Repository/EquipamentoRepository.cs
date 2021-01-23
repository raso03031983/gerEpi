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
    public class EquipamentoRepository : IEquipamentoRepository
    {
        private readonly DataContext _dataContext;

        public EquipamentoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<string> Delete(int id)
        {
            try {

                var item = _dataContext.Equipamentos.Find(id);
                 
                if (item == null)
                {
                    return "Não encontrado";
                }

                _dataContext.Equipamentos.Remove(item);
                await _dataContext.SaveChangesAsync();
                return "Realizado";

            }
            catch (Exception error)
            {
                return error.ToString();
            }
        }

        public async Task<List<Equipamento>> GetAll(Equipamento model)
        {

            var query = new StringBuilder();

            query.Append("select eq.Codigo_Equipamento, eq.Descricao_Equipamento, eq.ID_Grade, gr.Tamanho, Unidade_Equipamento, ");
            query.Append("eq.ID_Familia, fa.Descricao_Familia, eq.ID_Divisao, di.Descricao_Divisao, eq.ID_Categoria,  ");
            query.Append("ca.Descricao_Categoria, Equipamento_EmbMultipla, Mobile, eq.id_cliente ,  ");
            query.Append("CASE status WHEN 1 THEN 'SIM' WHEN 0 THEN 'NÃO' ELSE 'NÃO DEFINIDO' END as StatusDesc, status ");
            query.Append("from equipamento eq  ");
            query.Append("inner join grade_tamanho gr on gr.id_grade = eq.id_grade  ");
            query.Append("inner join Divisao di on di.ID_Divisao = eq.ID_Divisao  ");
            query.Append("inner join Familia fa on fa.ID_Familia = eq.ID_Familia ");
            query.Append("inner join Categoria ca on ca.ID_Categoria = eq.ID_Categoria ");
            query.Append("where eq.id_cliente = '" + model.id_cliente + "'  ");

            if (model.ID_Familia > 0)
                query.Append("and eq.ID_Familia = '" + model.ID_Familia + "'  ");

            if (model.ID_Divisao > 0)
                query.Append("and eq.ID_Divisao = '" + model.ID_Divisao + "'  ");

            if (model.ID_Categoria > 0)
                query.Append("and eq.ID_Categoria = '" + model.ID_Categoria + "'  ");

            if (model.Status >= 0)
                query.Append("and eq.status = '" + model.Status + "'  ");

            if (!string.IsNullOrEmpty(model.Descricao_Equipamento))
                query.Append("and Descricao_Equipamento LIKE '%" + model.Descricao_Equipamento + "%'  ");


            var resp = _dataContext.Equipamentos.FromSqlRaw(query.ToString()).ToList();

            return resp;

        }

        public async Task<string> Post(Equipamento model)
        {
            try {
                Equipamento param = new Equipamento {
                    id_cliente = 1
                };

                var getList = GetAll(param);

                var lastID = getList.Result.Last().id + 1;

                var query = new StringBuilder();

                query.Append("INSERT INTO Equipamento (Codigo_Equipamento, Descricao_Equipamento, ID_Grade, Unidade_Equipamento, ID_Familia, ");
                query.Append("ID_Divisao, ID_Categoria, Equipamento_EmbMultipla , Status , Mobile , id_cliente) ");
                query.Append("VALUES ('" + lastID + "', '" + model.Descricao_Equipamento + "', '" + model.ID_Grade + "', '" + model.Unidade_Equipamento + "', '" + model.ID_Familia + "', ");
                query.Append("'" + model.ID_Divisao + "', '" + model.ID_Categoria + "', '" + model.Equipamento_EmbMultipla + "', '" + model.Status + "', '" + model.Mobile + "', '" + model.id_cliente + "')");

                _dataContext.Database.ExecuteSqlCommand(query.ToString());

               
                return "Realizado";
          
            }
            catch (Exception error)
            {
                return error.ToString();
            }
           
        }

        public async Task<string> Put(Equipamento model)
        {
            try
            {
                var query = new StringBuilder();

                query.Append("update Equipamento set Descricao_Equipamento =  '" + model.Descricao_Equipamento + "', ID_Grade = '" + model.ID_Grade + "', Unidade_Equipamento =  '" + model.Unidade_Equipamento + "',  ");
                query.Append("ID_Familia =  '" + model.ID_Familia + "', ID_Divisao = '" + model.ID_Divisao + "', ID_Categoria =  '" + model.ID_Categoria + "',  ");
                query.Append("Equipamento_EmbMultipla =  '" + model.Equipamento_EmbMultipla + "', Status = '" + model.Status + "', Mobile =  '" + model.Mobile + "' where Codigo_Equipamento = '" + model.id + "'  ");

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

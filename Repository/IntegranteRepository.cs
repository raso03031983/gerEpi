using Back.Models;
using Back.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data;

namespace Back.Repository
{
    public class IntegranteRepository : IIntegranteRepository
    {
        private readonly DataContext _dataContext;
       
        public IntegranteRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<string> Delete(Integrante model)
        {
            try {

                var item = _dataContext.Integrantes.Find(model.id);
                 
                if (item == null)
                {
                    return "Não encontrado";
                }

                _dataContext.Integrantes.Remove(item);
                await _dataContext.SaveChangesAsync();
                return "Realizado";

            }
            catch (Exception error)
            {
                return error.ToString();
            }
        }

        public async Task<List<Integrante>> GetAll(Integrante model)
        {

            var query = new StringBuilder();

            query.Append("SELECT ID_Empresa, ID_Integrante, i.Matricula, Nome_Integrante, C.ID_Cargo, Descricao_Cargo, ");
            query.Append("L.ID_Local, L.Descricao_Local, CC.ID_CentroCusto, CC.Codigo_CentroCusto, CC.Descricao_CentroCusto, Img_Integrante, PWD,  ");
            query.Append("Cracha, Login, Perfil, Fingerprint, i.ID_UsuarioCadastro, i.ID_UsuarioUltAlteracao, i.id_cliente,  ");
            query.Append("Situacao, case Situacao when 'A' then 'ATIVO' else 'INATIVO' end as situacaoDesc, ");
            query.Append("Tipo_MO, case Tipo_MO when 'D' then 'DIRETA' else 'INDIRETA' end as tipoMODesc,  ");
            query.Append("FORMAT (Data_Admissao, 'dd/MM/yyyy') as Data_AdmissaoDesc, Data_Admissao,  ");
            query.Append("FORMAT (Data_Demissao, 'dd/MM/yyyy') as Data_DemissaoDesc, Data_Demissao, ");
            query.Append("FORMAT (i.DtHorUlt_Alteracao, 'dd/MM/yyyy') as DtHorUlt_AlteracaoDesc, i.DtHorUlt_Alteracao, ");
            query.Append("FORMAT (i.DtHor_Cadastro, 'dd/MM/yyyy') as DtHor_CadastroDesc, i.DtHor_Cadastro, ");
            query.Append("FORMAT (i.DtHor_UltAtualizacao, 'dd/MM/yyyy') as DtHor_UltAtualizacaoDesc, i.DtHor_UltAtualizacao   ");
            query.Append("FROM Integrante I   ");
            query.Append("LEFT OUTER JOIN Cargo C ON I.ID_Cargo = C.ID_Cargo  ");
            query.Append("LEFT OUTER JOIN Local L ON I.ID_Local = L.ID_Local  ");
            query.Append("LEFT OUTER JOIN Centro_Custo CC ON I.ID_CentroCusto = CC.ID_CentroCusto  ");
            query.Append("LEFT OUTER JOIN Usuario U ON I.ID_Integrante = U.ID_Usuario  ");
            query.Append("LEFT OUTER JOIN Integrante_Biometria IB ON I.Matricula = IB.Matricula  ");
            query.Append("where I.id_cliente = '" + model.id_cliente + "' ");

            if (!string.IsNullOrEmpty(model.Matricula))
                query.Append(" and i.Matricula = '"+ model.Matricula +"'  ");

            if (!string.IsNullOrEmpty(model.Cracha))
                query.Append("and Cracha = '" + model.Cracha + "'  ");

            if (model.Tipo_MO > 0)
                query.Append("and Tipo_MO = '" + model.Tipo_MO + "'  ");

            if (model.Situacao > 0)
                query.Append("and Situacao = '" + model.Situacao + "'  ");

            if (!string.IsNullOrEmpty(model.Nome_Integrante))
                query.Append("and Nome_Integrante LIKE '%" + model.Nome_Integrante + "%'  ");


            var resp = _dataContext.Integrantes.FromSqlRaw(query.ToString()).ToList();

            return resp;

        }

        public async Task<string> Post(Integrante model)
        {
            try {

                var matricula = _dataContext.Integrantes.Select(x => x.Matricula == model.Matricula).FirstOrDefault();

                if (matricula) {
                    return "Matricula já cadastrada";
                }
                else{

                    var query = new StringBuilder();

                    query.Append("INSERT INTO Integrante (ID_Empresa, Matricula, Nome_Integrante, ID_Cargo, ID_Local, ID_CentroCusto,")
                         .Append("Data_Admissao, Situacao, Tipo_MO, PWD,  Cracha, DtHor_Cadastro, id_cliente) ")
                         .Append("values( '" + model.ID_Empresa + "', '" + model.Matricula + "', '" + model.Nome_Integrante + "', '" + model.ID_Cargo + "', '" + model.ID_Local + "', '" + model.ID_CentroCusto + "',  ")
                         .Append(" '" + model.Data_Admissao + "',  '" + model.Situacao + "',  '" + model.Tipo_MO + "',  '" + model.PWD + "',  '" + model.Cracha + "',  getDate(),  '" + model.id_cliente + "' )");

                    _dataContext.Database.ExecuteSqlCommand(query.ToString());

                    return "Realizado";
                }
            }
            catch (Exception error)
            {
                return error.ToString();
            }
           
        }

        public async Task<string> Put(Integrante model)
        {
            try
            {
                _dataContext.Integrantes.Update(model);
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

        public async Task<string> PostSenha(string newSenha, string senhaAtual, int idUser)
        {
            try
            {

                var confereSenha = _dataContext.Integrantes
                                  .Select(x => x.PWD == senhaAtual && x.id == idUser)
                                  .FirstOrDefault();

                if (confereSenha == false)
                {
                    return "Senha Atual Incorreta";
                }
                else
                {

                    var query = new StringBuilder();

                    query.Append(" update Integrante set pwd = '" + newSenha + "' where id_integrante = '" + idUser + "' ");
                         
                    _dataContext.Database.ExecuteSqlCommand(query.ToString());

                    return "Realizado";
                }
            }
            catch (Exception error)
            {
                return error.ToString();
            }
        }
    }
}

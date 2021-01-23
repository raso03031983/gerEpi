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
    public class CargoRepository : ICargoRepository
    {
        private readonly DataContext _dataContext;

        public CargoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<string> Delete(Cargo cargo)
        {
            try {

                var item = _dataContext.Cargos.Find(cargo.id);
                 
                if (item == null)
                {
                    return "Não encontrado";
                }

                _dataContext.Cargos.Remove(item);
                await _dataContext.SaveChangesAsync();
                return "Realizado";

            }
            catch (Exception error)
            {
                return error.ToString();
            }
        }

        public async Task<List<Cargo>> GetAll(string Codigo_Cargo, string Descricao_Cargo, int id_cliente)
        {

            var query = new StringBuilder();

            query.Append(" SELECT ID_Cargo, Codigo_Cargo, Descricao_Cargo, CBO, id_cliente FROM Cargo WHERE id_cliente = '"+ id_cliente +"' ");

            if (!string.IsNullOrEmpty(Codigo_Cargo))
                query.Append("  and Codigo_Cargo = '"+ Codigo_Cargo + "' ");

            if (!string.IsNullOrEmpty(Descricao_Cargo))
                query.Append("  and Descricao_Cargo LIKE '%" + Descricao_Cargo + "%' ");

            var resp = _dataContext.Cargos.FromSqlRaw(query.ToString()).ToList();
            return resp;
        }

        public async Task<string> Post(Cargo cargo)
        {
            try {
                _dataContext.Cargos.Add(cargo);
                _dataContext.SaveChanges();
                return "Realizado";
            }
            catch (Exception error)
            {
                return error.ToString();
            }
           
        }

        public async Task<string> Put(Cargo cargo){
            try
            {
                _dataContext.Cargos.Update(cargo);
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

using Back.Models;
using Back.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using WebApi.Data;

namespace Back.Repository
{
    public class IntegranteBiometriaRepository : IIntegranteBiometriaRepository
    {
        private readonly DataContext _dataContext;

        public IntegranteBiometriaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<string> Delete(Integrante_Biometria model)
        {
            try {

                var item = _dataContext.Integrantes_Biometria.Find(model.Matricula);
                 
                if (item == null)
                {
                    return "Não encontrado";
                }

                _dataContext.Integrantes_Biometria.Remove(item);
                await _dataContext.SaveChangesAsync();
                return "Realizado";

            }
            catch (Exception error)
            {
                return error.ToString();
            }
        }

        public async Task<List<Integrante_Biometria>> GetAll(string matricula, int id_cliente)
        {

            var resp =  _dataContext.Integrantes_Biometria.Where(x => x.id_cliente == id_cliente && x.Matricula == matricula).ToList();
            return resp;
           
        }

        public async Task<string> Post(Integrante_Biometria model)
        {
            try {

                _dataContext.Integrantes_Biometria.Add(model);
                await _dataContext.SaveChangesAsync();
                return "Realizado";
          
            }
            catch (Exception error)
            {
                return error.ToString();
            }
           
        }

        public async Task<string> Put(Integrante_Biometria model)
        {
            try
            {
                _dataContext.Integrantes_Biometria.Update(model);
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

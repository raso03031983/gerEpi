﻿using Back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Repository.Interface
{
    public interface IIntegranteBiometriaRepository
    {
        Task<List<Integrante_Biometria>> GetAll(string matricula, int id_cliente);
        Task<string> Post(Integrante_Biometria model);
        Task<string> Put(Integrante_Biometria model);
        Task<string> Delete(Integrante_Biometria model);
    }
}

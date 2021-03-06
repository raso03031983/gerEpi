﻿using Back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Services.Interface
{
    public interface IGrade_TamanhoServices
    {
        Task<List<Grade_Tamanho>> GetAll(int id_divisao, int id_cliente);
        Task<string> Post(Grade_Tamanho model);
        Task<string> Put(Grade_Tamanho model);
        Task<string> Delete(Grade_Tamanho model);
    }
}

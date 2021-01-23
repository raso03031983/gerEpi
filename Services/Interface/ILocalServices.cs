﻿using Back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Services.Interface
{
    public interface ILocalServices
    {
        Task<List<Local>> GetAll(Local model);
        Task<string> Post(Local model);
        Task<string> Put(Local model);
        Task<string> Delete(int id);
    }
}

using Back.Models;
using Back.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Controllers
{
    [Route("Empresa")]
    [ApiController]
    public class EmpresaController : Controller
    {
        private readonly IEmpresaServices _services;

        public EmpresaController(IEmpresaServices services)
        {
            _services = services;
        }


        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<Empresa>> Get(int id_cliente)
        {
            var item = await _services.GetAll(id_cliente);

            return Ok(item);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult<string>> Post(Empresa model)
        {
            var resp = await _services.Post(model);

            return Ok(resp);
        }

        [HttpPut]
        [Route("Put")]
        public async Task<ActionResult<string>> Put(Empresa model)
        {
            var resp =  await _services.Put(model);
            
            return Ok(resp);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<string>> Delete(Empresa model)
        {
            var resp = await _services.Delete(model);

            return Ok(resp);
        }
    }
}

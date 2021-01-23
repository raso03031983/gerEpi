using Back.Models;
using Back.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Controllers
{
    [Route("Entrada")]
    [ApiController]
    public class EntradaController : Controller
    {
        private readonly IEntradaServices _services;

        public EntradaController(IEntradaServices services)
        {
            _services = services;
        }


        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<List<Entrada>>> Get(string desc, int idItem, int id_cliente)
        {
            var item = await _services.GetAll(desc, idItem, id_cliente);

            return Ok(item);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult<string>> Post(Entrada model)
        {
            var resp = await _services.Post(model);

            return Ok(resp);
        }

        [HttpPut]
        [Route("Put")]
        public async Task<ActionResult<string>> Put(Entrada model)
        {
            var resp =  await _services.Put(model);
            
            return Ok(resp);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<string>> Delete(Entrada model)
        {
            var resp = await _services.Delete(model);

            return Ok(resp);
        }
    }
}

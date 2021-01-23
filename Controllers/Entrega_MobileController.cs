using Back.Models;
using Back.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Controllers
{
    [Route("Entrega_Mobile")]
    [ApiController]
    public class Entrega_MobileController : Controller
    {
        private readonly IEntrega_MobileServices _services;

        public Entrega_MobileController(IEntrega_MobileServices services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<List<Entrega_Mobile>>> Get(int id_cliente)
        {
            var item = await _services.GetAll(id_cliente);

            return Ok(item);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult<string>> Post(Entrega_Mobile model)
        {
            var resp = await _services.Post(model);

            return Ok(resp);
        }

        [HttpPut]
        [Route("Put")]
        public async Task<ActionResult<string>> Put(Entrega_Mobile model)
        {
            var resp =  await _services.Put(model);
            
            return Ok(resp);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<string>> Delete(Entrega_Mobile model)
        {
            var resp = await _services.Delete(model);

            return Ok(resp);
        }
    }
}

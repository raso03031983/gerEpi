using Back.Models;
using Back.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Controllers
{
    [Route("Local")]
    [ApiController]
    public class LocalController : Controller
    {
        private readonly ILocalServices _services;

        public LocalController(ILocalServices services)
        {
            _services = services;
        }

        [HttpPost]
        [Route("Get")]
        public async Task<ActionResult<List<Local>>> Get(Local model)
        {

            if (model.id_cliente < 1) {
                return NotFound("Código Cliente é obrigatório");
            }

            var item = await _services.GetAll(model);

            return Ok(item);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult<string>> Post(Local model)
        {
            var resp = await _services.Post(model);

            return Ok(resp);
        }

        [HttpPut]
        [Route("Put")]
        public async Task<ActionResult<string>> Put(Local model)
        {
            var resp =  await _services.Put(model);
            
            return Ok(resp);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var resp = await _services.Delete(id);

            return Ok(resp);
        }
    }
}

using Back.Models;
using Back.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Controllers
{
    [Route("Equipamento")]
    [ApiController]
    public class EquipamentoController : Controller
    {
        private readonly IEquipamentoServices _services;

        public EquipamentoController(IEquipamentoServices services)
        {
            _services = services;
        }


        [HttpPost]
        [Route("Get")]
        public async Task<ActionResult<List<Equipamento>>> Get(Equipamento model)
        {
            var item = await _services.GetAll(model);

            return Ok(item);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult<string>> Post(Equipamento model)
        {
            var resp = await _services.Post(model);

            return Ok(resp);
        }

        [HttpPut]
        [Route("Put")]
        public async Task<ActionResult<string>> Put(Equipamento model)
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

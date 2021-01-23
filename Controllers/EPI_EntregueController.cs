using Back.Models;
using Back.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Controllers
{
    [Route("EPI_Entregue")]
    [ApiController]
    public class EPI_EntregueController : Controller
    {
        private readonly IEPI_EntregueServices _services;

        public EPI_EntregueController(IEPI_EntregueServices services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<List<EPI_Entregue>>> Get(int id_entrega, int id_cargo, int id_integrante, int id_cliente)
        {
            var item = await _services.GetAll(id_entrega, id_cargo, id_integrante, id_cliente);

            return Ok(item);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult<string>> Post(EPI_Entregue model)
        {
            var resp = await _services.Post(model);

            return Ok(resp);
        }

        [HttpPut]
        [Route("Put")]
        public async Task<ActionResult<string>> Put(EPI_Entregue model)
        {
            var resp =  await _services.Put(model);
            
            return Ok(resp);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<string>> Delete(EPI_Entregue model)
        {
            var resp = await _services.Delete(model);

            return Ok(resp);
        }
    }
}

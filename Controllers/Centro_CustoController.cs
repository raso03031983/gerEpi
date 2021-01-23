using Back.Models;
using Back.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Controllers
{
    [Route("Centro_Custo")]
    [ApiController]
    public class Centro_CustoController : Controller
    {
        private readonly ICentro_CustoServices _services;

        public Centro_CustoController(ICentro_CustoServices services)
        {
            _services = services;
        }


        [HttpPost]
        [Route("Get")]
        public async Task<ActionResult<List<Centro_Custo>>> Get(Centro_Custo model)
        {
            var item = await _services.GetAll(model);

            return Ok(item);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult<string>> Post(Centro_Custo model)
        {
            var resp = await _services.Post(model);

            return Ok(resp);
        }

        [HttpPut]
        [Route("Put")]
        public async Task<ActionResult<string>> Put(Centro_Custo model)
        {
            var resp =  await _services.Put(model);
            
            return Ok(resp);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<string>> Delete(Centro_Custo model)
        {
            var resp = await _services.Delete(model);

            return Ok(resp);
        }
    }
}

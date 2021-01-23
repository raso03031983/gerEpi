using Back.Models;
using Back.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Controllers
{
    [Route("GSE")]
    [ApiController]
    public class GSEController : Controller
    {
        private readonly IGSEServices _services;

        public GSEController(IGSEServices services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<List<GSE>>> Get(string desc, int id_cliente)
        {
            var item = await _services.GetAll(desc, id_cliente);

            return Ok(item);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult<string>> Post(GSE model)
        {
            var resp = await _services.Post(model);

            return Ok(resp);
        }

        [HttpPut]
        [Route("Put")]
        public async Task<ActionResult<string>> Put(GSE model)
        {
            var resp =  await _services.Put(model);
            
            return Ok(resp);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<string>> Delete(GSE model)
        {
            var resp = await _services.Delete(model);

            return Ok(resp);
        }
    }
}

using Back.Models;
using Back.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Controllers
{
    [Route("Fornecedor")]
    [ApiController]
    public class FornecedorController : Controller
    {
        private readonly IFornecedorServices _services;

        public FornecedorController(IFornecedorServices services)
        {
            _services = services;
        }

        [HttpPost]
        [Route("Get")]
        public async Task<ActionResult<List<Fornecedor>>> Get(Fornecedor model)
        {
            var item = await _services.GetAll(model.Nome_Fantasia, model.id_cliente);

            return Ok(item);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult<string>> Post(Fornecedor model)
        {
            var resp = await _services.Post(model);

            return Ok(resp);
        }

        [HttpPut]
        [Route("Put")]
        public async Task<ActionResult<string>> Put(Fornecedor model)
        {
            var resp =  await _services.Put(model);
            
            return Ok(resp);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<string>> Delete(Fornecedor model)
        {
            var resp = await _services.Delete(model);

            return Ok(resp);
        }
    }
}

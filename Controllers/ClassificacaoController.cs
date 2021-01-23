using Back.Models;
using Back.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Controllers
{
    [Route("Classificacao")]
    [ApiController]
    public class ClassificacaoController : Controller
    {
        private readonly IClassificacaoServices _services;

        public ClassificacaoController(IClassificacaoServices services)
        {
            _services = services;
        }


        [HttpPost]
        [Route("Get")]
        public async Task<ActionResult<List<Classificacao>>> Get(Classificacao model)
        {
            var item = await _services.GetAll(model);

            return Ok(item);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult<string>> Post(Classificacao model)
        {
            var resp = await _services.Post(model);

            return Ok(resp);
        }

        [HttpPut]
        [Route("Put")]
        public async Task<ActionResult<string>> Put(Classificacao model)
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

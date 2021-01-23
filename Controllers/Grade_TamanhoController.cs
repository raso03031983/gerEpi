using Back.Models;
using Back.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Controllers
{
    [Route("Grade_Tamanho")]
    [ApiController]
    public class Grade_TamanhoController : Controller
    {
        private readonly IGrade_TamanhoServices _services;

        public Grade_TamanhoController(IGrade_TamanhoServices services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("Get/{id_divisao}/{id_cliente}")]
        public async Task<ActionResult<List<Grade_Tamanho>>> Get(int id_divisao, int id_cliente)
        {
            var item = await _services.GetAll(id_divisao, id_cliente);

            return Ok(item);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult<string>> Post(Grade_Tamanho model)
        {
            var resp = await _services.Post(model);

            return Ok(resp);
        }

        [HttpPut]
        [Route("Put")]
        public async Task<ActionResult<string>> Put(Grade_Tamanho model)
        {
            var resp =  await _services.Put(model);
            
            return Ok(resp);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<string>> Delete(Grade_Tamanho model)
        {
            var resp = await _services.Delete(model);

            return Ok(resp);
        }
    }
}

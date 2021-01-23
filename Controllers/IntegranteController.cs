using Back.Models;
using Back.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Controllers
{
    [Route("Integrante")]
    [ApiController]
    public class IntegranteController : Controller
    {
        private readonly IIntegranteServices _services;

        public IntegranteController(IIntegranteServices services)
        {
            _services = services;
        }

        [HttpPost]
        [Route("Get")]
        public async Task<ActionResult<List<Integrante>>> Get(Integrante model)
        {
            var item = await _services.GetAll(model);

            return Ok(item);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult<string>> Post(Integrante model)
        {
            var resp = await _services.Post(model);

            return Ok(resp);
        }

        [HttpPost]
        [Route("PostSenha/{newSenha}/{senhaAtual}/{idUser}")]
        public async Task<ActionResult<string>> PostSenha(string newSenha, string senhaAtual, int idUser)
        {
            var resp = await _services.PostSenha(newSenha, senhaAtual, idUser);

            return Ok(resp);
        }

        [HttpPut]
        [Route("Put")]
        public async Task<ActionResult<string>> Put(Integrante model)
        {
            var resp =  await _services.Put(model);
            
            return Ok(resp);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<string>> Delete(Integrante model)
        {
            var resp = await _services.Delete(model);

            return Ok(resp);
        }
    }
}

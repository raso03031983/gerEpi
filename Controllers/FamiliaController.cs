using Back.Models;
using Back.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Controllers
{
    [Route("Familia")]
    [ApiController]
    public class FamiliaController : Controller
    {
        private readonly IFamiliaServices _services;

        public FamiliaController(IFamiliaServices services)
        {
            _services = services;
        }

        [HttpPost]
        [Route("Get")]
        public async Task<ActionResult<List<Familia>>> Get(Familia model)
        {
            var item = await _services.GetAll(model.Descricao_Familia, Convert.ToInt16(model.id_cliente));

            return Ok(item);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult<string>> Post(Familia model)
        {
            var resp = await _services.Post(model);

            if (resp == "Realizado")
            {
                return Ok(resp);
            }
            else {
                return BadRequest("erroInterno");
            }
        }

        [HttpPut]
        [Route("Put")]
        public async Task<ActionResult<string>> Put(Familia model)
        {
            var resp = await _services.Put(model);

            if (resp == "Realizado")
            {
                return Ok(resp);
            }
            else
            {
                return BadRequest("erroInterno");
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var resp = await _services.Delete(id);

            if (resp == "Realizado")
            {
                return Ok(resp);
            }
            else
            {
                return BadRequest("erroInterno");
            }
        }
    }
}

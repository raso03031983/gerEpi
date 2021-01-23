using Back.Models;
using Back.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.Controllers
{
    [Route("Cargo")]
    [ApiController]
    public class CargoController : Controller
    {
        private readonly ICargoServices _cargoServices;

        public CargoController(ICargoServices cargoServices)
        {
            _cargoServices = cargoServices;
        }

        [HttpPost]
        [Route("Get")]
        public async Task<ActionResult<List<Cargo>>> Get(Cargo model)
        {
            var item = await _cargoServices.GetAll(model.Codigo_Cargo, model.Descricao_Cargo, model.id_cliente);

            return Ok(item);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult<string>> Post(Cargo cargo)
        {
            var resp = await _cargoServices.Post(cargo);

            return Ok(resp);
        }

        [HttpPut]
        [Route("Put")]
        public async Task<ActionResult<string>> Put(Cargo cargo)
        {
            var resp =  await _cargoServices.Put(cargo);
            
            return Ok(resp);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<string>> Delete(Cargo cargo)
        {
            var resp = await _cargoServices.Delete(cargo);

            return Ok(resp);
        }
    }
}

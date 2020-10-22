using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

[Route("v1/integrante_biometria")]
public class Integrante_BiometriaController : Controller
{

  // [Authorize]
  [HttpGet]
  [Route("{idCliente:int}")]
  public async Task<ActionResult<List<Integrante_Biometria>>> Get(int idCliente, [FromServices] DataContext context)
  {
    try
    {
      var item = await context.Integrantes_Biometria.Where(x => x.id_cliente == idCliente).AsNoTracking().ToListAsync();
      return Ok(item);
    }
    catch (Exception error)
    {
      return BadRequest(error);
    }
  }

  [HttpGet]
  [Route("GetById/{id:int}/{idCliente:int}")]
  public async Task<ActionResult<Integrante_Biometria>> GetById(string matricula, int idCliente, [FromServices] DataContext context)
  {
    try
    {
      var item = await context.Integrantes_Biometria.AsNoTracking().FirstOrDefaultAsync(x => x.Matricula == matricula && x.id_cliente == idCliente);
      if (item == null)
      {
        return NotFound("Item não encontrado");
      }
      else
      {
        return Ok(item);
      }
    }
    catch (Exception error)
    {

      return BadRequest(new { message = error.Message });
    }

  }

  [HttpPost]
  [Route("")]
  public async Task<ActionResult<Integrante_Biometria>> Post([FromBody] Integrante_Biometria model, [FromServices] DataContext context)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }
    else
    {
      try
      {
        context.Integrantes_Biometria.Add(model);
        await context.SaveChangesAsync();
        return Ok(model);
      }
      catch (Exception error)
      {
        return BadRequest(new { message = error.Message });
      }
    }
  }

  [HttpPut]
  [Route("{id:int}")]
  public async Task<ActionResult<Integrante_Biometria>> Put(string matricula, [FromBody] Integrante_Biometria model, [FromServices] DataContext context)
  {
    try
    {
      if (model.Matricula == matricula)
      {
        context.Entry<Integrante_Biometria>(model).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return Ok(model);
      }
      else
      {
        return NotFound(new { message = "Item não encontrado" });
      }
    }
    catch (DbUpdateConcurrencyException)
    {
      return BadRequest(new { message = "Item esta sendo atualizado neste momento, tente mais tarde" });
    }
    catch (Exception error)
    {
      return BadRequest(new { message = error.Message });
    }
  }


  [HttpDelete]
  [Route("{id:int}")]
  public async Task<ActionResult<Integrante_Biometria>> Delete(string matricula, [FromServices] DataContext context)
  {

    var item = await context.Integrantes_Biometria.FirstOrDefaultAsync(x => x.Matricula == matricula);
    if (item == null)
    {
      return NotFound("Item não encontrado");
    }

    try
    {
      context.Integrantes_Biometria.Remove(item);
      await context.SaveChangesAsync();
      return Ok(new { message = "Transação Realizada" });
    }
    catch (Exception error)
    {

      return BadRequest(new { message = error.Message });
    }
  }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

[Route("v1/nota_entradadetalhes")]
public class Nota_EntradaDetalhesController : Controller
{

  // [Authorize]
  [HttpGet]
  public async Task<ActionResult<List<Nota_EntradaDetalhes>>> Get([FromServices] DataContext context)
  {
    try
    {
      var item = await context.Nota_EntradaDetalhes.AsNoTracking().ToListAsync();
      return Ok(item);
    }
    catch (Exception error)
    {
      return BadRequest(error);
    }
  }

  [HttpGet]
  [Route("{id:int}")]
  public async Task<ActionResult<Nota_EntradaDetalhes>> GetById(int id, [FromServices] DataContext context)
  {
    try
    {
      var item = await context.Nota_EntradaDetalhes.AsNoTracking().FirstOrDefaultAsync(x => x.id == id);
      return Ok(item);
    }
    catch (Exception error)
    {

      return BadRequest(new { message = error.Message });
    }

  }

  [HttpPost]
  [Route("")]
  public async Task<ActionResult<Nota_EntradaDetalhes>> Post([FromBody] Nota_EntradaDetalhes model, [FromServices] DataContext context)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }
    else
    {
      try
      {
        context.Nota_EntradaDetalhes.Add(model);
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
  public async Task<ActionResult<Nota_EntradaDetalhes>> Put(int id, [FromBody] Nota_EntradaDetalhes model, [FromServices] DataContext context)
  {
    try
    {
      if (model.id == id)
      {
        context.Entry<Nota_EntradaDetalhes>(model).State = EntityState.Modified;
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
  public async Task<ActionResult<Nota_EntradaDetalhes>> Delete(int id, [FromServices] DataContext context)
  {

    var item = await context.Nota_EntradaDetalhes.FirstOrDefaultAsync(x => x.id == id);
    if (item == null)
    {
      return NotFound("Item não encontrado");
    }

    try
    {
      context.Nota_EntradaDetalhes.Remove(item);
      await context.SaveChangesAsync();
      return Ok(new { message = "Transação Realizada" });
    }
    catch (Exception error)
    {

      return BadRequest(new { message = error.Message });
    }
  }
}
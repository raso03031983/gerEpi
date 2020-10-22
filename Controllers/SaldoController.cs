using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

[Route("v1/saldo")]
public class SaldoController : Controller
{

  // [Authorize]
  [HttpGet]
  [Route("{idCliente:int}")]
  public async Task<ActionResult<List<Saldo>>> Get(int idCliente, [FromServices] DataContext context)
  {
    try
    {
      var item = await context.Saldos.Where(x => x.id_cliente == idCliente).AsNoTracking().ToListAsync();
      return Ok(item);
    }
    catch (Exception error)
    {
      return BadRequest(error);
    }
  }

  [HttpGet]
  [Route("{id:int}")]
  public async Task<ActionResult<Saldo>> GetById(int id, int idCliente, [FromServices] DataContext context)
  {
    try
    {
      var item = await context.Saldos.AsNoTracking().FirstOrDefaultAsync(x => x.Codigo_Equipamento == id && x.id_cliente == idCliente);

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
  public async Task<ActionResult<Saldo>> Post([FromBody] Saldo model, [FromServices] DataContext context)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }
    else
    {
      try
      {
        context.Saldos.Add(model);
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
  public async Task<ActionResult<Saldo>> Put(int id, [FromBody] Saldo model, [FromServices] DataContext context)
  {
    try
    {
      if (model.Codigo_Equipamento == id)
      {
        context.Entry<Saldo>(model).State = EntityState.Modified;
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
  public async Task<ActionResult<Saldo>> Delete(int id, [FromServices] DataContext context)
  {

    var item = await context.Saldos.FirstOrDefaultAsync(x => x.Codigo_Equipamento == id);
    if (item == null)
    {
      return NotFound("Item não encontrado");
    }

    try
    {
      context.Saldos.Remove(item);
      await context.SaveChangesAsync();
      return Ok(new { message = "Transação Realizada" });
    }
    catch (Exception error)
    {

      return BadRequest(new { message = error.Message });
    }
  }
}
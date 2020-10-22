using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

[Route("v1/gse_cargolocal")]
public class GSE_CargoLocalController : Controller
{

  // [Authorize]
  [HttpGet]
  [Route("{idCliente:int}")]
  public async Task<ActionResult<List<GSE_CargoLocal>>> Get(int idCliente, [FromServices] DataContext context)
  {
    try
    {
      var item = await context.GSE_CargoLocais.Where(x => x.id_cliente == idCliente).AsNoTracking().ToListAsync();
      return Ok(item);
    }
    catch (Exception error)
    {
      return BadRequest(error);
    }
  }

  [HttpGet]
  [Route("GetById/{id:int}/{idCliente:int}")]
  public async Task<ActionResult<GSE_CargoLocal>> GetById(int id, int idCliente, [FromServices] DataContext context)
  {
    try
    {
      var item = await context.GSE_CargoLocais.AsNoTracking().FirstOrDefaultAsync(x => x.id == id && x.id_cliente == idCliente);
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
  public async Task<ActionResult<GSE_CargoLocal>> Post([FromBody] GSE_CargoLocal model, [FromServices] DataContext context)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }
    else
    {
      try
      {
        context.GSE_CargoLocais.Add(model);
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
  public async Task<ActionResult<GSE_CargoLocal>> Put(int id, [FromBody] GSE_CargoLocal model, [FromServices] DataContext context)
  {
    try
    {
      if (model.id == id)
      {
        context.Entry<GSE_CargoLocal>(model).State = EntityState.Modified;
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
  public async Task<ActionResult<GSE_CargoLocal>> Delete(int id, [FromServices] DataContext context)
  {

    var item = await context.GSE_CargoLocais.FirstOrDefaultAsync(x => x.id == id);
    if (item == null)
    {
      return NotFound("Item não encontrado");
    }

    try
    {
      context.GSE_CargoLocais.Remove(item);
      await context.SaveChangesAsync();
      return Ok(new { message = "Transação Realizada" });
    }
    catch (Exception error)
    {

      return BadRequest(new { message = error.Message });
    }
  }
}
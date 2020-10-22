using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

[Route("v1/categorias")]
public class CategoriaController : Controller
{

  // [Authorize]
  [HttpGet]
  [Route("{idCliente:int}")]
  public async Task<ActionResult<List<Categoria>>> Get(int idCliente, [FromServices] DataContext context)
  {
    try
    {
      var item = await context.Categorias.Where(x => x.id_cliente == idCliente).AsNoTracking().ToListAsync();
      return Ok(item);
    }
    catch (Exception error)
    {
      return BadRequest(error);
    }
  }

  [HttpGet]
  [Route("{id:int}/{idCliente:int}")]
  public async Task<ActionResult<Categoria>> GetById(int id, int idCliente, [FromServices] DataContext context)
  {
    try
    {
      var item = await context.Categorias.AsNoTracking().FirstOrDefaultAsync(x => x.id == id && x.id_cliente == idCliente);
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
  public async Task<ActionResult<Categoria>> Post([FromBody] Categoria model, [FromServices] DataContext context)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }
    else
    {
      try
      {
        context.Categorias.Add(model);
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
  public async Task<ActionResult<Categoria>> Put(int id, [FromBody] Categoria model, [FromServices] DataContext context)
  {
    try
    {
      if (model.id == id)
      {
        context.Entry<Categoria>(model).State = EntityState.Modified;
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
  public async Task<ActionResult<Categoria>> Delete(int id, [FromServices] DataContext context)
  {

    var item = await context.Categorias.FirstOrDefaultAsync(x => x.id == id);
    if (item == null)
    {
      return NotFound("Item não encontrado");
    }

    try
    {
      context.Categorias.Remove(item);
      await context.SaveChangesAsync();
      return Ok(new { message = "Transação Realizada" });
    }
    catch (Exception error)
    {

      return BadRequest(new { message = error.Message });
    }
  }
}
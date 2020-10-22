using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

[Route("v1/entradas")]
public class EntradaController : Controller
{

  // [Authorize]
  [HttpGet]
  [Route("{idCliente:int}")]
  public async Task<ActionResult<List<Entrada>>> Get(int idCliente, [FromServices] DataContext context)
  {
    try
    {
      var item = await context.Entradas.Where(x => x.id_cliente == idCliente).AsNoTracking().ToListAsync();
      return Ok(item);
    }
    catch (Exception error)
    {
      return BadRequest(error);
    }
  }

  [HttpGet]
  [Route("GetById/{id:int}/{idCliente:int}")]
  public async Task<ActionResult<Entrada>> GetById(int idCliente, int idEmpresa, int idSubEquipamento, int idOperacao, [FromServices] DataContext context)
  {
    try
    {
      var item = await context.Entradas.AsNoTracking().FirstOrDefaultAsync(x => x.ID_Empresa == idEmpresa &&
                                                                                x.ID_SubEquipamento == idSubEquipamento &&
                                                                                x.ID_Operacao == idOperacao &&
                                                                                x.id_cliente == idCliente);
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
  public async Task<ActionResult<Entrada>> Post([FromBody] Entrada model, [FromServices] DataContext context)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }
    else
    {
      try
      {
        context.Entradas.Add(model);
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
  public async Task<ActionResult<Entrada>> Put([FromBody] Entrada model, [FromServices] DataContext context)
  {
    try
    {
      context.Entry<Entrada>(model).State = EntityState.Modified;
      await context.SaveChangesAsync();
      return Ok(model);

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
  public async Task<ActionResult<Entrada>> Delete(int idEmpresa, int idSubEquipamento, char idOperacao, [FromServices] DataContext context)
  {

    var item = await context.Entradas.FirstOrDefaultAsync(x => x.ID_Empresa == idEmpresa &&
                                                               x.ID_SubEquipamento == idSubEquipamento &&
                                                               x.ID_Operacao == idOperacao);
    if (item == null)
    {
      return NotFound("Item não encontrado");
    }

    try
    {
      context.Entradas.Remove(item);
      await context.SaveChangesAsync();
      return Ok(new { message = "Transação Realizada" });
    }
    catch (Exception error)
    {

      return BadRequest(new { message = error.Message });
    }
  }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;



// organizar um identificador no vbanco para as saídas


[Route("v1/Saidas")]
public class SaidasController : Controller
{

  // [Authorize]
  [HttpGet]
  public async Task<ActionResult<List<Saidas>>> Get([FromServices] DataContext context)
  {
    try
    {
      var item = await context.Saidas.AsNoTracking().ToListAsync();
      return Ok(item);
    }
    catch (Exception error)
    {
      return BadRequest(error);
    }
  }

  // [HttpGet]
  // [Route("{id:int}")]
  // public async Task<ActionResult<Saidas>> GetById(int id, [FromServices] DataContext context)
  // {
  //   try
  //   {
  //     var item = await context.Saidas.AsNoTracking().FirstOrDefaultAsync(x => x.id == id);
  //     return Ok(item);
  //   }
  //   catch (Exception error)
  //   {

  //     return BadRequest(new { message = error.Message });
  //   }

  // }

  [HttpPost]
  [Route("")]
  public async Task<ActionResult<Saidas>> Post([FromBody] Saidas model, [FromServices] DataContext context)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }
    else
    {
      try
      {
        context.Saidas.Add(model);
        await context.SaveChangesAsync();
        return Ok(model);
      }
      catch (Exception error)
      {
        return BadRequest(new { message = error.Message });
      }
    }
  }

  // [HttpPut]
  // [Route("{id:int}")]
  // public async Task<ActionResult<Saidas>> Put(int id, [FromBody] Saidas model, [FromServices] DataContext context)
  // {
  //   try
  //   {
  //     if (model.ID_Empresa == id)
  //     {
  //       context.Entry<Saidas>(model).State = EntityState.Modified;
  //       await context.SaveChangesAsync();
  //       return Ok(model);
  //     }
  //     else
  //     {
  //       return NotFound(new { message = "Item não encontrado" });
  //     }
  //   }
  //   catch (DbUpdateConcurrencyException)
  //   {
  //     return BadRequest(new { message = "Item esta sendo atualizado neste momento, tente mais tarde" });
  //   }
  //   catch (Exception error)
  //   {
  //     return BadRequest(new { message = error.Message });
  //   }
  // }


  // [HttpDelete]
  // [Route("{id:int}")]
  // public async Task<ActionResult<Saidas>> Delete(int id, [FromServices] DataContext context)
  // {

  //   var item = await context.Saidas.FirstOrDefaultAsync(x => x.ID_Empresa == id);
  //   if (item == null)
  //   {
  //     return NotFound("Item não encontrado");
  //   }

  //   try
  //   {
  //     context.Categorias.Remove(item);
  //     await context.SaveChangesAsync();
  //     return Ok(new { message = "Transação Realizada" });
  //   }
  //   catch (Exception error)
  //   {

  //     return BadRequest(new { message = error.Message });
  //   }
  // }
}
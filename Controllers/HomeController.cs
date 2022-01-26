using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers
{
  [ApiController]
  public class HomeController : ControllerBase
  {
    [HttpGet("/")]
    public IActionResult Get([FromServices] AppDataContext context)
    {
      return Ok(context.Todos.ToList());
    }


    [HttpPost("/")]
    public IActionResult Post(
      [FromBody] TodoList todo,
      [FromServices] AppDataContext context
    )
    {
      context.Todos.Add(todo);
      context.SaveChanges();
      return Created($"/{todo.Id}", todo);
    }


    [HttpGet("/{id:int}")]
    public IActionResult GetById(
      [FromRoute] int id,
      [FromServices] AppDataContext context
    )
    {
      var todo = context.Todos.FirstOrDefault(x => x.Id == id);

      if (todo == null)
        return NotFound();

      return Ok(todo);
    }


    [HttpPut("/{id:int}")]
    public IActionResult Put(
      [FromRoute] int id,
      [FromBody] TodoList request,
      [FromServices] AppDataContext context
    )
    {
      var model = context.Todos.FirstOrDefault(x => x.Id == id);

      if (model == null)
        return NotFound();

      model.Title = request.Title;
      model.Done = request.Done;

      context.Todos.Update(model);
      context.SaveChanges();
      return Ok(model);
    }


    [HttpDelete("/{id:int}")]
    public IActionResult Delete(
      [FromRoute] int id,
      [FromServices] AppDataContext context
    )
    {
      var model = context.Todos.FirstOrDefault(x => x.Id == id);

      if (model == null)
        return NotFound();

      context.Todos.Remove(model);
      context.SaveChanges();
      return Ok(model);
    }

  }
}
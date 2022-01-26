using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers
{
  [ApiController]
  public class HomeController : ControllerBase
  {
    [HttpGet("/")]
    public List<TodoList> Get([FromServices] AppDataContext context)
    {
      return context.Todos.ToList();
    }


    [HttpPost("/")]
    public TodoList Post(
      [FromBody] TodoList todo,
      [FromServices] AppDataContext context
    )
    {
      context.Todos.Add(todo);
      context.SaveChanges();
      return todo;
    }


    [HttpGet("/{id:int}")]
    public TodoList GetById(
      [FromRoute] int id,
      [FromServices] AppDataContext context
    )
    {
      return context.Todos.FirstOrDefault(x => x.Id == id);
    }


    [HttpPut("/{id:int}")]
    public TodoList Put(
      [FromRoute] int id,
      [FromBody] TodoList request,
      [FromServices] AppDataContext context
    )
    {
      var model = context.Todos.FirstOrDefault(x => x.Id == id);

      if (model == null)
        return request;

      model.Title = request.Title;
      model.Done = request.Done;

      context.Todos.Update(model);
      context.SaveChanges();
      return model;
    }


    [HttpDelete("/{id:int}")]
    public TodoList Delete(
      [FromRoute] int id,
      [FromServices] AppDataContext context
    )
    {
      var model = context.Todos.FirstOrDefault(x => x.Id == id);

      context.Todos.Remove(model);
      context.SaveChanges();
      return model;
    }

  }
}
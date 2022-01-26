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
  }
}
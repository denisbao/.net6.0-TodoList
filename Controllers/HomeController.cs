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
  }
}
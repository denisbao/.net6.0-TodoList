namespace Todo.Models
{
  public class TodoList
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public bool Done { get; set; }
    public DateTime CreatedAt { get; set; }
  }
}
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]

public class TodoController : ControllerBase {
  private static List<Todo> todos = new();

  private readonly ILogger<TodoController> logger;

  public TodoController(ILogger<TodoController> logger) {
    this.logger = logger;
  }

  [HttpGet(Name = "GetTodos")]
  public List<Todo> Get() {
    return todos;
  }
  
  [HttpPost(Name = "PostTodos")]
  public List<Todo> Create(Todo todo) {
    var oldIndex = todos.FindIndex(it => it.id == todo.id);
    if (oldIndex == -1) todos = todos.Prepend(todo).ToList();
    else todos[oldIndex] = todo;
    logger.Log(LogLevel.Information, $"Saved {todo}");
    return todos;
  }
  
  [HttpDelete(Name = "DeleteTodos")]
  public List<Todo> Delete(Todo todo) {
    todos = todos.Where(t => t.id != todo.id).ToList();
    return todos;
  }
}
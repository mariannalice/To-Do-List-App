using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
  private static List<Task> Tasks = new();

  [HttpGet]
  public IActionResult GetTasks() => Ok(Tasks);

  [HttpPost]
  public IActionResult AddTask([FromBody] Task newTask)
  {
    newTask.Id = Tasks.Count + 1;
    Tasks.Add(newTask);
    return CreatedAtAction(nameof(GetTasks), new { id = newTask.Id }, newTask);
  }

  [HttpDelete("{id}")]
  public IActionResult DeleteTask(int id)
  {
    var task = Tasks.FirstOrDefault(t => t.Id == id);
    if (task == null) 
    return NotFound();

    Tasks.Remove(task);
    return NoContent();
  }

}
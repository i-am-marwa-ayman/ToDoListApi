using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Data;


namespace ToDoList.controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase {
        private readonly Entity context;

        public TaskController(Entity _context){
            context = _context;
        }
        [HttpGet]
        public IActionResult GetAllTasks(){
            List<ToDoTask>AllTasks = context.ToDoTasks.ToList();
            return Ok(AllTasks);
        }
        [HttpGet("{id:int}",Name = "new task")]
        public IActionResult GetTaskById([FromRoute] int id){
            ToDoTask? task = context.ToDoTasks.FirstOrDefault(e => e.Id == id);
            return task == null ? NotFound() : Ok(task);
        }
        [HttpGet("{name:alpha}")]
        public IActionResult GetTaskByTitle([FromRoute] string title){
            ToDoTask? task = context.ToDoTasks.FirstOrDefault(e => e.Title == title);
            return task == null ? NotFound() : Ok(task);
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateTask([FromRoute] int id, [FromBody] ToDoTask task){
            if(ModelState.IsValid){
                ToDoTask? OldTask = context.ToDoTasks.FirstOrDefault(e => e.Id == id);
                if (OldTask != null) {
                    OldTask.Title = task.Title;
                    OldTask.DueDate = task.DueDate;
                    OldTask.Priority = task.Priority;
                    OldTask.Description = task.Description ?? OldTask.Description;
                    OldTask.Tags = task.Tags ?? OldTask.Tags;
                    context.SaveChanges();
                    return StatusCode(204);
                }
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteTask([FromRoute] int id){
            ToDoTask? task = context.ToDoTasks.FirstOrDefault(e => e.Id == id);
            if(task != null){
                context.ToDoTasks.Remove(task);
                context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult AddTask([FromBody] ToDoTask task){
            if(ModelState.IsValid){
                context.ToDoTasks.Add(task);
                context.SaveChanges();
                return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
            }
            return BadRequest(ModelState);
        }

    }
}

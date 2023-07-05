using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using TaskManagementSystem.Repositories;
using TaskManagementSystem.Repositories.Implemenatation;
using TaskManagementSystem.Repositories.Models;
using TaskManagementSystem.WebApi.Database;
using TaskManagementSystem.WebApi.Database.Entities;
using TaskManagementSystem.WebApi.Models;
using TaskManagementSystem.WebApi.Utilities;
using Task = TaskManagementSystem.WebApi.Database.Entities.Task;

namespace TaskManagementSystem.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TaskController : ControllerBase
    {
        public TaskRepository Repo { get; }
        public TaskController(TaskRepository repo)
        {
            Repo = repo;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var task = Repo.GetById(id);
            if (task == null)
            {
                return NotFound("Task not found");
            }
            return Ok(task);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var tasks = Repo.GetAll();
            return Ok(tasks);
        }
        [HttpPost]
        public ActionResult AddTask(AddTaskModel model)
        {
            var Add = Repo.Add(model);
            return Ok(Add);
        }
        [HttpPost("{id}")]
        public IActionResult EditTask(int id, UpdatetaskModel model)
        {
            var updatedTask = Repo.Update(model, id);
            return Ok(updatedTask);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool deleted = Repo.Delete(id);
            return Ok(deleted);
        }
    }
}

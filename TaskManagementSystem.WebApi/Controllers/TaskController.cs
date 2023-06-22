using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using TaskManagementSystem.Repositories;
using TaskManagementSystem.Repositories.Implemenatation;
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
        private readonly AppDbContext db;

        public TaskRepository Repo { get; }
        public TaskController(AppDbContext _db, TaskRepository repo)
        {
            db = _db;
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

            var found = db.TaskStatuses.FirstOrDefault(x => x.Status == "Pending");

            var task = new Task
            {
                Title = model.Title,
                Description = model.Description,
                Status = found
            };
            var Add = Repo.Add(task);
            if (Add == true)
            {
                return Ok(task);
            }
            else
            {
                return Ok(false);
            }
        }
        // Edit Task EndPoint For new Branch
        [HttpPost("{id}")]
        public IActionResult EditTask(int id, AddTaskModel model)
        {
            var task = Repo.GetById(id);
            if (task == null)
            {
                return NotFound("Task not found");
            }
            task.Title = model.Title;
            task.Description = model.Description;
            var updatedTask = Repo.Update(task);
            if (updatedTask != null)
            {
                return Ok(updatedTask);
            }
            else
            {
                return Ok(false);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var task = Repo.GetById(id);
            if (task == null)
            {
                return Ok(false);
            }
            bool deleted = Repo.Delete(id);
            if (deleted == true)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }
    }
}

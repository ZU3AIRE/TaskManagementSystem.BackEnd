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
            //return Ok(db.Tasks.FirstOrDefault(x => x.TaskId == id));
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var tasks = Repo.GetAll();
            return Ok(tasks);
            // return Ok(db.Tasks.ToList());
        }

        [HttpPost]
        public ActionResult AddTask(AddTaskModel model)
        {
            var task = new Task
            {
                Title = model.Title,
                Description = model.Description,
                IsActive = model.IsActive
            };
            var Add = Repo.Add(task);
            if (Add==true)
            {
                return Ok(task);
            }
            else
            {
                return Ok(false);
            }

            //Database.Entities.Task task = new Database.Entities.Task
            //{
            //    Title = model.Title,
            //    Description = model.Description,
            //    IsActive = model.IsActive

            //};
            //db.Tasks.Add(task);
            //db.SaveChanges();
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




            //if (db.Tasks.Any(x => x.TaskId == id))
            //{
            //    db.Tasks.Remove(db.Tasks.Find(id)!);
            //    db.SaveChanges();

            //    return Ok("Deleted");
            //}
            //else
            //{
            //    return NotFound("Task does not exist");
            //}
        }

    }
}

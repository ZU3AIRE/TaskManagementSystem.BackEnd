using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
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

        public TaskController(AppDbContext _db)
        {
            db = _db;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(db.Tasks.FirstOrDefault(x => x.TaskId == id));
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(db.Tasks.ToList());
        }

        [HttpPost]
        public ActionResult AddTask(AddTaskModel model)
        {
            Database.Entities.Task task = new Database.Entities.Task
            {
                Title = model.Title,
                Description = model.Description,
                IsActive = model.IsActive

            };
            // Create new object of Entity Task
            //Task entity = model.ToEntity();


            //// For adding Task Status Pending
            //var status = db.TaskStatuses.First(x => x.Status == "Pending");
            //entity.Status = status!;

            //// Add new object to the DbSet
            db.Tasks.Add(task);
            db.SaveChanges();

            return Ok(task);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (db.Tasks.Any(x => x.TaskId == id))
            {
                db.Tasks.Remove(db.Tasks.Find(id)!);
                db.SaveChanges();

                return Ok("Deleted");
            }
            else
            {
                return NotFound("Task does not exist");
            }
        }

    }
}

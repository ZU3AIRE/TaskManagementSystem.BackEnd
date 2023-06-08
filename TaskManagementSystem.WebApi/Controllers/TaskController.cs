using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using TaskManagementSystem.WebApi.Database;
using TaskManagementSystem.WebApi.Models;
using TaskManagementSystem.WebApi.Utilities;

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
            // Create new object of Entity Task
            Database.Entities.Task entity = model.ToEntity();

            // For adding Task Status Pending
            var status = db.TaskStatuses.Find(1); // 1 is the TaskStatusId of status "PENDING"
            entity.Status = status!;

            // Add new object to the DbSet
            db.Tasks.Add(entity);
            db.SaveChanges();

            return Ok(entity);
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

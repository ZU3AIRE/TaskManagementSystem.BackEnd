using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.WebApi.Database;

namespace TaskManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskStatusController : ControllerBase
    {
        private readonly AppDbContext db;

        public TaskStatusController(AppDbContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.TaskStatuses.ToList());
        }

        [HttpPost]
        public IActionResult AddStatus(string status)
        {
            if (db.TaskStatuses.Any(x => x.Status == status))
            {
                return Ok("Already Exist.");
            }
            else
            {
                Database.Entities.TaskStatus taskStatus = new Database.Entities.TaskStatus
                {
                    Status = status
                };

                db.TaskStatuses.Add(taskStatus);
                db.SaveChanges();

                return Ok(taskStatus);
            }
        }

        [HttpDelete("{status}")]
        public IActionResult Delete(string status)
        {
            if(db.TaskStatuses.Any(x =>x.Status == status))
            {
                db.TaskStatuses.Remove(db.TaskStatuses.First(x => x.Status == status));
                db.SaveChanges();
                return Ok("Deleted");
            }
            else
            {
                return NotFound("Specified TaskStatus does not exist");

            }
        }
    }
}

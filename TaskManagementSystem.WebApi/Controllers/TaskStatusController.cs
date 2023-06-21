using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Repositories.Implemenatation;
using TaskManagementSystem.WebApi.Database;
using TaskManagementSystem.WebApi.Database.Entities;
using TaskManagementSystem.WebApi.Models;

namespace TaskManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskStatusController : ControllerBase
    {
        private readonly AppDbContext db;
        private readonly TaskStatusRepository repo;

        public TaskStatusController(AppDbContext _db, TaskStatusRepository repo)
        {
            db = _db;
            this.repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tasksStatus = repo.GetAll();
            return Ok(tasksStatus);
        }

        [HttpPost]
        public IActionResult AddStatus(string status, TaskStatusModel model)
        {
            var task = new Database.Entities.TaskStatus
            {
               Status = model.Status,
            };
            var Add = repo.Add(task);
            if (Add == true)
            {
                return Ok(task);
            }
            else
            {
                return Ok(false);
            }


        }

        [HttpDelete("{status}")]
        public IActionResult Delete(string status)
        {
            if (db.TaskStatuses.Any(x => x.Status == status))
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

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
     
        private readonly TaskStatusRepository repo;

        public TaskStatusController(TaskStatusRepository repo)
        {
           this.repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tasksStatus = repo.GetAll();
            return Ok(tasksStatus);
        }

        [HttpPost]
        public IActionResult AddStatus(string status, TaskManagementSystem.WebApi.Models.TaskStatusModel model)
        {
            var Add = repo.Add(model);
            return Ok(Add);
            
        }

        [HttpDelete("{status}")]
        public IActionResult Delete(string status)
        {

            var deleted = repo.Delete(status);
            if (deleted)
            {
                return Ok("Deleted");
            }

            return NotFound("Not Found");

        }
    }
}

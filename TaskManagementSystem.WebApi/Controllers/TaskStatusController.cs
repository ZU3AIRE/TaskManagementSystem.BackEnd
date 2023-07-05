using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Data;
using TaskManagementSystem.Repositories;
using TaskManagementSystem.Repositories.Implementtation;

namespace TaskManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskStatusController : ControllerBase
    {
        private readonly ITaskStatusRepository Repo;

        public TaskStatusController(ITaskStatusRepository _repo)
        {
            Repo = _repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var taskStatuses = Repo.GetAll();
            return Ok(taskStatuses);
        }

        [HttpPost]
        public IActionResult AddStatus(string status)
        {
            var taskStatus = new Data.Entities.TaskStatus
            {
                Status = status
            };

            var isAdded = Repo.AddStatus(taskStatus);
            if (isAdded)
            {
                return Ok(taskStatus);
            }
            else
            {
                return Ok("Already Exist.");
            }
        }

        [HttpDelete("{status}")]
        public IActionResult Delete(string status)
        {
            var deleted = Repo.Delete(status);
            if (deleted)
            {
                return Ok("Deleted");
            }

            return NotFound("Specified TaskStatus does not exist");
        }
    }
}

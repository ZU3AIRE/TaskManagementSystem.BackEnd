using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Database;
using TaskManagementSystem.Repositories;

namespace TaskManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskStatusController : ControllerBase
    {
        private readonly ITaskStatusRepository taskStatusRepository;

        public TaskStatusController(ITaskStatusRepository _taskStatusRepository)
        {
            taskStatusRepository = _taskStatusRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(taskStatusRepository.GetAll());
        }

        [HttpPost]
        public IActionResult AddStatus(string status)
        {
            return Ok(taskStatusRepository.AddStatus(status));
        }

        [HttpDelete("{status}")]
        public IActionResult Delete(string status)
        {
            return Ok(taskStatusRepository.DeleteStatus(status));
        }
    }
}

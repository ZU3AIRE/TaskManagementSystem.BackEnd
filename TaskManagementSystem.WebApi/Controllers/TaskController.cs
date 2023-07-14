using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Repositories;
using TaskManagementSystem.Repositories.Models;

namespace TaskManagementSystem.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository taskRepo;

        public TaskController(ITaskRepository _taskRepo)
        {
            taskRepo = _taskRepo;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(taskRepo.GetById(id));
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(taskRepo.GetAll());
        }
        [HttpGet("{title}")]
        public IActionResult GetBySearch(string title)
        {
            return Ok(taskRepo.GetTaskBySearch(title));
        }
        [HttpGet("{statusId}")]
        public IActionResult GetByStatus(int statusId)
        {
            return Ok(taskRepo.GetTaskByStatusId(statusId));
        }

        [HttpPost]
        public ActionResult AddTask(TaskModel model)
        {
            return Ok(taskRepo.AddTask(model));
        }

        [HttpPost("{id}")]
        public ActionResult UpdateTask(UpdateTaskModel model, int id)
        {
            return Ok(taskRepo.UpdateTask(model, id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(taskRepo.DeleteTask(id));
        }

        //[HttpPost("{taskId}")]
        //public ActionResult AssignTo(int taskId, int developerId)
        //{
        //    return Ok(taskRepo.AssignTo(taskId, developerId));
        //}
    }
}

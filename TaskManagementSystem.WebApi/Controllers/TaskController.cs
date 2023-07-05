using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using TaskManagementSystem.Repositories;
using TaskManagementSystem.Repositories.Models;
using TaskManagementSystem.WebApi.Utilities;

namespace TaskManagementSystem.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TaskController : ControllerBase
    {

        private readonly ITaskRepository taskRepository;

        public TaskController(ITaskRepository _taskRepository)
        {
            taskRepository = _taskRepository;
        }



        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var task = taskRepository.Get(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var tasks = taskRepository.GetAll();

            return Ok(tasks);
        }

        [HttpPost]
        public ActionResult AddTask(AddTaskModel model)
        {
            var success = taskRepository.AddTask(model);

            if (!success)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult EditTask(Taskmodel model ,int id)
        {
            if (ModelState.IsValid)
            {
                var res = taskRepository.EditTask(model, id);
                if (res)
                { 
                    return Ok(); 
                }
                else
                {
                    return BadRequest("Failed to edit the task."); 
                }
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = taskRepository.Delete(id);

            if (!success)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}

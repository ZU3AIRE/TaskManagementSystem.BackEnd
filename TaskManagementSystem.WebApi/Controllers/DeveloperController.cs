using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Data;
using TaskManagementSystem.Data.Entities;
using TaskManagementSystem.Repositories;
using TaskManagementSystem.Repositories.Models;

namespace TaskManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperRepository developerRepository;

        public DeveloperController(IDeveloperRepository _developerRepository)
        {
            developerRepository = _developerRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = developerRepository.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = developerRepository.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddDeveloper(DeveloperModel model)
        {
            bool result = developerRepository.AddDeveloper(model);
            if (result)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }

        [HttpPost]
        public IActionResult UpdateDeveloper(int id, DeveloperModel model)
        {
            bool result = developerRepository.UpdateDeveloper(id, model);
            if (result)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDeveloper(int id)
        {
            bool result = developerRepository.DeleteDeveloper(id);
            if (result)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }
    }
}

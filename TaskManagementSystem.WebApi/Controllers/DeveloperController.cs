using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Repositories;
using TaskManagementSystem.Repositories.Models;

namespace TaskManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperRepository developerRepo;

        public DeveloperController(IDeveloperRepository _developerRepo)
        {
            developerRepo = _developerRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(developerRepo.GetAll());
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            return Ok(developerRepo.Get(id));
        }

        [HttpPost]
        public IActionResult AddDeveloper(DeveloperModel model)
        {
            return Ok(developerRepo.AddDeveloper(model));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDeveloper(int id)
        {
            return Ok(developerRepo.RemoveDeveloper(id));
        }

    }
}

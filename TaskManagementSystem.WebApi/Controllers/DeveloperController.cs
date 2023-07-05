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
    public class DeveloperController : ControllerBase
    {
        private readonly AppDbContext db;

        public DeveloperRepository repo { get; }

        public DeveloperController(AppDbContext _db, DeveloperRepository Repo)
        {
            db = _db;
            repo = Repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tasks = repo.GetAll();
            return Ok(tasks);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var dev = repo.GetById(id);
            if (dev == null)
            {
                return NotFound("Task not found");
            }
            return Ok(dev);
        }
        [HttpPost]
        public IActionResult AddDeveloper(DeveloperModel devModel)
        {

            var Add = repo.Add(devModel);
            return Ok(Add);
           
        }
        [HttpPost]
        public IActionResult UpdateDeveloper(int id, DeveloperModel model)
        {
            var dev = db.Developers.Find(id);
            dev.Name = model.Name;
            dev.Email = model.Email;
            dev.Password = model.Password;
            //dev.IsActive = model.IsActive;
            db.SaveChanges();
            return Ok(true);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDeveloper(int id)
        {
            var dev = repo.GetById(id);
            if (dev == null)
            {
                return Ok(false);
            }
            bool deleted = repo.Delete(id);
            if (deleted == true)
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

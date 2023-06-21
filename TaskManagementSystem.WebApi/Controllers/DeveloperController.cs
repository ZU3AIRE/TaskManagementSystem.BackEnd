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
            try
            {
                //  var found = db.TaskStatuses.FirstOrDefault(x => x.Status == "Pending");

                var dev = new Developer
                {
                    Name = devModel.Name,
                    Email = devModel.Email,
                    Password = devModel.Password
                };
                var Add = repo.Add(dev);
                if (Add == true)
                {
                    return Ok(dev);
                }
                else
                {
                    return Ok(false);
                }
            }
            catch (Exception)
            {
                return Ok(false);
            }

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

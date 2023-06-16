using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public DeveloperController(AppDbContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dev = db.Developers.ToList();
            return Ok(dev);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var dev = db.Developers.Find(id);
            return Ok();
        }
        [HttpPost]
        public IActionResult AddDeveloper(DeveloperModel devModel)
        {
            try
            {
                Developer dev = new Developer
                {
                    //  UserId = userModel.UserId,
                    Name = devModel.Name,
                    Email = devModel.Email,
                    Password = devModel.Password,
                    IsActive = devModel.IsActive

                };

                db.Developers.Add(dev);
                db.SaveChanges();


                return Ok(true);
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
            dev.IsActive = model.IsActive;


            db.SaveChanges();
            return Ok(true);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDeveloper(int id)
        {
            var dev = db.Developers.Find(id);
            if (dev == null)
            {
                return Ok(false);
            }

            db.Developers.Remove(dev);
            db.SaveChanges();
            return Ok(true);

        }

    }
}

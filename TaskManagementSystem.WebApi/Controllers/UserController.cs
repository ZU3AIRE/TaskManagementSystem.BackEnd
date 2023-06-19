using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.WebApi.Database;
using TaskManagementSystem.WebApi.Database.Entities;
using TaskManagementSystem.WebApi.Models;
using TaskManagementSystem.WebApi.Utilities;

namespace TaskManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private AppDbContext db;
        public UserController(AppDbContext _db)
        {

            db = _db;

        }
        public AppDbContext Db { get; }
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = db.Users
           .Where(x => x.IsActive == true)
           .Select(x => new
           {
               x.UserId,
               x.Name,
               x.Email,
           }).ToList();

            return Ok(users);

        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = db.Users
            .Where(x => x.UserId == id)
            .Select(x => new
            {
                //x.UserId,
                x.Name,
                x.Email,
            })
           .FirstOrDefault();

            if (user == null)
            {
                return Ok(false);
            }

            return Ok(user);
        }
        [HttpPost]
        public IActionResult AddUser(UserModel userModel)
        {
            try
            {
                User user = new User
                {
                    Name = userModel.Name,
                    Email = userModel.Email,
                    Password = userModel.Password,
                    //IsActive = userModel.IsActive

                };
                // SAVE DATA TO DB
                db.Users.Add(user);
                db.SaveChanges();
                return Ok(true);
            }
            catch (Exception)
            {
                return Ok(false);
            }
        }
        [HttpPost]
        public IActionResult UpdateUser(int id, UserModel model)
        {
            var user = db.Users.Find(id);
            user.Name = model.Name;
            user.Email = model.Email;
            user.Password = model.Password;
            //user.IsActive = model.IsActive;
            //SAVE DATA TO DB
            db.SaveChanges();
            return Ok(true);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = db.Users.Find(id);
            if (user == null)
            {
                return Ok(false);
            }
            user.IsActive = false;
            db.SaveChanges();
            return Ok(true);
        }
    }
}


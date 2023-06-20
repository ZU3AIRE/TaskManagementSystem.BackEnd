using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Repositories;
using TaskManagementSystem.Repositories.Implemenatation;
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
        public UserController(AppDbContext _db, UserRepository repo)
        {
            db = _db;
            Repo = repo;
        }

        public AppDbContext Db { get; }
        public UserRepository Repo { get; }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = Repo.GetAll();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = Repo.GetById(id);
            if (user == null)
            {
                return Ok(false);
            }
            var userModel = new UserModel
            {
                Name = user.Name,
                Email = user.Email
            };
            return Ok(userModel);
        }
        [HttpPost]
        public IActionResult AddUser(UserModel userModel)
        {
            User user = new User
            {
                Name = userModel.Name,
                Email = userModel.Email,
                Password = userModel.Password
            };

            bool AddUser = Repo.Add(user);
            if (AddUser == false)
            {
                return Ok(false);
            }
            else
            {
                return Ok(true);
            }
        }

        [HttpPost]
        public IActionResult UpdateUser(int id, UserModel model)
        {
            User? user = Repo.GetById(id);
            if (user == null)
            {
                return Ok(false);
            }

            user.Name = model.Name;
            user.Email = model.Email;
            user.Password = model.Password;

            bool result = Repo.Update(user, id);
            if (result == false)
            {
                return Ok(false);
            }
            else
            {
                return Ok(true);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            bool result = Repo.Delete(id);
            if (result != true)
            {
                return Ok(false);
            }
            else
            {
                return Ok(true);
            }
        }

    }
}


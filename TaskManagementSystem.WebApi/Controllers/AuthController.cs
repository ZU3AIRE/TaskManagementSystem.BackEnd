using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.WebApi.Database;
using TaskManagementSystem.WebApi.Database.Entities;
using TaskManagementSystem.WebApi.Models;
using TaskManagementSystem.WebApi.Utilities;

namespace TaskManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext db;

        public AuthController(AppDbContext _db)
        {
            db = _db;
        }

        // Login Method
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            // Find user from db
            var user = db.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);

            if (user == null)
            {
                return Ok("Incorrect username or password.");
            }
            else
            {
                return Ok(true);
            }
        }

        // Signup Method
        [HttpPost]
        public IActionResult Signup(SignupModel model)
        {
            if (db.Users.Any(x => x.Email == model.Email))
            {
                return Ok("User with same email, already exist.");
            }
            else
            {
                // Make user object
                User user = model.ToEntity();

                // Add newly created object to the DbSet
                db.Users.Add(user);
                db.SaveChanges();

                return Ok(user);
            }
        }

     

    }
}

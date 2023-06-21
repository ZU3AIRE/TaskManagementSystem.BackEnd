using Microsoft.AspNetCore.Mvc;

using TaskManagementSystem.WebApi.Utilities;
using TaskManagementSystem.Repositories;
using TaskManagementSystem.Repositories.Models;
using TaskManagementSystem.Data.Entities;

namespace TaskManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository userRepository;

        public AccountController(IAccountRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        // Login Method
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            var user = userRepository.Login(model.Email, model.Password);

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
            var existingUser = userRepository.GetByEmail(model.Email);

            if (existingUser != null)
            {
                return Ok("User with the same email already exists.");
            }
            else
            {
                var user = new User
                {
                    Email = model.Email,
                    Password = model.Password,
                    // Set other properties
                };

                userRepository.Signup(user);

                return Ok(user);
            }
        }
    }
}

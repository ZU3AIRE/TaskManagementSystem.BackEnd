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
            bool result = userRepository.Signup(model);
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

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Repositories;
using TaskManagementSystem.Repositories.Models;

namespace TaskManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepo;

        public AccountController(IAccountRepository _accountRepo)
        {
            accountRepo = _accountRepo;
        }
        // Login Method
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            return Ok(accountRepo.Login(model));
        }

        // Signup Method
        [HttpPost]
        public IActionResult Signup(SignupModel model)
        {
            return Ok(accountRepo.SignUp(model));
        }
    }
}

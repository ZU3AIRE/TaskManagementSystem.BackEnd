using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Repositories.Models;
using TaskManagementSystem.Repositories;
using TaskManagementSystem.Data;
using TaskManagementSystem.Data.Entities;

namespace TaskManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = userRepository.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = userRepository.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser(UserModel userModel)
        {
            bool result = userRepository.AddUser(userModel);
            if (result)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }

        [HttpPost]
        public IActionResult UpdateUser(int id, UserModel model)
        {
            bool result = userRepository.UpdateUser(id, model);
            if (result)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            bool result = userRepository.DeleteUser(id);
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

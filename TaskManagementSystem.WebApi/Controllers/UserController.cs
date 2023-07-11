using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Repositories;

namespace TaskManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepo;

        public UserController(IUserRepository _userRepo)
        {
            userRepo = _userRepo;
        }

        //Get All User

        [HttpGet]
        public IActionResult GetAllUser()
        {
            return Ok(userRepo.GetAll());
        }

        //Get All User

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
           
                return Ok(userRepo.GetById(id));
        }

        //Get All User

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(userRepo.Delete(id));
        }
    }
}

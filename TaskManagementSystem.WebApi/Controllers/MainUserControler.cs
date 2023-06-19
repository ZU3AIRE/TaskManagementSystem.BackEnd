﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.WebApi.Database.Entities;
using TaskManagementSystem.WebApi.Database;
using TaskManagementSystem.WebApi.Models;

namespace TaskManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainUserControler : ControllerBase
    {
        private AppDbContext db;

        public MainUserControler(AppDbContext _db)
        {

            db = _db;

        }

        public AppDbContext Db { get; }

        [HttpGet]
        public IActionResult GetAll()
        {
            var user = db.Users.ToList();
            return Ok(user.Where(x => x.IsActive == true));
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = db.Users.FirstOrDefault(u => u.UserId == id && u.IsActive);
            if (user == null)
            {
                return NotFound();
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
                    //  UserId = userModel.UserId,
                    Name = userModel.Name,
                    Email = userModel.Email,
                    Password = userModel.Password,
                    //IsActive = userModel.IsActive

                };

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
            var user = db.Users.Find(id)
;         
            user.Name = model.Name;
            user.Email = model.Email;
            user.Password = model.Password;
            //user.IsActive = model.IsActive;


            db.SaveChanges();
            return Ok(true);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = db.Users.Find(id)
;
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

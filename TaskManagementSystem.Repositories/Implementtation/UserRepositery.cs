using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Data;
using TaskManagementSystem.Data.Entities;
using TaskManagementSystem.Repositories.Models;

namespace TaskManagementSystem.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext db;

        public UserRepository(AppDbContext dbContext)
        {
            db = dbContext;
        }

        public bool AddUser(UserModel model)
        {
            try
            {
                User user = new User
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password,
                    IsActive = true
                };

                db.Users.Add(user);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteUser(int id)
        {
            var user = db.Users.Find(id);
            if (user == null)
            {
                return false;
            }

            user.IsActive = false;
            db.SaveChanges();
            return true;
        }

        public User Get(int id)
        {
            var user = db.Users.FirstOrDefault(u => u.UserId == id && u.IsActive);
            return user;
        }

        public User[] GetAll()
        {
            var users = db.Users.Where(u => u.IsActive).ToArray();
            return users;
        }

        public bool UpdateUser(int id, UserModel model)
        {
            var user = db.Users.Find(id);
            if (user == null)
            {
                return false;
            }

            user.Name = model.Name;
            user.Email = model.Email;
            user.Password = model.Password;
            //user.IsActive = model.IsActive;

            db.SaveChanges();
            return true;
        }
    }
}

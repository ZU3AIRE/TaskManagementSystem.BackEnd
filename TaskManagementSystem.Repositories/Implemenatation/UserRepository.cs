using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.WebApi.Database;
using TaskManagementSystem.WebApi.Database.Entities;
namespace TaskManagementSystem.Repositories.Implemenatation
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext db;
        public UserRepository(AppDbContext _db)
        {
            db = _db;
        }
        public User[] GetAll()
        {
            return db.Users.Where(x => x.IsActive == true).ToArray();
        }
        public User? GetById(int id)
        {
            return db.Users.Find(id);
        }
        public bool Add(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return true;
        }
        public bool Update(User user, int id)
        {
            var users = db.Users.Find(id);
            user.Name = users.Name;
            user.Email = users.Email;
            user.Password = users.Password;
            db.SaveChanges();
            return true;
        }
        public bool Delete(int id)
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

    }
}

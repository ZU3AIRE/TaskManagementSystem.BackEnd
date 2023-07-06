using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TaskManagementSystem.Data;
using TaskManagementSystem.Data.Entities;
using TaskManagementSystem.Repositories.Models;

namespace TaskManagementSystem.Repositories.Implementation
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext db;

        public AccountRepository(AppDbContext _db)
        {
            db = _db;
        }

        public User Login(string email, string password)
        {
            return db.Users.Where(x => x.IsActive == true).FirstOrDefault(x => x.Email == email && x.Password == password);
        }

        public User GetByEmail(string email)
        {
            return db.Users.Where(x => x.IsActive == true).FirstOrDefault(x => x.Email == email);
        }

        public bool Signup(SignupModel model)
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Database;
using TaskManagementSystem.Database.Entities;
using TaskManagementSystem.Repositories.Models;
using TaskManagementSystem.Repositories.Utilities;

namespace TaskManagementSystem.Repositories.Implementation
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext db;

        public AccountRepository(AppDbContext _db)
        {
            db = _db;
        }
        public bool Login(LoginModel model)
        {
            // Find user from db
            var user = db.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password && x.IsActive == true);

            if (user != null)
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        public bool SignUp(SignupModel model)
        {
            if (db.Users.Any(x => x.Email == model.Email))
            {
                return (false);
            }
            else
            {
                // Make user object
                User user = model.ToEntity();

                // Add newly created object to the DbSet
                db.Users.Add(user);
                db.SaveChanges();

                return (true);
            }
        }
    }
}

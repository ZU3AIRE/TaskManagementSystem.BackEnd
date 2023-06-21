using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Data;
using TaskManagementSystem.Data.Entities;

namespace TaskManagementSystem.Repositories.Implementtation
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
            return db.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
        }

        public User GetByEmail(string email)
        {
            return db.Users.FirstOrDefault(x => x.Email == email);
        }

        public void Signup(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
    }
}

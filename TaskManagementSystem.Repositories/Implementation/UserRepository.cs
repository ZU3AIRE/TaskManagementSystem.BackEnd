using TaskManagementSystem.Database;
using TaskManagementSystem.Database.Entities;

namespace TaskManagementSystem.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext db;

        public UserRepository(AppDbContext _db)
        {
            db = _db;
        }

        //Method for Soft Delete User
        public bool Delete(int id)
        {
            var user = db.Users.FirstOrDefault(x => x.UserId == id && x.IsActive == true);
            if (user != null)
            {
                user.IsActive = false;
                db.Users.Update(user);
                db.SaveChanges();
                return (true);
            }
            else
            {
                return (false);
            }
        }

        //Method for Get All User
        public User[] GetAll()
        {
            return(db.Users.Where(x => x.IsActive == true)).ToArray();
        }

        //Method for Get User by Id
        public User GetById(int id)
        {
            return (db.Users.FirstOrDefault(x => x.UserId == id && x.IsActive == true)!);
        }   
    }
}

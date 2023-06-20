using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Database;
using TaskManagementSystem.WebApi.Database.Entities;
namespace TaskManagementSystem.Repositories
{
    public interface IUserRepository
    {
        User[] GetAll();
        User GetById(int id);
        bool Add(User model);
        bool Update(User user,int id);
        bool Delete(int id);
    }
}

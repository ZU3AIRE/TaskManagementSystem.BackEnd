using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Data.Entities;
using TaskManagementSystem.Repositories.Models;

namespace TaskManagementSystem.Repositories
{
    public interface IUserRepositery 
    {
        User[] GetAll();
        User Get(int id);
        bool AddUser(UserModel model);
        bool UpdateUser(int id, UserModel model);
        bool DeleteUser(int id);
    }
}

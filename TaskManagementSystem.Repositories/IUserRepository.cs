using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Database.Entities;
using TaskManagementSystem.Repositories.Models;

namespace TaskManagementSystem.Repositories
{
    public interface IUserRepository
    {
        User[] GetAll();
        User GetById(int id);
        bool Delete (int id);
        
    }
}

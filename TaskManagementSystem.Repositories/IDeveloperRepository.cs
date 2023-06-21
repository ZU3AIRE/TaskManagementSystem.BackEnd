using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Data.Entities;
using TaskManagementSystem.Repositories.Models;

namespace TaskManagementSystem.Repositories
{
    public interface IDeveloperRepository
    {
       



        bool AddDeveloper(DeveloperModel model);
        bool DeleteDeveloper(int id);
        Developer Get(int id);
        Developer[] GetAll();
        bool UpdateDeveloper(int id, DeveloperModel model);




    }
}

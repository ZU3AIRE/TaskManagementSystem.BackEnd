using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Database.Entities;
using TaskManagementSystem.Repositories.Models;

namespace TaskManagementSystem.Repositories
{
    public interface IDeveloperRepository
    {
        Developer[] GetAll();
        Developer Get(int id);
        bool AddDeveloper(DeveloperModel model);
        bool RemoveDeveloper(int id);

    }
}

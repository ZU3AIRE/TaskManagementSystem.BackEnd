using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Repositories.Models;
using TaskManagementSystem.WebApi.Database.Entities;
using TaskManagementSystem.WebApi.Models;

namespace TaskManagementSystem.Repositories
{
    public interface IDeveloperRepository
    {
        Developer[] GetAll();
        Developer GetById(int id);
        bool Add(DeveloperModel devModel);
        bool Update(DeveloperModel model, int id);
        bool Delete(int id);
    }
}

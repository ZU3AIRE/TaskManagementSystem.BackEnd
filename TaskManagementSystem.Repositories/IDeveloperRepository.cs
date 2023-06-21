using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.WebApi.Database.Entities;

namespace TaskManagementSystem.Repositories
{
    public interface IDeveloperRepository
    {
        Developer[] GetAll();
        Developer GetById(int id);
        bool Add(Developer developer);
        bool Update(Developer developer, int id);
        bool Delete(int id);
    }
}

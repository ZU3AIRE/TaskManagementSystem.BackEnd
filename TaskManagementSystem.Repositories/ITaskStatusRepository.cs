using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Database;
using TaskManagementSystem.WebApi.Database;

namespace TaskManagementSystem.Repositories
{
    public interface ITaskStatusRepository
    {
        object GetAll();
        // WebApi.Database.Entities.TaskStatus[] GetAll();
        bool Add(WebApi.Database.Entities.TaskStatus taskStatus);
        bool Delete(WebApi.Database.Entities.TaskStatus taskStatus,string status);
     
    }
}

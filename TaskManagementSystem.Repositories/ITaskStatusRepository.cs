using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Database;
using TaskManagementSystem.WebApi.Database;
using TaskManagementSystem.WebApi.Models;

namespace TaskManagementSystem.Repositories
{
    public interface ITaskStatusRepository
    {
        object GetAll();
        // WebApi.Database.Entities.TaskStatus[] GetAll();
        bool Add(TaskStatusModel taskStatus);
        bool Delete(string status);
     
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskStatus = TaskManagementSystem.Database.Entities.TaskStatus;
namespace TaskManagementSystem.Repositories
{
    public interface ITaskStatusRepository
    {
        TaskStatus[] GetAll();
        bool AddStatus(string status);
        bool DeleteStatus(string status);
    }
}

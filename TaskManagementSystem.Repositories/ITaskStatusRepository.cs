using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaskStatus = TaskManagementSystem.Data.Entities.TaskStatus;


namespace TaskManagementSystem.Repositories
{
    public interface ITaskStatusRepository
    {
        TaskStatus[] GetAll();
        bool AddStatus(TaskStatus status);
        bool Delete(string status);
    }
}

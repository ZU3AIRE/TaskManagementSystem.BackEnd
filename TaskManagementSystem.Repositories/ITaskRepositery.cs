using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Repositories.Models;

using Task = TaskManagementSystem.Data.Entities.Task;

namespace TaskManagementSystem.Repositories
{
    public interface ITaskRepository
    {
        Task[] GetAll();
        Task Get(int id);
        bool AddTask(AddTaskModel model);
        bool EditTask(Taskmodel model, int id);

        bool Delete(int id);
    }
}

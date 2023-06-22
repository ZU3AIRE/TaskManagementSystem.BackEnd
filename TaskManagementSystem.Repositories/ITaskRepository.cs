using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = TaskManagementSystem.WebApi.Database.Entities.Task;


namespace TaskManagementSystem.Repositories
{
    public interface ITaskRepository
    {
        Task[] GetAll();
        Task GetById(int id);
        bool Add(Task task);
        bool Update(Task task);
        bool Delete(int id);
    }
}

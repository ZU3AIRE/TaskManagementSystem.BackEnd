using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Repositories.Models;
using TaskManagementSystem.WebApi.Models;
using Task = TaskManagementSystem.WebApi.Database.Entities.Task;


namespace TaskManagementSystem.Repositories
{
    public interface ITaskRepository
    {
        Task[] GetAll();
        Task GetById(int id);
        bool Add(AddTaskModel model);
        bool Update(UpdatetaskModel model, int id);
        bool Delete(int id);
    }
}

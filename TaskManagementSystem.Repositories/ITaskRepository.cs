using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Repositories.Models;
using Task = TaskManagementSystem.Database.Entities.Task;

namespace TaskManagementSystem.Repositories
{
    public interface ITaskRepository
    {
        Task[] GetAll();
        Task GetById(int id);
        bool AddTask(TaskModel model);
        bool UpdateTask(UpdateTaskModel model, int id);
        bool DeleteTask(int id);
        Task[] GetTaskBySearch(string title);
        Task[] GetTaskByStatusId(int statusId);
        //bool AssignTo(int taskid, int developerId);
    }
}

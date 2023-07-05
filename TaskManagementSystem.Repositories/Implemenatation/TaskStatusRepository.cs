using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.WebApi.Database;
using TaskManagementSystem.WebApi.Database.Entities;
using TaskManagementSystem.WebApi.Models;

namespace TaskManagementSystem.Repositories.Implemenatation
{
    public class TaskStatusRepository : ITaskStatusRepository
    {
        private readonly AppDbContext db;
        public TaskStatusRepository(AppDbContext _DB)
        {
            db = _DB;
        }
        public bool Add(TaskStatusModel taskStatus)
        {
            try
            {
                var task = new WebApi.Database.Entities.TaskStatus
                {
                    Status = taskStatus.Status,
                };
                db.TaskStatuses.Add(task);
                db.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }
        public bool Delete(string status)
        {
            var taskStatus = db.TaskStatuses.FirstOrDefault(x => x.Status == status);
            if (taskStatus == null)
            {
                return false;
            }

            taskStatus.IsActive = false;
            db.SaveChanges();

            return true;

        }
        public object GetAll()
        {
            return db.TaskStatuses.ToArray();
        }
    }
}



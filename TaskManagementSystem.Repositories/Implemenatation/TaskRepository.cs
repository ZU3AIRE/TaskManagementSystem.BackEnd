using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Repositories.Models;
using TaskManagementSystem.WebApi.Database;
using TaskManagementSystem.WebApi.Models;

namespace TaskManagementSystem.Repositories.Implemenatation
{
    public class TaskRepository : ITaskRepository
    {
        public TaskRepository(AppDbContext _db)
        {
            db = _db;
        }

        private AppDbContext db { get; }

        public bool Add(AddTaskModel model)
        {
            try
            {
                var found = db.TaskStatuses.FirstOrDefault(x => x.Status == "Pending");

                var taskk = new WebApi.Database.Entities.Task
                {
                    Title = model.Title,
                    Description = model.Description,
                    Status = found
                };
                db.Tasks.Add(taskk);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var tasks = db.Tasks.Find(id);
                if (tasks == null)
                {
                    return false;
                }
                tasks.IsActive = false;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public WebApi.Database.Entities.Task[] GetAll()
        {
            return db.Tasks.Include(x => x.Status).Where(x => x.IsActive == true).ToArray();
        }

        public WebApi.Database.Entities.Task? GetById(int id)
        {
            return db.Tasks.FirstOrDefault(x => x.TaskId == id);
        }

        public bool Update(UpdatetaskModel model, int id)
        {
            var exTask = db.Tasks.FirstOrDefault(x => x.TaskId == id);
            if (exTask != null)
            {
                exTask.Title = model.Title;
                exTask.Description = model.Description;

                var status = db.TaskStatuses.FirstOrDefault(x => x.Status == model.Status);
                if (status != null)
                {
                    exTask.Status = status;
                }
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

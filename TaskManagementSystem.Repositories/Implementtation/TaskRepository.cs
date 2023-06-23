using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Data;
using TaskManagementSystem.Repositories.Models;

namespace TaskManagementSystem.Repositories.Implementtation
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext db;

        public TaskRepository(AppDbContext _db)
        {
            db = _db;
        }

        public bool AddTask(AddTaskModel model)
        {
            try
            {
                var task = new TaskManagementSystem.Data.Entities.Task
                {
                    Title = model.Title,
                    Description = model.Description
                };

                // For adding Task Status Pending
                var status = db.TaskStatuses.First(x => x.Status == "Pending");
                task.Status = status!;

                // Add new object to the DbSet
                db.Tasks.Add(task);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                // Handle any exceptions or log the error
                return false;
            }
        }

         public bool EditTask(AddTaskModel model)
        {
            try
            {
                var task = db.Tasks.Find(model.TaskId);

                if (task != null)
                {
                    task.Title = model.Title;
                    task.Description = model.Description;

                    // Update the task in the DbSet
                    db.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions or log the error
                return false;
            }
        }

        public bool Delete(int id)
        {
            var task = db.Tasks.Find(id);

            if (task != null)
            {
                db.Tasks.Remove(task);
                db.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public Data.Entities.Task Get(int id)
        {
            return db.Tasks.FirstOrDefault(x => x.TaskId == id);
        }

        public Data.Entities.Task[] GetAll()
        {
            return db.Tasks.ToArray();
        }
    }
}

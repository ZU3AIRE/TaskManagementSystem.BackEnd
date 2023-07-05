using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
                    Description = model.Description,
                    IsActive = true
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

        public bool EditTask(Taskmodel model, int id)
            {
            try
            {
                var task = db.Tasks.FirstOrDefault(x => x.TaskId == id);
             

                if (task != null)
                {
                    task.Title = model.Title;
                    task.Description = model.Description;

                    // Update the task in the DbSet
                    var status = db.TaskStatuses.FirstOrDefault(x => x.Status == model.Status);
                    if (status != null)
                    {
                        task.Status = status;
                    }




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
                return false;
            }
        }

        public bool Delete(int id)
        {
            var tsk = db.Tasks.Find(id);
            if (tsk == null)
            {
                return false;
            }

            tsk.IsActive = false;
            db.SaveChanges();
            return true;
        }

        public Data.Entities.Task Get(int id)
        {
            return db.Tasks.FirstOrDefault(x => x.TaskId == id);
        }

        public Data.Entities.Task[] GetAll()
        {
            return db.Tasks.Include(x => x.Status).Where(x => x.IsActive == true).ToArray();

        }
    }
}

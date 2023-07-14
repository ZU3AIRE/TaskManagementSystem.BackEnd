using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Database;
using TaskManagementSystem.Repositories.Models;
using TaskManagementSystem.Repositories.Utilities;

namespace TaskManagementSystem.Repositories.Implementation
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext db;

        public TaskRepository(AppDbContext _Db)
        {
            db = _Db;
        }

        public bool AddTask(TaskModel model)
        {
            // Create new object of Entity Task
            TaskManagementSystem.Database.Entities.Task entity = model.ToEntity();

            // For adding Task Status Pending
            var status = db.TaskStatuses.First(x => x.Status == "Pending");
            entity.Status = status!;

            // Add new object to the DbSet
            db.Tasks.Add(entity);
            db.SaveChanges();

            return (true);
        }

        //public bool AssignTo(int taskid, int developerId)
        //{
        //    var task = db.Tasks.Find(taskid);
        //    var developer = db.Developers.Find(developerId);
        //    if (task == null && developer == null)
        //    {
        //        return (false);
        //    }
        //    else
        //    {
        //        task.Developers = developer;
        //        db.Tasks.Update(task);
        //        db.SaveChanges();
        //        return (true);
        //    }
        //}

        public bool DeleteTask(int id)
        {
            var task = db.Tasks.FirstOrDefault(x => x.TaskId == id && x.IsActive == true);
            if (task != null)
            {
                task.IsActive = false;
                db.Tasks.Update(task);
                db.SaveChanges();

                return (true);
            }
            else
            {
                return (false);
            }
        }

        public Database.Entities.Task[] GetAll()
        {
            return (db.Tasks.Include(x => x.Status).Where(x => x.IsActive == true).ToArray());
        }

        public Database.Entities.Task GetById(int id)
        {
            return (db.Tasks.Include(x => x.Status).FirstOrDefault(x => x.TaskId == id && x.IsActive == true)!);
        }

        public Database.Entities.Task[] GetTaskBySearch(string title)
        {
            return (db.Tasks.Include(x => x.Status).Where(x => x.Title.Contains(title) && x.IsActive == true).ToArray());
        }

        public Database.Entities.Task[] GetTaskByStatusId(int statusId)
        {
            return (db.Tasks.Include(x => x.Status).Where(x => x.Status.TaskStatusID == statusId && x.IsActive == true).ToArray());
        }

        public bool UpdateTask(UpdateTaskModel model, int id)
        {
            var task = db.Tasks.FirstOrDefault(x => x.TaskId == id);
            if (task != null)
            {
                task.Title = model.Title;
                task.Description = model.Description;

                var stat = db.TaskStatuses.FirstOrDefault(x => x.Status == model.Status.Trim());
                if (stat != null)
                {
                    task.Status = stat;
                    db.Tasks.Update(task);
                    db.SaveChanges();
                    return (true);
                }
                else
                {
                    return (false);
                }

            }
            else
            {
                return (false);
            }
        }
    }
}
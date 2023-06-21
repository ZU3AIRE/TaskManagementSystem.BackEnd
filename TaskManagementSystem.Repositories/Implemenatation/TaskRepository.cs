using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.WebApi.Database;

namespace TaskManagementSystem.Repositories.Implemenatation
{
    public class TaskRepository : ITaskRepository
    {
        public TaskRepository(AppDbContext _db)
        {
            db = _db;
        }

        public AppDbContext db { get; }

        public bool Add(WebApi.Database.Entities.Task task)
        {
            db.Tasks.Add(task);
            db.SaveChanges();
            return true;

        }

        public bool Delete(int id)
        {
            var tasks = db.Users.Find(id);
            if (tasks == null)
            {
                return false;
            }
            tasks.IsActive = false;
            db.SaveChanges();
            return true;
        }

        public WebApi.Database.Entities.Task[] GetAll()
        {
            return db.Tasks.ToArray();
        }

        public WebApi.Database.Entities.Task? GetById(int id)
        {
            return db.Tasks.FirstOrDefault(x => x.TaskId == id);
        }
    }
}

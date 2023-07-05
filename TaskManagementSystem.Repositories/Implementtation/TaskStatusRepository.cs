using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Data;

namespace TaskManagementSystem.Repositories.Implementtation
{
    public class TaskStatusRepository : ITaskStatusRepository
    {
        private readonly AppDbContext db;

        public TaskStatusRepository(AppDbContext _db ) 
        {
            db = _db;
        }

        public bool AddStatus(Data.Entities.TaskStatus status)
        {
            if (db.TaskStatuses.Any(x => x.Status == status.Status))
            {

                return false; // Status already exists

            }

            status.IsActive = true;
            db.TaskStatuses.Add(status);

            db.SaveChanges();

            return true; // Status added successfully
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

        public Data.Entities.TaskStatus[] GetAll()
        {
            return db.TaskStatuses.Where(x => x.IsActive == true).ToArray();
        }
    }
}

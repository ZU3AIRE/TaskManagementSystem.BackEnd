using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Database;

namespace TaskManagementSystem.Repositories.Implementation
{
    public class TaskStatusRepository : ITaskStatusRepository
    {
        private readonly AppDbContext db;

        public TaskStatusRepository(AppDbContext _Db)
        {
            db = _Db;
        }

        public bool AddStatus(string status)
        {

            if (db.TaskStatuses.Any(x => x.Status == status))
            {
                return (false);
            }
            else
            {
                TaskManagementSystem.Database.Entities.TaskStatus taskStatus = new Database.Entities.TaskStatus
                {
                    Status = status
                };

                db.TaskStatuses.Add(taskStatus);
                db.SaveChanges();

                return (true);
            }
        }

        public bool DeleteStatus(string status)
        {
            var taskstatus = db.TaskStatuses.FirstOrDefault(x => x.Status == status && x.IsActive == true);
            if (taskstatus != null)
            {
                taskstatus.IsActive = false;
                db.TaskStatuses.Update(taskstatus);
                db.SaveChanges();
                return (true);
            }
            else
            {
                return (false);

            }
        }

        public Database.Entities.TaskStatus[] GetAll()
        {
            return (db.TaskStatuses.Where(x => x.IsActive == true).ToArray());
        }
    }
}

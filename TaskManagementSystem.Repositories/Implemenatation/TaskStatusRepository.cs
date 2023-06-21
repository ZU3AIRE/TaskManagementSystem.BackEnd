using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.WebApi.Database;
using TaskManagementSystem.WebApi.Database.Entities;

namespace TaskManagementSystem.Repositories.Implemenatation
{

    public class TaskStatusRepository : ITaskStatusRepository
    {
        private readonly AppDbContext db;
        public TaskStatusRepository(AppDbContext _DB)
        {
            db = _DB;
        }
        public bool Add(WebApi.Database.Entities.TaskStatus taskStatus)
        {
            db.TaskStatuses.Add(taskStatus);
            db.SaveChanges();
            return true;
        }

     

        public bool Delete(WebApi.Database.Entities.TaskStatus taskStatus, string status)
        {
            throw new NotImplementedException();
        }

        public object GetAll()
        {
            return db.TaskStatuses.ToArray();
        }

        //WebApi.Database.Entities.TaskStatus[] ITaskStatusRepository.GetAll()
        //{
        //    return db.TaskStatuses.ToArray();
        //}




    }
}



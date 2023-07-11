using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Database;
using TaskManagementSystem.Database.Entities;
using TaskManagementSystem.Repositories.Models;
using TaskManagementSystem.Repositories.Utilities;

namespace TaskManagementSystem.Repositories.Implementation
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly AppDbContext db;

        public DeveloperRepository(AppDbContext _db)
        {
            db = _db;
        }
        public bool AddDeveloper(DeveloperModel model)
        {
            Developer entity = model.ToEntity();

            db.Developers.Add(entity);
            db.SaveChanges();
            return (true);
        }

        public Developer Get(int id)
        {
            return (db.Developers.FirstOrDefault(x => x.DeveloperId == id && x.IsActive == true)!);
        }

        public Developer[] GetAll()
        {
            return (db.Developers.Where(x => x.IsActive == true).ToArray());
        }

        public bool RemoveDeveloper(int id)
        {
            var developer=db.Developers.FirstOrDefault(x=>x.DeveloperId==id && x.IsActive == true);
            if (developer!=null)
            {
                developer.IsActive = false;
                db.Developers.Update(developer);
                db.SaveChanges();
                return (true);
            }
            else
            {
                return (false);
            }
        }
    }
}

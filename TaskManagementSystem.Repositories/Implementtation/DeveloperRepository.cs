using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Data;
using TaskManagementSystem.Data.Entities;
using TaskManagementSystem.Repositories.Models;

namespace TaskManagementSystem.Repositories.Implementation
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly AppDbContext db;

        public DeveloperRepository(AppDbContext dbContext)
        {
            db = dbContext;
        }

        public bool AddDeveloper(DeveloperModel model)
        {
            try
            {
                Developer dev = new Developer
                {
                    DeveloperName = model.Name,
                    Email = model.Email,
                    Password = model.Password,
                    IsActive = true
                };

                db.Developers.Add(dev);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteDeveloper(int id)
        {
            var dev = db.Developers.Find(id);
            if (dev == null)
            {
                return false;
            }

            dev.IsActive = false;
            db.SaveChanges();
            return true;
        }

        public Developer Get(int id)
        {
            var dev = db.Developers.FirstOrDefault(u => u.DeveloperId == id && u.IsActive);
            return dev;
        }

        public Developer[] GetAll()
        {
            return db.Developers.Where(x => x.IsActive == true).ToArray();
        }

        public bool UpdateDeveloper(int id, DeveloperModel model)
        {
            var dev = db.Developers.Find(id);
            if (dev == null)
            {
                return false;
            }

            dev.DeveloperName = model.Name;
            dev.Email = model.Email;
            dev.Password = model.Password;
            //user.IsActive = model.IsActive;

            db.SaveChanges();
            return true;
        }
    }
}

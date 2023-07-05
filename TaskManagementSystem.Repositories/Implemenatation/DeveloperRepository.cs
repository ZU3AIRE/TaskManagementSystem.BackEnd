using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.WebApi.Database;
using TaskManagementSystem.WebApi.Database.Entities;
using TaskManagementSystem.WebApi.Models;

namespace TaskManagementSystem.Repositories.Implemenatation
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly AppDbContext db;
        private readonly DeveloperRepository repo;

        public DeveloperRepository(AppDbContext _DB, DeveloperRepository repo)
        {
            db = _DB;
            this.repo = repo;
        }
        public bool Add(DeveloperModel devModel)
        {
            try
            {
                var dev = new Developer
                {
                    Name = devModel.Name,
                    Email = devModel.Email,
                    Password = devModel.Password
                };
                db.Developers.Add(dev);
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
            var dev = db.Developers.Find(id);
            if (dev == null)
            {
                return false;
            }
            dev.IsActive = false;
            db.SaveChanges();
            return true;
        }

        public Developer[] GetAll()
        {
            return db.Developers.ToArray();
        }

        public Developer GetById(int id)
        {
            return db.Developers.FirstOrDefault(x => x.DeveloperId == id);
        }

        public bool Update(DeveloperModel model, int id)
        {
            throw new NotImplementedException();
        }
    }
}

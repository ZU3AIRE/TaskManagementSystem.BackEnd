using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.WebApi.Database;
using TaskManagementSystem.WebApi.Database.Entities;

namespace TaskManagementSystem.Repositories.Implemenatation
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly AppDbContext db;

        public DeveloperRepository(AppDbContext _DB)
        {
            db = _DB;
        }
        public bool Add(Developer developer)
        {
            db.Developers.Add(developer);
            db.SaveChanges();
            return true;
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

        public bool Update(Developer developer, int id)
        {
            throw new NotImplementedException();
        }
    }
}

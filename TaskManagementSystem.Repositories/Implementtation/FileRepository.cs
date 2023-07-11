using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Data;

namespace TaskManagementSystem.Repositories.Implementtation
{
    public class FileRepository : IFileRepository
    {
        private readonly AppDbContext db;

        public FileRepository(AppDbContext dbContext)
        {
            db = dbContext;
        }


        public void SaveFilePath(string filePath)
        {
            var fileEntity = new TaskManagementSystem.Data.Entities.Filee
            {
                FilePath = filePath
            };

           
          db.Files.Add(fileEntity);
            db.SaveChanges();

            //throw new NotImplementedException();
        }
    }
}

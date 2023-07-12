using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Filee = TaskManagementSystem.Data.Entities.Filee;


namespace TaskManagementSystem.Repositories
{
    public interface IFileRepository
    {
        Filee[] GetAll();

        void SaveFilePath(string filePath);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Repositories
{
    public interface IFileRepository
    {
        void SaveFilePath(string filePath);
    }
}

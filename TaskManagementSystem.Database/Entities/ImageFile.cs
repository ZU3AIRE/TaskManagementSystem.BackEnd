using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Database.Entities
{
    public class ImageFile
    {
        public int ImageFileId { get; set; }
        public string? name { get; set; }
        public string? path { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

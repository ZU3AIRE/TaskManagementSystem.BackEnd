﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Database.Entities
{
    public class FileSaving
    {
        [Key]
        public int FileId { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
    }
}

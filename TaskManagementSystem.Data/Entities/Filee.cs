﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Data.Entities
{
    public class Filee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FilePath { get; set; }
    }
}

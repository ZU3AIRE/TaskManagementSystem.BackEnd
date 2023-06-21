﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Data.Entities;

namespace TaskManagementSystem.Repositories
{
    public interface IAccountRepository
    {
        User Login(string email, string password);
        User GetByEmail(string email);
        void Signup(User user);
    }
}

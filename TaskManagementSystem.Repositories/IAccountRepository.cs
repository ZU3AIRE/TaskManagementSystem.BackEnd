using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Repositories.Models;

namespace TaskManagementSystem.Repositories
{
    public interface IAccountRepository
    {
        bool Login(LoginModel model);
        bool SignUp(SignupModel model);
    }
}

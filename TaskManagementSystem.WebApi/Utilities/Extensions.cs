using TaskManagementSystem.WebApi.Database.Entities;
using TaskManagementSystem.WebApi.Models;

namespace TaskManagementSystem.WebApi.Utilities
{
    public static class Extensions
    {
        public static User ToEntity(this SignupModel model)
        {
            return new User
            {
                Email = model.Email,
                Name = model.Name,
                Password = model.Password,
            };
        }
    }
}

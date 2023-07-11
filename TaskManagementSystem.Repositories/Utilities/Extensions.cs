using TaskManagementSystem.Database.Entities;
using TaskManagementSystem.Repositories.Models;

namespace TaskManagementSystem.Repositories.Utilities
{
    public static class Extensions
    {
        #region For User Entity
        public static User ToEntity(this SignupModel model)
        {
            return new User
            {
                Email = model.Email,
                Name = model.Name,
                Password = model.Password,
            };
        }
        #endregion

        #region For Task Entity
        public static Database.Entities.Task ToEntity(this TaskModel model)
        {
            return new Database.Entities.Task
            {
                Title = model.Title,
                Description = model.Description

            };
        }
        #endregion

        #region For User Entity
        public static User ToEntity(this UserModel model)
        {
            return new User
            {
                Email = model.Email,
                Name = model.Name,
                Password = model.Password,
            };
        }
        #endregion

        #region For Developer Entity
        public static Developer ToEntity(this DeveloperModel model)
        {
            return new Developer
            {
                Email = model.Email,
                Name = model.Name,
                Password = model.Password
            };
        }
        #endregion
    }
}

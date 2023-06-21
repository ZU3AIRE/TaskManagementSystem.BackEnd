using TaskManagementSystem.Data.Entities;
using TaskManagementSystem.Repositories.Models;

namespace TaskManagementSystem.WebApi.Utilities
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
        public static Data.Entities.Task ToEntity(this AddTaskModel model)
        {
            return new TaskManagementSystem.Data.Entities.Task
            {
                Title = model.Title,
                Description = model.Description
            };
        }
        #endregion
    }
}

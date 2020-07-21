using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolidDemo.DependencyInversion
{
    internal class OkDependencyInversion
    {
        #region Controller level (Highest abstraction level)
        private IServiceProvider serviceProvider = null; // injected from constructor
        internal int GetActiveUserCount()
        {
            var service = (IUserService)serviceProvider.GetService(typeof(IUserService));
            return service.GetActiveUsersCount();
        }
        
        // in ../Models/
        internal class User
        {
            public bool IsActive { get; set; }
        }

        #endregion

        #region Business layer (Lower abstraction level)
        internal class UserService : IUserService
        {
            private IServiceProvider serviceProvider = null; // injected from controller
            public int GetActiveUsersCount()
            {
                using (var userRepository = (IUserRepository)serviceProvider.GetService(typeof(IUserRepository)))
                {
                    var activeUsers = userRepository.GetActiveUsers().ToList();
                    return activeUsers.Count;
                }
            }
        }
        // in ../Services/
        internal interface IUserService
        {
            int GetActiveUsersCount();
        }

        // in ../Repositories/
        internal interface IUserRepository : IDisposable
        {
            IEnumerable<User> GetActiveUsers();
        }

        #endregion

        #region Data access layer (Lowest abstraction level)

        internal class UserRepository : IUserRepository
        {
            public void Dispose()
            {
                return;
            }

            public IEnumerable<User> GetActiveUsers()
            {
                using(var dbContext = new DbContext())
                {
                    return dbContext.GetUsers().Where(u => u.IsActive).ToList();
                }
            }
        }

        private class DbContext : IDisposable
        {
            public void Dispose()
            {
                return;
            }

            internal IEnumerable<User> GetUsers()
            {
                Random random = new Random();
                for (var i = 0; i < random.Next(1, 1000); i++)
                    yield return new User { IsActive = i % 2 == 0 };
            }
        }
        #endregion
    }
}

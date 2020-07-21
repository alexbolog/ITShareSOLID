using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolidDemo.DependencyInversion
{
    internal class BadDependencyInversion
    {
        // assume this is at the controller level
        internal int GetActiveUserCount()
        {
            using (var dbContext = new DbContext())
            {
                return dbContext.GetUsers().Where(u => u.IsActive).Count();
            }
        }

        // db level
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

        // db model
        private class User
        {
            public bool IsActive { get; set; }
        }
    }
}

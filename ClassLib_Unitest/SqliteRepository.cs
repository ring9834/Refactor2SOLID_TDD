using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib_Unitest
{
    public class SqliteRepository : IRepository
    {
        private readonly DbConnection _connection;

        public SqliteRepository(DbConnection connection)
        {
            _connection = connection;
        }

        public bool IsUserActive(int userId)
        {
            return true;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            // Simulate fetching user from database
            await Task.Delay(100); // Simulate async operation
            return new User { Id = id, Name = "Test User" };
        }

        public async Task<bool> SaveUserAsync(User user)
        {
            // Simulate saving user to database
            await Task.Delay(100); // Simulate async operation
            return true; // Assume save was successful
        }
    }
}

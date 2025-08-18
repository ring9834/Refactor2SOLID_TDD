using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib_Unitest
{
    public class DatabaseFixture : IDisposable
    {
        public IRepository Repository { get; private set; }
        private readonly SQLiteConnection _connection;
        public DatabaseFixture()
        {
            _connection = new SQLiteConnection("Data Source=:memory:;Version=3;New=True;");
            Repository = new SqliteRepository(_connection);

            // Simulate database setup (e.g., in-memory database)
            Console.WriteLine("Setting up database...");
        }

        public void Dispose()
        {
            _connection?.Close();
            _connection?.Dispose();

            // Simulate database cleanup
            Console.WriteLine("Cleaning up database...");
        }
    }
}

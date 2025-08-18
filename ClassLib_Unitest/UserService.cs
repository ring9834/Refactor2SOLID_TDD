using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib_Unitest
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class UserService
    {
        private readonly IRepository _repository;

        public UserService(IRepository repository)
        {
            _repository = repository;
        }

        public string GetUserStatus(int userId)
        {
            return _repository.IsUserActive(userId) ? "Active" : "Inactive";
        }

        public async Task<string> GetUserGreetingAsync(int id)
        {
            var user = await _repository.GetUserByIdAsync(id);
            if (user == null)
                return "User not found";
            return $"Hello, {user.Name}!";
        }

        public async Task<bool> CreateUserAsync(string name)
        {
            var user = new User { Name = name };
            return await _repository.SaveUserAsync(user);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib_Unitest
{
    public interface IRepository
    {
        bool IsUserActive(int userId);
        Task<User> GetUserByIdAsync(int id);
        Task<bool> SaveUserAsync(User user);
    }

    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib_Unitest
{
    public class Order
    {
        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public decimal Total { get; set; }
    }

    public class OrderService
    {
        public Order CreateOrder(int id, string customerName, decimal total)
        {
            return new Order
            {
                Id = id,
                CustomerName = customerName,
                Total = total
            };
        }
    }
}

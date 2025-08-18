using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib_Unitest
{
    public class DataAsyncService
    {
        public async Task<string> FetchDataAsync(int id)
        {
            // Simulate async operation (e.g., calling an API)
            await Task.Delay(100);
            return id > 0 ? $"Data-{id}" : throw new ArgumentException("Invalid ID");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib_Unitest
{
    public class ListProcessor
    {
        public List<int> FilterPositiveNumbers(List<int> numbers)
        {
            return numbers.Where(n => n > 0).ToList();
        }
    }
}

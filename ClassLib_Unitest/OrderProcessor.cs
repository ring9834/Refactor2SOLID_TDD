namespace ClassLib_Unitest
{
    public class OrderProcessor
    {
        public bool ProcessOrder(Order? order)
        {
            return order != null && order.Total > 0;
        }
    }
}

namespace ClassLib_Unitest
{
    public class Stock
    {
        public event EventHandler<int>? StockLevelChanged;

        private int _stockLevel;
        public void UpdateStock(int newLevel)
        {
            _stockLevel = newLevel;
            StockLevelChanged?.Invoke(this, _stockLevel);
        }
    }
}

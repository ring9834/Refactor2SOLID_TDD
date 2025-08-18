namespace ClassLib_Unitest
{
    public class OperationService
    {
        public async Task<int> PerformLongOperationAsync()
        {
            await Task.Delay(500); // Simulate long operation
            return 42;
        }
    }
}

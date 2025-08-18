namespace ClassLib_Unitest
{
    public interface IExternalService
    {
        Task<bool> TryOperationAsync();
    }

    public class RetryService
    {
        private readonly IExternalService _externalService;

        public RetryService(IExternalService externalService)
        {
            _externalService = externalService;
        }

        public async Task<bool> ExecuteWithRetryAsync(int maxRetries = 3)
        {
            for (int i = 0; i < maxRetries; i++)
            {
                if (await _externalService.TryOperationAsync())
                {
                    return true;
                }
                await Task.Delay(100 * (i + 1)); // Exponential backoff simulation
            }
            return false;
        }
    }
}

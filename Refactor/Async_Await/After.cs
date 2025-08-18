namespace MyLibrary;

// Used async/await to avoid blocking calls.
// Added using for proper resource disposal.
public class After9
{
    // Synchronous blocking call
    public async Task<string> FetchDataAsync()
    {
        using var client = new HttpClient();
        return await client.GetStringAsync("https://api.example.com/data");
    }
}

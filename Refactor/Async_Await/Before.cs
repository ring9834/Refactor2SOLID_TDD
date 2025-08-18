namespace MyLibrary;

public class Before9
{
    // Synchronous blocking call
    public string FetchData()
    {
        var client = new HttpClient();
        var response = client.GetStringAsync("https://api.example.com/data").Result;
        return response;
    }
}

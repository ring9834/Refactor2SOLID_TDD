namespace MyLibrary;

public class Before10
{
    // Generic method lacking domain context
    public void Update(int id, string value)
    {
        // Update database
        Console.WriteLine($"Updating ID {id} with value {value}");
    }
}

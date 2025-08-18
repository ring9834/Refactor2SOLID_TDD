namespace MyLibrary;

// Class handling multiple responsibilities
public class UserManager
{
    public void SaveUser(string name, string email)
    {
        // Save to database
        Console.WriteLine($"Saving {name}, {email} to database");
        // Send email
        Console.WriteLine($"Sending welcome email to {email}");
    }
}

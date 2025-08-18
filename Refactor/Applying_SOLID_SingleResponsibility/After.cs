namespace MyLibrary;

// Split responsibilities into separate classes (UserRepository, EmailService).
public class UserRepository
{
    public void SaveUser(string name, string email)
    {
        Console.WriteLine($"Saving {name}, {email} to database");
    }
}

public class EmailService
{
    public void SendWelcomeEmail(string email)
    {
        Console.WriteLine($"Sending welcome email to {email}");
    }
}

// Used dependency injection for better testability and flexibility.
public class UserManager_After
{
    private readonly UserRepository _repository;
    private readonly EmailService _emailService;

    public UserManager_After(UserRepository repository, EmailService emailService)
    {
        _repository = repository;
        _emailService = emailService;
    }

    public void RegisterUser(string name, string email)
    {
        _repository.SaveUser(name, email);
        _emailService.SendWelcomeEmail(email);
    }
}

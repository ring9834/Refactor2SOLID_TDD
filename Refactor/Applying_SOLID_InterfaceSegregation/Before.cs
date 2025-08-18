namespace MyLibrary;

// A large class with multiple responsibilities violates Single Responsibility Principle and has a bloated interface.
// IEmployeeManager interface is too broad, forcing implementers to provide methods they may not need (violates Interface Segregation Principle).
public interface IEmployeeManager
{
    void SaveEmployee(string name, string email);
    void SendEmail(string email, string message);
    decimal CalculateSalary(int employeeId);
}

// EmployeeManager class has multiple responsibilities (data storage, email sending, salary calculation).
// Hard to test and maintain due to mixed concerns.
public class EmployeeManager : IEmployeeManager
{
    public void SaveEmployee(string name, string email)
    {
        Console.WriteLine($"Saving {name}, {email} to database");
    }

    public void SendEmail(string email, string message)
    {
        Console.WriteLine($"Sending email to {email}: {message}");
    }

    public decimal CalculateSalary(int employeeId)
    {
        // Simulate salary calculation
        return 5000.0m;
    }
}

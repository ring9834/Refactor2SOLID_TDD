namespace MyLibrary;

public interface IEmployeeRepository
{
    void SaveEmployee(string name, string email);
}

public interface IEmailService
{
    void SendEmail(string email, string message);
}

public interface ISalaryCalculator
{
    decimal CalculateSalary(int employeeId);
}

public class EmployeeRepository_After : IEmployeeRepository
{
    public void SaveEmployee(string name, string email)
    {
        Console.WriteLine($"Saving {name}, {email} to database");
    }
}

public class EmailService_After : IEmailService
{
    public void SendEmail(string email, string message)
    {
        Console.WriteLine($"Sending email to {email}: {message}");
    }
}

public class SalaryCalculator_After : ISalaryCalculator
{
    public decimal CalculateSalary(int employeeId)
    {
        // Simulate salary calculation
        return 5000.0m;
    }
}

public class EmployeeManager_After
{
    private readonly IEmployeeRepository _repository;
    private readonly IEmailService _emailService;
    private readonly ISalaryCalculator _salaryCalculator;

    public EmployeeManager_After(IEmployeeRepository repository, IEmailService emailService, ISalaryCalculator salaryCalculator)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
        _salaryCalculator = salaryCalculator ?? throw new ArgumentNullException(nameof(salaryCalculator));
    }

    public void RegisterEmployee(string name, string email)
    {
        _repository.SaveEmployee(name, email);
        _emailService.SendEmail(email, "Welcome!");
    }

    public decimal GetEmployeeSalary(int employeeId)
    {
        return _salaryCalculator.CalculateSalary(employeeId);
    }
}

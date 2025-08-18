using Moq;
using Xunit;
namespace MyLibrary;

// Split IEmployeeManager into smaller, focused interfaces (IEmployeeRepository, IEmailService, ISalaryCalculator), adhering to Interface Segregation Principle.
// Separated responsibilities into distinct classes, following Single Responsibility Principle.
// Used dependency injection for better testability and flexibility.
public class EmployeeManager_xunittest
{
    [Fact]
    public void RegisterEmployee_SavesAndSendsEmail()
    {
        // Arrange
        var mockRepository = new Mock<IEmployeeRepository>();
        var mockEmailService = new Mock<IEmailService>();
        var mockSalaryCalculator = new Mock<ISalaryCalculator>();
        var manager = new EmployeeManager_After(mockRepository.Object, mockEmailService.Object, mockSalaryCalculator.Object);

        // Act
        manager.RegisterEmployee("John Doe", "john@example.com");

        // Assert
        mockRepository.Verify(repo => repo.SaveEmployee("John Doe", "john@example.com"), Times.Once());
        mockEmailService.Verify(service => service.SendEmail("john@example.com", "Welcome!"), Times.Once());
    }
}

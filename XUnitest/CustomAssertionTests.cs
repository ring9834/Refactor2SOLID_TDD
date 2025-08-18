using ClassLib_Unitest;

namespace Xunitest
{
    public class CustomAssertionTests
    {
        private readonly UserValidator _validator;

        // Setup in Constructor: Initializes _validator once for all tests.
        public CustomAssertionTests()
        {
            _validator = new UserValidator();
        }

        [Fact]
        public void IsValidUser_ValidUser_ReturnsTrue()
        {
            // Arrange
            var user = new User1 { Name = "Alice", Age = 25 };

            // Act
            bool result = _validator.IsValidUser(user);

            // Assert
            AssertValidUser(user, result);
        }

        [Fact]
        public void IsValidUser_UnderageUser_ReturnsFalse()
        {
            // Arrange
            var user = new User1 { Name = "Bob", Age = 17 };

            // Act
            bool result = _validator.IsValidUser(user);

            // Assert
            AssertInvalidUser(user, result);
        }

        private void AssertValidUser(User1 user, bool result)
        {
            Assert.True(result, $"Expected user {user.Name} (Age: {user.Age}) to be valid.");
        }

        private void AssertInvalidUser(User1 user, bool result)
        {
            Assert.False(result, $"Expected user {user.Name} (Age: {user.Age}) to be invalid.");
        }
    }
}

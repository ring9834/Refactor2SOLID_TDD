using ClassLib_Unitest;

namespace Xunitest
{
    // use [MemberData] to provide custom test data for a [Theory] test, improving reusability.
    public class MemberDataTests
    {
        // Edge Cases: Tests valid, invalid, empty, and malformed inputs.
        public static IEnumerable<object[]> EmailTestData =>
         new List<object[]>
         {
            new object[] { "test@example.com", true },
            new object[] { "invalid.email", false },
            new object[] { "", false },
            new object[] { "noextension@", false }
         };

        // [Theory] attribute allows testing multiple scenarios with different inputs in a single test method.
        // Uses [MemberData] to provide reusable test data.
        [Theory]
        [MemberData(nameof(EmailTestData))]
        public void IsValidEmail_VariousInputs_ReturnsExpectedResult(string email, bool expected)
        {
            // Arrange
            var validator = new StringValidator();

            // Act
            bool result = validator.IsValidEmail(email);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}

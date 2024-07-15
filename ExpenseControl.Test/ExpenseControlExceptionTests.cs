using ExpenseControl.Domain.Exceptions;
using Xunit;

namespace ExpenseControl.Test
{
    public class ExpenseControlExceptionTests
    {
        [Fact]
        public void ExpenseControlException_ShouldInitializeCorrectly_WithMessage()
        {
            // Arrange
            var expectedMessage = "Test exception message";

            // Act
            var exception = new ExpenseControlException(expectedMessage);

            // Assert
            Assert.Equal(expectedMessage, exception.Message);
        }

        [Fact]
        public void ExpenseControlException_ShouldInitializeCorrectly_WithMessageAndInnerException()
        {
            // Arrange
            var expectedMessage = "Test exception message";
            var innerException = new Exception("Inner exception message");

            // Act
            var exception = new ExpenseControlException(expectedMessage, innerException);

            // Assert
            Assert.Equal(expectedMessage, exception.Message);
            Assert.Equal(innerException, exception.InnerException);
        }
    }
}

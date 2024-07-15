using ExpenseControl.Domain.Response;
using Xunit;

namespace ExpenseControl.Test
{
    public class ApiResponseTests
    {
        [Fact]
        public void ApiResponse_ShouldInitializeCorrectly()
        {
            // Arrange
            bool expectedSuccess = true;
            object expectedContent = new { Message = "Test" };

            // Act
            var response = new ApiResponse(expectedSuccess, expectedContent);

            // Assert
            Assert.Equal(expectedSuccess, response.Sucess);
            Assert.Equal(expectedContent, response.Content);
        }

        [Fact]
        public void ApiResponse_ShouldAllowNullContent()
        {
            // Arrange
            bool expectedSuccess = false;

            // Act
            var response = new ApiResponse(expectedSuccess, null);

            // Assert
            Assert.Equal(expectedSuccess, response.Sucess);
            Assert.Null(response.Content);
        }
    }
}

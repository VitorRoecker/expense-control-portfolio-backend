using ExpenseControl.Domain.Entities;
using Xunit;

namespace ExpenseControl.Test
{
    public class UserTokenTests
    {
        [Fact]
        public void UserToken_ShouldInitializeCorrectly()
        {
            // Arrange
            var expectedUserId = Guid.NewGuid();
            var expectedToken = "sample_token";
            var expectedExpiration = DateTime.UtcNow.AddHours(1);

            // Act
            var userToken = new UserToken
            {
                UserId = expectedUserId,
                Token = expectedToken,
                Expiration = expectedExpiration
            };

            // Assert
            Assert.Equal(expectedUserId, userToken.UserId);
            Assert.Equal(expectedToken, userToken.Token);
            Assert.Equal(expectedExpiration, userToken.Expiration);
        }

        [Fact]
        public void UserToken_ShouldAllowNullToken()
        {
            // Arrange
            var expectedUserId = Guid.NewGuid();
            DateTime expectedExpiration = DateTime.UtcNow.AddHours(1);

            // Act
            var userToken = new UserToken
            {
                UserId = expectedUserId,
                Token = null,
                Expiration = expectedExpiration
            };

            // Assert
            Assert.Equal(expectedUserId, userToken.UserId);
            Assert.Null(userToken.Token);
            Assert.Equal(expectedExpiration, userToken.Expiration);
        }
    }
}

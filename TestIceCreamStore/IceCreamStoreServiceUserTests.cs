using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using IceCreamStoreService;
using DTO;
using IceCreamStoreRepostery;
using Entity;
using AutoMapper;

namespace TestIceCreamStore
{
    public class IceCreamStoreServiceUserTests
    {
        [Fact]
        public async Task LoginAsync_ValidCredentials_LogsSuccess()
        {
            // Arrange
            var mockRepo = new Mock<IIceCreamStoreReposteryUser>();
            var mockLogger = new Mock<ILogger<IceCreamStoreServiceUser>>();
            var mockMapper = new Mock<IMapper>();

            var userLoginDto = new UserLoginDTO("test", "1234");
            // מכיוון ש-UserLoginDTO הוא record עם ctor של שני פרמטרים

            var userLogin = new UserLogin { userName = "test", password = "1234" };
            // שימי לב ל-case של השדות (קטנות ב-UserLogin)

            var user = new User { Id = 1, UserName = "test", Password = "1234", FirstName = "Naama", LastName = "Yafen" };

            var userDto = new UserDTO { Id = 1, UserName = "test", Password = "1234", FirstName = "Naama", LastName = "Yafen" };


            mockMapper.Setup(m => m.Map<UserLogin>(userLoginDto)).Returns(userLogin);
            mockRepo.Setup(r => r.getUserByUserNameAndPasswordLogin(userLogin)).ReturnsAsync(user);
            mockMapper.Setup(m => m.Map<UserDTO>(user)).Returns(userDto);

            var service = new IceCreamStoreServiceUser(mockRepo.Object, mockMapper.Object, mockLogger.Object);

            // Act
            var result = await service.getUserByUserNameAndPasswordLogin(userLoginDto);

            // Assert
            Assert.NotNull(result);
            mockLogger.Verify(
                l => l.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Login successful")),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Once);
        }
    }
}

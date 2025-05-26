using Moq;
using Xunit;
using Microsoft.EntityFrameworkCore;
using IceCreamStoreRepostery;
using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq.EntityFrameworkCore;

namespace TestIceCreamStore
{
    public class UserTest1
    {
        [Fact]
        
            public async Task AddUserRegister_AddsUserSuccessfully()
            {
                // Arrange
                var users = new List<User>();
                var mockContext = new Mock<WebApiContext>();

                // Mock את DbSet<User> כך שיתמוך ב־AddAsync ושישתמש ברשימת users
                mockContext.Setup(x => x.Users).ReturnsDbSet(users);

                var repo = new IceCreamStoreReposteryUser(mockContext.Object);

                var newUser = new User
                {
                    Id = 1,
                    UserName = "tester",
                    Password = "1234",
                    FirstName = "Test",
                    LastName = "User"
                };

                // Act
                var result = await repo.addUserRegister(newUser);

                // Assert
                Assert.NotNull(result);
                Assert.Equal("tester", result.UserName);
                Assert.Equal("Test", result.FirstName);
                Assert.Equal("User", result.LastName);
                 
            }

            [Fact]
            public async Task GetUserByUserNameAndPasswordLogin_ReturnsCorrectUser()
            {
                // Arrange
                var user = new User { Id = 1, UserName = "tester", Password = "1234" ,FirstName = "Test1",
                    LastName = "User1"
                };
                var users = new List<User> { user };

                var mockContext = new Mock<WebApiContext>();
                mockContext.Setup(x => x.Users).ReturnsDbSet(users);

                var repo = new IceCreamStoreReposteryUser(mockContext.Object);

                var login = new UserLogin { userName = "tester", password = "1234" };

                // Act
                var result = await repo.getUserByUserNameAndPasswordLogin(login);

                // Assert
                Assert.NotNull(result);
                Assert.Equal("tester", result.UserName);
            }

            [Fact]
            public async Task UpdateUser_UpdatesUserSuccessfully()
            {
                // Arrange
                var user = new User { Id = 1, UserName = "original", Password = "1234", FirstName = "A", LastName = "B" };
                var users = new List<User> { user };

                var mockContext = new Mock<WebApiContext>();
                mockContext.Setup(x => x.Users).ReturnsDbSet(users);

                var repo = new IceCreamStoreReposteryUser(mockContext.Object);

                var updatedUser = new User { UserName = "updated", Password = "abcd", FirstName = "New", LastName = "Name" };

                // Act
                var result = await repo.UpdateUser(1, updatedUser);

            // Assert
            Assert.NotNull(result);


            }
    }
}


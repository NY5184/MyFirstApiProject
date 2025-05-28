using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using IceCreamStoreRepostery;
using Entity;



namespace TestIceCreamStore
{
    public class UserIntegrationTest: IClassFixture<DatabaseFixture>
    {
        private readonly IceCreamStoreReposteryUser _userRepository;
        private readonly WebApiContext _dbContext;
        public UserIntegrationTest(DatabaseFixture fixture)
        {
            _dbContext = fixture.Context;
            _userRepository = new IceCreamStoreReposteryUser(_dbContext);

        }

        [Fact]
        public async Task AddUserRegister_ShouldAddUser_WhenPasswordValid()
        {
            var user = new User
            {
                FirstName = "Test",
                LastName = "User",
                UserName = "testuser1",
                Password = "StrongPass123!"
            };

            var result = await _userRepository.addUserRegister(user);

            Assert.NotNull(result);
            Assert.Equal("testuser1", result.UserName);
        }

        [Fact]
        public async Task GetUserByUserNameAndPasswordLogin_ShouldReturnUser_WhenExists()
        {
            var user = new User
            {
                FirstName = "Login",
                LastName = "User",
                UserName = "loginuser",
                Password = "StrongPass456!"
            };
            await _userRepository.addUserRegister(user);

            var userLogin = new UserLogin { userName = "loginuser", password = "StrongPass456!" };

            var foundUser = await _userRepository.getUserByUserNameAndPasswordLogin(userLogin);

            Assert.NotNull(foundUser);
            Assert.Equal("loginuser", foundUser.UserName);
        }

        [Fact]
        public async Task UpdateUser_ShouldUpdateUser_WhenUserExists()
        {
            var user = new User
            {
                FirstName = "BeforeUpdate",
                LastName = "User",
                UserName = "updateuser",
                Password = "StrongPass789!"
            };
            var addedUser = await _userRepository.addUserRegister(user);

            var updatedUser = new User
            {
                FirstName = "AfterUpdate",
                LastName = "User",
                Password = "NewStrongPass123!"
            };

            var result = await _userRepository.UpdateUser(addedUser.Id, updatedUser);

            Assert.NotNull(result);
            Assert.Equal("AfterUpdate", result.FirstName);
        }
    }
}

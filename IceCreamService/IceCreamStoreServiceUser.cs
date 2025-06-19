
using Entity;
using IceCreamStoreRepostery;
using Zxcvbn;
using System.Linq;
using AutoMapper;
using DTO;
using Microsoft.Extensions.Logging;


namespace IceCreamStoreService
{
    public class IceCreamStoreServiceUser : IIceCreamStoreServiceUser
    {
        IIceCreamStoreReposteryUser _repostery;
        private readonly IMapper _mapper;
        private readonly ILogger<IceCreamStoreServiceUser> _logger;


        public IceCreamStoreServiceUser(IIceCreamStoreReposteryUser repostery, IMapper mapper, ILogger<IceCreamStoreServiceUser> logger)
        {
            _repostery = repostery;
            _mapper = mapper;
            _logger = logger;

        }



        public async Task<UserDTO> addUserRegister(UserDTO newUserDto)
        {
            if (!validPassword(newUserDto.Password))
            {
                throw new ArgumentException("you nead to enter a good password");
            }
            var newUser = _mapper.Map<User>(newUserDto);
            var addedUser=await _repostery.addUserRegister(newUser);
            Console.WriteLine("######");
            Console.WriteLine(addedUser?.GetType().ToString() ?? "NULL!");
            Console.WriteLine( "######");

            return _mapper.Map<UserDTO>(addedUser);

        }

        public bool validPassword(string password)
        {

            var result = Zxcvbn.Core.EvaluatePassword(password);
            int score = result.Score;
            if ((score) < 2)
                return false;
            return true;

        }

        public async Task<UserDTO> getUserByUserNameAndPasswordLogin(UserLoginDTO userLoginDto)
        {
            _logger.LogInformation($"Login attempt for username: {userLoginDto.UserName}");

            var userLogin = _mapper.Map<UserLogin>(userLoginDto);
            User theLoggedInUser = await _repostery.getUserByUserNameAndPasswordLogin(userLogin);
            if (theLoggedInUser == null)
            {
                _logger.LogWarning($"Login failed for username: {userLoginDto.UserName}");

                throw new KeyNotFoundException("User not found with the provided username and password.");
            }

            _logger.LogInformation($"Login successful for user id: {theLoggedInUser.Id}");

            return _mapper.Map<UserDTO>(theLoggedInUser);

        }

        public async Task<UserDTO> UpdateUser(int id, UserDTO updatedUserDto)
        {
            if (!validPassword(updatedUserDto.Password))
            {
                throw new ArgumentException("you nead to enter a good password");
            }
            var updatedUser = _mapper.Map<User>(updatedUserDto);
            User theUpdatedUser = await _repostery.UpdateUser(id, updatedUser);
            if (theUpdatedUser == null)
            {
                throw new KeyNotFoundException("you are not logged in");
            }
            return _mapper.Map<UserDTO>(theUpdatedUser);

        }


    }
}
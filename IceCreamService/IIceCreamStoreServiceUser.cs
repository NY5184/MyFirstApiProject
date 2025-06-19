//using System;
//using Entity;
//using IceCreamStoreRepostery;
//using Zxcvbn;
//namespace IceCreamStoreService
//{
//    public interface IIceCreamStoreServiceUser
//    {
//       Task<User> addUserRegister(User newUser);
//        bool validPassword(string password);
//        Task<User> getUserByUserNameAndPasswordLogin(UserLogin userLogin);
//        Task<User> UpdateUser(int id, User updatedUser);
//        Task AddOrderAsync(Order order);
//    }
//}
using System;
using Entity;
using IceCreamStoreRepostery;
using Zxcvbn;
using DTO;
namespace IceCreamStoreService
{
    public interface IIceCreamStoreServiceUser
    {
        Task<UserDTO> addUserRegister(UserDTO newUserDto);
        bool validPassword(string password);
        Task<UserDTO> getUserByUserNameAndPasswordLogin(UserLoginDTO userLoginDto);
        Task<UserDTO> UpdateUser(int id, UserDTO updatedUserDto);


    }
}
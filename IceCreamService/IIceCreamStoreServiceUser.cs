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
//        Task<User> UpdateUser(short id, User updatedUser);
//        Task AddOrderAsync(Order order);
//    }
//}
using System;
using Entity;
using IceCreamStoreRepostery;
using Zxcvbn;
namespace IceCreamStoreService
{
    public interface IIceCreamStoreServiceUser
    {
        Task<User> addUserRegister(User newUser);
        bool validPassword(string password);
        Task<User> getUserByUserNameAndPasswordLogin(UserLogin userLogin);
        Task<User> UpdateUser(short id, User updatedUser);


    }
}
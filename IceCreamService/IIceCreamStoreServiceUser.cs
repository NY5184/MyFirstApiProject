using System;
using Entity;
using IceCreamStoreRepostery;
using Zxcvbn;
namespace IceCreamStoreService
{
    public interface IIceCreamStoreServiceUser
    {
        User addUserRegister(User newUser);
        bool validPassword(string password);
        User getUserByUserNameAndPasswordLogin(UserLogin userLogin);
        User UpdateUser(int id, User updatedUser);


    }
}
